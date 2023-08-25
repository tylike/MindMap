namespace ProjectB.Views.WPF.DataFlow_2_0.NetworkDisplayLayouts.Layout.Data
{
    public class Interval
    {
        public double Start { get; set; }
        public double End { get; set; }

        public override string ToString()
        {
            return Start.ToString("f2") + " ->" + End.ToString("f2");
        }
    }
}
