using System;
using System.ComponentModel;
using System.Windows.Controls;
using Side.Interfaces;
using Side.Interfaces.Services;

namespace Side.Core.CodeBox
{
    public class CodeViewModel : ViewModelBase
    {
        private CodeModel _model;
        private ILoggerService _logger;

        private string _title = null;
        private IWorkspace _workspace;

        public CodeViewModel(IWorkspace workspace, ILoggerService logger)
        {
            _workspace = workspace;
            _logger = logger;
        }

        public CodeModel Model
        {
            get { return _model; }
            set
            {
                if (_model != null)
                {
                    _model.PropertyChanged -= Model_PropertyChanged;
                }
                if (value == null) return;
                _model = value;
                _model.PropertyChanged += Model_PropertyChanged;
            }
        }

        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged("Model");
            RaisePropertyChanged("Title");
        }

        public UserControl View { get; set; }

        public string Title
        {
            get
            {
                if (Model.IsDirty)
                {
                    return _title + "*";
                }
                return _title;
            }
            set
            {
                if (_title == value) return;
                _title = value;
                RaisePropertyChanged("Title");
            }
        }

    }
}
