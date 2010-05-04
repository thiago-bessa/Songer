namespace Songer.Presentation
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.controleDeAbas = new System.Windows.Forms.TabControl();
            this.tabBusca = new System.Windows.Forms.TabPage();
            this.capturadaGroupBox = new System.Windows.Forms.GroupBox();
            this.sequenciaCapturadaTextBox = new System.Windows.Forms.TextBox();
            this.buscaListView = new System.Windows.Forms.ListView();
            this.artistaMusicaColumn = new System.Windows.Forms.ColumnHeader();
            this.cifraColumn = new System.Windows.Forms.ColumnHeader();
            this.entradaGroupBox = new System.Windows.Forms.GroupBox();
            this.textoButton = new System.Windows.Forms.Button();
            this.arquivoButton = new System.Windows.Forms.Button();
            this.instrumentoButton = new System.Windows.Forms.Button();
            this.tabInserir = new System.Windows.Forms.TabPage();
            this.inserirGroupBox = new System.Windows.Forms.GroupBox();
            this.procurarInserirButton = new System.Windows.Forms.Button();
            this.musicaTextBox = new System.Windows.Forms.TextBox();
            this.waveTextBox = new System.Windows.Forms.TextBox();
            this.artistaTextBox = new System.Windows.Forms.TextBox();
            this.inserirButton = new System.Windows.Forms.Button();
            this.waveLabel = new System.Windows.Forms.Label();
            this.musicaLabel = new System.Windows.Forms.Label();
            this.artistaLabel = new System.Windows.Forms.Label();
            this.instrumentoPanel = new System.Windows.Forms.Panel();
            this.capturaLabel = new System.Windows.Forms.Label();
            this.capturaButton = new System.Windows.Forms.Button();
            this.openWaveDialog = new System.Windows.Forms.OpenFileDialog();
            this.controleDeAbas.SuspendLayout();
            this.tabBusca.SuspendLayout();
            this.capturadaGroupBox.SuspendLayout();
            this.entradaGroupBox.SuspendLayout();
            this.tabInserir.SuspendLayout();
            this.inserirGroupBox.SuspendLayout();
            this.instrumentoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // controleDeAbas
            // 
            this.controleDeAbas.Controls.Add(this.tabBusca);
            this.controleDeAbas.Controls.Add(this.tabInserir);
            this.controleDeAbas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controleDeAbas.Location = new System.Drawing.Point(0, 0);
            this.controleDeAbas.Name = "controleDeAbas";
            this.controleDeAbas.SelectedIndex = 0;
            this.controleDeAbas.Size = new System.Drawing.Size(624, 442);
            this.controleDeAbas.TabIndex = 0;
            // 
            // tabBusca
            // 
            this.tabBusca.Controls.Add(this.capturadaGroupBox);
            this.tabBusca.Controls.Add(this.buscaListView);
            this.tabBusca.Controls.Add(this.entradaGroupBox);
            this.tabBusca.Location = new System.Drawing.Point(4, 22);
            this.tabBusca.Name = "tabBusca";
            this.tabBusca.Padding = new System.Windows.Forms.Padding(3);
            this.tabBusca.Size = new System.Drawing.Size(616, 416);
            this.tabBusca.TabIndex = 0;
            this.tabBusca.Text = "Buscar";
            this.tabBusca.UseVisualStyleBackColor = true;
            // 
            // capturadaGroupBox
            // 
            this.capturadaGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.capturadaGroupBox.Controls.Add(this.sequenciaCapturadaTextBox);
            this.capturadaGroupBox.Location = new System.Drawing.Point(6, 122);
            this.capturadaGroupBox.Name = "capturadaGroupBox";
            this.capturadaGroupBox.Size = new System.Drawing.Size(604, 47);
            this.capturadaGroupBox.TabIndex = 2;
            this.capturadaGroupBox.TabStop = false;
            this.capturadaGroupBox.Text = "Sequencia Capturada";
            // 
            // sequenciaCapturadaTextBox
            // 
            this.sequenciaCapturadaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sequenciaCapturadaTextBox.Location = new System.Drawing.Point(6, 19);
            this.sequenciaCapturadaTextBox.Name = "sequenciaCapturadaTextBox";
            this.sequenciaCapturadaTextBox.ReadOnly = true;
            this.sequenciaCapturadaTextBox.Size = new System.Drawing.Size(592, 20);
            this.sequenciaCapturadaTextBox.TabIndex = 0;
            // 
            // buscaListView
            // 
            this.buscaListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buscaListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.artistaMusicaColumn,
            this.cifraColumn});
            this.buscaListView.FullRowSelect = true;
            this.buscaListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.buscaListView.Location = new System.Drawing.Point(6, 175);
            this.buscaListView.MultiSelect = false;
            this.buscaListView.Name = "buscaListView";
            this.buscaListView.Size = new System.Drawing.Size(604, 235);
            this.buscaListView.TabIndex = 1;
            this.buscaListView.UseCompatibleStateImageBehavior = false;
            this.buscaListView.View = System.Windows.Forms.View.Details;
            // 
            // artistaMusicaColumn
            // 
            this.artistaMusicaColumn.Text = "Artista - Música";
            this.artistaMusicaColumn.Width = 200;
            // 
            // cifraColumn
            // 
            this.cifraColumn.Text = "Cifra";
            this.cifraColumn.Width = 370;
            // 
            // entradaGroupBox
            // 
            this.entradaGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.entradaGroupBox.Controls.Add(this.textoButton);
            this.entradaGroupBox.Controls.Add(this.arquivoButton);
            this.entradaGroupBox.Controls.Add(this.instrumentoButton);
            this.entradaGroupBox.Location = new System.Drawing.Point(6, 6);
            this.entradaGroupBox.Name = "entradaGroupBox";
            this.entradaGroupBox.Size = new System.Drawing.Size(604, 110);
            this.entradaGroupBox.TabIndex = 0;
            this.entradaGroupBox.TabStop = false;
            this.entradaGroupBox.Text = "Entrada";
            // 
            // textoButton
            // 
            this.textoButton.Location = new System.Drawing.Point(200, 19);
            this.textoButton.Name = "textoButton";
            this.textoButton.Size = new System.Drawing.Size(91, 85);
            this.textoButton.TabIndex = 2;
            this.textoButton.Text = "Texto";
            this.textoButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.textoButton.UseVisualStyleBackColor = true;
            this.textoButton.Visible = false;
            // 
            // arquivoButton
            // 
            this.arquivoButton.BackgroundImage = global::Songer.Presentation.Properties.Resources.Wave;
            this.arquivoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.arquivoButton.Location = new System.Drawing.Point(103, 19);
            this.arquivoButton.Name = "arquivoButton";
            this.arquivoButton.Size = new System.Drawing.Size(91, 85);
            this.arquivoButton.TabIndex = 1;
            this.arquivoButton.Text = "Arquivo Wave";
            this.arquivoButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.arquivoButton.UseVisualStyleBackColor = true;
            this.arquivoButton.Click += new System.EventHandler(this.arquivoButton_Click);
            // 
            // instrumentoButton
            // 
            this.instrumentoButton.BackgroundImage = global::Songer.Presentation.Properties.Resources.Instrument;
            this.instrumentoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.instrumentoButton.ImageIndex = 0;
            this.instrumentoButton.Location = new System.Drawing.Point(6, 19);
            this.instrumentoButton.Name = "instrumentoButton";
            this.instrumentoButton.Size = new System.Drawing.Size(91, 85);
            this.instrumentoButton.TabIndex = 0;
            this.instrumentoButton.Text = "Instrumento";
            this.instrumentoButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.instrumentoButton.UseVisualStyleBackColor = true;
            this.instrumentoButton.Click += new System.EventHandler(this.instrumentoButton_Click);
            // 
            // tabInserir
            // 
            this.tabInserir.Controls.Add(this.inserirGroupBox);
            this.tabInserir.Location = new System.Drawing.Point(4, 22);
            this.tabInserir.Name = "tabInserir";
            this.tabInserir.Padding = new System.Windows.Forms.Padding(3);
            this.tabInserir.Size = new System.Drawing.Size(616, 416);
            this.tabInserir.TabIndex = 1;
            this.tabInserir.Text = "Inserir";
            this.tabInserir.UseVisualStyleBackColor = true;
            // 
            // inserirGroupBox
            // 
            this.inserirGroupBox.Controls.Add(this.procurarInserirButton);
            this.inserirGroupBox.Controls.Add(this.musicaTextBox);
            this.inserirGroupBox.Controls.Add(this.waveTextBox);
            this.inserirGroupBox.Controls.Add(this.artistaTextBox);
            this.inserirGroupBox.Controls.Add(this.inserirButton);
            this.inserirGroupBox.Controls.Add(this.waveLabel);
            this.inserirGroupBox.Controls.Add(this.musicaLabel);
            this.inserirGroupBox.Controls.Add(this.artistaLabel);
            this.inserirGroupBox.Location = new System.Drawing.Point(6, 6);
            this.inserirGroupBox.Name = "inserirGroupBox";
            this.inserirGroupBox.Size = new System.Drawing.Size(376, 148);
            this.inserirGroupBox.TabIndex = 0;
            this.inserirGroupBox.TabStop = false;
            this.inserirGroupBox.Text = "Inserir Nova Música no Banco";
            // 
            // procurarInserirButton
            // 
            this.procurarInserirButton.Location = new System.Drawing.Point(282, 71);
            this.procurarInserirButton.Name = "procurarInserirButton";
            this.procurarInserirButton.Size = new System.Drawing.Size(88, 20);
            this.procurarInserirButton.TabIndex = 7;
            this.procurarInserirButton.Text = "Procurar...";
            this.procurarInserirButton.UseVisualStyleBackColor = true;
            this.procurarInserirButton.Click += new System.EventHandler(this.procurarInserirButton_Click);
            // 
            // musicaTextBox
            // 
            this.musicaTextBox.Location = new System.Drawing.Point(87, 45);
            this.musicaTextBox.Name = "musicaTextBox";
            this.musicaTextBox.Size = new System.Drawing.Size(189, 20);
            this.musicaTextBox.TabIndex = 6;
            // 
            // waveTextBox
            // 
            this.waveTextBox.Location = new System.Drawing.Point(87, 71);
            this.waveTextBox.Name = "waveTextBox";
            this.waveTextBox.ReadOnly = true;
            this.waveTextBox.Size = new System.Drawing.Size(189, 20);
            this.waveTextBox.TabIndex = 5;
            // 
            // artistaTextBox
            // 
            this.artistaTextBox.Location = new System.Drawing.Point(87, 19);
            this.artistaTextBox.Name = "artistaTextBox";
            this.artistaTextBox.Size = new System.Drawing.Size(189, 20);
            this.artistaTextBox.TabIndex = 4;
            // 
            // inserirButton
            // 
            this.inserirButton.Location = new System.Drawing.Point(153, 108);
            this.inserirButton.Name = "inserirButton";
            this.inserirButton.Size = new System.Drawing.Size(75, 23);
            this.inserirButton.TabIndex = 3;
            this.inserirButton.Text = "Inserir";
            this.inserirButton.UseVisualStyleBackColor = true;
            this.inserirButton.Click += new System.EventHandler(this.inserirButton_Click);
            // 
            // waveLabel
            // 
            this.waveLabel.AutoSize = true;
            this.waveLabel.Location = new System.Drawing.Point(6, 74);
            this.waveLabel.Name = "waveLabel";
            this.waveLabel.Size = new System.Drawing.Size(75, 13);
            this.waveLabel.TabIndex = 2;
            this.waveLabel.Text = "Arquivo Wave";
            this.waveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // musicaLabel
            // 
            this.musicaLabel.AutoSize = true;
            this.musicaLabel.Location = new System.Drawing.Point(40, 48);
            this.musicaLabel.Name = "musicaLabel";
            this.musicaLabel.Size = new System.Drawing.Size(41, 13);
            this.musicaLabel.TabIndex = 1;
            this.musicaLabel.Text = "Música";
            this.musicaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // artistaLabel
            // 
            this.artistaLabel.AutoSize = true;
            this.artistaLabel.Location = new System.Drawing.Point(45, 22);
            this.artistaLabel.Name = "artistaLabel";
            this.artistaLabel.Size = new System.Drawing.Size(36, 13);
            this.artistaLabel.TabIndex = 0;
            this.artistaLabel.Text = "Artista";
            this.artistaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // instrumentoPanel
            // 
            this.instrumentoPanel.Controls.Add(this.capturaLabel);
            this.instrumentoPanel.Controls.Add(this.capturaButton);
            this.instrumentoPanel.Location = new System.Drawing.Point(389, 209);
            this.instrumentoPanel.Name = "instrumentoPanel";
            this.instrumentoPanel.Size = new System.Drawing.Size(97, 100);
            this.instrumentoPanel.TabIndex = 2;
            this.instrumentoPanel.Visible = false;
            // 
            // capturaLabel
            // 
            this.capturaLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.capturaLabel.Location = new System.Drawing.Point(3, 0);
            this.capturaLabel.Name = "capturaLabel";
            this.capturaLabel.Size = new System.Drawing.Size(91, 25);
            this.capturaLabel.TabIndex = 4;
            this.capturaLabel.Text = "Captura de Som";
            this.capturaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // capturaButton
            // 
            this.capturaButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.capturaButton.BackgroundImage = global::Songer.Presentation.Properties.Resources.Play;
            this.capturaButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.capturaButton.Location = new System.Drawing.Point(3, 28);
            this.capturaButton.MaximumSize = new System.Drawing.Size(91, 69);
            this.capturaButton.Name = "capturaButton";
            this.capturaButton.Size = new System.Drawing.Size(91, 69);
            this.capturaButton.TabIndex = 3;
            this.capturaButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.capturaButton.UseVisualStyleBackColor = true;
            this.capturaButton.Click += new System.EventHandler(this.capturaButton_Click);
            // 
            // openWaveDialog
            // 
            this.openWaveDialog.DefaultExt = "wav";
            this.openWaveDialog.Filter = "Arquivo Wave|*.wav";
            this.openWaveDialog.Title = "Abra um arquivo wave";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.instrumentoPanel);
            this.Controls.Add(this.controleDeAbas);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
            this.Text = "Thiago Bessa\'s Songer - The Song Searcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.controleDeAbas.ResumeLayout(false);
            this.tabBusca.ResumeLayout(false);
            this.capturadaGroupBox.ResumeLayout(false);
            this.capturadaGroupBox.PerformLayout();
            this.entradaGroupBox.ResumeLayout(false);
            this.tabInserir.ResumeLayout(false);
            this.inserirGroupBox.ResumeLayout(false);
            this.inserirGroupBox.PerformLayout();
            this.instrumentoPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl controleDeAbas;
        private System.Windows.Forms.TabPage tabBusca;
        private System.Windows.Forms.TabPage tabInserir;
        private System.Windows.Forms.GroupBox entradaGroupBox;
        private System.Windows.Forms.Button instrumentoButton;
        private System.Windows.Forms.ListView buscaListView;
        private System.Windows.Forms.Button textoButton;
        private System.Windows.Forms.Button arquivoButton;
        private System.Windows.Forms.GroupBox inserirGroupBox;
        private System.Windows.Forms.ColumnHeader artistaMusicaColumn;
        private System.Windows.Forms.ColumnHeader cifraColumn;
        private System.Windows.Forms.Button procurarInserirButton;
        private System.Windows.Forms.TextBox musicaTextBox;
        private System.Windows.Forms.TextBox waveTextBox;
        private System.Windows.Forms.TextBox artistaTextBox;
        private System.Windows.Forms.Button inserirButton;
        private System.Windows.Forms.Label waveLabel;
        private System.Windows.Forms.Label musicaLabel;
        private System.Windows.Forms.Label artistaLabel;
        private System.Windows.Forms.Panel instrumentoPanel;
        private System.Windows.Forms.Button capturaButton;
        private System.Windows.Forms.Label capturaLabel;
        private System.Windows.Forms.GroupBox capturadaGroupBox;
        private System.Windows.Forms.TextBox sequenciaCapturadaTextBox;
        private System.Windows.Forms.OpenFileDialog openWaveDialog;
    }
}

