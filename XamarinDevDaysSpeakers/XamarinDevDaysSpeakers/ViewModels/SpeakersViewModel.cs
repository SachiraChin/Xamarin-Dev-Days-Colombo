using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using XamarinDevDaysSpeakers.Models;

namespace XamarinDevDaysSpeakers.ViewModels
{
    public class SpeakersViewModel : INotifyPropertyChanged
    {
        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Speaker> Speakers { get; set; }

        public Command SyncSpeakersCommand { get; set; }

        public SpeakersViewModel()
        {
            Speakers = new ObservableCollection<Speaker>();

            SyncSpeakersCommand = new Command(async () => await GetSpeakers());
        }

        public async Task GetSpeakers()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            using (var client = new HttpClient())
            {
                var json = await  client.GetStringAsync("http://demo4404797.mockable.io/speakers");
                var speakers = JsonConvert.DeserializeObject<List<Speaker>>(json);

                Speakers.Clear();
                foreach (var speaker in speakers)
                {
                    Speakers.Add(speaker);
                }
            }

            IsBusy = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
