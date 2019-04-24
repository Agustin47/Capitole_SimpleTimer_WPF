using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Threading;
using CC_Test.Contracts;


namespace CC_Test.ViewModels
{
    /// <summary>
    /// Clase controladora de la vista.
    /// </summary>
    public class TimeViewModel : INotifyPropertyChanged
    {

        #region Props

        /// <summary>
        /// Servicio del reloj.
        /// </summary>
        private IClockService _clockService { get; set; }

        /// <summary>
        /// Property Time.
        /// </summary>
        private DateTime _time;

        /// <summary>
        /// OnChange.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Hilo.
        /// </summary>
        private DispatcherTimer _timer { get; set; }


        public TimeViewModel(IClockService clockService)
        {
            this.Time = "00:00:00";
            this._clockService = clockService;
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(500);
            _timer.Tick += timer_Tick;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var newTime = _clockService.StartClock(new StartClockRequest { Time = this._time }).Time;
            this.Time = newTime.ToLongTimeString();
            this._time = newTime;
        }

        #endregion


        /// <summary>
        /// Public property.
        /// </summary>
        public string Time
        {
            get { return _time.ToLongTimeString(); }
            set {
                var timeString = value.Split(':').Select( x => Int32.TryParse(x, out int n) ? n : 0 ).ToList();
                if (timeString.Count != 3) _time = new DateTime(0, 0, 0);
                else _time = new DateTime(2020, 1,1,timeString[0], timeString[1], timeString[2]);

                OnPropertyChanged("Time");
            }
        }

        public void Pause()
        {
            Time = _clockService.PauseClock(new PauseClockRequest { Time = this.Time }).Time;
            _timer.Stop();
        }

        public void Stop()
        {
            Time = _clockService.StopClock(new StopClockRequest { }).Time;
            _timer.Stop();
        }


        public void Play()
        {
            _timer.Start();
        }

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
