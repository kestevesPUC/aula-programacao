using Microsoft.EntityFrameworkCore;

public class UserRepo
{

    private readonly CondominioContext _context;

    public UserRepo(CondominioContext context)
    {
        this._context = context;
    }
    public async Task<List<User>> ListAll()
    {
        List<User> users = await _context.users
        .ToListAsync();
        return users;
    }

    
    public async Task<List<User>> GetById(int id)
    {
        List<User> users = await _context.users
            .Where(v => v.id == id)
            .ToListAsync();
            
        return users;
    }
}