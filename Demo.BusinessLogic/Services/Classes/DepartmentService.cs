using Demo.BusinessLogic.DTOS.DepartmentDTOS;
using Demo.BusinessLogic.Factories;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Models.DepartmentModule;
using Demo.DataAccess.Repositories.Classes;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.BusinessLogic.Services.Classes
{
    public class DepartmentService(IUnitOfWork _unitOfWork) :IDepartmentService
    {
        // GET ALL ==> ID , Name ,Description , DateOfCreation [Date part Only]
        public IEnumerable<DepartmentDto> GetAllDepartments(string? DepartmentSearchName)
        {
            IEnumerable<Department> departments;
            if (!String.IsNullOrWhiteSpace(DepartmentSearchName))
            {
                departments = _unitOfWork.DepartmentRepositorie.GetAll(e => e.Name.ToLower().Contains(DepartmentSearchName.ToLower()));

            }
            else
            {
                departments = _unitOfWork.DepartmentRepositorie.GetAll();
            } 
            return departments.Select(d => d.ToDepartmentDto());

        }

        // GET BY ID
        public DepartmentDetailsDto GetDepartmentById(int id)
        {
            var department = _unitOfWork.DepartmentRepositorie.GetById(id);
            return department is null ? null : department.ToDepartmentDetailsDto();
        }

        // ADD
        public int AddDepartment(CreatedepartmentDto departmentdto)
        {
            _unitOfWork.DepartmentRepositorie.Add(departmentdto.ToEntity());
            return _unitOfWork.SaveChanges();
        }

        //UPDATE
        public int UpdateDepartment(UpdatedDepartmentDto updatedDepartmentDto)
        {
            _unitOfWork.DepartmentRepositorie.Update(updatedDepartmentDto.ToEntity());
            return _unitOfWork.SaveChanges();
        }

        //REMOVE
        public bool DeleteDepartment(int id)
        {
            var deparement = _unitOfWork.DepartmentRepositorie.GetById(id);
            if (deparement is null)
                return false;
            _unitOfWork.DepartmentRepositorie.Remove(deparement);
            return _unitOfWork.SaveChanges() > 0 ? true : false;
        }


    }
}
