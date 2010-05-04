using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Songer.MusicalInterpreter;
using Songer.Database;

namespace Songer.Presentation
{
    public partial class MainForm : Form
    {
        private delegate void AtualizaTextoDelegate(string texto);

        private MusicalAnalyzer musicalAnalyzer;
        private SongStore db;
        private bool capturing;
        private bool isSearching;

        public MainForm()
        {
            InitializeComponent();
            this.db = new SongStore();
            this.musicalAnalyzer = new MusicalAnalyzer();
            this.musicalAnalyzer.ProcessingFinished += new EventHandler<AudioProcessingFinishedEventArgs>(onEntradaProcessada);
        }

        private void onEntradaProcessada(object sender, AudioProcessingFinishedEventArgs e)
        {
            if (this.isSearching)
            {
                this.Invoke(new AtualizaTextoDelegate(this.AtualizaTextoSequencia), e.Chords);
            }
            else
            {
                Song musica = new Song(this.musicaTextBox.Text, this.artistaTextBox.Text, e.Chords);
                this.db.Add(musica);

                MessageBox.Show("Sequência: " + e.Chords, "Música Inserida no Banco com sucesso.");
                this.Invoke(new MethodInvoker(this.LimpaTelaInserir));
            }
        }

        private void AtualizaTextoSequencia(string texto)
        {
            this.buscaListView.Items.Clear();
            this.sequenciaCapturadaTextBox.Text = texto;

            IList<Song> musicas = this.db.Search(texto);

            if (musicas.Count > 0)
            {
                foreach(Song musica in musicas)
                {
                    ListViewItem item = buscaListView.Items.Add(String.Format("{0} - {1}", musica.Artist, musica.Name));
                    item.SubItems.Add(musica.ChordSequence);
                }
            }
            else
            {
                MessageBox.Show("Nenhuma música encontrada", "Songer");
            }
        }

        private void LimpaTelaInserir()
        {
            this.artistaTextBox.Text = string.Empty;
            this.musicaTextBox.Text = string.Empty;
            this.waveTextBox.Text = string.Empty;
        }

        private void instrumentoButton_Click(object sender, EventArgs e)
        {
            this.instrumentoPanel.Visible = true;
            this.instrumentoPanel.Dock = DockStyle.Fill;
        }

        private void capturaButton_Click(object sender, EventArgs e)
        {
            if (this.capturing)
            {//Stop
                this.capturaButton.BackgroundImage = global::Songer.Presentation.Properties.Resources.Play;
                this.instrumentoPanel.Visible = false;
                this.musicalAnalyzer.AbortAnalysis();
            }
            else
            {//Start
                this.capturaButton.BackgroundImage = global::Songer.Presentation.Properties.Resources.Stop;
                this.musicalAnalyzer.AnalyzeAudio();
                this.isSearching = true;
            }

            this.capturing = !this.capturing;
        }

        private void arquivoButton_Click(object sender, EventArgs e)
        {
            this.openWaveDialog.InitialDirectory = @"..\Sounds\";
            if (this.openWaveDialog.ShowDialog() == DialogResult.OK)
            {
                this.musicalAnalyzer.AnalyzeAudio(this.openWaveDialog.FileName);
                this.isSearching = true;
            }
        }

        private void procurarInserirButton_Click(object sender, EventArgs e)
        {
            if (this.openWaveDialog.ShowDialog() == DialogResult.OK)
            {
                this.waveTextBox.Text = this.openWaveDialog.FileName;
            }
        }

        private void inserirButton_Click(object sender, EventArgs e)
        {
            this.musicalAnalyzer.AnalyzeAudio(this.openWaveDialog.FileName);
            this.isSearching = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.db.Close();
        }
    }
}
