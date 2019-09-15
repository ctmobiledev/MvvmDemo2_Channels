using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using MvvmDemo2.Models;
using MvvmDemo2.Views;

using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using System.ComponentModel;


//*****************************************************************************************************
//
//  MVVM Demo 2: "Channels"
//
//  Author: Charles Tatum II
//
//  Summary: A simple demo of MVVM concepts. This is a database that saves a series of TV channel
//  callsigns, cities of license, and channel numbers. Note that all data are stored in memory; this
//  does not persist data to any device, but such functionality can be added.
//
//*****************************************************************************************************

// Assists:
// The Model objects AND the ViewModel should implement INotifyPropertyChanged
// https://forums.xamarin.com/discussion/99191/xamarin-forms-mvvm-in-c-propertychanged-event-handler-is-always-null-when-onpropertychanged-call


namespace MvvmDemo2.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        //**********************************************************
        // Constructor
        //**********************************************************
        public MainPageViewModel()
        {
            // get data here
            LoadData();
        }


        //**********************************************************
        // Data Structures (usually collections) 
        // These are all PUBLIC PROPERTIES the Binder connects to
        //**********************************************************
        public ObservableCollection<Channel> Channels
        {
            get;
            set;
        }

        private string _Callsign_Entered;
        public string Callsign_Entered
        {
            get
            {
                return _Callsign_Entered;
            }
            set
            {
                Debug.WriteLine(">>> Callsign_Entered set fired, value is: " + value);
                _Callsign_Entered = value;
                RaisePropertyChanged("Callsign_Entered");
                
            }
        }

        private string _LicenseCity_Entered;
        public string LicenseCity_Entered
        {
            get
            {
                return _LicenseCity_Entered;
            }
            set
            {
                Debug.WriteLine(">>> LicenseCity_Entered set fired, value is: " + value);
                _LicenseCity_Entered = value;
                RaisePropertyChanged("LicenseCity_Entered");
            }
        }

        private string _ChannelNum_Entered;
        public string ChannelNum_Entered
        {
            get
            {
                return _ChannelNum_Entered;
            }
            set
            {
                Debug.WriteLine(">>> ChannelNum_Entered set fired, value is: " + value);
                _ChannelNum_Entered = value;
                RaisePropertyChanged("ChannelNum_Entered");
            }
        }


        public Channel SelectedChannel
        {
            get;
            set;
        }


        //**********************************************************
        // Commands (containers of executable instructions)
        // => is a single-line command (cosmetic)
        // Call example: 
        //   <Button Text="Print Channels" Command="PrintChannelsCommand"/>
        //**********************************************************
        public ICommand PrintChannelsCommand => new Command(PrintChannels);

        public void PrintChannels()
        {

            Debug.WriteLine(">>> PrintChannels fired");

            foreach (Channel ch in Channels)
            {
                Debug.WriteLine(">>> Channel: " + ch.Callsign + ", count = " + ch.CableSystemsCount);
            }

            Debug.WriteLine(">>> SelectedChannel: " + SelectedChannel.Callsign + ", count = " + SelectedChannel.CableSystemsCount);

            //Debug.WriteLine(">>> NewChannelEntry: " + NewChannelEntry.CallsignEntry + ", count = " + NewChannelEntry.CableSystemsCountEntry);

        }

        public ICommand AddChannelCommand => new Command(AddChannel);
        
        private void AddChannel()
        {

            Debug.WriteLine(">>> AddChannel fired");
            Debug.WriteLine(">>> Callsign_Entered = " + Callsign_Entered);
            Debug.WriteLine(">>> LicenseCity_Entered = " + LicenseCity_Entered);
            Debug.WriteLine(">>> ChannelNum_Entered = " + ChannelNum_Entered);

            int channelNum;
            bool success = int.TryParse(ChannelNum_Entered, out channelNum);
            if (!success) { channelNum = 0; }

            Channels.Add(new Channel
            {
                Callsign = Callsign_Entered,
                LicenseCity = LicenseCity_Entered,
                ChannelNum = channelNum
            });


            // Clear new channel entry for next time - change of properties raises property change 
            // event and clears the text boxes.  Don't forget Two-Way!

            // Tactical change: these three strings used to be in NewChannelEntry but the binding
            // wasn't working - couldn't clear the entry boxes. Decided to go more simply and just
            // use straight strings. Could be a Xamarin bug, or something quirky in the Binder.

            //***************************************************************************************
            // SOLUTION: Was missing INotifyPropertyChanged - without this the Binder doesn't detect
            // changes after the initial display.
            //***************************************************************************************

            ClearEntryFields();

        }


        public ICommand DeleteChannelCommand => new Command(DeleteChannel);

        private void DeleteChannel()
        {

            Debug.WriteLine(">>> DeleteChannel fired, SelectedChannel object is:");
            Debug.WriteLine(">>> Callsign = " + SelectedChannel.Callsign);
            Debug.WriteLine(">>> LicenseCity = " + SelectedChannel.LicenseCity);
            Debug.WriteLine(">>> ChannelNum = " + SelectedChannel.ChannelNum);

            Channel dc = new Channel
            {
                Callsign = SelectedChannel.Callsign,
                LicenseCity = SelectedChannel.LicenseCity,
                ChannelNum = SelectedChannel.ChannelNum
            };

            Channels.Remove(Channels.Where(item => item.Callsign == SelectedChannel.Callsign).First());

        }


        public ICommand ClearEntryFieldsCommand => new Command(ClearEntryFields);

        private void ClearEntryFields()
        {

            Debug.WriteLine(">>> ClearEntryFieldsCommand fired");

            Callsign_Entered = string.Empty;
            LicenseCity_Entered = string.Empty;
            ChannelNum_Entered = string.Empty;

        }


        public ICommand ShowDisplayAlertCommand => new Command(ShowDisplayAlert);

        private async void ShowDisplayAlert()
        {

            Debug.WriteLine(">>> ShowDisplayAlertCommand fired");

            await Application.Current.MainPage.DisplayAlert("Alert", "A call to a DisplayAlert from the ViewModel.", "Ok");

        }


        public ICommand ShowAboutPageCommand => new Command(ShowAboutPage);

        private async void ShowAboutPage()
        {

            Debug.WriteLine(">>> ShowAboutPage fired");

            await Application.Current.MainPage.Navigation.PushAsync(new AboutPage());

        }



        //**********************************************************
        // Helper Methods - initialization, etc.
        //**********************************************************
        public void LoadData()
        {

            // Channels.Add - can't just push objects to it - here's why:
            // 
            //  1. The OC is created with the getter and setter. But it still has no 'new' action to 
            //     construct it.
            //  2. In the code example, a temporary OC is created with a 'new' constructor. 
            //
            // The temporary OC, because it had a 'new' instantiation, is not null. Hence the 
            // Channels OC won't be, either.

            ObservableCollection<Channel> RetrievedChannels = new ObservableCollection<Channel>();


            //RetrievedChannels.Add(new Channel { Callsign = "XXXX", ChannelNum = 1, LicenseCity = "Someplace", CableSystemsCount = 50 });


            // Initialize these public properties of the ViewModel

            SelectedChannel = new Channel();


            // Move the data to the "real" data source

            Channels = RetrievedChannels;


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


    }

}
