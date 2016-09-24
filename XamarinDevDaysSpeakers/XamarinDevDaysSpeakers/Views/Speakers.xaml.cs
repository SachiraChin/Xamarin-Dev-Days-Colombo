using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamarinDevDaysSpeakers.Views
{
    public partial class Speakers : ContentPage
    {
        public Speakers()
        {
            InitializeComponent();

            this.BindingContext = App.ViewModel;
        }
    }
}
