using System;

namespace ReWriteClient.Events
{
    public class MessageHubArgs : EventArgs
    {
        public string Viewer { get; set; }
        public string MethodName { get; set; }
        public string Value { get; set; }
    }
}