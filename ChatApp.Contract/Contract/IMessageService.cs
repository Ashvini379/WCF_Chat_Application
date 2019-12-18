using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ChatApp.Contract.Domain;
using System.Collections.ObjectModel;

namespace ChatApp.Contract.Contract
{
    [ServiceContract(CallbackContract =typeof(IMessaseServiceCallBack),SessionMode =SessionMode.Required)]
   public interface IMessageService
    {

        [OperationContract(IsOneWay = true)]
        void Connect(User user);

        [OperationContract(IsOneWay = false)]
        void SendMessage(Message message);

        [OperationContract(IsOneWay = false)]
        ObservableCollection<User> GetConnectedUsers();
    }


   
}
