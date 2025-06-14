using Flunt.Notifications;
using IWantApp.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace IWantApp.Infra.Data;

public class ApplicationDbContext : DbContext
{
    // Aqui você pode definir as propriedades e métodos necessários para o contexto do banco de dados
    // Por exemplo, DbSet<Product> Products { get; set; }
    // DbSet<Category> Categories { get; set; }
    // etc.

    // Você também pode configurar o construtor para aceitar opções de configuração, como a string de conexão
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    //

    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.Ignore<Notification>();
        //Convenções Entity Framework Core
        builder.Entity<Product>().
            Property(p => p.Name).IsRequired();
        builder.Entity<Product>().
            Property(p => p.Description).HasMaxLength(255);
        builder.Entity<Category>()
            .Property(c => c.Name).IsRequired();
    }


    // Aqui você pode configurar as entidades, relacionamentos, etc.
    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        configuration.Properties<string>()
            .HaveMaxLength(100); // Exemplo de configuração de convenção para propriedades string
    }
}
