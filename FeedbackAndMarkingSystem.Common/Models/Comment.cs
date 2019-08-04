using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackAndMarkingSystem.Common.Models
{
    public class Comment
    {
        public string AssignmentCode { get; set; }
        public string Title { get; set; }
        public string CommentText { get; set; }
        public string CommentType { get; set; }
        public int CommentTypeValue1 { get; set; }
        public int CommentTypeValue2 { get; set; }

    }
}
