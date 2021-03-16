
using System.Runtime.Serialization;

namespace LogicLayer
{
    [DataContract]
    public class DTO
    {
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int RollNo { get; set; }
        [DataMember]
        public string NameRollNo { get; set; }
        [DataMember]
        public int SemesterID { get; set; }
        [DataMember]
        public string SemesterDescription { get; set; }
        [DataMember]
        public int SubjectID { get; set; }
        [DataMember]
        public string SubjectName { get; set; }
        [DataMember]
        public int MarksID { get; set; }
        [DataMember]
        public int MarksScored { get; set; }        
    }
}
