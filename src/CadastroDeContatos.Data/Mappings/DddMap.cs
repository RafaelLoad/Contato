using CadastroDeContatos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroDeContatos.Data.Mappings
{
    public class DddMap : IEntityTypeConfiguration<Ddd>
    {
        public void Configure(EntityTypeBuilder<Ddd> builder)
        {
            builder.ToTable("Ddd");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id")
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(x => x.ContatoId)
                .HasColumnName("contato_id");

            builder.Property(x => x.Regiao)
                .HasColumnName("regiao");

            builder.HasOne(x => x.Contato)
                .WithOne();

            builder.HasOne(x => x.Contato)
                .WithOne()
                .HasForeignKey<Ddd>(x => x.ContatoId);
        }
    }
}
