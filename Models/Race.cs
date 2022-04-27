using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrassDragonArchive.Models
{
    public class Race
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
        public int RaceID { get; set; }

        public string RaceName { get; set; }

        public string RacialBonus { get; set; }

        public string RacialSkills { get; set; }

        public string RacialTraits { get; set; }
    }
}
