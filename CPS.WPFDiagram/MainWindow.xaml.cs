using DevExpress.Diagram.Core;
using DevExpress.Diagram.Core.Localization;
using DevExpress.Diagram.Core.Shapes;
using DevExpress.Mvvm.UI;
using DevExpress.Utils.Text;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Diagram;
using DevExpress.Xpf.Diagram.Native;
using DevExpress.Xpf.Editors;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CPS.WPFDiagram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        public MainWindow()
        {
            DiagramControlLocalizer.Active = new DiagramControlLocalizerEx();

            InitializeComponent(); 
            DiagramControl.ItemTypeRegistrator.Register(typeof(DiagramConnectorEx));

            CreateToolboxItems();
            this.diagram.AddingNewItem += Diagram_AddingNewItem;
            this.diagram.QueryConnectionPoints += Diagram_QueryConnectionPoints;
            this.diagram.Loaded += Diagram_Loaded;
            this.diagram.ItemsDeleting += Diagram_ItemsDeleting;
            this.diagram.MouseDoubleClick += Diagram_MouseDoubleClick;

            DiagramContentItem item = new DiagramContentItem();
            item.Content = new RichTextBox();

            this.diagram.Items.Add(item);

        }

        private void Diagram_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (richTextBox.Visibility == Visibility.Visible)
            {
                richTextBox.Visibility = Visibility.Collapsed;
            }
        }

        private void Diagram_ItemsDeleting(object sender, DiagramItemsDeletingEventArgs e)
        {
            foreach (var item in e.Items)
            {
                Debug.WriteLine(item.GetType().FullName);
            }
        }

        private void Diagram_Loaded(object sender, RoutedEventArgs e)
        {

            //移除掉搜索框 和 更多图形
            DiagramToolboxControl toolbox = LayoutTreeHelper.GetVisualChildren(diagram).OfType<DiagramToolboxControl>().FirstOrDefault();
            if (toolbox != null)
            {
                SearchControl searchControl = LayoutTreeHelper.GetVisualChildren(toolbox).OfType<SearchControl>().FirstOrDefault();
                if (searchControl != null)
                    searchControl.Visibility = Visibility.Collapsed;

                ListBox listBox = LayoutTreeHelper.GetVisualChildren(toolbox).OfType<ListBox>().FirstOrDefault(c => c.Name != "ShapesListBox");
                if (listBox != null)
                {
                    var willRemove = listBox.Items.OfType<MenuStencilInfo>().Where(c => c.Id == "MoreShapes").ToArray();
                    foreach (var item in willRemove)
                    {
                        listBox.Items.Remove(item);
                    }

                    //foreach (var x in listBox.Items)
                    //{

                    //    //listBox.Visibility = Visibility.Collapsed;
                    //}
                }
            }
        }

        private void Diagram_QueryConnectionPoints(object sender, DiagramQueryConnectionPointsEventArgs e)
        {
            var hi = e.HoveredItem;
            foreach (var p in e.ItemConnectionPointStates)
                p.State = ConnectionElementState.Visible;

            if (e.ConnectorPointType == ConnectorPointType.Begin)
            {
                if (hi.Tag is ConnectPointCategory.Output)
                {

                }
                else
                {
                    foreach (var p in e.ItemConnectionPointStates)
                        p.State = ConnectionElementState.Hidden;

                    return;
                }
            }
            if (e.ConnectorPointType == ConnectorPointType.End)
            {
                if (hi.Tag is ConnectPointCategory.Input)
                {

                }
                else
                {
                    foreach (var p in e.ItemConnectionPointStates)

                        p.State = ConnectionElementState.Disabled;
                    return;
                }
            }
        }

        private void Diagram_AddingNewItem(object sender, DiagramAddingNewItemEventArgs e)
        {

            if (e.Item is DiagramShape ds)
            {

                var points = ds.Shape.GetPoints();
                if (points == null) return;

                #region 整体容器
                var con = new DiagramContainer();
                con.Items.Add(ds);
                //e.Item = con;
                diagram.Items.Add(con);

                //con.SetTop(ds.GetTop());
                con.Width = ds.Width;
                con.Height = ds.Height;
                con.Position = ds.Position;
                //con.BorderThickness = new Thickness(0);
                con.StrokeThickness = 0;
                //con.SizeChanged += (s, evt) => { ds.Width = con.Width; ds.Height = con.Height; };
                con.AdjustBoundsBehavior = AdjustBoundaryBehavior.None;
                con.ConnectionPoints = new DiagramPointCollection();
                con.CanAddItems = false;

                #endregion

                #region 内部真实图
                ds.CanResize = false;
                ds.Position = new Point(0, 0);
                ds.Anchors = Sides.All;
                ds.CanSelect = false;
                //ds.CanDelete = false;
                ds.CanMove = false;
                ds.CanEdit = false;
                ds.CanRotate = false;

                #endregion

                foreach (var item in points)
                {
                    var p = new DiagramShape();
                    p.Tag = item.Category;
                    p.MinHeight = 0;
                    p.MinWidth = 0;
                    p.CanDelete = false;
                    p.CanMove = false;
                    p.CanResize = false;
                    p.CanEdit = false;
                    p.CanRotate = false;
                    p.CanSelect = false;
                    con.SizeChanged += (s, evt) =>
                    {
                        p.Position = new Point(item.Location.X * con.Width, item.Location.Y * con.Height);
                    };
                    con.Items.Add(p);
                }

                e.Handled = true;
                e.Cancel = true;
            }
            else
            {
                if (e.Item is DiagramConnector dc)
                {
                    if (dc.BeginItem == null || dc.EndItem == null)
                    {
                        e.Handled = true;
                        e.Cancel = true;
                    }
                }
            }

            //item.IncomingConnectors
            //item.OutgoingConnectors
            //如何设置只允许一个连接点只能做为输入或输出呢?
            //item.ActualConnectionPoints
            //item.ConnectionPoints
        }

        void CreateToolboxItems()
        {
            ShapeTemplate st = new ShapeTemplate();
            //st.Segments.Add(new ShapeSegment);
            List<DiagramStencil> Stencils = DiagramToolboxRegistrator.Stencils.ToList<DiagramStencil>();
            Stencils.ForEach(s => DiagramToolboxRegistrator.UnregisterStencil(s));

            #region input parameter
            var toolboxGroup_InputParameter = new DiagramStencil("InputParameter", "Input Parameter");
            toolboxGroup_InputParameter.CreateInputParameter();

            var diagramDesignerControl1 = this.diagram;
            DiagramToolboxRegistrator.RegisterStencil(toolboxGroup_InputParameter);
            #endregion

            #region Operator
            var toolboxGroup_Operator = new DiagramStencil("Operator", "Operator");
            toolboxGroup_Operator.CreateOperatorGroup();

            DiagramToolboxRegistrator.RegisterStencil(toolboxGroup_Operator);
            #endregion

            #region Function
            var toolboxGroup_Function = new DiagramStencil("Function", "Function");
            toolboxGroup_Function.CreateFunction("Max", true);
            toolboxGroup_Function.CreateFunction("Min", true);
            toolboxGroup_Function.CreateFunction("Log10");
            toolboxGroup_Function.CreateFunction("Natural Log");
            toolboxGroup_Function.CreateFunction("Vote");
            toolboxGroup_Function.CreateFunction("Exact Vote");
            toolboxGroup_Function.CreateFunction("Square Root");
            toolboxGroup_Function.CreateFunction("Power");
            toolboxGroup_Function.CreateFunction("ABS");
            toolboxGroup_Function.CreateFunction("Int");
            toolboxGroup_Function.CreateFunction("If\nThen", true);
            toolboxGroup_Function.CreateFunction("No Eval", true, ToolboxHelper.Function_NoEval());
            DiagramToolboxRegistrator.RegisterStencil(toolboxGroup_Function);

            #endregion
        }

        WndRichTextBox richTextBox = new WndRichTextBox();

        private void diagram_ShowingEditor(object sender, DiagramShowingEditorEventArgs e)
        {
            if (e.Item is DiagramShape ds)
            {
                if (ds.Shape.Name == "Rectangle")
                {
                    //element.TransformToAncestor(container).TransformBounds(new Rect(0.0, 0.0, element.ActualWidth, element.ActualHeight));
                    var p = ds.TransformToAncestor(this);
                    var p1 = p.TransformBounds(new Rect(0.0, 0.0, ds.ActualWidth, ds.ActualHeight));
                    richTextBox.Width = ds.Width;
                    richTextBox.Height = ds.Height;
                    richTextBox.Top = p1.Y;
                    richTextBox.Left = p1.X;

                    if (richTextBox.Visibility != Visibility.Visible)
                    {
                        richTextBox.Visibility = Visibility.Visible;
                    }

                    e.Cancel = true;
                    return;
                }
            }

            var wnd = new WndEditInput();
            wnd.ShowDialog();
            e.Cancel = true;
        }
    }
    public class ConnectPoint
    {
        public Point Location { get; set; }
        public ConnectPointCategory Category { get; set; }
    }
    public enum ConnectPointCategory
    {
        Input,
        Output
    }
}
