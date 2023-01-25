using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class Message
    {
        
        public int id { get; set; }
        public string content { get; set; }
        public int sender_id { get; set; }
        public int recipient_id { get; set; }
        public string recipient_email { get; set; }

        public Message(string content, string recepient_email, User user)
        {
            
            this.content = content;
            this.sender_id = user.Id;
            UserRepository userRepository = new UserRepository();
            UserEntity Recepient = userRepository.FindByEmail(recepient_email);
            this.recipient_id = Recepient.id;
            this.recipient_email = recepient_email;
        }
    }
}
