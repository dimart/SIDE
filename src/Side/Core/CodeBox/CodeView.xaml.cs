using System.IO;
using System.Windows.Controls;
using System.Xml;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;

namespace Side.Core.CodeBox
{
    /// <summary>
    /// Interaction logic for CodeBoxView.xaml
    /// </summary>
    public partial class CodeView : UserControl
    {
        public CodeView()
        {
            InitializeComponent();
            var s = File.OpenRead("./../Highlighting/Suffle.xshd");
            XmlTextReader reader = new XmlTextReader(s);
            CodeEditor.SyntaxHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
        }
    }
}
