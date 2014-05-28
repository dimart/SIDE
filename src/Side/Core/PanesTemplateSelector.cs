using System.Windows;
using System.Windows.Controls;

using Side.Core.CodeBox;

namespace Side.Core
{
    public class PanesTemplateSelector : DataTemplateSelector
    {
        public DataTemplate CodeViewTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is CodeViewModel)
                return CodeViewTemplate;

            return base.SelectTemplate(item, container);
        }
    }
}
