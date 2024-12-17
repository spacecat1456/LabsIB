using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Шифр_Цезаря
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] alphavit = { "а", "б", "в", "г", "д", "е", "ё", "ж", 
                                "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", 
                                "у", "ф", "х", "ц", "ч", "ш", "щ", "Ъ", "ы", "ь", "э", "ю", "я" };

            Console.Write("Введите текст для шифрования: ");
            string text = Console.ReadLine().Trim();
            Console.WriteLine();
            Console.WriteLine("Сдвиг a*x + b: ");
            Console.Write("Введите а: ");
            int textA = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите b: ");
            int textB = Convert.ToInt32(Console.ReadLine());

            int sdvig = 0;

            Console.WriteLine();

            string[] words = text.Split(' ');

            string shifr = "";

            for (int i = 0; i < words.Length; i++)
            {
                char[] alphabitum1 = words[i].ToArray();

                for (int g = 0; g < alphabitum1.Length; g++)
                {
                    for (int j = 0; j < alphavit.Length; j++)
                    {
                        if (Convert.ToString(alphabitum1[g]) == alphavit[j])
                        {
                            sdvig = textA * (j + 1) + textB;

                            while (true)
                            {
                                if (j + sdvig >= alphavit.Length)
                                {
                                    sdvig -= alphavit.Length; 
                                }
                                else
                                {
                                    shifr += alphavit[j + sdvig];

                                    break;
                                }
                            }

                            j = alphavit.Length;
                        }
                    }
                }

                shifr += " ";
            }

            Console.WriteLine(shifr);

            Console.WriteLine();
        }
    }
}
