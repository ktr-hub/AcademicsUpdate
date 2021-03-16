using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public virtual int StudentID { get; set; }
        [DataMember]
        public virtual int RollNo { get; set; }
        [DataMember]
        public virtual String Name { get; set; }
    }
}
