using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Шифр_Цезаря
{
    internal class Program
    {
        public static string[] alphavit = { "а", "б", "в", "г", "д", "е", "ё", "ж",
                                            "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т",
                                            "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" };

        static string Shifr(string word, int sdvig, bool deshif = false)
        {
            string shifr = "";

            char[] alphabitum = word.ToArray();

            for (int g = 0; g < alphabitum.Length; g++)
            {
                int localSdvig = sdvig;

                for (int j = 0; j < alphavit.Length; j++)
                {
                    if (Convert.ToString(alphabitum[g]).ToLower() == alphavit[j])
                    {
                        while (true)
                        {
                            if (!deshif)
                            {
                                if (j + localSdvig >= alphavit.Length)
                                {
                                    localSdvig -= alphavit.Length;
                                }
                                else
                                {
                                    shifr += alphavit[j + localSdvig];

                                    break;
                                }
                            }
                            else
                            {
                                if (j - localSdvig <= 0)
                                {
                                    localSdvig += alphavit.Length;
                                }
                                else
                                {
                                    shifr += alphavit[j - localSdvig];

                                    break;
                                }
                            }
                        }

                        j = alphavit.Length;
                    }
                }
            }

            return shifr;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите цифру:");
                Console.WriteLine("1 - Шифр Цезаря");
                Console.WriteLine("2 - Дешифратор Шифра Цезаря");
                Console.WriteLine("3 - Функция взлома");

                Console.WriteLine();
                int d = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch(d)
                {
                    case 1:
                        Console.Write("Введите текст для шифрования: ");
                        string text = Console.ReadLine().Trim();

                        Console.WriteLine();
                        Console.Write("Сдвиг: ");
                        int textA = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine();

                        string[] words = text.Split(' ');
                        string[] result = new string[words.Length];

                        for (int i = 0; i < words.Length; i++)
                        {
                            result[i] = Shifr(words[i], textA);
                        }

                        for (int i = 0; i < result.Length; i++)
                            Console.Write(result[i] + " ");

                        Console.WriteLine("");
                        Console.WriteLine("");
                        break;
                    case 2:
                        Console.Write("Введите текст для дешифрования: ");
                        string text2 = Console.ReadLine().Trim();

                        Console.WriteLine();
                        Console.Write("Сдвиг: ");
                        int textA2 = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine();

                        string[] words2 = text2.Split(' ');
                        string[] result2 = new string[words2.Length];

                        for (int i = 0; i < words2.Length; i++)
                        {
                            result2[i] = Shifr(words2[i], textA2, true);
                        }

                        for (int i = 0; i < result2.Length; i++)
                            Console.Write(result2[i] + " ");

                        Console.WriteLine("");
                        Console.WriteLine("");
                        break;
                    case 3:
                        Console.Write("Введите текст для взлома: ");
                        string textDeshifr = Console.ReadLine().Trim();
                        textDeshifr = textDeshifr.ToLower();
                        Console.WriteLine();

                        string[] words1 = textDeshifr.Split(' ');
                        string[] result1 = new string[words1.Length];

                        int sdvig = 0;

                        for (int i = 0; i < alphavit.Length; i++)
                        {
                            StreamReader file = new StreamReader(@"RUS.txt", Encoding.Default);

                            string deShifr = Shifr(words1[0], i);

                            bool end = true;

                            while(end)
                            {
                                string line = file.ReadLine();

                                if (line == null)
                                {
                                    break;
                                }

                                if (line == deShifr)
                                {
                                    result1[0] = deShifr;

                                    sdvig = i;

                                    end = false;

                                    break;
                                }
                            }

                            if (!end) break;
                        }

                        if (result1[0] != null)
                        {
                            for (int i = 1; i < result1.Length; i++)
                            {
                                result1[i] = Shifr(words1[i], sdvig);
                            }

                            Console.Write("Зашифрованный текст: ");

                            for (int i = 0; i < result1.Length; i++)
                                Console.Write(result1[i] + " ");

                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("Текст не дефишруется");
                        }

                        Console.WriteLine("");
                        break;

                    default:
                        break;
                }

                
            }
        }
    }
}
