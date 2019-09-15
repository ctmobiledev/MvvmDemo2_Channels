using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Diagnostics;


//*******************************************************************************
//  The first things to do when defining a ViewModel:
//
//  1. Add ": INotifyPropertyChanged"
//  2. Mark it "public" (a public class)
//  3. Copy in a RaisePropertyChanged or OnPropertyChanged method
//  4. Add a constructor
//
//
//  And then in the associated View page (XAML file):
//
//  1. Add a reference at the root ContentPage tag similar to this:
//          xmlns:vmodel="clr-namespace:[yourProjectName].ViewModels"
//
//  2. Inside the root ContentPage tag, add a reference to 'vmodel' (or whatever
//     name you wish to use) with this:
//          <ContentPage.BindingContext>
//              <vmodel:[yourProjectName]ViewModel />
//          </ContentPage.BindingContext>
//     After you type the colon, Intellisense should present a group of view
//     model objects to choose from, or you can type it in manually.
// 
//*******************************************************************************

namespace MvvmDemo2.ViewModels
{
    public class AboutPageViewModel : INotifyPropertyChanged
    {

        //**********************************************************
        // NOTE: THIS PARTICULAR PAGE DOES NOT USE DATA, AND SO
        // DOES NOT HAVE A 'MODEL' PART OF THE MVVM TRIAD. IF THERE
        // WAS SUCH A MODEL OR DATA ENTITY, IT WOULD BE (FIRST)
        // REPRESENTED AS A PUBLIC CLASS IN THE 'VIEWS' FOLDER, AND
        // (SECOND) THERE WOULD BE EITHER AN OBSERVABLE COLLECTION
        // OR PUBLIC PROPERTY REFERRING TO SUCH AN OBJECT HERE.
        //**********************************************************

        //**********************************************************
        // Constructor
        //**********************************************************
        public AboutPageViewModel()
        {
            // Preparatory actions go here

            SetIntroMessageText();

        }

        //**********************************************************
        // Data Structures (usually collections) 
        // These are all PUBLIC PROPERTIES the Binder connects to
        //**********************************************************

        private string _IntroMessageText;
        public string IntroMessageText
        {
            get
            {
                return _IntroMessageText;
            }
            set
            {
                Debug.WriteLine(">>> IntroMessageText set fired, value is: " + value);
                _IntroMessageText = value;
                RaisePropertyChanged("IntroMessageText");

            }
        }


        //**********************************************************
        // Other Methods You Wish
        //**********************************************************

        private void SetIntroMessageText()
        {
            Debug.WriteLine(">>> SetIntroMessageText fired");

            IntroMessageText = "The text in this label is connected via the MVVM's Binder (a mysterious " +
                "element that exists in the background with all of this). If you open the AboutPageViewModel " +
                "code, you'll see a public property of type 'string' and lower in the code, an assignment " +
                "statement with this text in it. In the XAML file, there will be a '{Binding}' reference, " +
                "complete with curly braces, that points to a public property string.\n\n" +
                "Were this a data page with, perhaps, a ListView to display multiple rows in a table, " +
                "the ListView's ItemsSource would point to an ObservableCollection public property that contains " + 
                "a series of data rows or objects.\n\n" +
                "The BindingContext - the 'universe' from which the Binder searches for references to any " +
                "private properties - is set to the ViewModel. It can be done in the XAML file, or it can " +
                "also be done in the constructor for the ContentPage.\n\n" +
                "Purists will note that this is not a 100% 'pure' MVVM implementation - the buttons for " +
                "the About button and the Message button simply call the Application.Current object " +
                "to either pull up a DisplayAlert, or run a call to PushAsync (which requires the root " +
                "ContentPage to be a NavigationPage, set in the App.xaml.cs file - check elsewhere for the code). " +
                "But pragamatists may find this approach sufficient and much quicker than trying to wire up " +
                "a separate INavigation interface.";

        }


        //**********************************************************
        // Supporting MVVM Methods
        //**********************************************************
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            Debug.WriteLine(">>> AboutPageViewModel - RaisePropertyChanged fired - propertyName = " + propertyName);

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
