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
        private MusicalAnalyzer musicalAnalyzer;

        private delegate void UpdateDisplayDelegate(Dictionary<MusicalNote, double> notesBeingPlayed);
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.musicalAnalyzer = new MusicalAnalyzer();

            foreach (Chord chord in this.musicalAnalyzer.ChordDictionary)
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
            this.Invoke(new UpdateDisplayDelegate(this.UpdateFrequecyDisplays), this.musicalAnalyzer.GetNotesBeingPlayed(e.SoundData));
        }

        private void UpdateFrequecyDisplays(Dictionary<MusicalNote, double> notesBeingPlayed)
        {
            this.SuspendLayout();

            foreach (KeyValuePair<MusicalNote, double> musicalNote in notesBeingPlayed)
            {
                if (amplitudeView.Items.ContainsKey(musicalNote.Key.Name))
                {
                    ListViewItem item = amplitudeView.Items[musicalNote.Key.Name];
                    item.SubItems[2].Text = musicalNote.Value.ToString("f3");
                }
                else
                {
                    ListViewItem item = amplitudeView.Items.Add(musicalNote.Key.Name, musicalNote.Key.Name, 0);
                    item.SubItems.Add(musicalNote.Key.Frequency.ToString("f3"));
                    item.SubItems.Add(musicalNote.Value.ToString("f3"));
                }
            }

            this.ResumeLayout();
        }

    }
}
