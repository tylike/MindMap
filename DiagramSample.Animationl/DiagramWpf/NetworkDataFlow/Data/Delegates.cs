using System;

namespace ProjectB.Views.WPF.Controls.NetworkDataFlow.Data
{
    public class ZoomChangedEventArgs : EventArgs
    {
        public object NewZoom { get; set; }
        public object OldZoom { get; set; }
    }

    public delegate void ZoomChangedHandler(object sender, ZoomChangedEventArgs e);
}
