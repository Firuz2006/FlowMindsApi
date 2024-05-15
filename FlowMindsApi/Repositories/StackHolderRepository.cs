using FlowMindsApi.Common.Interfaces;
using FlowMindsApi.Models;

using MongoDB.Driver;

namespace FlowMindsApi.Repositories;

public class StackHolderRepository : IStackHolderRepository
{
    private readonly IMongoCollection<StackHolder> _collection;

    public StackHolderRepository(IMongoClient client)
    {
        var db = client.GetDatabase("FlowMinds");
        _collection = db.GetCollection<StackHolder>("StackHolders");
    }

    public async Task Create(StackHolder department)
    {
        await _collection.InsertOneAsync(department);
    }

    public async Task Delete(StackHolder department)
    {
        await _collection.DeleteOneAsync(department.Id);
    }

    public IQueryable<StackHolder> GetAll()
    {
        return _collection.AsQueryable();
    }

    public IQueryable<StackHolder> GetById(string id)
    {
        var result = _collection.AsQueryable().Where(department => department.Id == id);
        return result;
    }

    public async Task Update(StackHolder department)
    {
        var filter = Builders<StackHolder>.Filter.Eq(d => d.Id, department.Id);
        await _collection.ReplaceOneAsync(filter, department);
    }
}
