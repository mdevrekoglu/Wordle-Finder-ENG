using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trials
{
    class Program
    {
        static void Main()
        {
            // Read and assign all 5 letter words
            List<String> words = System.IO.File.ReadAllLines(@"D:\School\Year 3\Trials\Wordle-Finder-ENG\dictionary.txt").ToList();

            // To use random
            Random random = new Random();

            // We have 6 tries
            for (int i = 0; i < 6; i++)
            {
                // Pick a random word from the list
                int randomIndex = random.Next(0, words.Count);
                String wordleWord = words[randomIndex];

                /* 
                 * Print the word and ask for result
                 * If result is "" then remove the word from list
                 * If result is "ttttt" then end the program and send congratulations
                 * t-> letter on correct position, c-> letter on wrong position, f-> letter not in word (but word can contain two same letters)
                 * Remove all words that are not possible anymore
                */

                // Console.WriteLine("                  angel"); // for testing
                Console.WriteLine("Selected word is: " + wordleWord);

                // Get result from user
                Console.Write("Write result: ");
                String result = Console.ReadLine();

                // if result is "" then remove the word from list because game does note accept that selected word
                if (result == "")
                {
                    words.Remove(wordleWord);
                    i--;
                    continue;
                }
                else if (result == "ttttt") // if result is "ttttt" then end the program and send congratulations
                {
                    // End the program and send congratulations
                    Console.WriteLine("Congratulations, you won!");
                    break;
                }


                for (int j = 0; j < 5; j++)
                {
                    if (result[j] == 't') // True place for letter
                    {
                        for (int k = 0; k < words.Count; k++)
                        {
                            if (words[k][j] != wordleWord[j])
                            {
                                words.RemoveAt(k);
                                k--;
                            }
                        }
                    }
                    else if (result[j] == 'c') // Word contains that letter
                    {
                        for (int k = 0; k < words.Count; k++)
                        {
                            if (words[k][j] == wordleWord[j])
                            {
                                words.RemoveAt(k);
                                k--;
                            }
                            else
                            {
                                bool found = false;
                                for (int l = 0; l < 5; l++)
                                {
                                    if (l != j && result[l] != 't' && words[k][l] == wordleWord[j])
                                    {
                                        found = true;
                                        break;
                                    }
                                }
                                if (!found)
                                {
                                    words.RemoveAt(k);
                                    k--;
                                }
                            }
                        }
                    }
                    else if (result[j] == 'f') // Word does not contains that letter
                    {
                        for (int k = 0; k < words.Count; k++)
                        {
                            if (words[k][j] == wordleWord[j])
                            {
                                words.RemoveAt(k);
                                k--;
                            }
                            else
                            {
                                bool flag = false;
                                for (int l = 0; l < 5; l++)
                                {
                                    if (l != j && result[l] == 'c' && wordleWord[l] == wordleWord[j])
                                    {
                                        flag = true;
                                        break;
                                    }
                                }

                                if (!flag)
                                {
                                    bool flag2 = false;
                                    for (int l = 0; l < 5; l++)
                                    {
                                        if (l != j && result[l] != 't' && words[k][l] == wordleWord[j])
                                        {
                                            flag2 = true;
                                            break;
                                        }
                                    }

                                    if (flag2)
                                    {
                                        words.RemoveAt(k);
                                        k--;
                                    }
                                }
                            }
                        }
                    }


                }

                // Print all words that are still possible
                Console.WriteLine("Possible words: ");
                foreach (String word in words)
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}