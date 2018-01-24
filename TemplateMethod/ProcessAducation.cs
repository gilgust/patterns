using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    abstract class ProcessAducation
    {
        public abstract void Enter();

        public abstract void Study();

        public abstract void PassExams();

        public abstract void GetAttestat();

        public void Process_of_Aducation()
        {
            Enter();
            Study();
            PassExams();
            GetAttestat();
        }
    }
}
