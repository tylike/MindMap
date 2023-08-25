using System.Collections.Generic;
using System.Windows;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Diagram;

namespace ProjectB.Views.WPF.Controls.NetworkDataFlow
{
    public class DiagramControlEx : DiagramControl
    {
        public bool ReactToZoomChanged { get; set; } = true;

        public static readonly DependencyProperty ContextMenuItemsProperty = DependencyProperty.Register(
            "ContextMenuItems", typeof(List<BarItem>), typeof(DiagramControlEx), new PropertyMetadata(null));

        public List<BarItem> ContextMenuItems
        {
            get => (List<BarItem>)GetValue(ContextMenuItemsProperty);
            set => SetValue(ContextMenuItemsProperty, value);
        }

        public DiagramControlEx()
        {
            ContextMenuItems = new List<BarItem>();
            DataContextChanged += OnDataContextChanged;
        }

        // https://www.devexpress.com/Support/Center/Question/Details/t802448/using-barlinkcontaineritem-for-diagram-contextmenu-requires-extra-click
        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            foreach (var item in ContextMenuItems)
            {
                item.DataContext = e.NewValue;
            }
        }

        // https://www.devexpress.com/Support/Center/Question/Details/T522437/how-to-customize-the-context-menu-in-diagramcontrol
        protected override IEnumerable<IBarManagerControllerAction> CreateContextMenu()
        {
            if (PrimarySelection is DiagramContentItem)
            {
                foreach (var contextMenuItem in ContextMenuItems)
                {
                    yield return contextMenuItem;
                }
            }
        }
    }
}