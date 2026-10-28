
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
        List<Veiculo> veiculos = await veiculoRepo.GetById(id);

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
}