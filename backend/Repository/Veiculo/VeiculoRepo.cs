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
    public async Task<Veiculo> GetById(int id)
    {
        Veiculo? veiculos = await _context.veiculos
            .Where(v => v.id == id)
            .FirstOrDefaultAsync();
            
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

    public async Task<Veiculo> Update(int id, VeiculoUpdateDTO dto)
    {
        
        Veiculo veiculo = await this.GetById(id);

        if(veiculo == null)
        {
            return null;
        }

        veiculo.placa = dto.Placa.Trim();
        veiculo.modelo = dto.Modelo.Trim();
        veiculo.marca = dto.Marca.Trim();

        await _context.SaveChangesAsync();


        return veiculo;
    }
}