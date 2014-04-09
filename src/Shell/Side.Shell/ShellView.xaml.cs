using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;
using Side.Interfaces;

namespace Side.Shell
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : IShell
    {
        public ShellView()
        {
            InitializeComponent();
        }

        public void LoadLayout()
        {
            Console.WriteLine("LOADED");
        }

        public void SaveLayout()
        {
            Console.WriteLine("SAVED");
        }
    }
}
