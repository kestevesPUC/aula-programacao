using Microsoft.EntityFrameworkCore;
public class CondominioContext : DbContext
{
    public CondominioContext(DbContextOptions<CondominioContext> options) : base(options)
    { }

    public DbSet<User> users { get; set; }
    public DbSet<Veiculo> veiculos { get; set; }
}