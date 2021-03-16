using LogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        BusinnessLogic bl = new BusinnessLogic();
        public void InsertStudent(DTO dto, out string _status)
        {
            bl.InsertStudent(dto, out _status);
        }
        public void UpdateStudent(DTO dto, out string _status)
        {
            bl.UpdateStudent(dto, out _status);
        }
        public void DeleteStudent(DTO dto, out string _status)
        {
            bl.DeleteStudent(dto, out _status);
        }
        public List<DTO> GetStudentDatatable()
        {
            return bl.GetStudentDatatable();
        }
        public List<DTO> callSearch(string searchText)
        {
            return bl.callSearch(searchText);
        }
        public void InsertMarks(DTO dto, out string _status)
        {
            bl.InsertMarks(dto, out _status);
        }
        public void UpdateMarks(DTO dto, out string _status)
        {
            bl.UpdateMarks(dto, out _status);
        }
        public void DeleteMarks(DTO dto, out string _status)
        {
            bl.DeleteMarks(dto, out _status);
        }
        public List<DTO> GetMarksDatatable()
        {
            return bl.GetMarksDatatable();
        }
        public List<DTO> callSearchMarks(string searchText)
        {
            return bl.callSearchMarks(searchText);
        }
        public List<DTO> GetSemesterDatatable()
        {
            return bl.GetSemesterDatatable();
        }
        public List<DTO> GetSubjectsDatatable()
        {
            return bl.GetSubjectsDatatable();
        }
    }
}
