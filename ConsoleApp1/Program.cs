using Alfateam.Messenger.Lib;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var insta = new InstagramMessenger(new Alfateam.Messenger.Models.Accounts.SocialNetworks.InstagramAccount());

            Console.ReadLine();
        }
    }
}
