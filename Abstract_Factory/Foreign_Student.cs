namespace Abstract_Factory
{
    class Foreign_Student : IStudent
    {
        Course_Work _CoursWork;

        public Foreign_Student()
        {
            _CoursWork = new Course_Work();
            _CoursWork.Grade = 4;
        }

        public string GetInfo()
        {
            return "Foreign Student";
        }
        public Course_Work GetCoursWork()
        {
            return _CoursWork;
        }
    }
} 