using DevExpress.Mvvm.UI.Interactivity;
using System.Windows;

namespace CPS.WPFDiagram
{
    public class DpiAwareSizeBehavior : Behavior<Window>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            base.AssociatedObject.Do(delegate (Window x)
            {
                DpiAwareSizeCorrector.Attach(x);
            });
        }
    }
}
