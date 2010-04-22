using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Songer.SoundInput;

namespace Songer
{
    public partial class MainForm : Form
    {
        private SoundSource soundSource;
        private MusicalNoteDictionary notes;
        private ChordDictionary chords;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.notes = new MusicalNoteDictionary(@"Docs\Notes.txt");
            this.chords = new ChordDictionary(@"Docs\Chords.txt", this.notes);

            foreach (Chord chord in this.chords)
            {
                ListViewItem item = chordsView.Items.Add(chord.Name);
                item.SubItems.Add(chord.ToString());
            }

            this.soundSource = new LineInCapture();
            //this.soundSource = new WaveFileCapture(@"..\..\..\Sounds\G.wav");
            
            this.soundSource.SoundDetected += (o, args) =>
            {
                this.BeginInvoke(new EventHandler<SoundDetectedEventArgs>(UpdateFrequecyDisplays), o, args);
            };

            this.soundSource.Listen();

            this.chordsView.Focus();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.soundSource.Stop();
            Application.Exit();
        }

        private void chordsView_Leave(object sender, EventArgs e)
        {
            this.chordsView.Focus();
        }

        private void UpdateFrequecyDisplays(object sender, SoundDetectedEventArgs e)
        {
            Dictionary<MusicalNote, double> notesToShow = new Dictionary<MusicalNote, double>();

            if (e.Frequency > 0)
            {
                for (int i = 1; i < e.MaxSpectrogram; i++)
                {
                    double freq = (double)44100 * i / e.Spectrogram.Length;
                    double amplitude = e.Spectrogram[i] / 1000000000000;

                    if (freq < 70 || amplitude < 100)
                        continue;

                    MusicalNote musicalNote = notes.FindClosestNote(freq);

                    if (notesToShow.ContainsKey(musicalNote))
                    {
                        if (notesToShow[musicalNote] < amplitude)
                            notesToShow[musicalNote] = amplitude;
                    }
                    else
                    {
                        notesToShow.Add(musicalNote, amplitude);
                    }
                }
            }

            this.SuspendLayout();
            amplitudeView.Items.Clear();

            foreach (KeyValuePair<MusicalNote, double> musicalNote in notesToShow)
            {
                ListViewItem item = amplitudeView.Items.Add(musicalNote.Key.Name);
                item.SubItems.Add(musicalNote.Key.Frequency.ToString("f3"));
                item.SubItems.Add(musicalNote.Value.ToString("f3"));
            }

            this.ResumeLayout();
        }
    }
}
