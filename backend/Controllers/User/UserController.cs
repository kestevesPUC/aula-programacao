using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    public CondominioContext _context;
    public UserRepo userRepo;
    public UserController(CondominioContext dbContext)
    {
        _context = dbContext; 
        userRepo = new UserRepo(dbContext);
    }

    [HttpGet]
    public async Task<ActionResult> ListAll()
    {
        List<User> lista = await userRepo.ListAll();

        return Ok(lista);
    }

    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        List<User> users = await userRepo.GetById(id);

        return Ok(users);
    }
}