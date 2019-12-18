using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChatApp.Contract.Domain;
using System.Collections.ObjectModel;
using System.Threading;

namespace ChatApp.Desktop.Views
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : UserControl
    {
        private User user;
        private MainWindow _window;
        private ObservableCollection<Message> _messages;
        private readonly SolidColorBrush[] userBackgroundd = new SolidColorBrush[4];

        public Main()
        {
            InitializeComponent();
        }
        public Main(MainWindow window, User user)
        {
            
            this._window = window;
            this.user = user;
            _window.Width = 540;
            _window.Height = 400;

            _window.Background = new SolidColorBrush();
            userBackgroundd[0] = new SolidColorBrush(Color.FromArgb(233,108,41,239));
            userBackgroundd[1] = new SolidColorBrush(Color.FromArgb(233,239,41,210));
            userBackgroundd[2] = new SolidColorBrush(Color.FromArgb(233,73,44,130));
            userBackgroundd[3] = new SolidColorBrush(Color.FromArgb(233,115,36,103));

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Timer timer = new Timer(obj=> {
                _window.MainView.Dispatcher.Invoke(() =>
                {

                });},null,TimeSpan.FromSeconds(1),TimeSpan.FromSeconds(1));
        }

        private void ListBox_OnLoaded(object sender, RoutedEventArgs e)
        {

        }

    }
}
