using CC_Test.ViewModels;
using CC_Test.Contracts;
using System.Windows;
using System.Windows.Threading;
using System;
using Unity;
using CC_Test.Services;

namespace CC_Test
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Clase de estado.
        /// </summary>
        private TimeViewModel _timeViewModel { get; set; }

        public MainWindow()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IClockService, ClockService>();

            _timeViewModel = container.Resolve<TimeViewModel>();

            DataContext = _timeViewModel;

            InitializeComponent();
        }
        
        private void Play(object sender, RoutedEventArgs e)
        {
            _timeViewModel.Play();
        }

        private void Pause(object sender, RoutedEventArgs e)
        {
            _timeViewModel.Pause();
        }

        private void Stop(object sender, RoutedEventArgs e)
        {
            _timeViewModel.Stop();
        }
    }
}
