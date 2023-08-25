using System.Windows;
using System.Windows.Controls;
using BusinessLogic;


namespace ProjectB.Views.WPF.DataFlow_2_0.Views
{
    public class NodeTypeTemplateSelector : DataTemplateSelector
    {
        public DataTemplate EntityNodeTemplate { get; set; }
        public DataTemplate TransformationNodeTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (!(item is NetworkNode data))
                return null;

            switch (data.NodeType)
            {
                case NetworkFlowNodeType.Entity:
                    return EntityNodeTemplate;
                case NetworkFlowNodeType.Transformation:
                    return TransformationNodeTemplate;
            }

            return base.SelectTemplate(item, container);
        }
    }
}