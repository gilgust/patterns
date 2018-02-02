using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimleChat
{
    public class ChatRoom
    {
        private readonly ISet<Participant> _colleagues = new HashSet<Participant>();

        public void SignOn(Participant participant)
        {
            _colleagues.Add(participant);
        }

        public void Send(string message, string from)
        {
            foreach (var colleague in _colleagues)
            {
                colleague.RecieveMessage(message, from);
            }
        }
    }
}
