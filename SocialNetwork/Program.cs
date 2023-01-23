using SocialNetwork.BLL.Services;
using SocialNetwork.BLL.Models;

namespace SocialNetwork
{
    internal class Program
    {
        public static UserService userService = new UserService();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Добро пожаловать в соц. сеть.");
                Console.WriteLine("Для регистрации введите логин: ");
                string firstName = Console.ReadLine();
                Console.WriteLine("Фамилия: ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Пароль: ");
                string password = Console.ReadLine();
                Console.WriteLine("Почтовый адрес: ");
                string email = Console.ReadLine();
                try
                {
                    userService.Register(new UserRegistrationData()
                    {
                        FirstName = firstName,
                        Email = email,
                        LastName = lastName,
                        Password = password
                    });
                    Console.WriteLine("Регистрация прошла успешно.");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Введите корректные значения.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка при регистрации.");
                }
                Console.ReadLine();
            }
            
        }
    }
}