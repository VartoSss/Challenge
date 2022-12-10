using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;


namespace ConsoleApp;

public class Cypher
{
    static char[] chars = new char[]
    {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
        'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
        'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3',
        '4', '5', '6', '7', '8', '9', '\'', ' '
    };
    public static string SolveCypher(string question)
    {
        var task = question;
        var splittedTask = task.Split(new[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
        if (splittedTask[0] == "reversed" && splittedTask.Length == 2)
        {
            var result = new StringBuilder();
            for (int i = splittedTask[1].Length - 1; i >= 0; i--)
                result.Append(splittedTask[1][i]);
            return result.ToString();
        }
        else if (splittedTask[0] == "dyslexia")
        {
            
            var directory = Directory.GetCurrentDirectory();
            var debug = Directory.GetParent(directory).ToString();
            var bin = Directory.GetParent(debug).ToString();
            var project = Directory.GetParent(bin).ToString();
            var h1_1 = Directory.GetParent(project);
            
            var allText = File.ReadAllText(h1_1 + @"\ConsoleApp\HarryPotterText.txt").ToLower();

            var text = allText.Split();
            var mixedWords = splittedTask[1].Split();
            var ok = false;
            for (var i = 0; i < text.Length; i++)
            {
                for (var j = 0; j < mixedWords.Length; j++)
                {
                    if (HaveTheSameAmountOfChars(text[i + j], mixedWords[j]))
                    {
                        ok = true;
                    }
                    else
                    {
                        ok = false;
                        break;
                    }
                }

                if (ok)
                {
                    var result = new string[mixedWords.Length];
                    
                    for (var j = 0; j < mixedWords.Length; j++)
                    {
                        result[j] = text[i + j];
                    }

                    return String.Join(" ", result);
                }
            }

            return "";
        }
        else if (splittedTask.Length == 2 && splittedTask[0].Substring(0, 14) == "Caesar's code=")
        {
            var str = splittedTask[1];
            var shift = int.Parse(splittedTask[0].Substring(14));
            var result = new StringBuilder();
            var alphabet = chars;
            if (splittedTask.Length == 3)
            {
                alphabet = splittedTask[1].Substring(4).ToCharArray();
                str = splittedTask[2];
            }
            if (splittedTask.Length == 2 || splittedTask.Length == 3)
            {
                //поменяй тут пж чтобы принимало с сайта
                for (var i = 0; i < str.Length; i++)
                {
                    var index = (Array.LastIndexOf(alphabet, str[i]) - shift) % alphabet.Length;
                    if (index < 0)
                        index = alphabet.Length + index;
                    var newSymbol = alphabet[index];
                    result.Append(newSymbol.ToString());
                }

                //и тут на return)
                return result.ToString();
            }
            else throw new Exception("Unknown Caesar's code");
        }
        else if (splittedTask[0].Substring(0, 15) == "Vigenere's code")
        {

            var alphabet = chars;
            var str = splittedTask[1];
            if (splittedTask.Length == 3)
            {
                alphabet = splittedTask[1].Substring(4).ToCharArray();
                str = splittedTask[2];
            }
            var keyWord = splittedTask[0].Substring(16);
            var answer = new StringBuilder();
            for (var i = 0; i < str.Length; i++)
            {
                var step = Array.IndexOf(alphabet, keyWord[i % keyWord.Length]);
                answer.Append(alphabet[(Array.IndexOf(alphabet, str[i]) - step + alphabet.Length) % alphabet.Length]);
            }

            return answer.ToString();
        }
        else if (splittedTask[0].Substring(0, 20) == "prime multiplicator=")
        {
            var result = new StringBuilder();

            var taskParts = splittedTask[0].Split(": ");
            var formula = taskParts[1];
            var multiplicator = new StringBuilder();
            for (var i = 20; i < taskParts[0].Length; i++)
            {
                if (char.IsDigit(taskParts[0][i]))
                    multiplicator.Append(taskParts[0][i]);
                else
                    break;
            }

            var intMultiplicator = int.Parse(multiplicator.ToString());

            if (formula == "(multiplicator * (charIndex + 1)) % (|ABC| + 1) - 1")
            {
                var alphabetPower = chars.Length;
                for (var i = 0; i < splittedTask[1].Length; i++)
                {
                    var currentIndex = Array.IndexOf(chars, splittedTask[1][i]);
                    for (var j = 0; j < chars.Length; j++)
                    {
                        if ((intMultiplicator * (j + 1) % (chars.Length + 1) - 1) == currentIndex)
                        {
                            result.Append(chars[j].ToString());
                            break;
                        }
                    }
                }
                return result.ToString();
            }
            else
                throw new Exception("new formula in cypher task");
        }
        else if (splittedTask[0].Substring(0, 35) == "a first longest word of the message")
        {
            var alphabet = new char[]
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
                'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3',
                '4', '5', '6', '7', '8', '9', ' ', '\''
            };
            var word = splittedTask[0].Split('=')[1];
            var str = splittedTask[1];

            var directory = Directory.GetCurrentDirectory();
            var debug = Directory.GetParent(directory).ToString();
            var bin = Directory.GetParent(debug).ToString();
            var project = Directory.GetParent(bin).ToString();
            var h1_1 = Directory.GetParent(project);

            var allText = File.ReadAllText(h1_1 + @"\ConsoleApp\HarryPotterText.txt").ToLower();

            var text = allText.Split();
            var ok = false;
            var keyWord = "";
            for (var i = 0; i < alphabet.Length; i++)
            {
                ok = false;
                var newString = str.Split(alphabet[i]);
                foreach (var j in newString)
                {
                    if (j.Length == word.Length)
                    {
                        if (ok == false)
                            keyWord = j;
                        ok = true;
                    }
                }

                if (ok == true)
                {
                    var decodedString = new StringBuilder();
                    foreach (var q in str)
                    {
                        if (keyWord.Contains(q))
                        {
                            decodedString.Append(word[keyWord.IndexOf(q)]);
                        }
                        else if (q == alphabet[i])
                            decodedString.Append(' ');
                        else
                            decodedString.Append('?');
                    }

                    var dString = decodedString.ToString();
                    for (var h = 0; h < allText.Length - str.Length; h++)
                    {
                        if (StringsAreSame(allText.Substring(h, str.Length), dString))
                        {
                            return allText.Substring(h, str.Length);
                        }
                    }
                }
            }

            return null;
        }
        
        else
            throw new Exception("AAAAAA TASK GOT HARDER");
    }

    private static bool HaveTheSameAmountOfChars(string s, string mixedWord)
    {
        if (s.Length != mixedWord.Length) return false;
        foreach (var ch in s)
        {
            if (s.Count(f => f == ch) != mixedWord.Count(f => f == ch))
                return false;
        }

        return true;
    }


    private static bool StringsAreSame(string s1, string s2)
    {
        if (s1.Length != s2.Length)
            return false;
        for (var i = 0; i < s1.Length; i++)
        {
            if (s1[i] == s2[i] || s2[i] == '?')
            {
                continue;
            }
            else
                return false;
        }

        return true;
    }
}
