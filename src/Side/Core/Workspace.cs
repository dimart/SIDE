using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;
using Side.Core.CodeBox;
using Side.Interfaces;
using Side.Interfaces.Events;
using Side.Interfaces.Services;

namespace Side.Core
{
    class Workspace : ViewModelBase, IWorkspace
    {
        private IUnityContainer _container;
        private IEventAggregator _eventAggregator;

        private ObservableCollection<CodeViewModel> _docs = new ObservableCollection<CodeViewModel>();
        private CodeViewModel _activeDocument;

        private string _document;
        private const string _title = "Simple IDE";

        private OpenFileDialog openFileDialog;

        #region CTOR

        public Workspace(IUnityContainer container, IEventAggregator eventAggregator)
        {
            _container = container;
            _eventAggregator = eventAggregator;

            _docs = new ObservableCollection<CodeViewModel>();
            _docs.CollectionChanged += Docs_CollectionChanged;

            _eventAggregator.GetEvent<ActiveContentChangedEvent>().Subscribe(ContentChanged);
            _document = "";
        }

        #endregion

        #region IWorkspace Members

        public ObservableCollection<CodeViewModel> Documents
        {
            get { return _docs; }
            set { _docs = value; }
        }

        public CodeViewModel ActiveDocument { get; set; }

        public string Title
        {
            get
            {
                string newTitle = _title;
                if (_document != "")
                {
                    newTitle += " - " + _document;
                }
                return newTitle;
            }
        }

        #endregion

        #region Commands
        public ICommand OpenFileCommand
        {
            get { return new DelegateCommand(OpenFile, () => true); }
        }

        public ICommand InterpretCommand
        {
            get { return new DelegateCommand(() => MessageBox.Show(_container.Resolve<IInterpreter>().Interpret(ActiveDocument.Model.Code.Text)), () => true); }
        }
        
        #endregion

        #region CommandsHandlers

        private void OpenFile()
        {
            string path = String.Empty;
            Stream myStream = null;
            openFileDialog = new OpenFileDialog();

            var result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    myStream = openFileDialog.OpenFile();
                    using (myStream)
                    {
                        using (StreamReader reader = new StreamReader(myStream))
                        {
                            path = reader.ReadLine();
                        }
                    }
                }
                catch (Exception ex)
                {
                    var logger = _container.Resolve<ILoggerService>();
                    logger.Log("Error: Could not read file from disk. Original error: " + ex.Message, LogCategory.Error, LogPriority.High);
                }
                string filePath = openFileDialog.FileName;
                string folderPath = Path.GetDirectoryName(filePath);

                var vm = _container.Resolve<CodeViewModel>();
                var model = _container.Resolve<CodeModel>();
                var view = _container.Resolve<CodeView>();

                model.Code.UndoStack.ClearAll();
                model.Code.Text = File.ReadAllText(filePath);
                vm.Model = model;
                vm.View = view;
                vm.Title = Path.GetFileName(filePath);
                vm.View.DataContext = model;

                Documents.Add(vm);
                ActiveDocument = vm;
            }
        }
        #endregion

        #region Events
        private void ContentChanged(CodeViewModel model)
        {
            _document = model == null ? "" : model.Title;
            RaisePropertyChanged("Title");
        }

        protected void ModelChangedEventHandler(object sender, PropertyChangedEventArgs e)
        {
            string newValue = ActiveDocument == null ? "" : ActiveDocument.Title;
            if (_document == newValue) return;
            _document = newValue;
            RaisePropertyChanged("Title");
        }

        private void Docs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (INotifyPropertyChanged item in e.OldItems)
                    item.PropertyChanged -= ModelChangedEventHandler;
            }

            if (e.NewItems != null)
            {
                foreach (INotifyPropertyChanged item in e.NewItems)
                    item.PropertyChanged += ModelChangedEventHandler;
            }

            if (e.Action != NotifyCollectionChangedAction.Remove) return;
            if (_docs.Count == 0)
            {
                this.ActiveDocument = null;
            }
        }
        #endregion
    }
}
