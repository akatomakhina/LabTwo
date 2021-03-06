﻿using GamesProjectWeb.DataAccess.Common.Models;
using System.Data.Entity.ModelConfiguration;

namespace GamesProjectWeb.DataAccess.ModelConfigurations
{
    public class ChannelDbModelConfig : EntityTypeConfiguration<DbChannel>
    {
        public ChannelDbModelConfig()
        {
            ToTable("Channels");
            HasKey(k => k.Id);
            Property(p => p.Title).IsRequired().IsUnicode().IsVariableLength();
            Property(p => p.Link).IsRequired().IsUnicode().IsVariableLength();
            Property(p => p.LinkRSS).IsRequired().IsUnicode().IsVariableLength();
            Property(p => p.LastModified).IsOptional();

            HasMany(g => g.Games);
        }
    }
}
