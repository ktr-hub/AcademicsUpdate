using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Marks
    {
        public int MarksID { get; set; }
        public Student student { get; set; }
        public Subject subject { get; set; }
        public Semester semester { get; set; }
        public int MarksScored { get; set; }

        public Marks()
        {
            student = new Student();
            subject = new Subject();
            semester = new Semester();
        }
    }
}
