using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BrassDragonArchive.Models
{
    public class CharacterContext : DbContext
    {
        /**************************************************************
        * Constructors
        ***************************************************************/
        public CharacterContext(DbContextOptions<CharacterContext> dbContextOptions)
            : base(dbContextOptions)
        { }

        /**************************************************************
        * Creating Database Tables
        ***************************************************************/
        public DbSet<Character> Characters { get; set; }

        // Seeding initial database data.
        protected override void OnModelCreating(ModelBuilder modelBuilder)  // Overrids the method in the base class.
        {
            modelBuilder.Entity<Character>().HasData(
                new Character
                {
                    CharacterID = 1,
                    Name = "Nicholas Oliver Charles Hofmann",
                    Class = "Dovahkiin",
                    Race = "Human"
                }
                //},
                //new Character
                //{
                //    CharacterID = 1,
                //    Name = "Noah Clark",
                //    Class = "Enter Class Here",
                //    Race = "Human"
                //},
                //new Character
                //{
                //    CharacterID = 1,
                //    Name = "Trevor Cluney",
                //    Class = "Enter Class Here",
                //    Race = "Human"
                //}
                );
        }  // End of the OnModelCreating() method.
    }  // End of the CharacterContext() class.
}
