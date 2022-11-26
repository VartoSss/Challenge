using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static IronPython.Modules._ast;
using System.Diagnostics;

namespace Japan
{
    public class japanese
    {
        public static string SolveJapanese(string question)
        {
            var inputPath = "C:\\Users\\Артем\\H1_1\\ConsoleApp\\Input.txt";
            var outputPath = "C:\\Users\\Артем\\H1_1\\ConsoleApp\\Output.txt";
            File.WriteAllText(inputPath, string.Empty);
            File.WriteAllText(outputPath, string.Empty);
            var data = question;
            data = data.Replace("columns:","");
            data = data.Replace("rows:", " ");
            var info = data.Split(' ');
            var str = new StringBuilder();
            var str2 = new StringBuilder();
            foreach (var item in info[0])
            {
                if (item == ';')
                    str.Append(',');
                else if (item == ',')
                    str.Append(' ');
                else
                    str.Append(item);
            }
            foreach (var item in info[1])
            {
                if (item == ';')
                    str2.Append(',');
                else if (item == ',')
                    str2.Append(' ');
                else
                    str2.Append(item);
            }
            var str3 = str.ToString().TrimEnd(',');
            var str4 = str2.ToString().TrimEnd(',');
            var result = string.Format("[clues]\r\ncolumns={0}\r\nrows={1}", str3, str4);
            File.WriteAllText(@"C:\Users\Артем\H1_1\ConsoleApp\Input.txt", result);
            var command = $"pynogram -b {inputPath} >> {outputPath}";
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C "+command;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            process.Close();
            var text = new List<string>();
            using (StreamReader reader = new StreamReader(outputPath,Encoding.Default))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                    text.Add(line);
            }
            return TextParser(text);
        }
    }
}
