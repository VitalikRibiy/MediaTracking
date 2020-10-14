using System;
using System.Collections.Generic;
using System.Text;

namespace MediaTracking.DAL.Models.Entities
{
    public class MediaCategory
    {
        public int MediaId { get; set; }
        public Media Media { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
