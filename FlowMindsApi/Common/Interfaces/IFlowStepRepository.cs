using FlowMindsApi.Models;

namespace FlowMindsApi.Common.Interfaces;

public interface IFlowStepRepository
{
    Task Create(FlowStep flowStep);
    Task Delete(FlowStep flowStep);
    Task Update(FlowStep flowStep);
    IQueryable<FlowStep> GetAll();
    IQueryable<FlowStep> GetById(string id);
}
