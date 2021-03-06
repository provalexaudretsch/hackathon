﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Noteworthy.Models.Entities
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Topic()
        {

        }
        public Topic(string name)
        {
            Name = name;
        }
    }
}