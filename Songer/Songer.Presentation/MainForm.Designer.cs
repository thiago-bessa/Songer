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
            this.buscaListView = new System.Windows.Forms.ListView();
            this.artistaMusicaColumn = new System.Windows.Forms.ColumnHeader();
            this.cifraColumn = new System.Windows.Forms.ColumnHeader();
            this.entradaGroupBox = new System.Windows.Forms.GroupBox();
            this.textoButton = new System.Windows.Forms.Button();
            this.arquivoButton = new System.Windows.Forms.Button();
            this.instrumentoButton = new System.Windows.Forms.Button();
            this.tabInserir = new System.Windows.Forms.TabPage();
            this.inserirGroupBox = new System.Windows.Forms.GroupBox();
            this.artistaLabel = new System.Windows.Forms.Label();
            this.musicaLabel = new System.Windows.Forms.Label();
            this.waveLabel = new System.Windows.Forms.Label();
            this.inserirButton = new System.Windows.Forms.Button();
            this.artistaTextBox = new System.Windows.Forms.TextBox();
            this.waveTextBox = new System.Windows.Forms.TextBox();
            this.musicaTextBox = new System.Windows.Forms.TextBox();
            this.procurarInserirButton = new System.Windows.Forms.Button();
            this.instrumentoPanel = new System.Windows.Forms.Panel();
            this.capturaButton = new System.Windows.Forms.Button();
            this.controleDeAbas.SuspendLayout();
            this.tabBusca.SuspendLayout();
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
            this.controleDeAbas.Location = new System.Drawing.Point(0, 129);
            this.controleDeAbas.Name = "controleDeAbas";
            this.controleDeAbas.SelectedIndex = 0;
            this.controleDeAbas.Size = new System.Drawing.Size(365, 225);
            this.controleDeAbas.TabIndex = 0;
            // 
            // tabBusca
            // 
            this.tabBusca.Controls.Add(this.buscaListView);
            this.tabBusca.Controls.Add(this.entradaGroupBox);
            this.tabBusca.Location = new System.Drawing.Point(4, 22);
            this.tabBusca.Name = "tabBusca";
            this.tabBusca.Padding = new System.Windows.Forms.Padding(3);
            this.tabBusca.Size = new System.Drawing.Size(357, 199);
            this.tabBusca.TabIndex = 0;
            this.tabBusca.Text = "Buscar";
            this.tabBusca.UseVisualStyleBackColor = true;
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
            this.buscaListView.Location = new System.Drawing.Point(6, 106);
            this.buscaListView.MultiSelect = false;
            this.buscaListView.Name = "buscaListView";
            this.buscaListView.Size = new System.Drawing.Size(345, 87);
            this.buscaListView.TabIndex = 1;
            this.buscaListView.UseCompatibleStateImageBehavior = false;
            this.buscaListView.View = System.Windows.Forms.View.Details;
            // 
            // artistaMusicaColumn
            // 
            this.artistaMusicaColumn.Text = "Artista - Música";
            this.artistaMusicaColumn.Width = 170;
            // 
            // cifraColumn
            // 
            this.cifraColumn.Text = "Cifra";
            this.cifraColumn.Width = 280;
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
            this.entradaGroupBox.Size = new System.Drawing.Size(345, 94);
            this.entradaGroupBox.TabIndex = 0;
            this.entradaGroupBox.TabStop = false;
            this.entradaGroupBox.Text = "Entrada";
            // 
            // textoButton
            // 
            this.textoButton.Location = new System.Drawing.Point(200, 19);
            this.textoButton.Name = "textoButton";
            this.textoButton.Size = new System.Drawing.Size(91, 69);
            this.textoButton.TabIndex = 2;
            this.textoButton.Text = "Texto";
            this.textoButton.UseVisualStyleBackColor = true;
            // 
            // arquivoButton
            // 
            this.arquivoButton.Location = new System.Drawing.Point(103, 19);
            this.arquivoButton.Name = "arquivoButton";
            this.arquivoButton.Size = new System.Drawing.Size(91, 69);
            this.arquivoButton.TabIndex = 1;
            this.arquivoButton.Text = "Arquivo Wave";
            this.arquivoButton.UseVisualStyleBackColor = true;
            // 
            // instrumentoButton
            // 
            this.instrumentoButton.Location = new System.Drawing.Point(6, 19);
            this.instrumentoButton.Name = "instrumentoButton";
            this.instrumentoButton.Size = new System.Drawing.Size(91, 69);
            this.instrumentoButton.TabIndex = 0;
            this.instrumentoButton.Text = "Instrumento";
            this.instrumentoButton.UseVisualStyleBackColor = true;
            // 
            // tabInserir
            // 
            this.tabInserir.Controls.Add(this.inserirGroupBox);
            this.tabInserir.Location = new System.Drawing.Point(4, 22);
            this.tabInserir.Name = "tabInserir";
            this.tabInserir.Padding = new System.Windows.Forms.Padding(3);
            this.tabInserir.Size = new System.Drawing.Size(484, 340);
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
            // inserirButton
            // 
            this.inserirButton.Location = new System.Drawing.Point(154, 119);
            this.inserirButton.Name = "inserirButton";
            this.inserirButton.Size = new System.Drawing.Size(75, 23);
            this.inserirButton.TabIndex = 3;
            this.inserirButton.Text = "Inserir";
            this.inserirButton.UseVisualStyleBackColor = true;
            // 
            // artistaTextBox
            // 
            this.artistaTextBox.Location = new System.Drawing.Point(87, 19);
            this.artistaTextBox.Name = "artistaTextBox";
            this.artistaTextBox.Size = new System.Drawing.Size(189, 20);
            this.artistaTextBox.TabIndex = 4;
            // 
            // waveTextBox
            // 
            this.waveTextBox.Location = new System.Drawing.Point(87, 71);
            this.waveTextBox.Name = "waveTextBox";
            this.waveTextBox.Size = new System.Drawing.Size(189, 20);
            this.waveTextBox.TabIndex = 5;
            // 
            // musicaTextBox
            // 
            this.musicaTextBox.Location = new System.Drawing.Point(87, 45);
            this.musicaTextBox.Name = "musicaTextBox";
            this.musicaTextBox.Size = new System.Drawing.Size(189, 20);
            this.musicaTextBox.TabIndex = 6;
            // 
            // procurarInserirButton
            // 
            this.procurarInserirButton.Location = new System.Drawing.Point(282, 71);
            this.procurarInserirButton.Name = "procurarInserirButton";
            this.procurarInserirButton.Size = new System.Drawing.Size(88, 20);
            this.procurarInserirButton.TabIndex = 7;
            this.procurarInserirButton.Text = "Procurar...";
            this.procurarInserirButton.UseVisualStyleBackColor = true;
            // 
            // instrumentoPanel
            // 
            this.instrumentoPanel.Controls.Add(this.capturaButton);
            this.instrumentoPanel.Location = new System.Drawing.Point(210, 23);
            this.instrumentoPanel.Name = "instrumentoPanel";
            this.instrumentoPanel.Size = new System.Drawing.Size(155, 122);
            this.instrumentoPanel.TabIndex = 2;
            this.instrumentoPanel.Visible = false;
            // 
            // capturaButton
            // 
            this.capturaButton.Location = new System.Drawing.Point(29, 20);
            this.capturaButton.MaximumSize = new System.Drawing.Size(91, 69);
            this.capturaButton.Name = "capturaButton";
            this.capturaButton.Size = new System.Drawing.Size(91, 69);
            this.capturaButton.TabIndex = 3;
            this.capturaButton.Text = "Iniciar Captura";
            this.capturaButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 366);
            this.Controls.Add(this.instrumentoPanel);
            this.Controls.Add(this.controleDeAbas);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "MainForm";
            this.Text = "Thiago Bessa\'s Songer - The Song Searcher";
            this.controleDeAbas.ResumeLayout(false);
            this.tabBusca.ResumeLayout(false);
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
    }
}

