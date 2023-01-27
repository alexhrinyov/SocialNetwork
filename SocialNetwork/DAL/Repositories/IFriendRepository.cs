using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories
{
    public interface IFriendRepository
    {
        int Create(FriendEntity friendEntity);
        IEnumerable<FriendEntity> FindAllByUserId(int userId);
        int Delete(int id);
        /// <summary>
        /// Поиск сущности друга по его и своему пользовательскому id
        /// </summary>
        /// <param name="friendId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public FriendEntity FindByFriendsId(int friendId, int userId);
    }
}
