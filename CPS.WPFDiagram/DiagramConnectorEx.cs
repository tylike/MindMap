using DevExpress.Diagram.Core;
using DevExpress.Diagram.Core.Native;
using DevExpress.Xpf.Diagram;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace CPS.WPFDiagram
{
    public class DiagramConnectorEx : DiagramConnector
    {
        protected override void OnRender(DrawingContext drawingContext)
        {
            DrawBorder(drawingContext);
            base.OnRender(drawingContext);
        }
        void DrawBorder(DrawingContext drawingContext)
        {
            SolidColorBrush customBorderBrush = new SolidColorBrush(Color.FromArgb(0x4C, 0xE0, 0xCC, 0x72));
            Pen customBorderPen = new Pen(customBorderBrush, 20);
            List<System.Windows.Media.LineSegment> linesToDraw = new List<System.Windows.Media.LineSegment>();
            foreach (ConnectorSegment segment in this.Segments())
            {
                linesToDraw.Add(new System.Windows.Media.LineSegment()
                {
                    Point = new Point(segment.End.X - this.Position.X, segment.End.Y - this.Position.Y)
                });
            }
            ConnectorSegment firstSegment = this.Segments().First();
            PathFigure pathFigure = new PathFigure(new Point(firstSegment.Start.X - this.Position.X, firstSegment.Start.Y - this.Position.Y), linesToDraw, false);
            PathGeometry pathToDraw = new PathGeometry(new List<PathFigure>() { pathFigure });
            drawingContext.DrawGeometry(null, customBorderPen, pathToDraw);
        }
    }
}
