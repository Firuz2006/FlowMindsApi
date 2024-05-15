using FlowMindsApi.Models;

namespace FlowMindsApi.Common.Interfaces;

public interface ITemplateRepository
{
    Task Create(Template template);
    Task Delete(Template template);
    Task Update(Template template);
    IQueryable<Template> GetAll();
    IQueryable<Template> GetById(string id);
}
