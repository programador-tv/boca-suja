using Core.BocaSuja.Domain.Entities;
using Core.BocaSuja.Infrastructure.Context;
using Core.BocaSuja.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.BocaSuja.Infrastructure.Repositories;

public class EntidadeOfensoraRepository : IEntidadeOfensoraRepository
{
    private readonly BocaSujaDbContext _db;

    public EntidadeOfensoraRepository(BocaSujaDbContext db)
    {
        _db = db;
    }

    public async Task<EntidadeOfensora?> Select(string apelido) =>
        await _db.EntidadeOfensoras.FirstOrDefaultAsync(
            x => x.Inativo == false && x.ApelidoEntidade == apelido
        );

    public async Task Insert(EntidadeOfensora obj)
    {
        try
        {
            await _db.EntidadeOfensoras.AddAsync(obj);
            await _db.SaveChangesAsync();
        }
        // TODO: Exception Handler
        catch (Exception err)
        {
            throw new Exception(err.Message);
        }
    }
}
