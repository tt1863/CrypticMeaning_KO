using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace CrypticMeaning_KO.Models
{
    public class Thread
    {
        public int ThreadId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("Forum")]
        public int ForumId { get; set; }
        public virtual Forum Forum { get; set; }

        public virtual List<Post> Posts { get; set; }
    }
}