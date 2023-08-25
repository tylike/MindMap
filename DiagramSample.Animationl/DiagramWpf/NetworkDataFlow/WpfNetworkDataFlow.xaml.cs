using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using DevExpress.Diagram.Core;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Diagram;
using ProjectB.Views.WPF.Controls.NetworkDataFlow.Data;

namespace ProjectB.Views.WPF.Controls.NetworkDataFlow
{
    /// <summary>
    /// Interaction logic for WpfNetworkDataFlow.xaml
    /// </summary>
    public partial class WpfNetworkDataFlow
    {
        public event ZoomChangedHandler ZoomChanged;
        public event EventHandler RefreshRequested;
        public event EventHandler<DiagramItemsGeneratedEventArgs> ItemsGenerated;

        #region properties

        public static readonly DependencyProperty NodesProperty = DependencyProperty.Register(
            "Nodes", typeof(IEnumerable), typeof(WpfNetworkDataFlow),
            new PropertyMetadata(default(IEnumerable)));

        public IEnumerable Nodes
        {
            get => (IEnumerable)GetValue(NodesProperty);
            set => SetValue(NodesProperty, value);
        }

        public static readonly DependencyProperty ConnectorsProperty = DependencyProperty.Register(
            "Connectors", typeof(IEnumerable), typeof(WpfNetworkDataFlow),
            new PropertyMetadata(default(IEnumerable)));

        public IEnumerable Connectors
        {
            get => (IEnumerable)GetValue(ConnectorsProperty);
            set => SetValue(ConnectorsProperty, value);
        }

        public static readonly DependencyProperty ZoomFactorProperty = DependencyProperty.Register(
            "ZoomFactor", typeof(double), typeof(WpfNetworkDataFlow),
            new PropertyMetadata(1.0d, ZoomPropertyChangedCallback));

        private static void ZoomPropertyChangedCallback(DependencyObject sender,
            DependencyPropertyChangedEventArgs args)
        {
            var control = (WpfNetworkDataFlow)sender;
            control?.OnZoomChanged(args.NewValue, args.OldValue);
        }

        public double ZoomFactor
        {
            get => (double)GetValue(ZoomFactorProperty);
            set => SetValue(ZoomFactorProperty, value);
        }

        public static readonly DependencyProperty ItemTemplateProperty = DependencyProperty.Register(
            "ItemTemplate", typeof(DataTemplate), typeof(WpfNetworkDataFlow),
            new PropertyMetadata(default(DataTemplate)));

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        public static readonly DependencyProperty ContextMenuItemsProperty = DependencyProperty.Register(
            "ContextMenuItems", typeof(List<BarItem>), typeof(WpfNetworkDataFlow),
            new PropertyMetadata(new List<BarItem>()));

        public List<BarItem> ContextMenuItems
        {
            get => (List<BarItem>)GetValue(ContextMenuItemsProperty);
            set => SetValue(ContextMenuItemsProperty, value);
        }

        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
            "SelectedItem", typeof(object), typeof(WpfNetworkDataFlow), new PropertyMetadata(default(object)));

        public object SelectedItem
        {
            get => GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register(
            "SelectedItems", typeof(List<object>), typeof(WpfNetworkDataFlow),
            new PropertyMetadata(default(List<object>)));

        public List<object> SelectedItems
        {
            get => (List<object>)GetValue(SelectedItemsProperty);
            set => SetValue(SelectedItemsProperty, value);
        }

        public bool UsePointerTool
        {
            get => Diagram == null || Diagram.ActiveTool == Diagram.PointerTool;
            set => Diagram.ActiveTool = value ? Diagram.PointerTool : Diagram.PanTool;
        }

        public static readonly DependencyProperty AllowLayoutChangesProperty = DependencyProperty.Register(
            "AllowLayoutChanges", typeof(bool), typeof(WpfNetworkDataFlow), new PropertyMetadata(true));

        public bool AllowLayoutChanges
        {
            get => (bool)GetValue(AllowLayoutChangesProperty);
            set => SetValue(AllowLayoutChangesProperty, value);
        }

