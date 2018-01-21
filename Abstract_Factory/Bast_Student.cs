namespace Abstract_Factory
{
    class Bast_Student: IStudent
    {
        Course_Work _CoursWork;

        public Bast_Student()
        {
            _CoursWork = new Course_Work();
            _CoursWork.Grade = 5;
        }

        public string GetInfo()
        {
            return "Bast Student";
        }
        public Course_Work GetCoursWork() {
            return _CoursWork;
        }
    }
}
