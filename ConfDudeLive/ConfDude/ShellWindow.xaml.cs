using ConfDude.Services;
using Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ConfDude
{
    public partial class ShellWindow : Window
    {
        private IModuleService _moduleService;

        public ShellWindow()
        {
            InitializeComponent();
            _moduleService = ServicePool.Current.GetService<IModuleService>();
            var list = _moduleService.GetMetadata();
            this.moduleListBox.ItemsSource = list;
            this.moduleListBox.DisplayMemberPath = "DisplayName";
            this.moduleListBox.SelectionChanged += moduleListBox_SelectionChanged;
        }

        void moduleListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var metadata = e.AddedItems[0] as IModuleMetadata;
            var module = _moduleService.Activate(metadata);
            var view = module.GetView();
            this.moduleViewHost.Child = view;
        }
    }
}
