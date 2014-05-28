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
    }
}
