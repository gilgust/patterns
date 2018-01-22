namespace Abstract_Factory
{
    class Bad_Student : IStudent
    {
        Course_Work _CoursWork;

        public Bad_Student()
        {
            _CoursWork = new Course_Work();
            _CoursWork.Grade = 1;
        }

        public string GetInfo()
        {
            return "Bad Student";
        }
        public Course_Work GetCoursWork()
        {
            return _CoursWork;
        }
    }
} 