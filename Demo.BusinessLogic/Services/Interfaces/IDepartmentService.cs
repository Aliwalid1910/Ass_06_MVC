using Demo.BusinessLogic.DTOS.DepartmentDTOS;

namespace Demo.BusinessLogic.Services.Interfaces
{
    public interface IDepartmentService
    {
        int AddDepartment(CreatedepartmentDto departmentdto);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentDto> GetAllDepartments(string? DepartmentSearchName);
        DepartmentDetailsDto GetDepartmentById(int id);
        int UpdateDepartment(UpdatedDepartmentDto updatedDepartmentDto);
    }
}