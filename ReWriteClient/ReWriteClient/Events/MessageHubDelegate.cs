using System;
using System.Threading.Tasks;

namespace ReWriteClient.Events
{
    public delegate Task MessageHubDelegate(object sender, MessageHubArgs e);

    public class MessageHubEvent : EventArgs
    {

    }
}