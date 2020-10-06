using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.ViewModels
{
    public class VMCreateEmail : INotifyPropertyChanged
    {
        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        #region Properties

        private string recipient;
        private string subject;
        private string body;

        public string Recipient
        {
            get { return recipient; }
            set { recipient = value; OnPropertyChanged(); }
        }

        public string Subject
        {
            get { return subject; }
            set { subject = value; OnPropertyChanged(); }
        }

        public string Body
        {
            get { return body; }
            set { body = value; OnPropertyChanged(); }
        }

        #endregion

        public VMCreateEmail()
        {

#if DEBUG
            Recipient = "janoskikowalski@gmail.com";
            Subject = "WAPRO - Wiadomość testowa";
            Body = "To jest wiadomość testowa wysłana poprzez program do obsługi Wapro wfmag";
#endif
        }

        public void ClearFields()
        {
            Recipient = "";
            Subject = "";
            Body = "";
        }
    }
}
