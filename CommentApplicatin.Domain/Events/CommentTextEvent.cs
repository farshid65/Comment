using CommentApplicatin.Domain.Common;
using CommentApplicatin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplicatin.Domain.Events
{
    public class CommentTextEvent:BaseEvent
    {
        public CommentTextEvent(Comment text)
        {
            Text = text;
        }
        public Comment Text { get; set; }
    }
}
