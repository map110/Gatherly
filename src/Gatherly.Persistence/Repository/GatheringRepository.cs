using Gatherly.Domain.Entities;
using Gatherly.Domain.Repositories;

namespace Gatherly.Persistence.Repository;

internal sealed class GatheringRepository : IGatheringRepository
{
    public Task<Gathering?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Gathering?> GetByIdWithCreatorAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return null;
    }

    public void Add(Gathering gathering)
    {
    }
}