using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class FriendView
    {
        public FriendService friendService;
        public UserRepository userRepository;
        public FriendView(FriendService friendService, UserService userService)
        {
            this.friendService = friendService;
            userRepository = new UserRepository();
        }

        public void Show(User user)
        {
            
            while (true)
            {
                Console.WriteLine("Чтобы добавить пользователя в друзья, введите 1.");
                Console.WriteLine("Чтобы посмотреть список своих друзей, введите 2.");
                Console.WriteLine("Чтобы вернуться в пользовательское меню, введите 0.");
                string? key = Console.ReadLine();
                if (key == "0")
                    break;
                switch (key)
                {
                    case "1":
                        try
                        {
                            FriendAddingData friendAddingData = new FriendAddingData();
                            Console.WriteLine("Введите почтовый адрес пользователя, которого хотите добавить в друзья: ");
                            friendAddingData.FriendEmail = Console.ReadLine();
                            friendAddingData.UserId = user.Id;
                            friendService.AddFriendByEmail(friendAddingData);
                            SuccessMessage.Show("Пользователь успешно добавлен в друзья.");
                        }
                        catch (UserNotFoundException)
                        {
                            AlertMessage.Show("Такого пользователя нет в системе!");
                        }
                        catch (ArgumentNullException)
                        {
                            AlertMessage.Show("Введите корректное значение!");
                        }

                        catch (Exception)
                        {
                            AlertMessage.Show("Произошла ошибка при добавлении в друзья!");
                        }
                        break;
                    case "2":
                        try
                        {
                            List<Friend>  friends = friendService.GetUsersFriends(user.Id).ToList();
                            SuccessMessage.Show("Список ваших дружков: ");
                            foreach (Friend friend in friends)
                            {
                                
                                var friendEntity =  userRepository.FindById(friend.Id);
                                Console.WriteLine(friendEntity.firstname + " " + friendEntity.lastname);
                            }
                        }
                        catch(ArgumentNullException)
                        {
                            AlertMessage.Show("У вас нет дузей! Наверно, просто у вас нет зависимости от соц.сетей!");
                        }
                        break ;
                    
                        
                        
                }

            }


        }
    }
}
