using Microsoft.EntityFrameworkCore;
using MultiProject.ClassLibarary;

kiroPublicClass.SayQuote();

KiroPublicClassWithInternalMethod kiroin = new();

kiroin.PublicMethod();
kiroin.InternalMethod();

KiroInternaClass interclass = new();
interclass.InternalMethod();
interclass.PublicMethod();



public class AppContext : DbContext
{
    public DbSet<Product> TBProducts => Set<Product>();
}


public record Product(
    int id,
    string Name,
    string Description,
    decimal Price
    );