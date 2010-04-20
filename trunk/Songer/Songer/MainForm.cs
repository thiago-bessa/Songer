using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SoundCapture;

namespace Songer
{
    public partial class MainForm : Form
    {
        private bool isListenning = false;
        private MusicalNoteDictionary notes;
        private ChordDictionary chords;

        public bool IsListenning
        {
            get { return isListenning; }
        }

        public MainForm()
        {
            InitializeComponent();
            this.notes = new MusicalNoteDictionary(@"Docs\Notes.txt");
            this.chords = new ChordDictionary(@"Docs\Chords.txt", this.notes);

            foreach (Chord chord in this.chords)
            {
                ListViewItem item = chordsView.Items.Add(chord.Name);
                item.SubItems.Add(chord.ToString());
            }
        }

        FrequencyInfoSource frequencyInfoSource;

        private void StopListenning()
        {
            isListenning = false;
            frequencyInfoSource.Stop();
            frequencyInfoSource.FrequencyDetected -= new EventHandler<FrequencyDetectedEventArgs>(frequencyInfoSource_FrequencyDetected);
            frequencyInfoSource = null;
        }

        private void StartListenning(SoundCaptureDevice device)
        {
            isListenning = true;
            frequencyInfoSource = new SoundFrequencyInfoSource(device);
            frequencyInfoSource.FrequencyDetected += new EventHandler<FrequencyDetectedEventArgs>(frequencyInfoSource_FrequencyDetected);
            frequencyInfoSource.Listen();
        }

        void frequencyInfoSource_FrequencyDetected(object sender, FrequencyDetectedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<FrequencyDetectedEventArgs>(frequencyInfoSource_FrequencyDetected), sender, e);
            }
            else
            {
                UpdateFrequecyDisplays(e);
            }
        }

        private void UpdateFrequecyDisplays(FrequencyDetectedEventArgs e)
        {
            Dictionary<MusicalNote, double> notesToShow = new Dictionary<MusicalNote, double>();

            if (e.Frequency > 0)
            {
                for (int i = 1; i < e.MaxSpectrogram; i++)
                {
                    double freq = (double)frequencyInfoSource.SampleRate * i / e.Spectrogram.Length;
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

            foreach (KeyValuePair<MusicalNote, double> musicalNote in notesToShow.OrderByDescending(n => n.Value))
            {
                ListViewItem item = amplitudeView.Items.Add(musicalNote.Key.Name);
                item.SubItems.Add(musicalNote.Key.Frequency.ToString("f3"));
                item.SubItems.Add(musicalNote.Value.ToString("f3"));
            }

            this.ResumeLayout();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsListenning)
            {
                StopListenning();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SoundCaptureDevice device = null;
            using (SelectDeviceForm form = new SelectDeviceForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    device = form.SelectedDevice;
                }
            }

            if (device != null)
            {
                StartListenning(device);
                this.chordsView.Focus();
            }
        }

        private void chordsView_Leave(object sender, EventArgs e)
        {
            this.chordsView.Focus();
        }
    }
}
