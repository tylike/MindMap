using DevExpress.Diagram.Core.Native;
using DevExpress.Mvvm.UI;
using DevExpress.Utils.Serializing;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Diagram;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MindMap;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : ThemedWindow
{
    public MainWindow()
    {
        InitializeComponent();
        var root = (DiagramRootEx)diagram.RootItem();
        //ScrollViewer.HorizontalOffsetProperty
    }

    #region 选中放大动画、隐藏显示动画
    private void DiagramControl_SelectionChanged(object sender, DiagramSelectionChangedEventArgs e)
    {
        if (diagram.PrimarySelection != null)
        {


            // 假设你的 Diagram 控件名为 diagramControl

            // 创建适当的动画效果
            //DoubleAnimation scrollAnimation = new DoubleAnimation(diagramControl.HorizontalScrollOffset, 0, TimeSpan.FromSeconds(1));
            DoubleAnimation zoomAnimation = new DoubleAnimation(diagram.ZoomFactor, 2, TimeSpan.FromSeconds(1));

            // 订阅 FitItems 方法的完成事件
            //diagramControl.FitItemsCompleted += (sender, e) =>
            //{
            //    // 启动滚动位置动画
            //    diagramControl.BeginAnimation(DiagramControl.HorizontalScrollOffsetProperty, scrollAnimation);
            //    // 启动缩放系数动画
            //    diagramControl.BeginAnimation(DiagramControl.ZoomFactorProperty, zoomAnimation);
            //};

            // 执行 FitItems 方法

            diagram.BeginAnimation(DiagramControl.ZoomFactorProperty, zoomAnimation);
            diagram.FitToItems(diagram.SelectedItems);
        }
    }

    Dictionary<object, bool> running = new Dictionary<object, bool>();

    bool IsRunning(object obj)
    {
        Debug.Write(obj.ToString() + ":判读是否变化:");

        if (running.TryGetValue(obj, out var result))
        {
            Debug.WriteLine(result);
            return result;
        }
        Debug.WriteLine("false");
        running.Add(obj, false);
        return false;
    }
    void SetRunning(object obj, bool isRunning)
    {
        Debug.WriteLine(obj.ToString() + "=>" + isRunning.ToString());
        running[obj] = isRunning;
    }
    Random rnd = new Random();
    private void Ds_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (IsRunning(sender))
        {
            return;
        }

        SetRunning(sender, true);
        var o = sender;
        var v = e.NewValue;
        if (o is DiagramShape ds)
        {
            var f = 1d;
            var t = 0d;
            var 重新执行从显示到隐藏 = false;

            //从隐藏到显示
            if ((bool)v)
            {
                f = 0;
                t = 1;
            }
            else
            {
                重新执行从显示到隐藏 = true;
                ds.Visibility = Visibility.Visible;
            }

            var time = 0.6;// rnd.NextDouble() * 2;
                           //if (time == 0)
                           //    time = 0.5;

            DoubleAnimation animation = new DoubleAnimation
            {
                From = f,
                To = t,
                Duration = TimeSpan.FromSeconds(time)
            };
            // 创建动画完成时的事件处理程序
            animation.Completed += (s, ep) =>
            {
                if (重新执行从显示到隐藏)
                    ds.Visibility = Visibility.Collapsed;
                SetRunning(sender, false);

                // 在动画完成后隐藏控件
                //myControl.Visibility = Visibility.Hidden;
            };
            // 开始动画
            ds.BeginAnimation(UIElement.OpacityProperty, animation);
        }
    }
    #endregion
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
    public DiagramRootEx(DiagramControl diagram) : base(diagram)
    {


    }
    public ScrollViewer ScrollViewer { get; private set; }

    [XtraSerializableProperty]
    public double VerticalSrollPosition
    {
        get
        {
            if (ScrollViewer == null)
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