using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Diagnostics;


// Assists:
// https://docs.microsoft.com/en-us/dotnet/framework/wpf/data/how-to-implement-property-change-notification


namespace MvvmDemo2.Models
{
    public class ChannelEntry : INotifyPropertyChanged
    {

        /*
        private ChannelEntry _NewChannelEntry;
        public ChannelEntry NewChannelEntry
        {
            get
            {
                return _NewChannelEntry;
            }
            set
            {
                _NewChannelEntry = value;
                RaisePropertyChanged("NewChannelEntry");
            }
        }
        */

        //**********************************************************
        // Properties
        //**********************************************************
        private string _CallsignEntry;
        public string CallsignEntry
        {
            get
            {
                return _CallsignEntry;
            }
            set
            {
                _CallsignEntry = value;
                RaisePropertyChanged("CallsignEntry");
            }
        }

        private int _ChannelNumEntry;
        public int ChannelNumEntry
        {
            get
            {
                return _ChannelNumEntry;
            }
            set
            {
                _ChannelNumEntry = value;
                RaisePropertyChanged("ChannelNumEntry");
            }
        }

        private string _LicenseCityEntry;
        public string LicenseCityEntry
        {
            get
            {
                return _LicenseCityEntry;
            }
            set
            {
                _LicenseCityEntry = value;
                RaisePropertyChanged("LicenseCityEntry");
            }
        }

        private int _CableSystemsCountEntry;
        public int CableSystemsCountEntry
        {
            get
            {
                return _CableSystemsCountEntry;
            }
            set
            {
                _CableSystemsCountEntry = value;
                RaisePropertyChanged("CableSystemsCountEntry");
            }
        }


        //**********************************************************
        // Supporting MVVM Methods
        //**********************************************************
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            Debug.WriteLine(">>> ChannelEntry - RaisePropertyChanged fired - propertyName = " + propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void ClearEntryFields()
        {
            Debug.WriteLine(">>> ClearEntryFields fired");
            RaisePropertyChanged("CallsignEntry");
            RaisePropertyChanged("ChannelNumEntry");
            RaisePropertyChanged("LicenseCityEntry");
        }


    }
}
