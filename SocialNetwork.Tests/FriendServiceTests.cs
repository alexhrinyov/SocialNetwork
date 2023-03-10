using NUnit.Framework;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.Tests
{
    [TestFixture]
    public class FriendServiceTests
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
            FriendService.DeleteFriend(friendAddingData);

            //  если у заданного пользователя больше нет такого друга с таким email.
            Assert.Throws<ArgumentNullException>(() => FriendService.DeleteFriend(friendAddingData));
        }

        
    }
}