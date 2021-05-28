using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Net;
using System.Text;

namespace BruteForceYanDisk.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading...");
            GenerateCharURL.BruteYanUrls("https://disk.yandex.ru/d/H-mwgcDCDig7Q");
            GenerateCharURL.DownloadStringURL("https://disk.yandex.ru/d/HSmwgcDCDig7Q");

        }
    }



    //404 not found
    //302 found
    public static class GenerateCharURL
    {
        public static void DownloadStringURL(string url)
        {

            WebClient client = new WebClient();

            string docPathUrl = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            try
            {
                using (Stream stream = client.OpenRead(url))
                {
                    StreamWriter putFile = new StreamWriter(Path.Combine(docPathUrl, "URLresultArrays.txt"));
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string line = "";
                        while ((line = reader.ReadLine()) != null)
                        {
                            putFile.WriteLine(line);
                            Console.WriteLine(line);

                            Console.WriteLine("Файл загружен");
                            Console.Read();
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("ошибка");
                GenerateCharURL.DownloadStringURL("https://www.google.com/");
                //DownloadStringURL(GenerateCharURL.GetYanUrls);

                //DownloadStringURL("https://disk.yandex.ru/d/HSmwgcDCDig7Q");


            }
        }

        //сделать запись в базу и из базы вытаскивать  в веб интерфейс
        public static void BruteYanUrls(string YanUrl)
        {
            string UrlYandex = YanUrl;
            string[] charForBrut = { "-", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            Console.WriteLine($"Original URL {UrlYandex}");

            for (int index = 0; index < charForBrut.Length; index++)
            {
                var item = charForBrut[index];

                var BruteForceString = UrlYandex.Replace("-", item);
                Console.WriteLine("After :{0} {1} ", Environment.NewLine, BruteForceString);
            }

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "URLresult.txt")))
                for (int index = 0; index < charForBrut.Length; index++)
                {
                    var item = charForBrut[index];

                    var BruteForceString = UrlYandex.Replace("-", item);
                    outputFile.WriteLine("After :{0} {1}   ", Environment.NewLine, BruteForceString);
                }

        }
    }

}
