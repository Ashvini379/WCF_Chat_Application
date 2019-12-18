using ChatApp.Contract.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Contract.Domain;
using System.Collections.ObjectModel;

namespace ChatApp.Desktop.ViewModels
{
    public class MessageCallBack : IMessaseServiceCallBack
    {
        public void ForwardToClient(Message message)
        {
            throw new NotImplementedException();
        }

        public void UserConnected(ObservableCollection<User> users)
        {
            throw new NotImplementedException();
        }
    }
}
