using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        public IFriendRepository friendRepository;
        public IUserRepository userRepository;

        public FriendService()
        {
            friendRepository = new FriendRepository();
            userRepository = new UserRepository();
        }

        /// <summary>
        /// Добавить дружка
        /// </summary>
        /// <param name="friendAddingData"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="UserNotFoundException"></exception>
        /// <exception cref="Exception"></exception>
        public void AddFriendByEmail(FriendAddingData friendAddingData)
        {
            if (String.IsNullOrEmpty(friendAddingData.FriendEmail))
                throw new ArgumentNullException();

            var findUserEntity = this.userRepository.FindByEmail(friendAddingData.FriendEmail);
            if (findUserEntity is null) throw new UserNotFoundException();
            var friendEntity = new FriendEntity()
            {
                friend_id = findUserEntity.id,
                user_id = friendAddingData.UserId,
                
            };
            if (this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }

        /// <summary>
        /// Получить список дружков пользователя по его id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<Friend> GetUsersFriends(int userId)
        {
            List<Friend> friends = new List<Friend>();

            if (friendRepository.FindAllByUserId(userId).ToList() is null)
                throw new ArgumentNullException();
            friendRepository.FindAllByUserId(userId).ToList().ForEach(act =>
            {

                friends.Add(new Friend(act.id, userId, act.friend_id));
            }
            );

            return friends;

        }

    }
}
