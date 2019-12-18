using ChatApp.Contract.Contract;
using ChatApp.Contract.Domain;
using ChatApp.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

namespace ChatApp.Desktop.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        private MainWindow _window;
        public Login()
        {
            InitializeComponent();
            _window = (MainWindow)Application.Current.MainWindow;
            if(_window!= null)
            {
                _window.Width = 540;
                _window.Height = 420;
                _window.MinHeight = 420;
                _window.MinWidth = 540;
                _window.MaxWidth = 540;
                _window.MaxHeight = 420;
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
           if(!string.IsNullOrEmpty(UserName.Text))
            {
                User user = new User
                {
                    TimeCreated = DateTime.UtcNow,
                    Name = UserName.Text
                };


                _window.MainView = new Main(_window, user);
                var uri = "net.tcp://localhost:6565/MessageService";
                var callack = new InstanceContext(new MessageCallBack());
                var binding = new NetTcpBinding(SecurityMode.None);
                var channel = new DuplexChannelFactory<IMessageService>(callack, binding);
                var endpoint = new EndpointAddress(uri);
                var proxy = channel.CreateChannel(endpoint);
                proxy ?.Connect(user);
                _window.Main.Children.Clear();
                _window.Main.Children.Add(_window.MainView);
            }

        }
    }
}
