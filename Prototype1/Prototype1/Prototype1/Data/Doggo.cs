using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype1.Data
{
    [Table("DoggoDb")]
    public class Doggo
    {
        [NotNull, PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }

        public string Img { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Behaviour { get; set; }
        public string Care { get; set; }
    }
}
