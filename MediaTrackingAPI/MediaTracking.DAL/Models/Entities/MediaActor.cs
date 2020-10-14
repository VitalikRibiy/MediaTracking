using System;
using System.Collections.Generic;
using System.Text;

namespace MediaTracking.DAL.Models.Entities
{
    public class MediaActor
    {
        public int MediaId { get; set; }
        public Media Media { get; set; }
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
