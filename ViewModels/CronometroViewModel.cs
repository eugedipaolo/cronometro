using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cronometro.Helpers;
using Cronometro.Models;
using System.Windows.Input;

namespace Cronometro.ViewModels {
    public class CronometroViewModel:INotifyPropertyChanged {
      
            private readonly ICronometro _cronometro;
            private string _tiempo = string.Empty;

        public string Tiempo
        {
            get => _tiempo;

            set
            {
                _tiempo = value;
                OnPropertyChanged(nameof(Tiempo));
            }
        }

        public ICommand StartCommand { get; }
            public ICommand PauseCommand { get; }
            public ICommand StopCommand { get; }
            

        public CronometroViewModel(ICronometro cronometro) {
                _cronometro = cronometro;
                _cronometro.SecondTick += (sender, e) => Tiempo = _cronometro.GetActualTime();
                StartCommand = new RelayCommand(_ => Start());
                PauseCommand = new RelayCommand(_ => Pause());
                StopCommand  = new RelayCommand(_ => Stop());
                Tiempo = _cronometro.GetActualTime() ?? string.Empty;
        }

            private void Start() => _cronometro.Start();
            private void Pause() => _cronometro.Pause();
            private void Stop() => _cronometro.Stop();

            public event PropertyChangedEventHandler? PropertyChanged;
            protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


