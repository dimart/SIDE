using System;
using System.ComponentModel;
using Side.Interfaces;

namespace Side.Core.CodeBox
{
    public class CodeModel : ViewModelBase
    {
        private string _oldCode;
        private bool _isDirty;

        public ICSharpCode.AvalonEdit.Document.TextDocument Code { get; set; }

        public CodeModel()
        {
            Code = new ICSharpCode.AvalonEdit.Document.TextDocument();
            Code.PropertyChanged += CodePropertyChanged;
            Code.TextChanged += CodeOnTextChanged;
            _oldCode = "";
        }

        public bool IsDirty
        {
            get { return _isDirty; }
            set
            {
                _isDirty = value;
                RaisePropertyChanged("IsDirty");
                if (value == false)
                {
                    _oldCode = Code.Text;
                }
            }
        }
        
        private void CodeOnTextChanged(object sender, EventArgs eventArgs)
        {
            IsDirty = (_oldCode != Code.Text);
        }

        private void CodePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged("Document");
        }
    }
}
