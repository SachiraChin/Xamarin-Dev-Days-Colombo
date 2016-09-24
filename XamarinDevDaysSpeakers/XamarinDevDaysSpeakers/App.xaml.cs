using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinDevDaysSpeakers.ViewModels;
using Xamarin.Forms;
using XamarinDevDaysSpeakers.Views;

namespace XamarinDevDaysSpeakers
{
    public partial class App : Application
    {

        private static SpeakersViewModel _viewModel;

        public static SpeakersViewModel ViewModel
        {
            get { return _viewModel = (_viewModel ?? new SpeakersViewModel()); }
            set { _viewModel = value; }
        }


        public App()
        {
            InitializeComponent();

            MainPage = new Speakers();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
