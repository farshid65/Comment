using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplicatin.Domain.Common
{
    public abstract class BaseEvent: INotification
    {
        public Dictionary<string, string> MetaData { get; init; } = new();
    }
}
