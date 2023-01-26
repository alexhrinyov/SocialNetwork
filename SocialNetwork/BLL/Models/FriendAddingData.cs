using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class FriendAddingData
    {
        // почта потенциального друга
        public string FriendEmail { get; set; }
        // id пользователя, вошедшего в систему
        public int UserId { get; set; }

    }
}
