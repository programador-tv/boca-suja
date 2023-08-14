using Core.BocaSuja.Domain.Entities;

namespace Core.BocaSuja.Infrastructure.Repositories.Interfaces;

public interface IEntidadeOfensoraRepository
{
    public Task<EntidadeOfensora?> Select(string apelido);
    public Task Insert(EntidadeOfensora obj);
}
