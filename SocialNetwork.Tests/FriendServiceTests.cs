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
        IUserRepository UserRepository;
        FriendService FriendService;
        FriendRepository FriendRepository;
        
        [Test]
        public void DeleteFriendMustDeleteFriend(string friendEmail = "grinyov29@mail.ru", int UserId = 4)
        {
            FriendService = new FriendService();
            FriendRepository = new FriendRepository();
            UserRepository = new UserRepository();

            // вставляем данные в модель
            FriendAddingData friendAddingData = new FriendAddingData();
            friendAddingData.FriendEmail = friendEmail;
            friendAddingData.UserId = UserId;

            // Пытаемся удалить друга и проверяем, что не бросает исключения(друг был)
            FriendService.DeleteFriend(friendAddingData, UserId);
            //Assert.DoesNotThrow(() => FriendService.DeleteFriend(friendAddingData, UserId));

            //Ищем в базе пользователя с таким емэйл
            UserEntity userEntity = UserRepository.FindByEmail(friendEmail);

            // friendEntity = null, если у заданного пользователя больше нет такого друга с таким email.
            FriendEntity friendEntity = FriendRepository.FindByFriendsId(userEntity.id, UserId);
            
            
            Assert.IsTrue(friendEntity == null);
        }
    }
}