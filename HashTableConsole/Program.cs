using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HashTableLib;

namespace HashTableConsole
{
    internal class Program
    {
        static void Main()
        {
            string text = new StreamReader("WarAndWorld.txt",Encoding.UTF8).ReadToEnd();     //prestuplenie-i-nakazanie.txt      annakarenina.txt        worldandwar

            Regex regex = new Regex("[А-Яа-яA-Za-z]+");
            MatchCollection matchCollection = regex.Matches(text);
            string[] words = new string[matchCollection.Count];

            for (int i = 0; i < matchCollection.Count; i++)
            {
                words[i] = matchCollection[i].Value;
            }

            long commonTime = 0;
            long mineTime = 0;
            for (int i = 0; i < 50; i++)
            {
                mineTime += OneTryMine(words);
                commonTime += OneTryCommon(words);
            }
            double k = (double)mineTime / (double)commonTime;

            Console.WriteLine($"common: {commonTime / 50} mine: {mineTime / 50} coefficient: {k}");
            Console.ReadLine();
        }
        public static long OneTryCommon(string[] words)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            CommonDict(words);
            sw.Stop();

            long time = sw.ElapsedMilliseconds;

            return time;
        }
        public static long OneTryMine(string[] words)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            MineDict(words);
            sw.Stop();

            long time = sw.ElapsedMilliseconds;

            return time;
        }
        public static void MineDict(string[] words)
        {
            ChainHashTable<string, int> maDict = new ChainHashTable<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                if (maDict.ContainsKey(words[i]))
                {
                    maDict[words[i]]++;
                }
                else maDict.Add(words[i], 1);
            }
            var smallDict = new ChainHashTable<string, int>();
            foreach (var item in maDict)
            {
                if (item.Value > 27)
                {
                    smallDict.Add(item.Key, item.Value);
                }
            }
            foreach (var item in smallDict)
            {
                maDict.Remove(item.Key);
            }

        }
        public static void CommonDict(string[] words)
        {
            System.Collections.Generic.Dictionary<string, int> dict = new System.Collections.Generic.Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                if (dict.ContainsKey(words[i]))
                {
                    dict[words[i]]++;
                }
                else dict.Add(words[i], 1);
            }
            var smallDict = new System.Collections.Generic.Dictionary<string, int>();
            foreach (var item in dict)
            {
                if (item.Value > 27)
                {
                    smallDict.Add(item.Key, item.Value);
                }
            }
            foreach (var item in smallDict)
            {
                dict.Remove(item.Key);
            }
        }
    }
}
