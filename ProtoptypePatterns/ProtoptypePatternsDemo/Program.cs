namespace ProtoptypePatternsDemo
{
    public class Student
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
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Protoptype problme demo");
            Student obj=new Student(29,70,"sujeet");

            // Creating clone of object.
            Student cloneObject=new Student();
            cloneObject.age = obj.age;
            cloneObject.name = obj.name;
            //cloneObject.rollNumber=obj.rollNumber // it will give compile time error
                     //  as it is private. for fixing this issues we using prototype pattern.
                     // and we moving clone logic even in parent class/interfacee
            Console.ReadLine();
        }
    }
}