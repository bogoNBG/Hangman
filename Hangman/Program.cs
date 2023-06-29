using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Въведи дума:");

            string word = Console.ReadLine().ToLower();

            Console.Clear();

            int wordCount = word.Length;


            char[] actualWord = new char[wordCount];
            

             for (int i = 0; i < wordCount; i++)
             {
                Console.Write("_");
                actualWord[i] = '_';
             }

            string ActualWord = new string(actualWord);

            Console.WriteLine("\n");
            int count = 0;
            bool correct;

            while (count < 10 && ActualWord != word)
            {
                Console.Write("Въведи буква:");
                char guessed;
                if(!Char.TryParse(Console.ReadLine(), out guessed)) 
                {
                    Console.WriteLine("Неправилен вход!");
                    continue;
                }

                guessed = Char.ToLower(guessed);

                correct = false;
                for (int i = 0; i < wordCount; i++)
                
                {
                    if (guessed == word[i])
                    {
                        actualWord[i] = guessed;
                        correct = true;
                    }                
                }
                
                ActualWord = new string(actualWord);
                Console.WriteLine(ActualWord);

                if (!correct)
                {
                    count++;
                    Console.WriteLine("\nГрешна буква. Оставащи опити: " + (10 - count));                   
                }
                Console.WriteLine("\n");
            }

            if (ActualWord == word) Console.WriteLine("Печелиш");
            else Console.WriteLine("Губиш\nПравилната дума е: " + word);            

            Console.ReadLine();
        }
    }
}
