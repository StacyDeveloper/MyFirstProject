using System;
using System.Collections.Generic;
using System.Xml.Linq;


class Program
{
    static bool CheckCorrectAnswer(int count)
    {
        if (count > 0)
        {
            return true;
        }
        else
        {
            Console.WriteLine("Некорректное значение, давайте попробуем снова");
            return false;
        }
    }
    static string[] GetElements(int count)
    {
        string[] result = new string[count];

        for (int i = 0; i < count; i++)
        {
            Console.Write("Введите значение {0}: ", i + 1);
            result[i] = Console.ReadLine();
        }
        return result;
    }



    static (string name, string lastName, int age, bool hasAPet, string[] petNickNames, string[] favcolors) GetAnketa()
    {
        (string name, string lastName, int age, bool hasAPet, string[] petNickNames, string[] favcolors) User;
        Console.WriteLine("Введите имя: ");
        User.name = Console.ReadLine();
        Console.WriteLine("Введите фамилию: ");
        User.lastName = Console.ReadLine();

        do
        {
            Console.WriteLine("Введите возраст: ");
            User.age = Convert.ToInt32(Console.ReadLine());
        } while (!CheckCorrectAnswer(User.age));
        Console.WriteLine("Есть ли у вас животные?");
        var petExist = Console.ReadLine();
        if (petExist == "Да" || petExist == "да")
        {
            User.hasAPet = true;
            int petCount;
            do
            {
                Console.WriteLine("Введите количество питомцев цифрами: ");
                petCount = Convert.ToInt32(Console.ReadLine());
            } while (!CheckCorrectAnswer(petCount));
            Console.WriteLine("Введите клички питомцев");
            User.petNickNames = GetElements(petCount);
        }
        else
        {
            User.hasAPet = false;
            User.petNickNames = null;
        }
        int colorsCount;
        do
        {
            Console.WriteLine("Введите количество любимых цветов: ");
            colorsCount = Convert.ToInt32(Console.ReadLine());
        } while (!CheckCorrectAnswer(colorsCount));
        Console.WriteLine("Введите любимые цвета");
        User.favcolors = GetElements(colorsCount);

        return User;

    }
    static void ShowTuple((string name, string lastName, int age, bool hasAPet, string[] petNickNames, string[] favcolors) User)
    {
        Console.WriteLine("Ваша анкета:");
        Console.WriteLine($"Имя: {User.name}");
        Console.WriteLine($"Фамилия: {User.lastName}");
        Console.WriteLine($"Возраст: {User.age}");
        Console.WriteLine($"Наличие питомцев: {User.hasAPet}");

        if (User.hasAPet)
        {
            Console.WriteLine("Клички питомцев:");
            foreach (var nick in User.petNickNames)
            {
                Console.WriteLine(nick);
            }
        }
        Console.WriteLine("Любимые цвета:");
        foreach (var color in User.favcolors)
        {
            Console.WriteLine(color);
        }

    }

    public static void Main(string[] args)
    {
        (string name, string lastName, int age, bool hasAPet, string[] petNickNames, string[] favcolors) User;
        User = GetAnketa();
        ShowTuple(User);
    }

}

