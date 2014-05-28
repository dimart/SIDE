namespace Side.Core.CodeBox
{
    class CodeModel
    {
        public ICSharpCode.AvalonEdit.Document.TextDocument Code { get; set; }

        public CodeModel()
        {
            Code = new ICSharpCode.AvalonEdit.Document.TextDocument();
        }
    }
}
