using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Noteworthy.Models.Entities
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public int TopicId { get; set; }
        public virtual Topic Topic { get; set; }

        [MaxLength(60)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        public string AudioS3Path { get; set; }

        public string AudioAsText { get; set; }
    }
}