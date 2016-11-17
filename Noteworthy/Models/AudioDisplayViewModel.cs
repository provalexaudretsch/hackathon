using Noteworthy.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Noteworthy.Models
{
    public class AudioDisplayViewModel
    {
        public IList<Note> Notes { get; set; }

        public User CurrentUser { get; set; }

        public AudioDisplayViewModel(IList<Note> notes, User user)
        {
            Notes = notes;
            CurrentUser = user;
        }
    }
}