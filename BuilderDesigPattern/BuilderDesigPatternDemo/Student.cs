using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesigPatternDemo
{
    public class Student
    {
        int rollNumber;
        int age;
        String name;
        String fatherName;
        String motherName;
        List<String> subjects;

        public Student(StudentBuilder builder)
        {
            this.rollNumber = builder.rollNumber;
            this.age = builder.age;
            this.name = builder.name;
            this.fatherName = builder.fatherName;
            this.motherName = builder.motherName;
            this.subjects = builder.subjects;
        }

        public String toString()
        {
            return "" + " roll number: " + this.rollNumber +
                    " age: " + this.age +
                    " name: " + this.name +
                    " father name: " + this.fatherName +
                    " mother name: " + this.motherName +
                    " subjects: " + subjects[0] + "," + subjects[1] + "," + subjects[2];
        }
    }
}
