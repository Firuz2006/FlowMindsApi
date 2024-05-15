using FlowMindsApi.Common.Interfaces;
using FlowMindsApi.Models;

using MongoDB.Driver;

namespace FlowMindsApi.Repositories;

public class DocumentRepository : IDocumentRepository
{
    private readonly IMongoCollection<Document> _collection;

    public DocumentRepository(IMongoClient client)
    {
        var db = client.GetDatabase("FlowMinds");
        _collection = db.GetCollection<Document>("Documents");
    }

    public async Task Create(Document Document)
    {
        await _collection.InsertOneAsync(Document);
    }

    public async Task Delete(Document Document)
    {
        await _collection.DeleteOneAsync(Document.Id);
    }

    public IQueryable<Document> GetAll()
    {
        return _collection.AsQueryable();
    }

    public IQueryable<Document> GetById(string id)
    {
        var result = _collection.AsQueryable().Where(Document => Document.Id == id);
        return result;
    }

    public async Task Update(Document Document)
    {
        var filter = Builders<Document>.Filter.Eq(d => d.Id, Document.Id);
        await _collection.ReplaceOneAsync(filter, Document);
    }
}
