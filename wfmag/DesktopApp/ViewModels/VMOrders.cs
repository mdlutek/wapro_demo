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
    public class VMOrders : INotifyPropertyChanged
    {
        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        #region Properties
        private ObservableCollection<WIDOK_ZAMOWIENIE> zamowienia;
        private ObservableCollection<WIDOK_ZAMOWIENIE> ZamowieniaTemp;
        
        private string nrZamowienia;
        
        private DateTime? dataOd = DateTime.Now;
        private DateTime? dataDo = DateTime.Now;

        private int? recordsCount;

        public ObservableCollection<WIDOK_ZAMOWIENIE> Zamowienia
        {
            get { return zamowienia; }
            set { zamowienia = value; OnPropertyChanged(); }
        }

        public string NrZamowienia
        {
            get { return nrZamowienia; }
            set 
            { 
                nrZamowienia = value;

                //if (string.IsNullOrEmpty(value))
                //{
                //    Zamowienia = ZamowieniaTemp;
                //}
                //else
                //{
                    
                //}

                OnPropertyChanged();
                FilterData();
            }
        }               

        public DateTime? DataOd
        {
            get { return dataOd; }
            set 
            { 
                dataOd = value; 
                OnPropertyChanged();
                FilterData();
            }
        }

        public DateTime? DataDo
        {
            get { return dataDo; }
            set 
            { 
                dataDo = value; 
                OnPropertyChanged();
                FilterData();
            }
        }

        public int? RecordsCount
        {
            get { return recordsCount; }
            set { recordsCount = value; OnPropertyChanged(); }
        }


        #endregion

        public VMOrders()
        {
            if (MainWindow.DTier == null) return;

            LoadOrders();

            //query.Wait();

            //Zamowienia = query.Result;
        }

        public void LoadOrders()
        {
            ZamowieniaTemp = Zamowienia = new ObservableCollection<WIDOK_ZAMOWIENIE>( MainWindow.DTier.GetOrders());

            // ustaw początkową datę na podstawie pierwszego zamówienia
            var tmp1 = Zamowienia.OrderBy(r => r.DataWystawienia).Select(r => r.DataWystawienia).FirstOrDefault();
            DataOd = tmp1;

            // ustaw końcową datę na podstawie ostatniego zamówienia 
            var tmp2 = Zamowienia.OrderByDescending(r => r.DataWystawienia).Select(r => r.DataWystawienia).FirstOrDefault();
            DataDo = tmp2;

            NrZamowienia = null;
        }

        private void FilterData()
        {
            if (!string.IsNullOrEmpty(NrZamowienia))
            {
                Zamowienia = new ObservableCollection<WIDOK_ZAMOWIENIE>(ZamowieniaTemp.Where(r => r.Numer.Contains(NrZamowienia)));
            }
            else
            {
                Zamowienia = ZamowieniaTemp;
            }

            Zamowienia = new ObservableCollection<WIDOK_ZAMOWIENIE>(Zamowienia.Where(r =>r.DataWystawienia >= DataOd && r.DataWystawienia <= DataDo).ToList());

            RecordsCount = Zamowienia.Count;
        }

    }
}
