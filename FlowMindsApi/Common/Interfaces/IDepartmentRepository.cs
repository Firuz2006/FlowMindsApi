using FlowMindsApi.Models;

namespace FlowMindsApi.Common.Interfaces;

public interface IDepartmentRepository
{
    Task Create(Department department);
    Task Delete(Department department);
    Task Update(Department department);
    IQueryable<Department> GetAll();
    IQueryable<Department> GetById(string id);
}
