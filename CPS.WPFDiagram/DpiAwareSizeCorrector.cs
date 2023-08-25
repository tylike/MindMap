using DevExpress.Mvvm.UI.Native;
using DevExpress.Xpf.Core.Native;
using System;
using System.Windows;

namespace CPS.WPFDiagram
{
    public static class DpiAwareSizeCorrector
    {
        private static readonly PrimaryScreen screen = new PrimaryScreen();

        public static void Attach(Window window)
        {
            bool maximizeWindow;
            Size originSize = GetSize(out maximizeWindow, window.Width, window.Height);
            RoutedEventHandler loadedHandler = null;
            loadedHandler = delegate (object s, RoutedEventArgs __)
            {
                Window sender = s as Window;
                if (sender != null)
                {
                    sender.Loaded -= loadedHandler;
                    if (originSize.Width.IsNaN() || originSize.Height.IsNaN())
                    {
                        originSize = GetSize(out maximizeWindow, sender.Width, sender.Height);
                    }

                    screen.WorkingAreaChanged += delegate
                    {
                        UpdateSize(sender, sender.MinWidth, sender.MinHeight, originSize);
                    };
                    UpdateSize(sender, sender.MinWidth, sender.MinHeight, originSize);
                    if (maximizeWindow && sender.ResizeMode != 0 && sender.ResizeMode != ResizeMode.CanMinimize)
                    {
                        sender.WindowState = WindowState.Maximized;
                    }
                }
            };
            window.Loaded += loadedHandler;
        }

        private static Size GetSize(out bool maximizeWindow, double defaultWidth, double defaultHeight)
        {
            Size size = SystemParameters.WorkArea.Size;
            Size size2 = new Size(size.Width, size.Height);
            maximizeWindow = defaultWidth > size2.Width && defaultHeight > size2.Height;
            double width = Math.Min(defaultWidth, size2.Width);
            double height = Math.Min(defaultHeight, size2.Height);
            return new Size(width, height);
        }

        private static void UpdateSize(Window window, double minWidth, double minHeight, Size size)
        {
            if (PresentationSource.FromVisual(window) != null)
            {
                Point point = window.PointToScreen(new Point(window.Left, window.Top));
                Rect workingArea = screen.GetWorkingArea(point);
                window.MinWidth = Math.Min(workingArea.Width, minWidth);
                window.MinHeight = Math.Min(workingArea.Height, minHeight);
                window.Width = Math.Min(workingArea.Width, size.Width);
                window.Height = Math.Min(workingArea.Height, size.Height);
                window.Left = workingArea.Left + (workingArea.Width - window.Width) / 2.0;
                window.Top = workingArea.Top + (workingArea.Height - window.Height) / 2.0;
            }
        }
    }
}
