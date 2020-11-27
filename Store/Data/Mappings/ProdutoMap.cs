using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Model;

namespace Store.Data.Mappings
{
    public class ProdutoMap: IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Descricao).HasColumnType("VARCHAR(100)").IsRequired();
        }
    }
}