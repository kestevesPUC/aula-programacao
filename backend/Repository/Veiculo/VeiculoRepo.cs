 using Microsoft.EntityFrameworkCore;

public class VeiculoRepo
{

    private readonly CondominioContext _context;

    public VeiculoRepo(CondominioContext context)
    {
        this._context = context;
    }
    public async Task<List<Veiculo>> ListAll()
    {
        List<Veiculo> veiculos = await _context.veiculos
        .ToListAsync();
        return veiculos;
    }
    public async Task<List<Veiculo>> GetById(int id)
    {
        List<Veiculo> veiculos = await _context.veiculos
            .Where(v => v.id == id)
            .ToListAsync();
            
        return veiculos;
    }

    public async Task<bool> Create(Veiculo veiculo)
    {
        this._context.veiculos.Add(veiculo);

        if(await _context.SaveChangesAsync() > 0)
        {
            return true;
        }

        return false;
    }
}