using System;

namespace MasstransitExample.Autofac.Host
{
    public static class RandomWordGenerator
    {
        public static string Generate()
        {
            var rnd1 = new Random();
            var rnd2 = new Random();
         
            string[] words =
            {
                "Bold", "Think", "Friend", "Pony", "Fall", "Easy", "Difficult", "Wednesday", "Candy", "Blue", "Green", "Winter", "Chaos", "BBQ", "Trees",
                "Privacy", "Grand", "Franchise"
            };
            
            var randomString = $"{words[rnd1.Next(0, words.Length)]} {words[rnd2.Next(0, words.Length)]}";

            return randomString;

        }
    }
}