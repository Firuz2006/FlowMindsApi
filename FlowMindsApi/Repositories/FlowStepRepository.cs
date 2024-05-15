using FlowMindsApi.Common.Interfaces;
using FlowMindsApi.Models;

using MongoDB.Driver;

namespace FlowMindsApi.Repositories;

public class FlowStepRepository : IFlowStepRepository
{
    private readonly IMongoCollection<FlowStep> _collection;

    public FlowStepRepository(IMongoClient client)
    {
        var db = client.GetDatabase("FlowMinds");
        _collection = db.GetCollection<FlowStep>("FlowSteps");
    }

    public async Task Create(FlowStep department)
    {
        await _collection.InsertOneAsync(department);
    }

    public async Task Delete(FlowStep department)
    {
        await _collection.DeleteOneAsync(department.Id);
    }

    public IQueryable<FlowStep> GetAll()
    {
        return _collection.AsQueryable();
    }

    public IQueryable<FlowStep> GetById(string id)
    {
        var result = _collection.AsQueryable().Where(department => department.Id == id);
        return result;
    }

    public async Task Update(FlowStep department)
    {
        var filter = Builders<FlowStep>.Filter.Eq(d => d.Id, department.Id);
        await _collection.ReplaceOneAsync(filter, department);
    }
}
