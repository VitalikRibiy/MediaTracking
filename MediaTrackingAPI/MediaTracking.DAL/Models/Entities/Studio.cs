using System;
using System.Collections.Generic;
using System.Text;

namespace MediaTracking.DAL.Models.Entities
{
    public class Studio: IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Media> Medias { get; set; }
    }
}
