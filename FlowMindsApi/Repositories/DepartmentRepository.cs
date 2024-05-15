using FlowMindsApi.Common.Interfaces;
using FlowMindsApi.Models;

using MongoDB.Driver;

namespace FlowMindsApi.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly IMongoCollection<Department> _collection;

    public DepartmentRepository(IMongoClient client)
    {
        var db = client.GetDatabase("FlowMinds");
        _collection = db.GetCollection<Department>("Departments");
    }

    public async Task Create(Department department)
    {
        await _collection.InsertOneAsync(department);
    }

    public async Task Delete(Department department)
    {
        await _collection.DeleteOneAsync(department.Id);
    }

    public IQueryable<Department> GetAll()
    {
        return _collection.AsQueryable();
    }

    public IQueryable<Department> GetById(string id)
    {
        var result = _collection.AsQueryable().Where(department => department.Id == id);
        return result;
    }

    public async Task Update(Department department)
    {
        var filter = Builders<Department>.Filter.Eq(d => d.Id, department.Id);
        await _collection.ReplaceOneAsync(filter, department);
    }
}