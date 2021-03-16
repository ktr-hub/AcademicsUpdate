using DAL;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class BusinnessLogic
    {
        StudentDAL studentDAL = new StudentDAL();
        MarksDAL marksDAL = new MarksDAL();
        SubjectDAL subjectDAL = new SubjectDAL();
        SemesterDAL semesterDAL = new SemesterDAL();
        public List<DTO> dtoObjects;
        
        public List<DTO> callSearch(string keyword)
        {
            List<Student> students = studentDAL.Select(keyword);
            List<DTO> dtoObjects = new List<DTO>();
            foreach (var student in students)
            {
                DTO dto = new DTO();
                dto.RollNo = student.RollNo;
                dto.StudentID = student.StudentID;
                dto.Name = student.Name;
                dtoObjects.Add(dto);
            }
            return dtoObjects;
        }
        public List<DTO> callSearchMarks(string keyword)
        {
            List<DTO> dtoObjects = new List<DTO>();
            List<Marks> marksList = marksDAL.Select(keyword);
            foreach (var marksItem in marksList)
            {
                DTO marksDto = new DTO();
                marksDto.StudentID = marksItem.student.StudentID;
                marksDto.RollNo = marksItem.student.RollNo;
                marksDto.Name = marksItem.student.Name;
                marksDto.SubjectID = marksItem.subject.SubjectID;
                marksDto.SubjectName = marksItem.subject.SubjectName;
                marksDto.SemesterID = marksItem.semester.SemesterID;
                marksDto.SemesterDescription = marksItem.semester.SemesterDescription;
                marksDto.MarksID = marksItem.MarksID;
                marksDto.MarksScored = marksItem.MarksScored;
                dtoObjects.Add(marksDto);
            }
            return dtoObjects;
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
            if (marks >= 0 && marks <= 100)
            {
                isValidMarks = true;
            }
            return isValidMarks;
        }
       
        public List<DTO> GetStudentDatatable()
        {
            List<Student> students = studentDAL.Select();
            List<DTO> dtoObjects = new List<DTO>();
            foreach(var student in students)
            {
                DTO dto = new DTO();
                dto.RollNo = student.RollNo;
                dto.StudentID = student.StudentID;
                dto.Name = student.Name;
                dto.NameRollNo = student.Name +" ( "+student.RollNo.ToString()+" )";
                dtoObjects.Add(dto);
            }
            return dtoObjects;
        }
        public List<DTO> GetMarksDatatable()
        {
            List<DTO> dtoObjects = new List<DTO>();
            List<Marks> marksList = marksDAL.Select();
            foreach(var marksItem in marksList)
            {
                DTO marksDto = new DTO();
                marksDto.StudentID = marksItem.student.StudentID;
                marksDto.RollNo = marksItem.student.RollNo;
                marksDto.Name = marksItem.student.Name;
                marksDto.SubjectID = marksItem.subject.SubjectID;
                marksDto.SubjectName = marksItem.subject.SubjectName;
                marksDto.SemesterID = marksItem.semester.SemesterID;
                marksDto.SemesterDescription = marksItem.semester.SemesterDescription;
                marksDto.MarksID = marksItem.MarksID;
                marksDto.MarksScored = marksItem.MarksScored;
                dtoObjects.Add(marksDto);
            }
            return dtoObjects;
        }
        public List<DTO> GetSubjectsDatatable()
        {
            List<Subject> subjects = subjectDAL.Select();
            List<DTO> dtoObjects = new List<DTO>();
            foreach (var subject in subjects)
            {
                DTO dto = new DTO();
                dto.SubjectID = subject.SubjectID;
                dto.SubjectName = subject.SubjectName;
                dtoObjects.Add(dto);
            }
            return dtoObjects;
        }
        public List<DTO> GetSemesterDatatable()
        {
            List<Semester> semesters = semesterDAL.Select();
            List<DTO> dtoObjects = new List<DTO>();
            foreach (var semester in semesters)
            {
                DTO dto = new DTO();
                dto.SemesterID = semester.SemesterID;
                dto.SemesterDescription = semester.SemesterDescription;
                dtoObjects.Add(dto);
            }
            return dtoObjects;
        }
        public void InsertStudent(DTO dto,out string _status)
        {
            bool _canInsert = ValidateString(dto.Name);
            if (_canInsert)
            {
                Student student = new Student();
                student.Name = dto.Name;
                student.RollNo = dto.RollNo;
                studentDAL.Insert(student, out _status);
            }
            else
            {
                _status = "Name invalid. Should contain alphabets more than 2";
            }
        }
        public void UpdateStudent(DTO dto,out string _status)
        {
            bool _canInsert = ValidateString(dto.Name);
            if (_canInsert)
            {
                Student student = new Student();
                student.Name = dto.Name;
                student.RollNo = dto.RollNo;
                student.StudentID = dto.StudentID;
                studentDAL.Update(student, out _status);
            }
            else
            {
                _status = "Name invalid. Should contain alphabets more than 2";
            }
        }
        public void DeleteStudent(DTO dto,out string _status)
        {
            bool _canInsert = ValidateString(dto.Name);
            if (_canInsert)
            {
                Student student = new Student();
                student.Name = dto.Name;
                student.RollNo = dto.RollNo;
                student.StudentID = dto.StudentID;
                studentDAL.Delete(student, out _status);
            }
            else
            {
                _status = "Name invalid. Should contain alphabets more than 2";
            }
        }
        public void InsertMarks(DTO dto,out string _status)
        {
            bool _canInsert = ValidateMarks(dto.MarksScored);
            if (_canInsert)
            {
                Marks marksObj = new Marks();
                marksObj.student.StudentID = dto.StudentID;
                marksObj.subject.SubjectID = dto.SubjectID;
                marksObj.semester.SemesterID = dto.SemesterID;
                marksObj.MarksScored = dto.MarksScored;
                marksDAL.Insert(marksObj, out _status);
            }
            else
            {
                _status = "Please enter valid marks (0-100)";
            }
        }
        public void UpdateMarks(DTO dto,out string _status)
        {
            bool _canInsert = ValidateMarks(dto.MarksScored);
            if (_canInsert)
            {
                Marks marksObj = new Marks();
                marksObj.student.StudentID = dto.StudentID;
                marksObj.subject.SubjectID = dto.SubjectID;
                marksObj.semester.SemesterID = dto.SemesterID;
                marksObj.MarksScored = dto.MarksScored;
                marksObj.MarksID = dto.MarksID;
                marksDAL.Update(marksObj, out _status);
            }
            else
            {
                _status = "Please enter valid marks (0-100)";
            }
        }
        public void DeleteMarks(DTO dto,out string _status)
        {
            bool _canInsert = ValidateMarks(dto.MarksScored);
            if (_canInsert)
            {
                Marks marksObj = new Marks();
                marksObj.student.StudentID = dto.StudentID;
                marksObj.subject.SubjectID = dto.SubjectID;
                marksObj.semester.SemesterID = dto.SemesterID;
                marksObj.MarksScored = dto.MarksScored;
                marksObj.MarksID = dto.MarksID;
                marksDAL.Delete(marksObj, out _status);
            }
            else
            {
                _status = "Please enter valid marks (0-100)";
            }
        }
    }
}
