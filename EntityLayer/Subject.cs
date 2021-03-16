using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    [DataContract]
    public class Subject
    {
        [DataMember]
        public virtual string SubjectName { get; set; }
        [DataMember]
        public virtual int SubjectID { get; set; }
    }
}
