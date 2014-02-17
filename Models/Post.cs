using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CrypticMeaning_KO.Models
{
    public class Post
    {
        public int PostId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("Thread")]
        public int ThreadId { get; set; }
        public virtual Thread Thread { get; set; }
    }
}