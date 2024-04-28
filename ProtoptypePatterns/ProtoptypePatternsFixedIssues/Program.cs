namespace ProtoptypePatternsFixedIssues
{
    public interface IProtoType
    {
        IProtoType Clone();
    }
    public class Student : IProtoType
    {
        public int age;
        public string name;
        private int rollNumber;

        public Student()
        {

        }
        public Student(int age, int rollNumber, string name)
        {
            this.age = age;
            this.rollNumber = rollNumber;
            this.name = name;
        }

        public IProtoType Clone()
        {
            return new Student(age, rollNumber, name);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Protoptype Patterns Fixed Issues Demo");
            // first create original object
            Student obj = new Student(29,70,"sujeet");
            Console.WriteLine("orignal Name");
            Console.WriteLine(obj.name);
            // cloned object
            Student cloned =(Student)obj.Clone();
            // print cloned data
            Console.WriteLine("Cloned Names");
            Console.WriteLine(cloned.name);

            Console.ReadLine();
        }
    }
}