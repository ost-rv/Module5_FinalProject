using System;

namespace Module5_FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //User
            var userData = GetUserData();

            //Pets user
            string[] pets = null;
            Console.WriteLine("У вас есть питомец? (да/нет)");
            if (Console.ReadLine().ToLower() == "да")
            {
                int countPets;
                do
                {
                    Console.WriteLine("Введите количество питомцев");
                    GetNumberFromString(Console.ReadLine(), out countPets);
                }
                while (countPets <= 0);
                pets = GetDataPets(countPets);
            }

            //Colors user
            string[] favoritColors = null;
            int countColors;
            do
            {
                Console.WriteLine("Введите количество любимых цветов");
                GetNumberFromString(Console.ReadLine(), out countColors);
            }
            while (countColors <= 0);
            favoritColors = GetDataColors(countColors);

            ShowUserData(userData, pets, favoritColors);

        }

        private static (string FirstName, string LastName, int Age) GetUserData()
        {
            (string FirstName, string LastName, int Age) userData;

            Console.WriteLine("Введите имя");
            userData.FirstName = Console.ReadLine();

            Console.WriteLine("Введите фамилию");
            userData.LastName = Console.ReadLine();

            string age;
            while(true)
            {
                Console.WriteLine("Введите возраст цифрами");
                age = Console.ReadLine();

                if (GetNumberFromString(age, out userData.Age))
                {
                    if (userData.Age > 0)
                    {
                        break;
                    }
                }
            }

            return userData;
        }

        private static bool GetNumberFromString(string inputString, out int outputNumber)
        {
            if (int.TryParse(inputString, out int result))
            {
                outputNumber = result;
                if (outputNumber <= 0)
                {
                    outputNumber = 0;
                    return false;
                }
                return true;
            }
            else
            {
                outputNumber = 0;
                return false;
            }
        }

        private static string[] GetDataPets(int countPets)
        {
            string[] nicks = new string[countPets];

            for (int i = 0; i < countPets; i++)
            {
                Console.WriteLine($"Введите кличку питомца №{i+1}");
                nicks[i] = Console.ReadLine();
            }

            return nicks;
        }

        private static string[] GetDataColors(int countColors)
        {
            string[] colors = new string[countColors];

            for (int i = 0; i < countColors; i++)
            {
                Console.WriteLine($"Введите цвет №{i + 1}");
                colors[i] = Console.ReadLine();
            }

            return colors;
        }

        private static void ShowUserData((string FirstName, string LastName, int Age) user, string[] userPets, string[] userFavoritColors)
        {
            Console.WriteLine($"Пользователь {user.FirstName} {user.LastName} возростом {user.Age}");

            if (userPets != null && userPets.Length > 0)
            {
                Console.WriteLine("Владеет следующими домашними животными:");

                for (int i = 0; i < userPets.Length; i++)
                {
                    Console.WriteLine($"{i+1} {userPets[i]}");
                }
            }

            if (userFavoritColors != null && userFavoritColors.Length > 0)
            {
                Console.WriteLine("Любимые цвета пользователя:");

                for (int i = 0; i < userFavoritColors.Length; i++)
                {
                    Console.WriteLine($"{i + 1} {userFavoritColors[i]}");
                }
            }
            Console.ReadKey();
        }


    }
}
