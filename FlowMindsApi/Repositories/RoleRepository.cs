using FlowMindsApi.Common.Interfaces;
using FlowMindsApi.Models;

using MongoDB.Driver;

namespace FlowMindsApi.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly IMongoCollection<Role> _collection;

    public RoleRepository(IMongoClient client)
    {
        var db = client.GetDatabase("FlowMinds");
        _collection = db.GetCollection<Role>("Roles");
    }

    public async Task Create(Role department)
    {
        await _collection.InsertOneAsync(department);
    }

    public async Task Delete(Role department)
    {
        await _collection.DeleteOneAsync(department.Id);
    }

    public IQueryable<Role> GetAll()
    {
        return _collection.AsQueryable();
    }

    public IQueryable<Role> GetById(string id)
    {
        var result = _collection.AsQueryable().Where(department => department.Id == id);
        return result;
    }

    public async Task Update(Role department)
    {
        var filter = Builders<Role>.Filter.Eq(d => d.Id, department.Id);
        await _collection.ReplaceOneAsync(filter, department);
    }
}
