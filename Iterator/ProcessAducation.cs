namespace Iterator
{
    abstract class ProcessAducation
    {
     public abstract void Enter();

        public string Name { get; set; }

        public ProcessAducation( string strName)
        {
            Name = strName;
        }

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
