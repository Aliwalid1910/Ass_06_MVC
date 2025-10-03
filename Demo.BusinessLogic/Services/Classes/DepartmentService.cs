using Demo.BusinessLogic.DTOS.DepartmentDTOS;
using Demo.BusinessLogic.Factories;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Models.DepartmentModule;
using Demo.DataAccess.Repositories.Classes;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.BusinessLogic.Services.Classes
{
    public class DepartmentService(IDepartmentRepositorie _departmentRepositorie) :IDepartmentService
    {
        // GET ALL ==> ID , Name ,Description , DateOfCreation [Date part Only]
        public IEnumerable<DepartmentDto> GetAllDepartments(string? DepartmentSearchName)
        {
            IEnumerable<Department> departments;
            if (!String.IsNullOrWhiteSpace(DepartmentSearchName))
            {
                departments = _departmentRepositorie.GetAll(e => e.Name.ToLower().Contains(DepartmentSearchName.ToLower()));

            }
            else
            {
                departments = _departmentRepositorie.GetAll();
            } 
            return departments.Select(d => d.ToDepartmentDto());

        }

        // GET BY ID
        public DepartmentDetailsDto GetDepartmentById(int id)
        {
            var department = _departmentRepositorie.GetById(id);
            return department is null ? null : department.ToDepartmentDetailsDto();
        }

        // ADD
        public int AddDepartment(CreatedepartmentDto departmentdto)
        {
            return _departmentRepositorie.Add(departmentdto.ToEntity());
        }

        //UPDATE
        public int UpdateDepartment(UpdatedDepartmentDto updatedDepartmentDto)
        {
            return _departmentRepositorie.Update(updatedDepartmentDto.ToEntity());
        }

        //REMOVE
        public bool DeleteDepartment(int id)
        {
            var deparement = _departmentRepositorie.GetById(id);
            if (deparement is null)
                return false;
            int numOfRows = _departmentRepositorie.Remove(deparement);
            return numOfRows > 0 ? true : false;
        }


    }
}
