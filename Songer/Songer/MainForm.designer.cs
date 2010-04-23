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
            this.amplitudeView = new System.Windows.Forms.ListView();
            this.noteHeader = new System.Windows.Forms.ColumnHeader();
            this.frequencyHeader = new System.Windows.Forms.ColumnHeader();
            this.amplitudeHeader = new System.Windows.Forms.ColumnHeader();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
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
            this.mainSplitContainer.Panel2.Controls.Add(this.amplitudeView);
            this.mainSplitContainer.Size = new System.Drawing.Size(760, 368);
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
            this.chordsView.Size = new System.Drawing.Size(364, 368);
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
            this.notesHeader.Width = 300;
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
            this.amplitudeView.Size = new System.Drawing.Size(392, 368);
            this.amplitudeView.TabIndex = 10;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 368);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.ListView amplitudeView;
        private System.Windows.Forms.ColumnHeader noteHeader;
        private System.Windows.Forms.ColumnHeader frequencyHeader;
        private System.Windows.Forms.ColumnHeader amplitudeHeader;
        private System.Windows.Forms.ListView chordsView;
        private System.Windows.Forms.ColumnHeader chordHeader;
        private System.Windows.Forms.ColumnHeader notesHeader;

    }
}

