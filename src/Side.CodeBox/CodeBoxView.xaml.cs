using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using Side.Interfaces;

namespace Side.CodeBox
{
    /// <summary>
    /// Interaction logic for CodeBoxView.xaml
    /// </summary>
    internal partial class CodeBoxView : UserControl, INotifyPropertyChanged
    {
        public CodeBoxView()
        {
            InitializeComponent();
        }

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
