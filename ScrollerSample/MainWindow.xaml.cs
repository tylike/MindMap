using DevExpress.Mvvm.UI;
using DevExpress.Utils.Serializing;
using DevExpress.Xpf.Diagram;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp44 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e) {
            diagram.SaveDocument("test");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            diagram.LoadDocument("test");
        }
    
    }

    public class DiagramControlEx : DiagramDesignerControl
    {
        protected override DiagramRoot CreateRootItem()
        {
            return new DiagramRootEx(this) { };
        }
    }

    public class DiagramRootEx : DiagramRoot
    {
        public DiagramRootEx(DiagramControl diagram) : base(diagram) {
            
          
        }
        private ScrollViewer ScrollViewer;

        [XtraSerializableProperty]
        public double VerticalSrollPosition
        {
            get
            {
                if (ScrollViewer==null)
                    ScrollViewer = LayoutTreeHelper.GetVisualParents(this).OfType<ScrollViewer>().First();
                return ScrollViewer.VerticalOffset;
            }
            set
            {
                ScrollViewer.ScrollToVerticalOffset(value); ;
            }
        }

        [XtraSerializableProperty]
        public double HorizontalScrollPosition
        {
            get
            {
                if (ScrollViewer == null)
                    ScrollViewer = LayoutTreeHelper.GetVisualParents(this).OfType<ScrollViewer>().First();
                return ScrollViewer.HorizontalOffset;
            }
            set
            {
                ScrollViewer.ScrollToHorizontalOffset(value); ;
            }
        }
    }
}
