using FlowMindsApi.Common.Interfaces;
using FlowMindsApi.Models;

using MongoDB.Driver;

namespace FlowMindsApi.Repositories;

public class TemplateRepository : ITemplateRepository
{
    private readonly IMongoCollection<Template> _collection;

    public TemplateRepository(IMongoClient client)
    {
        var db = client.GetDatabase("FlowMinds");
        _collection = db.GetCollection<Template>("Templates");
    }

    public async Task Create(Template department)
    {
        await _collection.InsertOneAsync(department);
    }

    public async Task Delete(Template department)
    {
        await _collection.DeleteOneAsync(department.Id);
    }

    public IQueryable<Template> GetAll()
    {
        return _collection.AsQueryable();
    }

    public IQueryable<Template> GetById(string id)
    {
        var result = _collection.AsQueryable().Where(department => department.Id == id);
        return result;
    }

    public async Task Update(Template department)
    {
        var filter = Builders<Template>.Filter.Eq(d => d.Id, department.Id);
        await _collection.ReplaceOneAsync(filter, department);
    }
}
