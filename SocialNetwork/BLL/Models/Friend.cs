using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Friend_id { get; set; }

        public Friend(int id, int user_id, int friend_id)
        {
            this.Id = id;
            this.User_id = user_id;
            this.Friend_id = friend_id;
        }
    }
}
