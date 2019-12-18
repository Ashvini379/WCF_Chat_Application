using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Contract.Domain
{
    public class User
    {
        public User()
        {
            UserID = Guid.NewGuid().ToString().Split('-')[4];
        }
        public string UserID { get; set; }
        public string Name { get; set; }
        public DateTime TimeCreated { get; set; }
        public ObservableCollection<Message> UserMessages {get;set;}
    }
}
