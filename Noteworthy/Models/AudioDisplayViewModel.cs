using Noteworthy.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Noteworthy.Models
{
    public class AudioDisplayViewModel
    {
        public IList<NoteDisplayViewModel> Notes { get; private set; }

        public User CurrentUser { get; private set; }

        public string RecordingTopic { get; set; }

        public AudioDisplayViewModel(IEnumerable<Note> notes, User user)
        {
            Notes = notes.Select(n => new NoteDisplayViewModel(n)).ToList();
            CurrentUser = user;
           
        }
    }
}