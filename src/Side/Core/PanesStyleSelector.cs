using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Side.Core.CodeBox;

namespace Side.Core
{
    public class PanesStyleSelector : StyleSelector
    {

        public Style ContentStyle { get; set; }

        public override Style SelectStyle(object item, DependencyObject container)
        {
        
            if (item is CodeViewModel)
                return ContentStyle;

            return base.SelectStyle(item, container);
        }
    }
}
