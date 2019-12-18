using ChatApp.Contract.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Contract.Domain;
using System.Collections.ObjectModel;
using System.ServiceModel;

namespace ChatApp.Service
{
   

   public class Program
    {
        static void Main(string[] args)
        {
            var uris = new Uri[1];
            string adr = "net.tcp://localhost:6565/MessageService";
            IMessageService messageservice = new MessageService();
            uris[0] = new Uri(adr);
            ServiceHost host = new ServiceHost(messageservice,uris);

            var binding = new NetTcpBinding(SecurityMode.None);
            host.AddServiceEndpoint(typeof(IMessageService), binding, string.Empty);
            host.Opened += HostOpened;
            host.Open();
            Console.ReadLine();
        }

        private static void HostOpened(object sender, EventArgs e)
        {
            Console.WriteLine("Host started");
        }
    }
}
