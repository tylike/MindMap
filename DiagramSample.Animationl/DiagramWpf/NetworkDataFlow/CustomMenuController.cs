using System.Windows;
using DevExpress.Diagram.Core;
using DevExpress.Xpf.Diagram;
using DevExpress.Xpf.Diagram.Native;

namespace ProjectB.Views.WPF.Controls.NetworkDataFlow
{
    // https://www.devexpress.com/Support/Center/Question/Details/T404563/createmenucontroller-is-not-virtual-which-results-in-that-it-s-impossible-to-hide-the
    // https://www.devexpress.com/Support/Center/Question/Details/T646371/the-diagram-context-menu-is-no-longer-opened-at-the-correct-location  
    // https://www.devexpress.com/Support/Center/Question/Details/T647284/the-diagram-context-menu-is-shifted-to-the-right-in-version-18-1 

    public class DiagramContextMenuController : MenuController
    {
        public DiagramContextMenuController(DiagramControl diagram)
            : base(diagram)
        {
            ToolBar.Visibility = Visibility.Hidden;
        }

        protected override void OnShowMenu(DiagramMenuPlacement placement)
        {
            if (ToolBar.IsOpen || Menu.IsOpen)
                return;
            var placementTarget = GetDiagramPlacementTarget();
            if (placement == DiagramMenuPlacement.Mouse)
            {
                ToolBar.PlacementTarget = placementTarget;
                ToolBar.IsOpen = false;
            }
            Menu.DiagramPlacement = placement;
            Menu.ShowPopup(ToolBar.IsOpen ? ToolBar : placementTarget);
            Menu.Closed += (sender, args) => Menu.Destroy();
        }

        private UIElement GetDiagramPlacementTarget()
        {
            UIElement placementTarget = Diagram;
            if (Diagram.PrimarySelection != null)
                placementTarget = Diagram.PrimarySelection;
            return placementTarget;
        }

        protected override DiagramContextMenuPlacementStrategy CreatePlacementStrategy()
        {
            return new ContextMenuPlacementStrategy();
        }
    }
    public class ContextMenuPlacementStrategy : DiagramContextMenuPlacementStrategy
    {
        protected override Point GetItemRelativeOffset(UIElement diagramItem, Size popupSize)
        {
            return GetDiagramRelativePopupOffset(diagramItem, popupSize);
        }
    }
}
