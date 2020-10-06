using DesktopApp.UserControls;
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

namespace DesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static DataAccess.DB DTier;

        public MainWindow()
        {
            InitializeComponent();

            DTier = new DataAccess.DB();

            SetHomeUC();
        }

        private void SetHomeUC()
        {
            ClearMainContent();
            MainContent.Children.Add(new UCHome());
        }

        private void Command_Execute_Home(object sender, ExecutedRoutedEventArgs e)
        {
            SetHomeUC();
        }

        private void Command_Execute_MagAnalizaStanow(object sender, ExecutedRoutedEventArgs e)
        {
            ClearMainContent();
            MainContent.Children.Add(new UCMagAnalizaStanow());
        }

        private void Command_Execute_Orders(object sender, ExecutedRoutedEventArgs e)
        {
            ClearMainContent();
            MainContent.Children.Add(new UCOrders());
        }

        private void Command_Execute_SendEmail(object sender, ExecutedRoutedEventArgs e)
        {
            ClearMainContent();
            MainContent.Children.Add(new UCCreateEmail());
        }

        private void ClearMainContent()
        {
            if (MainContent.Children.Count > 0)
            {
                MainContent.Children.Clear();
            }
        }

        
    }
}
