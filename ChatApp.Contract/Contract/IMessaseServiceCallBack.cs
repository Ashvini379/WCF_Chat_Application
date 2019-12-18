using ChatApp.Contract.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Contract.Contract
{
   public interface IMessaseServiceCallBack
    {
        [OperationContract(IsOneWay = true)]
        void ForwardToClient(Message message);

        [OperationContract(IsOneWay = true)]
        void UserConnected(ObservableCollection<User> users);
    }
}
