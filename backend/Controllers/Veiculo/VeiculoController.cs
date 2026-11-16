
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class VeiculoController : Controller
{
    public CondominioContext _context;
    public VeiculoRepo veiculoRepo;
    public VeiculoController(CondominioContext dbContext)
    {
        _context = dbContext;
        veiculoRepo = new VeiculoRepo(dbContext);
    }

    [HttpGet]
    public async Task<ActionResult> ListAll()
    {
        List<Veiculo> veiculos = await veiculoRepo.ListAll();


        return Ok(veiculos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        Veiculo veiculos = await veiculoRepo.GetById(id);

        if (veiculos == null)
        {
            return NotFound("O veiculo informado não existe.");
        }
        
        return Ok(veiculos);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] VeiculoRequestDTO request)
    {
        Veiculo veiculo = request.ToEntity();

        bool result = await this.veiculoRepo.Create(veiculo);


        if (result)
        {
            return Ok("Veículo cadastrado com sucesso!");
        }

        return Ok("Não foi possível cadastrar o veículo.");
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, VeiculoUpdateDTO request)
    {
        Veiculo veiculo = await this.veiculoRepo.Update(id, request);

        if (veiculo == null)
        {
            return NotFound("O veiculo informado não existe.");
        }

        return Ok(veiculo);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {

        bool result = await this.veiculoRepo.Delete(id);

        if (result)
        {

            return Ok("Veículo deletado com sucesso!");
        }


        return NotFound("O veiculo informado não existe.");
    }
}