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
        public static readonly RoutedUICommand Home = new RoutedUICommand
            (
                "Home",
                "Home",
                typeof(Commands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.D1, ModifierKeys.Control)
                }
            );

        public static readonly RoutedUICommand MagAnalizaStanow = new RoutedUICommand
            (
                "MagAnalizaStanow",
                "MagAnalizaStanow",
                typeof(Commands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.D2, ModifierKeys.Control)
                }
            );

        public static readonly RoutedUICommand Orders = new RoutedUICommand
            (
                "Orders",
                "Orders",
                typeof(Commands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.D3, ModifierKeys.Control)
                }
            );


        public static readonly RoutedUICommand SendEmail = new RoutedUICommand
            (
                "SendEmail",
                "SendEmail",
                typeof(Commands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.E, ModifierKeys.Control)
                }
            );
    }
}
