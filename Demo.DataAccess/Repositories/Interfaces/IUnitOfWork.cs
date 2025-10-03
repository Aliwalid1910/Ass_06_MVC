namespace Demo.DataAccess.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        public IEmployeeRepositorie EmployeeRepositorie { get;}
        public IDepartmentRepositorie DepartmentRepositorie { get;}

        //Save Changes
        public int SaveChanges();
    }
}
