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
        }

        private void Command_CanExecute_MagAnalizaStanow(object sender, CanExecuteRoutedEventArgs e)
        {
            //if (MainContent.Children.Count > 0 && MainContent.Children[0] is UCMagAnalizaStanow)
            //{
            //    e.CanExecute = false;
            //    return;
            //}

            e.CanExecute = true;
        }

        private void Command_Execute_MagAnalizaStanow(object sender, ExecutedRoutedEventArgs e)
        {
            if (MainContent.Children.Count > 0)
            {
                MainContent.Children.Clear();
            }

            MainContent.Children.Add(new UCMagAnalizaStanow());
        }

        private void CreateNewEmail(object sender, RoutedEventArgs e)
        {
            if (MainContent.Children.Count > 0)
            {
                MainContent.Children.Clear();
            }

            MainContent.Children.Add(new UCCreateEmail());
        }
    }
}
