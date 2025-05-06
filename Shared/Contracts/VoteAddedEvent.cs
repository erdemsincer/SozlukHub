using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts
{
    public class VoteAddedEvent
    {
        public int EntryId { get; set; }

        public int UserId { get; set; }
        public bool IsUpvote { get; set; }
    }
}
