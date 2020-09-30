using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpParser
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<KeyValuePair<string, string>> allRecods = new List<KeyValuePair<string, string>>();

            string[] columns = File.ReadAllLines(@"D:\WhoKnows\Courses\Applications\ObjectParser\CsharpParser\Resoures\columnNames.txt");

            string[] rawData = File.ReadAllLines(@"D:\WhoKnows\Courses\Applications\ObjectParser\CsharpParser\Resoures\dataString.txt");

            List<string> finalResult = new List<string>();
            finalResult.Add(string.Join(",", columns));

            foreach (string eachLine in rawData)
            {
                List<string> eachDataLine = new List<string>();

                foreach (string eachColumn in columns)
                {
                    string res = GetValueForkey(eachColumn, eachLine);
                    eachDataLine.Add(string.IsNullOrWhiteSpace(res) ? "NULL" : res);
                }

                finalResult.Add(string.Join(",", eachDataLine));
            }

            File.WriteAllLines(@"D:\WhoKnows\Courses\Applications\ObjectParser\CsharpParser\Resoures\ResultData.txt", finalResult);


        }

        private static string GetValueForkey(string key, string fullText)
        {
            int idx1 = fullText.IndexOf(key);

            if(idx1 == -1)
            {
                return "";
            }

            string s1 = fullText.Substring(idx1 + key.Length);

            int idx2 = s1.IndexOf(":") + 1;

            //string s2 = s1.Substring(idx2);

            int idx3 = s1.IndexOf(",") - 1;

            if (idx3 > 0)
            {
                return s1.Substring(idx2, idx3).Trim();
            }
            else
            {
                return s1.Substring(idx2).Trim();
            }
            
            //int colIdx = fullText.Substring(key.Length + idx1).IndexOf(':') + key.Length + idx1;

            //int commaIdx = fullText.Substring(colIdx).IndexOf(",") + key.Length + idx1 + colIdx;

            //if(commaIdx != -1)
            //{
            //    return fullText.Substring(colIdx, commaIdx - colIdx).Trim();
            //}
            //else
            //{
            //    return fullText.Substring(colIdx).Trim();
            //}

        }
    }
}
