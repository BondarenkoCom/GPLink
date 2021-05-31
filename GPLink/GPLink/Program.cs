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

            Console.ForegroundColor = ConsoleColor.Red;
            GenerateCharURL.BruteYanUrls("https://yadi.sk/d/AcIvY02K4FIa4w?w=1");
            //GenerateCharURL.BruteYanUrls("https://disk.yandex.ru/d/H-mwgcDCDig7Q");
           

            Console.ForegroundColor = ConsoleColor.Green;
            GenerateCharURL.PlaceNextLink("C:\\Users\\ABondarenko\\Desktop\\URLresult.txt");
            //check and parse Link
            //GenerateCharURL.DownloadStringURL("https://disk.yandex.ru/d/H-mwgcDCDig7Q");
            //GenerateCharURL.DownloadStringURL("https://www.google.com/");
            
        }
    }

    //https://yadi.sk/d/qcIvY02K4FIa4w?w=1 correct Url
    //https://yadi.sk/d/AcIvY02K4FIa4w?w=1 Wrong URL
 

    //https://yadi.sk/d/qcIvY02K4FIa4w?w=1 Witch URL
    //https://disk.yandex.ru/d/HQmwgcDCDig7Q   (Generate URL) Is not work

    //https://docs.microsoft.com/ru-ru/dotnet/api/system.net.webclient?view=net-5.0 is work
    //https://disk.yandex.ru/ is work
    //https://www.lifeinvader.com/profile/sprunk not work
    //https://www.google.com/ is work

    public static class GenerateCharURL
    {

        public static void PlaceNextLink(string UrlPath)
        {
            Console.WriteLine("PlaceNextLink - work");
            //Console.WriteLine(Link);

            //string UrlPath;

            using (FileStream fstream = File.OpenRead($"{UrlPath}"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Text - {textFromFile}");

                var urls = File.ReadLines(UrlPath);
                //var urls = File.ReadLines(UrlPath).ToList();
                //urls[3] = "https://www.google.com";



                foreach (var url in urls)
                {
                    DownloadStringURL(url);
                }
            }
        }


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
                Console.WriteLine($"ошибка - Exception = {url}");
                //GenerateCharURL.PlaceNextLink($"Method Work");          
          
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


                string BruteForceString = UrlYandex.Replace("A", item);
                //https://disk.yandex.ru/d/H-mwgcDCDig7Q
                //string BruteForceString = UrlYandex.Replace("c", item);
                Console.WriteLine("{0} {1}", Environment.NewLine, BruteForceString);    
             
            }

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "URLresult.txt")))
                for (int index = 0; index < charForBrut.Length; index++)
                {
                    var item = charForBrut[index];

                    var BruteForceString = UrlYandex.Replace("A", item);
                    //string BruteForceString = UrlYandex.Replace("c", item);
                    outputFile.WriteLine("{0} {1}", Environment.NewLine, BruteForceString);
                }
        }     
    }
    
}
