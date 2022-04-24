using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrassDragonArchive.Models
{
    public class Character
    {
        /**************************************************************
        * Properties
        ***************************************************************/

        /*
         * EF Core will configure the database to generate this value.
         * 
         * Any property in your entity with a name of Id (or ID) or the entity name followed by Id (or ID) is a primary key.
         * If this property is also of the int type, the corresponding column is an identity column whose value is automatically
         * generated.
         */
        public int CharacterID { get; set; }

        [Required(ErrorMessage = "You must enter a name for this character.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must enter a class for this character.")]
        public string Class { get; set; }

        [Required(ErrorMessage = "You must enter a race for this character.")]
        public string Race { get; set; }

        // A read-only property named Slug in the format of the Name property (to lowercase). It replaces spaces with dashes.
        public string Slug =>
            Name?.Replace(' ', '-').ToLower();
    }
}
