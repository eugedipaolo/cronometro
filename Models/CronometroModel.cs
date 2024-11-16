using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Cronometro.Models {
    public interface ICronometro {
        event EventHandler SecondTick;
        void Start();
        void Pause();
        void Stop();
        string GetActualTime();
    }
    internal class CronometroModel:ICronometro {
        private DispatcherTimer _timer;
        private TimeSpan _elapsedTime;

        public event EventHandler? SecondTick;

        public CronometroModel() {
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer.Tick += (sender, args) =>  {
                _elapsedTime = _elapsedTime.Add(TimeSpan.FromSeconds(1));
                SecondTick?.Invoke(this, EventArgs.Empty);
            };
            _elapsedTime = TimeSpan.Zero;
        }

        public void Start() => _timer.Start();
        public void Pause() => _timer.Stop();
        public void Stop() {
            _timer.Stop();
            _elapsedTime = TimeSpan.Zero;
        }

        public string GetActualTime() => _elapsedTime.ToString(@"hh\:mm\:ss");
     }
  
}