        public static readonly DependencyProperty DirectionProperty = DependencyProperty.Register(
            "Direction", typeof(ENetworkDirection), typeof(WpfNetworkDataFlow), new PropertyMetadata(ENetworkDirection.Downwards));

        public ENetworkDirection Direction
        {
            get => (ENetworkDirection)GetValue(DirectionProperty);
            set => SetValue(DirectionProperty, value);
        }

        public static readonly DependencyProperty ConnectorFromMemberProperty = DependencyProperty.Register(
            "ConnectorFromMember", typeof(string), typeof(WpfNetworkDataFlow), new PropertyMetadata(default(string)));

        public string ConnectorFromMember
        {
            get => (string)GetValue(ConnectorFromMemberProperty);
            set => SetValue(ConnectorFromMemberProperty, value);
        }

        public static readonly DependencyProperty ConnectorToMemberProperty = DependencyProperty.Register(
            "ConnectorToMember", typeof(string), typeof(WpfNetworkDataFlow), new PropertyMetadata(default(string)));

        public string ConnectorToMember
        {
            get => (string)GetValue(ConnectorToMemberProperty);
            set => SetValue(ConnectorToMemberProperty, value);
        }

        public static readonly DependencyProperty DiagramPageBackgroundTemplateProperty = DependencyProperty.Register(
            "DiagramPageBackgroundTemplate", typeof(DataTemplate), typeof(WpfNetworkDataFlow), new PropertyMetadata(default(DataTemplate)));

        public DataTemplate DiagramPageBackgroundTemplate
        {
            get => (DataTemplate)GetValue(DiagramPageBackgroundTemplateProperty);
            set => SetValue(DiagramPageBackgroundTemplateProperty, value);
        }

        public static readonly DependencyProperty ConnectorsSeparationModeProperty = DependencyProperty.Register(
            "ConnectorsSeparationMode", typeof(DiagramConnectorsSeparationMode), typeof(WpfNetworkDataFlow), new PropertyMetadata(default(DiagramConnectorsSeparationMode)));

        public DiagramConnectorsSeparationMode ConnectorsSeparationMode
        {
            get => (DiagramConnectorsSeparationMode)GetValue(ConnectorsSeparationModeProperty);
            set => SetValue(ConnectorsSeparationModeProperty, value);
        }

        public static readonly DependencyProperty ConnectorTemplateProperty = DependencyProperty.Register(
            "ConnectorTemplate", typeof(DataTemplate), typeof(WpfNetworkDataFlow), new PropertyMetadata(default(DataTemplate)));

        public DataTemplate ConnectorTemplate
        {
            get => (DataTemplate)GetValue(ConnectorTemplateProperty);
            set => SetValue(ConnectorTemplateProperty, value);
        }
        #endregion properties

        public WpfNetworkDataFlow()
        {
            InitializeComponent();

            // using Display setting results in blurry fonts for DevExpress Diagram control
            TextOptions.SetTextFormattingMode(this, TextFormattingMode.Ideal);

            ContextMenuItems = new List<BarItem>();

            typeof(DiagramControl).GetField("menuController", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(Diagram, new DiagramContextMenuController(Diagram));

            Diagram.ScrollMargin = new Thickness(int.MaxValue);
            Diagram.ShowPageBreaks = false;
            Diagram.FitToDrawingMargin = new Thickness(0);
        }

        #region zoom

        private void ResetZoom(object sender, ItemClickEventArgs e)
        {
            ZoomFactor = 1;
        }

        protected virtual void OnZoomChanged(object newValue, object oldValue)
        {
            ZoomChanged?.Invoke(this, new ZoomChangedEventArgs { NewZoom = newValue, OldZoom = oldValue });
        }

        #endregion zoom      

        private void OptimizeLayoutItem_OnItemClick(object sender, ItemClickEventArgs e)
        {
            OnRefreshRequested();
        }

        private void DiagramDataBindingBehaviorBase_OnItemsGenerated(object sender, DiagramItemsGeneratedEventArgs e)
        {
            ItemsGenerated?.Invoke(sender, e);
        }

        #region event invocators

        protected virtual void OnRefreshRequested()
        {
            RefreshRequested?.Invoke(this, EventArgs.Empty);
        }

        #endregion event invocators
    }
}