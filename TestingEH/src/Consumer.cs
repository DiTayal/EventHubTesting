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
        private const string connectionString = "";

        private const string eventHubName = "";

        string storageconn = "";
        string blobname = "";


        public async Task consume()
        {
            MessageListener listener = new MessageListener(storageconn, blobname, connectionString, eventHubName);
            await listener.Start();
        }
    }
}
