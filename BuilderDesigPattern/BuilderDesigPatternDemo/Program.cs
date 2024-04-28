namespace BuilderDesigPatternDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client of Builder Design Pattern");

            Director directorObj1 = new Director(new EngineeringStudentBuilder());
            Director directorObj2 = new Director(new MBAStudentBuilder());

            Student engineerStudent = directorObj1.createStudent();
            Student mbaStudent = directorObj2.createStudent();

            Console.WriteLine(engineerStudent.toString());
            Console.WriteLine(mbaStudent.toString());

            Console.ReadLine();
        }
    }
}