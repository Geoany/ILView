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

namespace ILNumerics.ILView {
    public partial class ILShellForm : Form, IILShellControl, IILCompletionFormProvider {

        public ILShellForm() {
            InitializeComponent();
            ilShell1.CommandEntered += (s,arg) => {
                if (CommandEntered != null) {
                    CommandEntered(s, arg); 
                }
            }; 
        }

        private void ILShellForm_Load(object sender, EventArgs e) {
            //ilCompletionsForm1.Visible = false;
            ilShell1.CompletionRequested += (s, args) => { 
                OnCompletionRequested(args); 
            };
        }

        public event EventHandler<ILCommandEnteredEventArgs> CommandEntered;
        public event EventHandler<ILCompletionRequestEventArgs> CompletionRequested;
        protected void OnCompletionRequested(ILCompletionRequestEventArgs args) {
            if (CompletionRequested != null) {
                CompletionRequested(this, args);
            }
        }
        public void WriteCommand(string text) {
            ilShell1.WriteCommand(text); 
        }

        public void WriteError(string text) {
            ilShell1.WriteError(text);
        }

        public void WriteText(string text) {
            ilShell1.WriteText(text);
        }

        public void Init(object host) {
            // nothing to do here. More advanced IDE forms might have something... (docking setup a.t.l)
        }

        private void ILShellForm_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            Visible = false;             
        }


        protected override void OnKeyDown(KeyEventArgs e) {
            if (listBox1.Visible) {
                int a = 1; 
            } else {
                base.OnKeyDown(e);
            }
        }

        public ListBox GetCompletionForm() {
            return listBox1; 
        }

    }
}
