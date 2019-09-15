using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Diagnostics;


// Assists:
// https://docs.microsoft.com/en-us/dotnet/framework/wpf/data/how-to-implement-property-change-notification


namespace MvvmDemo2.Models
{
    public class Channel : INotifyPropertyChanged
    {

        //**********************************************************
        // Properties
        //**********************************************************
        private string _Callsign;
        public string Callsign
        {
            get
            {
                return _Callsign;
            }
            set
            {
                _Callsign = value;
                RaisePropertyChanged("Callsign");
            }
        }

        private int _ChannelNum;
        public int ChannelNum
        {
            get
            {
                return _ChannelNum;
            }
            set
            {
                _ChannelNum = value;
                RaisePropertyChanged("ChannelNum");
            }
        }

        private string _LicenseCity;
        public string LicenseCity
        {
            get
            {
                return _LicenseCity;
            }
            set
            {
                _LicenseCity = value;
                RaisePropertyChanged("LicenseCity");
            }
        }

        private int _CableSystemsCount;
        public int CableSystemsCount
        {
            get
            {
                return _CableSystemsCount;
            }
            set
            {
                _CableSystemsCount = value;
                RaisePropertyChanged("CableSystemsCount");
            }
        }


        //**********************************************************
        // Supporting MVVM Methods
        //**********************************************************
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            Debug.WriteLine(">>> Channel - RaisePropertyChanged fired - propertyName = " + propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
