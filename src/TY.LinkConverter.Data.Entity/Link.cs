using System.ComponentModel.DataAnnotations;

namespace TY.LinkConverter.Data.Entity
{
    public class Link : Entity
    {
        [MaxLength(1024)]
        public string Pattern { get; set; }

        [Required, MaxLength(1024)]
        public string ParameterizedLink { get; set; }
    }
}