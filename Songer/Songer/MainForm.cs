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
        private MusicalAnalyzer musicalAnalyzer;

        private delegate void UpdateDisplayDelegate(Dictionary<MusicalNote, double> notesBeingPlayed);
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.musicalAnalyzer = new MusicalAnalyzer();
            this.musicalAnalyzer.NotesDetected += new EventHandler<NotesDetectedEventArgs>(musicalAnalyzer_NotesDetected);

            foreach (Chord chord in MusicalAnalyzer.ChordDictionary)
            {
                ListViewItem item = chordsView.Items.Add(chord.Name);
                item.SubItems.Add(chord.ToString());
            }

            this.musicalAnalyzer.AnalyzeAudio(@"..\..\..\Sounds\G.wav");

            this.chordsView.Focus();
        }

        void musicalAnalyzer_NotesDetected(object sender, NotesDetectedEventArgs e)
        {
            this.Invoke(new UpdateDisplayDelegate(this.UpdateFrequecyDisplays), e.MusicalNotes);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.musicalAnalyzer.AbortAnalysis();
            Application.Exit();
        }

        private void chordsView_Leave(object sender, EventArgs e)
        {
            this.chordsView.Focus();
        }

        private void UpdateFrequecyDisplays(Dictionary<MusicalNote, double> notesBeingPlayed)
        {
            this.SuspendLayout();
            this.amplitudeView.Items.Clear();

            foreach (KeyValuePair<MusicalNote, double> musicalNote in notesBeingPlayed)
            {
                if (this.amplitudeView.Items.ContainsKey(musicalNote.Key.Name))
                {
                    ListViewItem item = this.amplitudeView.Items[musicalNote.Key.Name];
                    item.SubItems[2].Text = musicalNote.Value.ToString("f3");
                }
                else
                {
                    ListViewItem item = this.amplitudeView.Items.Add(musicalNote.Key.Name, musicalNote.Key.Name, 0);
                    item.SubItems.Add(musicalNote.Key.Frequency.ToString("f3"));
                    item.SubItems.Add(musicalNote.Value.ToString("f3"));
                }
            }

            this.ResumeLayout();
        }

    }
}
