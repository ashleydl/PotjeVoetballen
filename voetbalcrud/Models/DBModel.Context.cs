﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace voetbalcrud.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PotjeVoetballenDBEntities : DbContext
    {
        public PotjeVoetballenDBEntities()
            : base("name=PotjeVoetballenDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayerPositionStrength> PlayerPositionStrengths { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Setup> Setups { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TeamPlayer> TeamPlayers { get; set; }
        public virtual DbSet<TeamPartition> TeamPartitions { get; set; }
    }
}
