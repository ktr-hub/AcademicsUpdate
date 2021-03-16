using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    [DataContract]
    public class Marks
    {
        [DataMember]
        public virtual int MarksID { get; set; }
        [DataMember]
        public virtual Student student { get; set; }
        [DataMember]
        public virtual Subject subject { get; set; }
        [DataMember]
        public virtual Semester semester { get; set; }
        [DataMember]
        public virtual int MarksScored { get; set; }

        public Marks()
        {
            student = new Student();
            subject = new Subject();
            semester = new Semester();
        }
    }
}
