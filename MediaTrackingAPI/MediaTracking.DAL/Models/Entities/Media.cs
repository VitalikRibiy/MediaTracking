using System;
using System.Collections.Generic;
using System.Text;

namespace MediaTracking.DAL.Models.Entities
{
    public class Media : IBaseEntity
    {
        public Media()
        {
            MediaCategories = new HashSet<MediaCategory>();
            MediaActors = new HashSet<MediaActor>();
            Reviews = new HashSet<Review>();
            ChildMedias = new HashSet<Media>();
        }

        public int Id { get; set; }
        public MediaType MediaType { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        public int StudioId { get; set; }
        public Studio Studio { get; set; }
        public  virtual ICollection<MediaCategory> MediaCategories { get; set; }
        public virtual ICollection<MediaActor> MediaActors { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public int? ParentMediaId { get; set; }
        public Media ParentMedia { get; set; }
        public  virtual ICollection<Media> ChildMedias { get; set; }
    }
}
