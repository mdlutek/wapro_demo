using DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.ViewModels
{
    public class VMMagAnalizaStanow : INotifyPropertyChanged
    {
        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        #region Properties

        private ObservableCollection<ANALIZA_ILOSCIOWA_ARTYKULOW_ZAM_V> analizaIlosciowaList;

        public ObservableCollection<ANALIZA_ILOSCIOWA_ARTYKULOW_ZAM_V> AnalizaIlosciowaList
        {
            get { return analizaIlosciowaList; }
            set { analizaIlosciowaList = value; OnPropertyChanged(); }
        }


        #endregion

        public VMMagAnalizaStanow()
        {
            if (MainWindow.DTier == null) return;

            AnalizaIlosciowaList = new ObservableCollection<ANALIZA_ILOSCIOWA_ARTYKULOW_ZAM_V>(MainWindow.DTier.GetStanyMagazynowe());
        }
    }
}
