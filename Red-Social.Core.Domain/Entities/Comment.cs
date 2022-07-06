using Red_Social.Core.Domain.Commom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Core.Domain.Entities
{
    public class Comment : AuditableBaseEntity
    {

        public string Text { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }


        //public ICollection<Comment> Comments;


    }
}
