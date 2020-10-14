using MediaTracking.DAL.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaTracking.DAL.Models.Entities
{
    public class Review : IBaseEntity
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public string Comment { get; set; }
        public float Points { get; set; }
        public Media Media { get; set; }
    }
}
