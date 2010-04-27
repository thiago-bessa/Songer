using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Songer.SoundInput;
using Songer.MusicalInterpreter;
using Songer.SoundAnalysis;

namespace Songer
{
    public partial class MainForm : Form
    {
        private SoundSource soundSource;
        private MusicalNoteDictionary notes;
        private ChordDictionary chords;

        private delegate void UpdateDisplayDelegate(Dictionary<MusicalNote, double> notesBeingPlayed);
        

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

            //this.soundSource = new LineInCapture();
            this.soundSource = new WaveFileCapture(@"..\..\..\Sounds\G.wav");
            
            this.soundSource.SoundDetected += (o, args) =>
            {
                this.ProcessSoundData(o, args);                
            };

            this.soundSource.Start();

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

        private void ProcessSoundData(object sender, SoundDetectedEventArgs e)
        {
            Dictionary<MusicalNote, double> notesBeingPlayed = new Dictionary<MusicalNote, double>();

            double minFreq = 70; //Value based on possible guitar notes
            double maxFreq = 1300; //Value based on possible guitar notes
            double[] spectrogram = CooleyTukeyFFT.CalculateSpectrogram(e.SoundData);

            int index = 0;
            double max = spectrogram[0];
            int usefullMaxSpectr = Math.Min(spectrogram.Length, (int)(maxFreq * spectrogram.Length / 44100) + 1);

            for (int i = 1; i < usefullMaxSpectr; i++)
            {
                if (max < spectrogram[i])
                {
                    max = spectrogram[i];
                    index = i;
                }
            }

            if (((double)44100 * index / spectrogram.Length) > minFreq)
            {
                for (int i = 1; i < usefullMaxSpectr; i++)
                {
                    double freq = (double)44100 * i / spectrogram.Length;
                    double amplitude = spectrogram[i];

                    if (freq < minFreq || amplitude < 1000000000000000)
                        continue;

                    amplitude /= 100000000000000;

                    MusicalNote musicalNote = notes.FindClosestNote(freq);

                    if (notesBeingPlayed.ContainsKey(musicalNote))
                    {
                        if (notesBeingPlayed[musicalNote] < amplitude)
                            notesBeingPlayed[musicalNote] = amplitude;
                    }
                    else
                    {
                        notesBeingPlayed.Add(musicalNote, amplitude);
                    }
                }
            }

            this.Invoke(new UpdateDisplayDelegate(this.UpdateFrequecyDisplays), notesBeingPlayed);
        }

        private void UpdateFrequecyDisplays(Dictionary<MusicalNote, double> notesBeingPlayed)
        {
            this.SuspendLayout();
            amplitudeView.Items.Clear();

            foreach (KeyValuePair<MusicalNote, double> musicalNote in notesBeingPlayed)
            {
                ListViewItem item = amplitudeView.Items.Add(musicalNote.Key.Name);
                item.SubItems.Add(musicalNote.Key.Frequency.ToString("f3"));
                item.SubItems.Add(musicalNote.Value.ToString("f3"));
            }

            this.ResumeLayout();
        }
    }
}
