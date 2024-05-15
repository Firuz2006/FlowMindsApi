using FlowMindsApi.Common.Interfaces;
using FlowMindsApi.Models;

using MongoDB.Driver;

namespace FlowMindsApi.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly IMongoCollection<Category> _collection;

    public CategoryRepository(IMongoClient client)
    {
        var db = client.GetDatabase("FlowMinds");
        _collection = db.GetCollection<Category>("Categories");
    }

    public async Task Create(Category Category)
    {
        await _collection.InsertOneAsync(Category);
    }

    public async Task Delete(Category Category)
    {
        await _collection.DeleteOneAsync(Category.Id);
    }

    public IQueryable<Category> GetAll()
    {
        return _collection.AsQueryable();
    }

    public IQueryable<Category> GetById(string id)
    {
        var result = _collection.AsQueryable().Where(Category => Category.Id == id);
        return result;
    }

    public async Task Update(Category Category)
    {
        var filter = Builders<Category>.Filter.Eq(d => d.Id, Category.Id);
        await _collection.ReplaceOneAsync(filter, Category);
    }
}
