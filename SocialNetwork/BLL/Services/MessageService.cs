using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.BLL.Exceptions;
using System.ComponentModel.DataAnnotations;
using SocialNetwork.DAL.Entities;
using System.Reflection.Metadata;

namespace SocialNetwork.BLL.Services
{
    public class MessageService
    {
        IMessageRepository messageRepository;
        IUserRepository userRepository;
        public MessageService()
        {
            this.messageRepository = new MessageRepository();
            this.userRepository = new UserRepository();
        }

        public void SendMessage(Message message)
        {
            if (string.IsNullOrEmpty(message.content))
                throw new ArgumentNullException();
            if (message.content.Length > 5000)
                throw new MessageLengthExceededException();
            if(!new EmailAddressAttribute().IsValid(message.recipient_email))
                throw new WrongEmailException();
            if (userRepository.FindByEmail(message.recipient_email) == null)
                throw new UserNotFoundException();
            var messageEntity = new MessageEntity()
            {
                id = message.id,
                content = message.content,
                recipient_id = message.recipient_id,
                sender_id = message.sender_id
            };
           
            if (messageRepository.Create(messageEntity) == 0)
                throw new Exception();

        }

        
    }
}
