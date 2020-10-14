using System;
using System.Collections.Generic;
using System.Text;

namespace MediaTracking.DAL.Models.Entities
{
    public class Category: IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<MediaCategory> MediaCategories { get; set; }
    }
}
