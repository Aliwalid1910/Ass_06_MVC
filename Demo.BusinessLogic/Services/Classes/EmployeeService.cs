using AutoMapper;
using Demo.BusinessLogic.DTOS.EmployeeDTOS;
using Demo.BusinessLogic.Services.Attachment_Services;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Models.EmployeeModule;
using Demo.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Demo.BusinessLogic.Services.Classes
{
    public class EmployeeService(IUnitOfWork _unitofwork , IMapper _mapper , IAttachmentService  _attachmentServoce) : IEmployeeService
    {


        public IEnumerable<EmployeeDto> GetAllEmployees(string? EmployeeSearchName, bool withTracking = false)
        {
            //    var employeeDto = _employeeRepository.GetIQueryable().Where(e => e.IsDeleted == false)
            //        .Select(e => new EmployeeDto()
            //        {
            //            Id = e.Id,
            //            Name = e.Name,
            //            Salary = e.Salary,
            //            Age = e.Age,
            //        });
            //    return employeeDto.ToList();
            IEnumerable<Employee> employees;
            if (!String.IsNullOrWhiteSpace(EmployeeSearchName))
            {
                employees = _unitofwork.EmployeeRepositorie.GetAll(e => e.Name.ToLower().Contains(EmployeeSearchName.ToLower()));
            }
            else 
            {
                employees = _unitofwork.EmployeeRepositorie.GetAll(withTracking);
            }
                
        var employeesDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            //var employeesDto = employees.Select(E => new EmployeeDto()
            //{
            //    Email = E.Email,
            //    Age = E.Age,
            //    Id = E.Id,
            //    Name = E.Name,
            //    Salary = E.Salary,
            //    IsActive = E.IsActive,
            //    Gender = E.Gender.ToString(),
            //    EmployeeType = E.EmployeeType.ToString(),

                //});
                return employeesDto;

            }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _unitofwork.EmployeeRepositorie.GetById(id);
            return employee is null ? null : _mapper.Map<Employee,EmployeeDetailsDto>(employee);
            //{
            //    Email = employee.Email,
            //    Age = employee.Age,
            //    Id = employee.Id,
            //    Name = employee.Name,
            //    Address = employee.Address,
            //    PhoneNumber = employee.PhoneNumber,
            //    IsActive = employee.IsActive,
            //    Salary = employee.Salary,
            //    HiringDate = DateOnly.FromDateTime(employee.HiringDate),
            //    CreatedOn = employee.CreatedOn,
            //    ModifiedOn = employee.ModifiedOn,
            //    ModifiedBy = 1,
            //    CreatedBy = 1,
            //    EmployeeType = employee.EmployeeType.ToString(),
            //    Gender = employee.Gender.ToString()
            //};
            
        }

        public int CreateEmployee(CreateEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<CreateEmployeeDto, Employee>(employeeDto);
           _unitofwork.EmployeeRepositorie.Add(employee);
            return _unitofwork.SaveChanges();
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _unitofwork.EmployeeRepositorie.GetById(id);
            if (employee is null) return false;
            else
                employee.IsDeleted = true;
               _unitofwork.EmployeeRepositorie.Update(employee);
            return _unitofwork.SaveChanges() > 0 ? true : false;

         }


        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
           _unitofwork.EmployeeRepositorie.Update(_mapper.Map<UpdatedEmployeeDto, Employee>(employeeDto));
            return _unitofwork.SaveChanges();
        }
    }
}
