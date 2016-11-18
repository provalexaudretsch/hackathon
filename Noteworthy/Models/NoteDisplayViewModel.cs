using Noteworthy.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Noteworthy.Models
{
    public class NoteDisplayViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public int TopicId { get; set; }
        public virtual Topic Topic { get; set; }

        public string Title { get; set; }

        public string TimestampString
        {
            get; set;
        }

        public string AudioS3Path { get; set; }

        public string AudioAsText { get; set; }

        public bool IsUnread { get; set; }

        public bool IsRead { get { return !IsUnread; } }
        public NoteDisplayViewModel() { }
        public NoteDisplayViewModel(Note note)
        {
            Id = note.Id;
            UserId = note.UserId;
            User = note.User;
            Topic = note.Topic;
            TopicId = note.TopicId;
            Title = note.Title;
            TimestampString = note.TimestampString;
            AudioS3Path = note.AudioS3Path;
            AudioAsText = note.AudioAsText;
            IsUnread = note.IsUnread;
        }
    }
}