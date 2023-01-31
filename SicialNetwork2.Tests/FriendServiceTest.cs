using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SocialNetwork.BLL;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL;
using SocialNetwork.DAL.Repositories;

namespace SicialNetwork2.Tests
{
    [TestFixture]
    public class FriendServiceTest
    {
        UserRepository? UserRepository;
        FriendService? FriendService;
        FriendRepository? FriendRepository;

        [Test]
        public void DeleteFriendMustDeleteFriend()
        {
            UserRepository = new UserRepository();
            FriendService = new FriendService();
            FriendRepository = new FriendRepository();

            var friendEmail = "grinyov29@mail.ru";
            var UserId = 4;
            FriendService = new FriendService();
            FriendRepository = new FriendRepository();
            UserRepository = new UserRepository();

            // вставляем данные в модель
            FriendAddingData friendAddingData = new FriendAddingData();
            friendAddingData.FriendEmail = friendEmail;
            friendAddingData.UserId = UserId;

            //добавляем дружка
            FriendService.AddFriendByEmail(friendAddingData);

            // Пытаемся удалить друга и проверяем, что не бросает исключения(друг был)
            //FriendService.DeleteFriend(friendAddingData);

            //  если у заданного пользователя больше нет такого друга с таким email.
            //Assert.Throws(() => FriendService.DeleteFriend(friendAddingData));
            Assert.DoesNotThrow(() => FriendService.DeleteFriend(friendAddingData));
        }


    }
}
