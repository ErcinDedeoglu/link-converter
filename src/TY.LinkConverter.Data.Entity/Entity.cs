using System;

namespace TY.LinkConverter.Data.Entity
{
    public class Entity
    {
        public int Id { get; set; }

        public DateTime UpdateDate { get; set; }

        public DateTime CreateDate { get; set; }

        public bool Active { get; set; }

        public bool Deleted { get; set; }
    }
}