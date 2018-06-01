using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype1.Data
{
    // this class represents the FavLijst table in DogDBThree.db

    [Table("FavLijst")]
     public class FavorietLijst
    {
        [PrimaryKey, NotNull, Unique]
        public int Id { get; set; } 
    }
}
