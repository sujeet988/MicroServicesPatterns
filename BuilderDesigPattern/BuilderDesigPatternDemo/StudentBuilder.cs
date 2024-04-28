using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesigPatternDemo
{
    public abstract class StudentBuilder
    {

        internal int rollNumber;
        internal int age;
        internal String name;
        internal String fatherName;
        internal String motherName;
        internal List<String> subjects;

        public StudentBuilder setRollNumber(int rollNumber)
        {
            this.rollNumber = rollNumber;
            return this;
        }

        public StudentBuilder setAge(int age)
        {
            this.age = age;
            return this;
        }

        public StudentBuilder setName(String name)
        {
            this.name = name;
            return this;
        }

        public StudentBuilder setFatherName(String fatherName)
        {
            this.fatherName = fatherName;
            return this;
        }

        public StudentBuilder setMotherName(String motherName)
        {
            this.motherName = motherName;
            return this;
        }

         public abstract StudentBuilder setSubjects();

        public Student build()
        {
            return new Student(this);
        }

    }
}
