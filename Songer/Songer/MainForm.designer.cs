namespace Songer
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
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.chordsView = new System.Windows.Forms.ListView();
            this.chordHeader = new System.Windows.Forms.ColumnHeader();
            this.notesHeader = new System.Windows.Forms.ColumnHeader();
            this.secSplitContainer = new System.Windows.Forms.SplitContainer();
            this.amplitudeView = new System.Windows.Forms.ListView();
            this.noteHeader = new System.Windows.Forms.ColumnHeader();
            this.frequencyHeader = new System.Windows.Forms.ColumnHeader();
            this.amplitudeHeader = new System.Windows.Forms.ColumnHeader();
            this.possibleChordsLabel = new System.Windows.Forms.Label();
            this.chordsTextBox = new System.Windows.Forms.TextBox();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.secSplitContainer.Panel1.SuspendLayout();
            this.secSplitContainer.Panel2.SuspendLayout();
            this.secSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.mainSplitContainer.IsSplitterFixed = true;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.chordsView);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.secSplitContainer);
            this.mainSplitContainer.Size = new System.Drawing.Size(1079, 612);
            this.mainSplitContainer.SplitterDistance = 364;
            this.mainSplitContainer.TabIndex = 0;
            // 
            // chordsView
            // 
            this.chordsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chordHeader,
            this.notesHeader});
            this.chordsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chordsView.FullRowSelect = true;
            this.chordsView.HideSelection = false;
            this.chordsView.Location = new System.Drawing.Point(0, 0);
            this.chordsView.Name = "chordsView";
            this.chordsView.Size = new System.Drawing.Size(364, 612);
            this.chordsView.TabIndex = 12;
            this.chordsView.UseCompatibleStateImageBehavior = false;
            this.chordsView.View = System.Windows.Forms.View.Details;
            // 
            // chordHeader
            // 
            this.chordHeader.Text = "Chord";
            // 
            // notesHeader
            // 
            this.notesHeader.Text = "Composed of";
            this.notesHeader.Width = 260;
            // 
            // secSplitContainer
            // 
            this.secSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.secSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.secSplitContainer.Name = "secSplitContainer";
            this.secSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // secSplitContainer.Panel1
            // 
            this.secSplitContainer.Panel1.Controls.Add(this.amplitudeView);
            // 
            // secSplitContainer.Panel2
            // 
            this.secSplitContainer.Panel2.Controls.Add(this.chordsTextBox);
            this.secSplitContainer.Panel2.Controls.Add(this.possibleChordsLabel);
            this.secSplitContainer.Size = new System.Drawing.Size(711, 612);
            this.secSplitContainer.SplitterDistance = 427;
            this.secSplitContainer.TabIndex = 0;
            // 
            // amplitudeView
            // 
            this.amplitudeView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.noteHeader,
            this.frequencyHeader,
            this.amplitudeHeader});
            this.amplitudeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.amplitudeView.Location = new System.Drawing.Point(0, 0);
            this.amplitudeView.Name = "amplitudeView";
            this.amplitudeView.Size = new System.Drawing.Size(711, 427);
            this.amplitudeView.TabIndex = 11;
            this.amplitudeView.UseCompatibleStateImageBehavior = false;
            this.amplitudeView.View = System.Windows.Forms.View.Details;
            // 
            // noteHeader
            // 
            this.noteHeader.Text = "Musical Note";
            this.noteHeader.Width = 100;
            // 
            // frequencyHeader
            // 
            this.frequencyHeader.Text = "Frequency";
            this.frequencyHeader.Width = 100;
            // 
            // amplitudeHeader
            // 
            this.amplitudeHeader.Text = "Amplitude";
            this.amplitudeHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amplitudeHeader.Width = 160;
            // 
            // possibleChordsLabel
            // 
            this.possibleChordsLabel.AutoSize = true;
            this.possibleChordsLabel.Location = new System.Drawing.Point(10, 9);
            this.possibleChordsLabel.Name = "possibleChordsLabel";
            this.possibleChordsLabel.Size = new System.Drawing.Size(85, 13);
            this.possibleChordsLabel.TabIndex = 0;
            this.possibleChordsLabel.Text = "Possible Chords:";
            // 
            // chordsTextBox
            // 
            this.chordsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chordsTextBox.Location = new System.Drawing.Point(13, 25);
            this.chordsTextBox.Name = "chordsTextBox";
            this.chordsTextBox.Size = new System.Drawing.Size(686, 20);
            this.chordsTextBox.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 612);
            this.Controls.Add(this.mainSplitContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Songer - Protótipo 2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            this.mainSplitContainer.ResumeLayout(false);
            this.secSplitContainer.Panel1.ResumeLayout(false);
            this.secSplitContainer.Panel2.ResumeLayout(false);
            this.secSplitContainer.Panel2.PerformLayout();
            this.secSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.ListView chordsView;
        private System.Windows.Forms.ColumnHeader chordHeader;
        private System.Windows.Forms.ColumnHeader notesHeader;
        private System.Windows.Forms.SplitContainer secSplitContainer;
        private System.Windows.Forms.ListView amplitudeView;
        private System.Windows.Forms.ColumnHeader noteHeader;
        private System.Windows.Forms.ColumnHeader frequencyHeader;
        private System.Windows.Forms.ColumnHeader amplitudeHeader;
        private System.Windows.Forms.Label possibleChordsLabel;
        private System.Windows.Forms.TextBox chordsTextBox;

    }
}

