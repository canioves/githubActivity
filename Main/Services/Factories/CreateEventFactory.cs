using Main.DTOs.Events;
using Main.Models;
using Main.Models.Concrete;

namespace Main.Services
{
    public static class CreateEventFactory
    {
        public static IEvent Create(CreateEventDTO dto)
        {
            switch (dto.Payload.RefType)
            {
                case "repository":

                    CreateRepositoryEvent repositoryEvent = new CreateRepositoryEvent
                    {
                        RepoName = dto.Repo.Name,
                        RefType = dto.Payload.RefType,
                    };
                    return repositoryEvent;

                case "branch":
                    CreateBranchEvent branchEvent = new CreateBranchEvent
                    {
                        RepoName = dto.Repo.Name,
                        Ref = dto.Payload.Ref,
                        RefType = dto.Payload.RefType,
                    };
                    return branchEvent;
                default:
                    throw new ArgumentException("Unknown type of CreateEvent");
            }
        }
    }
}
