using FlowMindsApi.Models;

namespace FlowMindsApi.Common.Interfaces;

public interface IDocumentRepository
{
    Task Create(Document Document);
    Task Delete(Document Document);
    Task Update(Document Document);
    IQueryable<Document> GetAll();
    IQueryable<Document> GetById(string id);
}
