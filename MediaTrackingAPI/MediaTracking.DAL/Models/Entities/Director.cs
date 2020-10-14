using System;
using System.Collections.Generic;
using System.Text;

namespace MediaTracking.DAL.Models.Entities
{
    public class Director : IBaseEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime Born { get; set; }
        public string Nationality { get; set; }
        public string Biography { get; set; }
        public ICollection<Media> Medias { get; set; }
    }
}
