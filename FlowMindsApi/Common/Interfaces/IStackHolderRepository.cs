using FlowMindsApi.Models;

namespace FlowMindsApi.Common.Interfaces;

public interface IStackHolderRepository
{
    Task Create(StackHolder stackHolder);
    Task Delete(StackHolder stackHolder);
    Task Update(StackHolder stackHolder);
    IQueryable<StackHolder> GetAll();
    IQueryable<StackHolder> GetById(string id);
}
