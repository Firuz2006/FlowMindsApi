using FlowMindsApi.Models;

namespace FlowMindsApi.Common.Interfaces;

public interface IRoleRepository
{
    Task Create(Role role);
    Task Delete(Role role);
    Task Update(Role role);
    IQueryable<Role> GetAll();
    IQueryable<Role> GetById(string id);
}
