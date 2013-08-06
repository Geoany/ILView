/* License: MIT/X11

Copyright (c) 2013, ILNumerics KG

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ILNumerics;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting; 

namespace ILNumerics.ILView {
    public partial class ILMainFormSimple : Form, IILPanelForm, IILUserInterfaceControls {

        ILPanel panel1;

        public event EventHandler<ShellVisibleChangedEventArgs> ShellVisibleChanged;

        public event EventHandler ExportSVG;

        public event EventHandler ExportPNG;

        public event EventHandler<SourceChangedEventArgs> SourceChanged;
        protected void OnSourceChanged(string source) {
            if (SourceChanged != null) {
                SourceChanged(this, new SourceChangedEventArgs() { Source = source });
            }
        }

        /// <summary>
        /// Provides access to the ILNumerics panel
        /// </summary>
        public ILPanel Panel {
            get { return panel1; }
        }

        public ILMainFormSimple() {
            InitializeComponent();
            
            // setup source combo box
            // fill couple of interesting sources
            toolStripCmbSource.Items.Add("id0b426");
            toolStripCmbSource.Items.Add("if920ce");
            toolStripCmbSource.Items.Add("id8c59a");
            toolStripCmbSource.Items.Add("icd3109");
            toolStripCmbSource.Items.Add("i3748c4");
            toolStripCmbSource.Items.Add("ib5b26c");
            toolStripCmbSource.Items.Add("i8951b3");
            toolStripCmbSource.Items.Add("i794c2c");
            toolStripCmbSource.Items.Add("i461339");
            toolStripCmbSource.Items.Add("i9b1f80");
            toolStripCmbSource.Items.Add("ia3fcd0");
            toolStripCmbSource.Items.Add("i57d081");
            toolStripCmbSource.Items.Add("i77c8ac");
            toolStripCmbSource.Items.Add("i9481ea");
            toolStripCmbSource.Items.Add("i5a1dc1");
            toolStripCmbSource.Items.Add("i24bd56");
            toolStripCmbSource.Items.Add("example");

           
            panel1 = new ILPanel();
            Controls.Add(panel1);
            // wire up UI controls 
            this.toolStripCmbSource.KeyDown += (s, arg) => {
                if (arg.KeyCode == Keys.Enter) {
                    OnSourceChanged(this.toolStripCmbSource.Text);
                }
            };

            this.toolStripBtnConsoleVisible.Click += (s, arg) => {
                if (this.ShellVisibleChanged != null) {
                    this.ShellVisibleChanged(this, new ShellVisibleChangedEventArgs() { Visible = this.toolStripBtnConsoleVisible.Checked });
                };
            };

            Show(); 
        }

        private void toolStripButton1_Click(object sender, EventArgs e) {
            OnSourceChanged(this.toolStripCmbSource.Text); 
        }

        private void toolStripCmbSource_TextChanged(object sender, EventArgs e) {
            OnSourceChanged(this.toolStripCmbSource.Text); 
        }

        private void toolStripButtonSVG_Click(object sender, EventArgs e) {
            if (ExportSVG != null)
                ExportSVG(this, EventArgs.Empty); 
        }

        private void toolStripButtonPNG_Click(object sender, EventArgs e) {
            if (ExportPNG != null)
                ExportPNG(this, EventArgs.Empty);
        }


    }
}
