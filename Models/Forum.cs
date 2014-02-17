using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace CrypticMeaning_KO.Models
{
    public class Forum
    {
        public int ForumId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Sequence { get; set; }

        public virtual List<Thread> Threads { get; set; }
    }
}