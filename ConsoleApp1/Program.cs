﻿using Alfateam.Marketing.YandexWebmasterRestClient;
using Alfateam.Messenger.Lib;
using Alfateam.SMSGateways.Countries.Kazakhstan;

namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // var insta = new InstagramMessenger(new Alfateam.Messenger.Models.Accounts.SocialNetworks.InstagramAccount());

            try
            {
                var client = new YandexWebmasterClient();
                client.OAUTH_TOKEN = "dsfsdfdsfdsf";
                await client.User();
            }
            catch (Exception e)
            {

            }



            //try
            //{
            //    //var res = new MobizonSMSGateway("kz9f8e28245320e1e88d638c7754ecdf4bcc54bab8b81e0b7373d142c1a73c6614ed7b").GetBalance().Result;
            //    new MobizonSMSGateway("kz9f8e28245320e1e88d638c7754ecdf4bcc54bab8b81e0b7373d142c1a73c6614ed7b").Send("77057417483", "тест 123");
            //}
            //catch (Exception ex)
            //{

            //}

            //Console.ReadLine();
        }
    }
}
