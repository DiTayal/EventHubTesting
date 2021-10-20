using DaaSEventListener.Infra.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingEH.src
{


    class Consumer
    {
        private string connectionString;
        private string eventHubName;
        private string storageconn;
        private string blobname;

        public Consumer(string connectionString, string eventHubName, string storageconn, string blobname)
        {
            this.connectionString = connectionString;
            this.eventHubName = eventHubName;
            this.storageconn = storageconn;
            this.blobname = blobname;
        }

        public async Task consume()
        {
            MessageListener listener = new MessageListener(storageconn, blobname, connectionString, eventHubName);
            await listener.Start();
        }
    }
}
