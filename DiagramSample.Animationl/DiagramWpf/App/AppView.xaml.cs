using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjectB.Views.WPF.DataFlow_2_0.NetworkDisplayLayouts.Layout;
using WpfProject.App.NetworkCustomization.LayoutAlgorithms.Layout.Data;

namespace WpfProject.App
{
    /// <summary>
    /// Interaction logic for AppView.xaml
    /// </summary>
    public partial class AppView : UserControl
    {
        private AppViewModel _dataContext;

        public AppView()
        {
            InitializeComponent();
            DataContextChanged += (sender, args) =>
            {
                _dataContext = (AppViewModel)DataContext;
                _dataContext.LayoutRefreshRequested += OnLayoutRefreshRequested;
            };
        }

        private void OnLayoutRefreshRequested(LayoutRefreshRequestEventArgs args)
        {
            WpfNetworkDataFlow.Refresh(args, _dataContext.NetworkData);
        }
    }
}
