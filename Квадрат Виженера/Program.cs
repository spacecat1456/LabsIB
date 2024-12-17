using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Квадрат_Виженера
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*string[] alphavit = { "а", "б", "в", "г", "д", "е", "ё", "ж",
                                "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т",
                                "у", "ф", "х", "ц", "ч", "ш", "щ", "Ъ", "ы", "ь", "э", "ю", "я" };*/

            string[] alphavit = { "a", "b", "c", "d", "e", "f", "g", "h",
                                "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t",
                                "u", "v", "w", "x", "y", "z"};

            Console.Write("Введите шифр: ");
            string key = Console.ReadLine();
            key = key.Trim();
            key = key.ToLower();
            Console.WriteLine("");
            Console.Write("Введите слово: ");
            string zWord = Console.ReadLine();
            zWord = zWord.Trim();
            zWord = zWord.ToLower();

            string[,] table = new string[alphavit.Length, alphavit.Length];
            int hh = 1;
            int ss = 0;

            for (int i = 0; i < alphavit.Length; i++)
            {
                hh += ss;
                for (int j = 0; j < alphavit.Length; j++)
                {
                    if (hh > alphavit.Length) hh = 1;
                    table[j, i] = alphavit[hh - 1] + "";
                    hh++;
                }
                hh = 1;
                ss++;
            }

            Console.WriteLine("");
            for (int i = 0; i < alphavit.Length; i++)
            {
                for (int j = 0; j < alphavit.Length; j++)
                {
                    Console.Write(table[i, j] + " ");
                }
                Console.WriteLine("");
            }

            string[] zWords = zWord.Split(' ');

            string sentence = "";
            string world = "";

            for (int i = 0; i < zWords.Length; i++)
            {
                sentence += zWords[i];
            }

            string keys = "";
            int[] keysI = new int[sentence.Length];
            int[] zWordI = new int[sentence.Length];

            for (int i = 0; i < sentence.Length / key.Length + 1; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (sentence.Length == keys.Length) break;
                    keys += key[j] + "";
                }
            }

            for (int i = 0; i < keys.Length; i++)
            {
                for (int j = 0; j < alphavit.Length; j++)
                {
                    if (alphavit[j] == Convert.ToString(keys[i])) keysI[i] = j;
                    if (alphavit[j] == Convert.ToString(sentence[i])) zWordI[i] = j;
                }
            }

            for (int i = 0; i < sentence.Length; i++)
            {
                world += table[zWordI[i], keysI[i]] + "";
            }

            string end = "";

            int h = 0;

            for (int i = 0; i < zWords.Length; i++)
            {
                for (int j = 0; j < zWords[i].Length; j++)
                {
                    end += world[j + h];
                }

                h += zWords[i].Length;

                end += " ";
            }

            Console.WriteLine("");
            Console.WriteLine(end);
        }
    }
}
