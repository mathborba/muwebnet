using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MuwebNET.Models.GameContext
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(): base("GameDbConnection")
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountCharacter> AccountChars { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<AccountStat> Status { get; set; }
        public DbSet<Warehouse> Vaults { get; set; }
        public DbSet<Guild> Guilds { get; set; }
        public DbSet<GuildMember> GuildMembers { get; set; }
    }
}