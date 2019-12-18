using ChatApp.Contract.Contract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Contract.Domain;

namespace ChatApp.Service
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class MessageService : IMessageService
    {
        private IMessaseServiceCallBack _callBack = null;
        public ObservableCollection<User> Users;
        public Dictionary<string, IMessaseServiceCallBack> _clients;

        public MessageService()
        {
            Users = new ObservableCollection<User>();
            _clients = new Dictionary<string, IMessaseServiceCallBack>();
        }
        public void Connect(User user)
        {
            _callBack = OperationContext.Current.GetCallbackChannel<IMessaseServiceCallBack>();
            if(_callBack != null)
            {
                _clients.Add(user.UserID, _callBack);
                Users.Add(user);
                _clients?.ToList().ForEach(c => c.Value.UserConnected(Users));
                Console.WriteLine($"{user.Name} just connected");
            }
        }

        public ObservableCollection<User> GetConnectedUsers()
        {
            return Users;
        }

        public void SendMessage(Message message)
        {
            var sendTo = _clients.First(c => c.Key==message.ToUserID).Value;
            if(sendTo != null)
            {
                sendTo.ForwardToClient(message);
            }
        }

        
    }
}
