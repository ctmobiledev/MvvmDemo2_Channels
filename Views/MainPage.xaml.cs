using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using MvvmDemo2.Models;
using MvvmDemo2.ViewModels;


namespace MvvmDemo2.Views
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            InitializeComponent();

            //**********************************************************
            // Hitch View up to the data
            // Recommended: put this in the XAML instead with
            // <ContentPage.BindingContext> and an xmlns.
            //**********************************************************
            //this.BindingContext = new MainPageViewModel();

        }

    }
}
