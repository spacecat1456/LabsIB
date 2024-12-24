using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Квадрат_Виженера
{
    internal class Program
    {
        static string[] alphavit = { "а", "б", "в", "г", "д", "е", "ё", "ж",
                                "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т",
                                "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" };

        /*static string[] alphavit = { "a", "b", "c", "d", "e", "f", "g", "h",
                            "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t",
                            "u", "v", "w", "x", "y", "z"};*/

        static string[,] TableCreating()
        {
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

            return table;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите цифру:");
                Console.WriteLine("1 - шифрование по квадрату Виженера");
                Console.WriteLine("2 - дешифратор квадрата Виженера");
                Console.WriteLine("3 - функция взлома");

                Console.WriteLine("");
                int d = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");

                switch (d)
                {
                    case 1:
                        Console.Write("Введите текст для шифрования: ");
                        string zWord = Console.ReadLine();
                        zWord = zWord.Trim().ToLower();
                        Console.WriteLine("");
                        Console.Write("Введите шифр: ");
                        string key = Console.ReadLine();
                        key = key.Trim().ToLower(); ;

                        string[,] table = TableCreating();

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
                        Console.WriteLine("");
                        break;
                    case 2:
                        Console.Write("Введите текст для дешифрования: ");
                        string zWord1 = Console.ReadLine();
                        zWord1 = zWord1.Trim().ToLower();
                        Console.WriteLine("");
                        Console.Write("Введите шифр: ");
                        string key1 = Console.ReadLine();
                        key1 = key1.Trim().ToLower(); ;

                        string[,] table1 = TableCreating();

                        string[] zWords1 = zWord1.Split(' ');

                        string sentence1 = "";
                        string world1 = "";

                        for (int i = 0; i < zWords1.Length; i++)
                        {
                            sentence1 += zWords1[i];
                        }

                        string keys1 = "";
                        int[] keysI1 = new int[sentence1.Length];
                        int[] zWordI1 = new int[sentence1.Length];

                        for (int i = 0; i < sentence1.Length / key1.Length + 1; i++)
                        {
                            for (int j = 0; j < key1.Length; j++)
                            {
                                if (sentence1.Length == keys1.Length) break;
                                keys1 += key1[j] + "";
                            }
                        }
                     
                        for (int i = 0; i < keys1.Length; i++)
                        {
                            for (int j = 0; j < table1.GetLength(0); j++)
                            {
                                if (table1[0, j] == Convert.ToString(keys1[i]))
                                {
                                    bool endl = false;

                                    for (int g = 0; g < table1.GetLength(1); g++)
                                    {
                                        if (table1[g, j] == Convert.ToString(sentence1[i]))
                                        {
                                            world1 += table1[g, 0] + "";

                                            endl = true;

                                            break;
                                        }
                                    }

                                    if (endl) break;
                                }
                            }
                            
                        }

                        string end1 = "";

                        int h1 = 0;

                        for (int i = 0; i < zWords1.Length; i++)
                        {
                            for (int j = 0; j < zWords1[i].Length; j++)
                            {
                                end1 += world1[j + h1];
                            }

                            h1 += zWords1[i].Length;

                            end1 += " ";
                        }

                        Console.WriteLine("");
                        Console.WriteLine(end1);
                        Console.WriteLine("");
                        break;
                    case 3:
                        Console.Write("Введите текст для взлома: ");
                        string zWord2 = Console.ReadLine();
                        zWord2 = zWord2.Trim().ToLower();

                        string[] zWords2 = zWord2.Split(' ');

                        string sentence2 = "";

                        for (int i = 0; i < zWords2.Length; i++)
                        {
                            sentence2 += zWords2[i];
                        }

                        double[] indexSovpadenii = new double[20];

                        for (int i = 0; i < indexSovpadenii.Length; i++)
                        {
                            if (i >= sentence2.Length) break;

                            double[] indexes = new double[i + 1];

                            for (int p = 0; p < (i + 1); p++)
                            {
                                for (int j = 0; j < alphavit.Length; j++)
                                {
                                    double sov = 0;
                                    int count = 0;

                                    for (int g = p; g < sentence2.Length; g += (i + 1))
                                    {
                                        if (alphavit[j] == Convert.ToString(sentence2[g]))
                                        {
                                            sov++;
                                        }

                                        count++;
                                    }

                                    indexes[p] += (sov * (sov - 1)) / (count * (count - 1));
                                }
                            }

                            double index = 0;

                            for (int j = 0; j < indexes.Length; j++)
                            {
                                index += indexes[j];
                            }

                            indexSovpadenii[i] = index / indexes.Length;
                        }

                        int max = 0;
                        for (int i = 0; i < indexSovpadenii.Length; i++)
                        {
                            if (indexSovpadenii[i] > 1.35 * indexSovpadenii[0])
                            {
                                max = i;
                                Console.WriteLine("");
                                Console.WriteLine("Предполагаемая длина ключа: " + (max + 1));
                                Console.WriteLine("");
                                break;
                            }
                        }

                        for (int i = 0; i < indexSovpadenii.Length; i++)
                        {
                            Console.WriteLine((i + 1) + " " + indexSovpadenii[i]);
                        }

                        StreamReader file = new StreamReader(@"RUS.txt", Encoding.Default);

                        string[,] table2 = TableCreating();

                        while (true)
                        {
                            string line = file.ReadLine();

                            if (line == null)
                            {
                                break;
                            }

                            if(line.Length == max + 1)
                            {
                                string world2 = "";

                                string key2 = line;
                                string keys2 = "";

                                for (int i = 0; i < sentence2.Length / key2.Length + 1; i++)
                                {
                                    for (int j = 0; j < key2.Length; j++)
                                    {
                                        if (sentence2.Length == keys2.Length) break;
                                        keys2 += key2[j] + "";
                                    }
                                }

                                for (int i = 0; i < keys2.Length; i++)
                                {
                                    for (int j = 0; j < table2.GetLength(0); j++)
                                    {
                                        if (table2[0, j] == Convert.ToString(keys2[i]))
                                        {
                                            bool endl = false;

                                            for (int g = 0; g < table2.GetLength(1); g++)
                                            {
                                                if (table2[g, j] == Convert.ToString(sentence2[i]))
                                                {
                                                    world2 += table2[g, 0] + "";

                                                    endl = true;

                                                    break;
                                                }
                                            }

                                            if (endl) break;
                                        }
                                    }

                                }

                                string end2 = "";
                                bool check = false;

                                int h2 = 0;

                                for (int i = 0; i < zWords2.Length; i++)
                                {
                                    string word = "";

                                    for (int j = 0; j < zWords2[i].Length; j++)
                                    {
                                        end2 += world2[j + h2];
                                        word += world2[j + h2]; 
                                    }

                                    StreamReader file1 = new StreamReader(@"RUS.txt", Encoding.Default);

                                    while (true)
                                    {
                                        check = true;

                                        string line1 = file1.ReadLine();

                                        if (line1 == null) break;

                                        if (line1 == word)
                                        {
                                            check = false;
                                            break;
                                        }
                                    }

                                    if (check) break;

                                    h2 += zWords2[i].Length;

                                    end2 += " ";
                                }

                                if (check) continue;

                                Console.WriteLine("");
                                Console.WriteLine(key2);
                                Console.WriteLine(end2);

                                break;
                            }
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
