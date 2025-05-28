using Microsoft.EntityFrameworkCore;
using ApiLojaManoel.Models;
using ApiLojaManoel.models;

namespace ApiLojaManoel.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuração para Pedido
        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).ValueGeneratedOnAdd();
            
            // Relacionamento um para muitos
            entity.HasMany(p => p.Produtos)
                  .WithOne()
                  .HasForeignKey("PedidoId")
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Configuração para Produto
        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).IsRequired();
            entity.Property(p => p.Altura).IsRequired();
            entity.Property(p => p.Largura).IsRequired();
            entity.Property(p => p.Comprimento).IsRequired();
            entity.Property(p => p.Volume).IsRequired();
        });

        base.OnModelCreating(modelBuilder);
    }
}
