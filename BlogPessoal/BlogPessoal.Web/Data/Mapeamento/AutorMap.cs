﻿using BlogPessoal.Web.Models;
using System.Data.Entity.ModelConfiguration;

namespace BlogPessoal.Web.Data.Mapeamento
{
    public class AutorMap : EntityTypeConfiguration<Autor>
    {
        public AutorMap()
        {
            ToTable("autor", "dbo");

            HasKey(x => x.Id);

            Property(x => x.Nome).IsRequired().HasMaxLength(150);
            Property(x => x.Email).IsRequired().HasMaxLength(150);
            Property(x => x.Senha).IsRequired().HasMaxLength(50);
            Property(x => x.Administrador).IsRequired();
            Property(x => x.DataDeCadastro).IsRequired().HasColumnName("data_cadastro");
        }
    }
}