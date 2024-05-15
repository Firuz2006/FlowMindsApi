using FlowMindsApi.Common.Interfaces;
using FlowMindsApi.Models;

using MongoDB.Driver;

namespace FlowMindsApi.Repositories;

public class FieldRepository : IFieldRepository
{
    private readonly IMongoCollection<Field> _collection;

    public FieldRepository(IMongoClient client)
    {
        var db = client.GetDatabase("FlowMinds");
        _collection = db.GetCollection<Field>("Fields");
    }

    public async Task Create(Field department)
    {
        await _collection.InsertOneAsync(department);
    }

    public async Task Delete(Field department)
    {
        await _collection.DeleteOneAsync(department.Id);
    }

    public IQueryable<Field> GetAll()
    {
        return _collection.AsQueryable();
    }

    public IQueryable<Field> GetById(string id)
    {
        var result = _collection.AsQueryable().Where(department => department.Id == id);
        return result;
    }

    public async Task Update(Field department)
    {
        var filter = Builders<Field>.Filter.Eq(d => d.Id, department.Id);
        await _collection.ReplaceOneAsync(filter, department);
    }
}
