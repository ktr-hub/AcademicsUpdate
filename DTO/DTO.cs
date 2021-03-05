using DAL;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LogicLayer
{
    public class DTO
    {
        StudentDAL studentDAL = new StudentDAL();
        MarksDAL marksDAL = new MarksDAL();
        SubjectDAL subjectDAL = new SubjectDAL();
        SemesterDAL semesterDAL = new SemesterDAL();
        public int MarksID { get; set; }
        public int MarksScored { get; set; }
        public int SubjectID { get; set; }
        public string subjectName { get; set; }
        public int SemesterID { get; set; }
        public string SemesterDescription { get; set; }
        public int StudentID { get; set; }
        public int RollNo { get; set; }
        public string Name { get; set; }

        public List<Student> studentObjects;
        public List<Subject> subjectObjects;
        public List<Semester> semesterObjects;
        public List<Marks> marksObjects;

        public DataTable callSearch(string keyword)
        {
            return studentDAL.Select(keyword);
        }
        public DataTable callSearchMarks(string keyword)
        {
            return marksDAL.Select(keyword);
        }

        public bool ValidateString(string name)
        {
            bool isName = true;
            string pattern = "^[A-Za-z ]{3,30}$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(name))
            {
                isName = false;
            }
            return isName;
        }
        public bool ValidateMarks(int marks)
        {
            bool isValidMarks = false;
            if (marks>=0&&marks<=100)
            {
                isValidMarks = true;
            }
            return isValidMarks;
        }
        public int FindStudentId(int studentRollNo)
        {
            FillStudentObjects();
            foreach (Student studentItem in studentObjects)
            {
                if (studentItem.RollNo == studentRollNo)
                {
                    return studentItem.StudentID;
                }
            }
            return 0;
        }
        public void FillStudentObjects()
        {
            studentObjects = new List<Student>();
            DataTable _dataTable = GetStudentDatatable();
            for(int i=0;i<_dataTable.Rows.Count;i++)
            {
                Student student = new Student();
                student.StudentID = Convert.ToInt32(_dataTable.Rows[i][0]);
                student.RollNo = Convert.ToInt32(_dataTable.Rows[i][1]);
                student.Name = _dataTable.Rows[i][2].ToString();
                studentObjects.Add(student);
            }
        }
        public void FillMarksObjects()
        {
            marksObjects = new List<Marks>();
            DataTable _dataTable = GetMarksDatatable();
            for (int i = 0; i < _dataTable.Rows.Count; i++)
            {
                Marks marksObj = new Marks();
                marksObj.student.StudentID = StudentID;
                marksObj.subject.SubjectID = SubjectID;
                marksObj.semester.SemesterID = SemesterID;
                marksObj.MarksScored = MarksScored;
                marksObjects.Add(marksObj);
            }
        }
        public void FillSubjectsObjects()
        {
            subjectObjects = new List<Subject>();
            DataTable _dataTable = GetSubjectsDatatable();
            for (int i = 0; i < _dataTable.Rows.Count; i++)
            {
                Subject subject = new Subject();
                subject.SubjectID = Convert.ToInt32(_dataTable.Rows[i][0]);
                subject.SubjectName = _dataTable.Rows[i][1].ToString();
                subjectObjects.Add(subject);
            }
        }
        public void FillSemesterObjects()
        {
            semesterObjects = new List<Semester>();
            DataTable _dataTable = GetSemesterDatatable();
            for (int i = 0; i < _dataTable.Rows.Count; i++)
            {
                Semester semester = new Semester();
                semester.SemesterID = Convert.ToInt32(_dataTable.Rows[i][0]);
                semester.SemesterDescription = _dataTable.Rows[i][1].ToString();
                semesterObjects.Add(semester);
            }
        }
        public DataTable GetStudentDatatable()
        {
            DataTable dataTable = studentDAL.Select();
            return dataTable;
        }
        public DataTable GetMarksDatatable()
        {
            DataTable dataTable = marksDAL.Select();
            return dataTable;
        }
        public DataTable GetSubjectsDatatable()
        {
            DataTable dataTable = subjectDAL.Select();
            return dataTable;
        }
        public DataTable GetSemesterDatatable()
        {
            DataTable dataTable = semesterDAL.Select();
            return dataTable;
        }
        public void InsertStudent(out string _status)
        {
            bool _canInsert = ValidateString(Name);
            if (_canInsert)
            {
                Student student = new Student();
                student.Name = Name;
                student.RollNo = RollNo;
                studentDAL.Insert(student, out _status);
            }
            else
            {
                _status = "Name invalid. Should contain alphabets more than 2";
            }
        }
        public void UpdateStudent(out string _status)
        {
            bool _canInsert = ValidateString(Name);
            if (_canInsert)
            {
                Student student = new Student();
                student.Name = Name;
                student.RollNo = RollNo;
                FillStudentObjects();
                student.StudentID = FindStudentId(student.RollNo);
                if (student.StudentID != 0)
                {
                    studentDAL.Update(student, out _status);
                }
                else
                {
                    _status = "Student does not exist";
                }
            }
            else
            {
                _status = "Name invalid. Should contain alphabets more than 2";
            }
        }
        public void DeleteStudent(out string _status)
        {
            bool _canInsert = ValidateString(Name);
            if (_canInsert)
            {
                Student student = new Student();
                student.Name = Name;
                student.RollNo = RollNo;
                FillStudentObjects();
                student.StudentID = FindStudentId(student.RollNo);
                if (student.StudentID != 0)
                {
                    studentDAL.Delete(student, out _status);
                }
                else
                {
                    _status = "Student does not exist";
                }
            }
            else
            {
                _status = "Name invalid. Should contain alphabets more than 2";
            }
        }
        public void InsertMarks(out string _status)
        {
            bool _canInsert = ValidateMarks(MarksScored);
            if (_canInsert)
            {
                Marks marksObj = new Marks();
                marksObj.student.StudentID = StudentID;
                marksObj.subject.SubjectID = SubjectID;
                marksObj.semester.SemesterID = SemesterID;
                marksObj.MarksScored = MarksScored;
                marksDAL.Insert(marksObj,out _status);
            }
            else
            {
                _status = "Please enter valid marks (0-100)";
            }
        }
        public void UpdateMarks(out string _status)
        {
            bool _canInsert = ValidateMarks(MarksScored);
            if (_canInsert)
            {
                Marks marksObj = new Marks();
                marksObj.student.StudentID = StudentID;
                marksObj.subject.SubjectID = SubjectID;
                marksObj.semester.SemesterID = SemesterID;
                marksObj.MarksScored = MarksScored;
                FillMarksObjects();
                marksObj.MarksID = MarksID;
                if (marksObj.MarksID != 0)
                {
                    marksDAL.Update(marksObj, out _status);
                }
                else
                {
                    _status = "Record does not exist";
                }
            }
            else
            {
                _status = "Please enter valid marks (0-100)";
            }
        }
        public void DeleteMarks(out string _status)
        {
            bool _canInsert = ValidateMarks(MarksScored);
            if (_canInsert)
            {
                Marks marksObj = new Marks();
                marksObj.student.StudentID = StudentID;
                marksObj.subject.SubjectID = SubjectID;
                marksObj.semester.SemesterID = SemesterID;
                marksObj.MarksScored = MarksScored;
                FillMarksObjects();
                marksObj.MarksID = MarksID;
                if (marksObj.MarksID != 0)
                {
                    marksDAL.Delete(marksObj, out _status);
                }
                else
                {
                    _status = "Record does not exist";
                }
            }
            else
            {
                _status = "Please enter valid marks (0-100)";
            }
        }
    }
}
