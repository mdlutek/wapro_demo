using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopApp.Helpers
{
    public class Commands
    {
        public static readonly RoutedUICommand MagAnalizaStanow = new RoutedUICommand
            (
                "MagAnalizaStanow",
                "MagAnalizaStanow",
                typeof(Commands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.D1, ModifierKeys.Control)
                }
            );


        public static readonly RoutedUICommand SendEmail = new RoutedUICommand
            (
                "SendEmail",
                "SendEmail",
                typeof(Commands)
            );
    }
}
