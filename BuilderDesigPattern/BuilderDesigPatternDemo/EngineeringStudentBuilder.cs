using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesigPatternDemo
{
    public class EngineeringStudentBuilder : StudentBuilder
    {
        public override StudentBuilder setSubjects()
        {
            List<String> subs = new List<string>();
            subs.Add("DSA");
            subs.Add("OS");
            subs.Add("Computer Architecture");
            this.subjects = subs;
            return this;
        }
    }
}
