using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;

using ScintillaNET;

using Side.Interfaces;

namespace Side.CodeBox
{
    /// <summary>
    /// Interaction logic for CodeBoxView.xaml
    /// </summary>
    internal partial class CodeBoxView : UserControl, INotifyPropertyChanged
    {
        ScintillaNET.Scintilla codeBox;

        public CodeBoxView()
        {
            InitializeComponent();
            codeBox = (ScintillaNET.Scintilla)wfh.Child;

            // Integration fix from official instruction
            // ; 

            // Codebox configuration from JaNE.xml
            codeBox.ConfigurationManager.Language = "side";
            codeBox.ConfigurationManager.CustomLocation = @"side.xml";
            codeBox.ConfigurationManager.Configure();

            // Codebox's margins configuration for string numbers and code folding
            codeBox.Margins[0].Width = 25;
            codeBox.Margins[2].Width = 20;

            // CodeBox's autocomplete
            codeBox.CharAdded += CodeBox_CharAdded;
            codeBox.AutoComplete.MaxWidth = 20;
            codeBox.AutoComplete.MaxHeight = 10;
            codeBox.AutoComplete.List.Sort();

            // Highlighting current line (light grey)
            codeBox.Caret.HighlightCurrentLine = true;
            codeBox.Caret.CurrentLineBackgroundColor = System.Drawing.Color.FromArgb(245, 245, 245);

            //Code folding from default lexer
            codeBox.Folding.IsEnabled = true;
            codeBox.Folding.UseCompactFolding = true;

            //Background color
            codeBox.Selection.BackColor = System.Drawing.Color.FromArgb(190, 190, 190);

            //Brace Matching (red and bold)
            codeBox.IsBraceMatching = true;

            //Handler for keydown
            codeBox.KeyDown += CodeBox_KeyDown;


            this.DebugTools();
        }

        void DebugTools()
        {
            codeBox.Text = "This is \r\n a test.\r\nThis is only a test";
            this.BreakPointMarker(2);
            this.ErrorMarker(1);
            this.CurrentMarker(3);
            List<string> context = new List<string>();
            List<string> context2 = new List<string>();
            context.Add("qwerty");
            context.Add("qwe");
            context2.Add("qwe");
            this.AddContext(context2);
            this.AddContext(context);
            //this.RemoveContext(context);
        }
        void CodeBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == System.Windows.Forms.Keys.Space && e.Control)
            {
                codeBox.Snippets.ShowSnippetList();
            }

            if (e.KeyCode == System.Windows.Forms.Keys.E && e.Control)
            {
                this.CurrentMarker(codeBox.Lines.Current.Number + 1);

            }

            if (e.KeyCode == System.Windows.Forms.Keys.OemOpenBrackets && e.Shift)
            {
                codeBox.Lines.Current.Text += "}";
            }
        }

        void CodeBox_CharAdded(object sender, ScintillaNET.CharAddedEventArgs e)
        {
            if (Char.IsLetter(e.Ch))
                codeBox.AutoComplete.Show();
        }

        void ErrorMarker(int stringNum)
        {
            Marker marker = codeBox.Markers[0];
            marker.Symbol = MarkerSymbol.Circle;
            marker.BackColor = System.Drawing.Color.Red;
            codeBox.Lines[stringNum - 1].AddMarker(marker);
        }
        void BreakPointMarker(int stringNum)
        {
            Marker marker = codeBox.Markers[1];
            marker.Symbol = MarkerSymbol.FullRectangle;
            marker.BackColor = System.Drawing.Color.Blue;
            codeBox.Lines[stringNum - 1].AddMarker(marker);
        }
        void CurrentMarker(int stringNum)
        {
            Marker marker = codeBox.Markers[3];
            marker.Symbol = MarkerSymbol.Arrow;
            marker.BackColor = System.Drawing.Color.Green;
            codeBox.Lines[stringNum - 1].AddMarker(marker);
        }

        void AddContext(List<string> context)
        {
            codeBox.AutoComplete.List.AddRange(context);
            codeBox.AutoComplete.List = codeBox.AutoComplete.List.Distinct().ToList();
            codeBox.AutoComplete.List.Sort();
        }
        void RemoveContext(List<string> context)
        {
            codeBox.AutoComplete.List = codeBox.AutoComplete.List.Except(context).ToList();
            codeBox.AutoComplete.List.Sort();
        } 


        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
