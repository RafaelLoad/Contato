using CadastroDeContatos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroDeContatos.Data.Mappings
{
    public class ContatoMap : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable ("Contato");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id")
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("nome");

            builder.Property(x => x.Telefone)
                .HasColumnName("telefone");

            builder.Property(x => x.Email)
                .HasColumnName("email");

            builder.Property(x => x.DDD)
                .HasColumnName("ddd");

        }
    }
}
