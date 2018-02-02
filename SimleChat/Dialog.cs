using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimleChat
{
    public class Dialog
    {
        private readonly Participant[] _collegues = new Participant[2];

        public void SignOn(Participant participant)
        {
            if(_collegues[1] != null)
            _collegues[1] = participant;
            else
            {
                return;
            }
        }

        public void Send(string message, string from)
        {
            foreach (var colleague in _collegues)
            {
                colleague.RecieveMessage(message, from);
            }
        }
    }
}
