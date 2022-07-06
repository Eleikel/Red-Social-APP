using Red_Social.Core.Domain.Commom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Core.Domain.Entities
{
    public class Friend : AuditableBaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int FriendId { get; set; }

        public User Friendd { get; set; }
    }
}
