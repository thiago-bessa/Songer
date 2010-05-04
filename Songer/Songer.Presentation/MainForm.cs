using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Songer.MusicalInterpreter;

namespace Songer.Presentation
{
    public partial class MainForm : Form
    {
        private MusicalAnalyzer musicalAnalyzer;

        public MainForm()
        {
            InitializeComponent();
            this.musicalAnalyzer = new MusicalAnalyzer();
        }
    }
}
