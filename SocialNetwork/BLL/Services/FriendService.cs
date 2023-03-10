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

            var findUserEntity = userRepository.FindByEmail(friendAddingData.FriendEmail);
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
        /// Получить список дружков пользователя по его id. Возвращает перечисление Friend
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<Friend> GetUsersFriends(int userId)
        {
            List<Friend> friends = new List<Friend>();
            // можно было и так
            //friendRepository.FindAllByUserId(userId).ToList().ForEach(act =>
            //{

            //    friends.Add(new Friend(act.id, userId, act.friend_id));
            //}
            //);
            List<FriendEntity> friendEntities = friendRepository.FindAllByUserId(userId).ToList();
            if (friendEntities.Count == 0 || friendEntities == null)
            {
                throw new ArgumentNullException();
            }
            foreach (FriendEntity friendEntity in friendEntities)
            {
                friends.Add(new Friend(friendEntity.id, friendEntity.user_id, friendEntity.friend_id));
            }

            return friends;

        }

        /// <summary>
        /// Удалить дружка
        /// </summary>
        /// <param name="friendAddingData"></param>
        /// <param name="userId"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="UserNotFoundException"></exception>
        /// <exception cref="Exception"></exception>
        public void DeleteFriend(FriendAddingData friendAddingData)
        {
            if (String.IsNullOrEmpty(friendAddingData.FriendEmail))
                throw new ArgumentNullException();
            var findUserEntity = this.userRepository.FindByEmail(friendAddingData.FriendEmail);
            if (findUserEntity is null) throw new UserNotFoundException();
            FriendEntity friendEntity = friendRepository.FindByFriendsId(findUserEntity.id, friendAddingData.UserId);
            if (this.friendRepository.Delete(friendEntity.id) == 0)
                throw new Exception();
        }

    }
}
