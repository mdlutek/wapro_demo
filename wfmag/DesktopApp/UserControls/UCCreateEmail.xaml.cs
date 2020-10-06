using DesktopApp.Helpers;
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
    /// Interaction logic for UCCreateEmail.xaml
    /// </summary>
    public partial class UCCreateEmail : UserControl
    {
        public UCCreateEmail()
        {
            InitializeComponent();
        }

        private void Command_CanExecute_SendEmail(object sender, CanExecuteRoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(VMCreateEmail.Recipient) || string.IsNullOrWhiteSpace(VMCreateEmail.Subject) || string.IsNullOrWhiteSpace(VMCreateEmail.Body))
            {
                return;
            }

            e.CanExecute = true;
        }

        private void Command_Execute_SendEmail(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                var email = new Email(VMCreateEmail.Recipient, VMCreateEmail.Subject, VMCreateEmail.Body);

                email.Send();

                var userResult = MessageBox.Show("Wiadomość wysłana poprawnie. Czy wyczyścić formularz?", "Email Sended", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

                if(userResult == MessageBoxResult.Yes)
                {
                    VMCreateEmail.ClearFields();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sending email error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
