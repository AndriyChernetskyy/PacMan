using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PacWeb.Models
{
    public class CodeFirstContext : DbContext
    {
        public CodeFirstContext()
        {

        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(@"Server=DESKTOP-L3DGQ0O\SQLEXPRESS;Database=PacManPlayers;Trusted_Connection=True;");
        }

        public virtual DbSet<PlayerInfo> Players { get; set; }
    }

    public class PlayerInfo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }
}
