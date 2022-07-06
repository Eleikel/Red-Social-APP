using Red_Social.Core.Domain.Commom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Social.Core.Domain.Entities
{
    public class Post : AuditableBaseEntity
    {

        public string Text { get; set; }
        public string ImageUrl { get; set; }




        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Comment> Comments;


        //Ojo: Esto puede ser que no va
        public int? IdPostShared { get; set; }
        //public Post Posts { get; set; }

    }
}
