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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void InsertStudent(DTO dto,out string _status);
        [OperationContract]
        void UpdateStudent(DTO dto, out string _status);
        [OperationContract]
        void DeleteStudent(DTO dto, out string _status);
        [OperationContract]
        List<DTO> GetStudentDatatable();
        [OperationContract]
        List<DTO> callSearch(string searchText);
        [OperationContract]
        void InsertMarks(DTO dto, out string _status);
        [OperationContract]
        void UpdateMarks(DTO dto, out string _status);
        [OperationContract]
        void DeleteMarks(DTO dto, out string _status);
        [OperationContract]
        List<DTO> GetMarksDatatable();
        [OperationContract]
        List<DTO> callSearchMarks(string searchText);
        [OperationContract]
        List<DTO> GetSemesterDatatable();
        [OperationContract]
        List<DTO> GetSubjectsDatatable();

    }
}
