using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopApp.UserControls
{
    /// <summary>
    /// Interaction logic for UCOrders.xaml
    /// </summary>
    public partial class UCOrders : UserControl
    {
        public UCOrders()
        {
            InitializeComponent();
        }

        private void Btn_RefreshData(object sender, RoutedEventArgs e)
        {
            VMOrders.LoadOrders();
        }
    }
}
