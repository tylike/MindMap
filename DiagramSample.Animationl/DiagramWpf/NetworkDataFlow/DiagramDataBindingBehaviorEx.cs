using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DevExpress.Xpf.Diagram;

namespace ProjectB.Views.WPF.Controls.NetworkDataFlow
{
    public class DiagramDataBindingBehaviorEx : DiagramDataBindingBehavior
    {
        public List<object> SelectedObjects
        {
            get => (List<object>) GetValue(SelectedObjectsProperty);
            set => SetValue(SelectedObjectsProperty, value);
        }

        public static readonly DependencyProperty SelectedObjectsProperty =
            DependencyProperty.Register("SelectedObjects", typeof(List<object>), typeof(DiagramDataBindingBehaviorEx),
                new FrameworkPropertyMetadata(OnSelectedObjectsChanged));

        private static void OnSelectedObjectsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {        
            // only nodes, not connectors
            List<DiagramContentItem> items = null;
            var diagram = ((DiagramDataBindingBehaviorEx) d).AssociatedObject;

            var selectedObjects = (IList<object>) e.NewValue;
            if (selectedObjects != null)
            {
                items =
                    diagram.Items.OfType<DiagramContentItem>().Where(x => selectedObjects.Contains(x.Content)).ToList();
            }

            if (items == null)
            {
                diagram.ClearSelection();
            }
            else
            {
                diagram.SelectItems(items);
            }
        }

        public object PrimarySelection
        {
            get => GetValue(PrimarySelectionProperty);
            set => SetValue(PrimarySelectionProperty, value);
        }

        public static readonly DependencyProperty PrimarySelectionProperty =
            DependencyProperty.Register("PrimarySelection", typeof(object), typeof(DiagramDataBindingBehaviorEx),
                new FrameworkPropertyMetadata(OnPrimarySelectionChanged));

        private static void OnPrimarySelectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DiagramItem item = null;
            var diagram = ((DiagramDataBindingBehaviorEx) d).AssociatedObject;
            if (e.NewValue != null)
                item = diagram.Items.OfType<DiagramContentItem>().FirstOrDefault(x => x.Content == e.NewValue);
            if (item == null)
                diagram.ClearSelection();
            else if (diagram.PrimarySelection != item)
                diagram.SelectItem(item);
        }


        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectionChanged += AssociatedObject_SelectionChanged;
        }

        void AssociatedObject_SelectionChanged(object sender, DiagramSelectionChangedEventArgs e)
        {
            UpdateSelectedItems();
            UpdatePrimarySelection();
        }

        void UpdateSelectedItems()
        {
            // connector selction should not be prohibited
            if (AssociatedObject.SelectedItems.All(x => x is DiagramConnector))
            {
                return;
            }

            List<object> selectedItems = new List<object>();
            foreach (DiagramItem item in AssociatedObject.SelectedItems)
            {
                if (item is DiagramContentItem contentItem)
                {
                    selectedItems.Add(contentItem.Content);
                }
            }
            SelectedObjects = selectedItems;
        }

        void UpdatePrimarySelection()
        {
            if (this.AssociatedObject.PrimarySelection is DiagramContentItem selectedItem)
                this.PrimarySelection = selectedItem.Content;
        }  
    }
}