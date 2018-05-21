using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype1.Data
{
    [Table("NewDoggo")]
    public class Doggo
    {
        [NotNull, PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }
        public string Img { get; set; }
        public string Name { get; set; }
        public string InfoGeneral { get; set; }
        public string InfoBehaviour { get; set; }
        public string InfoCare { get; set; }
        public string TypeOne { get; set; }
        public string TypeTwo { get; set; }
        public string Exercise { get; set; }
        public string Care { get; set; }
        public string Fur { get; set; }
        public string Color { get; set; }
        public string ChildFriendly { get; set; }
        public string Tail { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public string Karakter { get; set; }
        public string Fav { get; set; }
    }
}
