using System;
using System.Threading.Tasks;

namespace ReWriteClient.Events
{
    public delegate Task OptionsDelegate(object sender, OptionsArgs e);

    public class OptionsEvent : EventArgs
    {

    }
}