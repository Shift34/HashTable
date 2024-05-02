using HashTableLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HashTableTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Add()
        {
            ChainHashTable<char, int> keyValuePairs = new ChainHashTable<char, int>();
            string text = "abcdef";
            for (int i = 0; i < text.Length; i++)
            {
                if (keyValuePairs.ContainsKey(text[i]))
                {
                    keyValuePairs[text[i]]++;
                }
                else keyValuePairs.Add(text[i], 1);
            }
            Assert.AreEqual(keyValuePairs.Count,text.Length);
        }
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void AddingDuplicate()
        {
            ChainHashTable<char, int> keyValuePairs = new ChainHashTable<char, int>();
            string text = "abcdef";
            for (int i = 0; i < text.Length; i++)
            {
                if (keyValuePairs.ContainsKey(text[i]))
                {
                    keyValuePairs[text[i]]++;
                }
                else keyValuePairs.Add(text[i], 1);
            }
            keyValuePairs.Add(text[0], 1);
        }
        [TestMethod]
        public void AdditionAndComparison()
        {
            ChainHashTable<char,int> keyValuePairs = new ChainHashTable<char,int>();
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            string text;
            using(StreamReader sr = new StreamReader("Necyt.txt"))
            {
                text = sr.ReadToEnd();
            }
            for (int i = 0; i < text.Length; i++)
            {
                if (keyValuePairs.ContainsKey(text[i]))
                {
                    keyValuePairs[text[i]]++;
                }
                else keyValuePairs.Add(text[i], 1);
            }
            for (int i = 0; i < text.Length; i++)
            {
                if (dictionary.ContainsKey(text[i]))
                {
                    dictionary[text[i]]++;
                }
                else dictionary.Add(text[i], 1);
            }
            List<int> list1 = (List<int>)keyValuePairs.Values;
            List<int> list2 = dictionary.Values.ToList();
            list1.Sort();
            list2.Sort();
            Assert.AreEqual(list1.Count, list2.Count);
            bool flag = true;
            for (int i = 0;i < list1.Count;i++)
            {
                if (list1[i] != list2[i])
                {
                    flag = false;
                    break;
                }
            }
            Assert.AreEqual(true, flag);
        }
        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void RemoveNoExist()
        {
            ChainHashTable<char, int> keyValuePairs = new ChainHashTable<char, int>();
            string text = "abcdef";
            for (int i = 0; i < text.Length; i++)
            {
                if (keyValuePairs.ContainsKey(text[i]))
                {
                    keyValuePairs[text[i]]++;
                }
                else keyValuePairs.Add(text[i], 1);
            }
            keyValuePairs.Remove('h');
        }
        [TestMethod]
        public void AdditionAndRemoveAndComparison()
        {
            ChainHashTable<char, int> keyValuePairs = new ChainHashTable<char, int>();
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            string text;
            using (StreamReader sr = new StreamReader("Necyt.txt"))
            {
                text = sr.ReadToEnd();
            }
            for (int i = 0; i < text.Length; i++)
            {
                if (keyValuePairs.ContainsKey(text[i]))
                {
                    keyValuePairs[text[i]]++;
                }
                else keyValuePairs.Add(text[i], 1);
            }
            for (int i = 0; i < text.Length; i++)
            {
                if (dictionary.ContainsKey(text[i]))
                {
                    dictionary[text[i]]++;
                }
                else dictionary.Add(text[i], 1);
            }
            for (int i = 0; i < text.Length; i += 10)
            {
                if (dictionary.ContainsKey(text[i]))
                {
                    dictionary.Remove(text[i]);

                }
            }
            for (int i = 0; i < text.Length; i += 10)
            {
                if (keyValuePairs.ContainsKey(text[i]))
                {
                    keyValuePairs.Remove(text[i]);
                }
            }
            List<int> list1 = (List<int>)keyValuePairs.Values;
            List<int> list2 = dictionary.Values.ToList();
            list1.Sort();
            list2.Sort();
            Assert.AreEqual(list1.Count, list2.Count);
            bool flag = true;
            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] != list2[i])
                {
                    flag = false;
                    break;
                }
            }
            Assert.AreEqual(true, flag);
        }
    }
}
