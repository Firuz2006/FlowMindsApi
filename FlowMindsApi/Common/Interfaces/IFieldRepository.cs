using FlowMindsApi.Models;

namespace FlowMindsApi.Common.Interfaces;

public interface IFieldRepository
{
    Task Create(Field field);
    Task Delete(Field field);
    Task Update(Field field);
    IQueryable<Field> GetAll();
    IQueryable<Field> GetById(string id);
}
