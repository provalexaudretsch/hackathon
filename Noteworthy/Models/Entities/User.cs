using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Noteworthy.Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.EmailAddress)]
        [MaxLength(70)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [MaxLength(70)]
        [MinLength(3)]
        [Index(IsUnique = true)]
        public string DisplayName { get; set; }
    }
}