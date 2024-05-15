using FlowMindsApi.Models;

namespace FlowMindsApi.Common.Interfaces;

public interface ICategoryRepository
{
    Task Create(Category Category);
    Task Delete(Category Category);
    Task Update(Category Category);
    IQueryable<Category> GetAll();
    IQueryable<Category> GetById(string id);
}
