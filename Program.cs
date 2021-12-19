using System;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using HtmlAgilityPack;
using iTextSharp.tool.xml.html;
using System.Web;
using OpenQA.Selenium.Html5;




namespace WebscrapingConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //IWebDriver driver;
            //WebDriverWait wait;
            //int count = 0;
            int keuze;
            string zoek;
            //string zoeken;

            string urlzoek;
            

            WebDriverWait wait;

            
            //Keuze opties weergeven in de console voor de gebruiker

            Console.WriteLine("For youtube scraping press 1: ");
            Console.WriteLine("For indeed scraping press  2: ");
            Console.WriteLine("For Amazon scraping press  3: ");
            
            //Gebruikers input lezen
            keuze = int.Parse(Console.ReadLine());


            Console.WriteLine("Enter your search value: ");

            //Gebruikers input lezen
            zoek = Console.ReadLine();



            while ((keuze < 0) || (keuze > 3))
            {
                Console.WriteLine("The given value is not correct ! ");
                Console.WriteLine("Give a value 1, 2 or 3: ");

                keuze = int.Parse(Console.ReadLine());


                Console.WriteLine("You have selected the following options " + keuze + "!"
                          + zoek);

                Console.WriteLine("Geef enter in om te starten met scrappen");
                Console.ReadLine();


            }

            if (keuze == 1)
            {
                string youtubelaatst = "&sp=CAI%253D";
                string youtubebegin = "results?search_query=";
                zoek = zoek.Replace(" ", "+");
                urlzoek = string.Concat(youtubebegin, zoek, youtubelaatst);
                var url = $"https://www.youtube.com/{urlzoek}";
                //int num = 0;
                IWebDriver driver = new ChromeDriver();
                Console.WriteLine(urlzoek);
                Console.WriteLine($"Url to be queried: {url}");
                Console.WriteLine("You have selected the following options " + keuze + "!"
                            + zoek);
                
                driver.Navigate().GoToUrl(@"https://www.youtube.com");
                

                driver.FindElement(By.XPath("/html/body/ytd-app/ytd-consent-bump-v2-lightbox/tp-yt-paper-dialog/div[4]/div[2]/div[5]/div[2]/ytd-button-renderer[2]/a/tp-yt-paper-button/yt-formatted-string")).Click();
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                //var search = driver.FindElement(By.CssSelector("[aria-label]=Zoek"));
                //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                //search.SendKeys(zoek);
                //search.SendKeys("shitzooi");
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                driver.Navigate().GoToUrl(url);

                IWebElement l = driver.FindElement(By.Id("contents"));
                var tag = driver.FindElement(By.Id("contents"));
                string content = l.Text;
                Console.WriteLine("Text content: " + content);
                Console.ReadLine();

                //lezen van link, titel, uploader en aantal

                //HtmlDocument htmlSnippet = new HtmlDocument();
                //htmlSnippet.LoadHtml(urlzoek);
                HtmlWeb w = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                var hd = w.Load(urlzoek);
                doc = w.Load(urlzoek);

                var cites = hd.DocumentNode.SelectNodes("//*[@id=video-title]");
                var cites2 = hd.DocumentNode.SelectNodes("//*[@id=\"thumbnail\"]");
                var href = hd.DocumentNode.SelectNodes("//a[@href]");

                foreach(HtmlNode link in doc.DocumentNode.SelectNodes("//*[@id=\"video-title\"]"))
                {
                    HtmlAttribute att = link.Attributes["href"];
                    if (att.Value.Contains("a")) 
                    {
                        Console.WriteLine(att.Value);
                    }
                }
                



                //*[@id="thumbnail"]
                //foreach (var tags in cites)

                Console.WriteLine(cites);
                Console.WriteLine(cites2);

                Console.WriteLine("De urls: ", href);
                /*List<string> hrefTags = new List<string>();

                foreach (HtmlNode link in htmlSnippet.DocumentNode.SelectNodes("//a[title]"))
                {
                  if (num < 6)
                {
                       num++;
                        HtmlAttribute att = link.Attributes["href"];
                        hrefTags.Add(att.Value);
                        Console.WriteLine(hrefTags);
                        Console.ReadLine();

                    }





                }*/
            }
            else if (keuze == 2)
             {
                 //string indeedlaatst = "&fromage=3";
                 //string indeedbegin = "jobs?q=";
                 //zoek = zoek.Replace(" ", "%20");

                 //urlzoek = string.Concat(indeedbegin, zoek, indeedlaatst);
                 //var url = $"https://be.indeed.com/{urlzoek}";
                 int num = 0;

                 Console.WriteLine("You have selected the following options " + keuze + "!"
                                + zoek);
                 IWebDriver driver = new ChromeDriver();
                 driver.Navigate().GoToUrl(@"https://be.indeed.com");
                 //driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div[1]/div/div[2]/div/button[2")).Click();
                 var search2 = driver.FindElement(By.XPath("//*[@id=\"text-input-what\"]"));


                 wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                 search2.SendKeys(zoek);
                 search2.Submit();
                 wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                 driver.FindElement(By.XPath("//*[@id=\"filter-dateposted\"]")).Click();
                 driver.FindElement(By.XPath("//*[@id=\"filter-dateposted-menu\"]/li[2]/a")).Click();

                //driver.Navigate().GoToUrl(url);

                 driver.FindElement(By.XPath("//*[@id=\"popover-x\"]/button")).Click();
                //HtmlDocument htmlDoc = new HtmlDocument();
                //string url = HttpContext.Current.Request.Url.AbsoluteUri;
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                
                String currentURL = driver.Url;
                //HtmlDocument htmlDoc = new HtmlDocument();
                int i = 0;

                var titel1 = driver.FindElement(By.XPath("/html/body/table[2]/tbody/tr/td/table/tbody/tr/td[1]/div[5]/div/a[1]/div[1]/div/div[1]/div/table[1]/tbody/tr/td/div[1]/h2/span"));
                 //var titel2 = driver.FindElement(By.XPath("/html/body/table[2]/tbody/tr/td/table/tbody/tr/td[1]/div[5]/div/a[1]/div[1]/div/div[1]/div/table[1]/tbody/tr/td/div[1]/h2/span"));
                //string content = l.Text;
                Console.WriteLine("Text content: " + titel1);
                Console.WriteLine("De url van de pagina ia: " + currentURL);
                //var node = htmlDoc.DocumentNode.SelectSingleNode("//body");
                //var link = htmlDoc.DocumentNode;

                var htmlDoc = new HtmlDocument();
                //htmlDoc.LoadHtml(html);
                htmlDoc.LoadHtml(currentURL);

                string name = htmlDoc.DocumentNode.SelectSingleNode("//body").InnerText;

                Console.WriteLine(name);
                //Console.WriteLine(node.GetDirectInnerText);
                
                Console.ReadLine();


             }
           
             if (keuze == 3)
             {
                 //string amazonlaatst = "&fromage=3";
                 //string amazonbegin = "jobs?q=";
                 //zoek = zoek.Replace(" ", "%20");
                 //urlzoek = string.Concat(amazonbegin, zoek, amazonlaatst);
                 //var url = $"https://www.amazon.com/{urlzoek}";
                 int num = 0;

                 Console.WriteLine("You have selected the following options " + keuze + "!"
                             + zoek);
                 IWebDriver driver = new ChromeDriver();
                 driver.Navigate().GoToUrl(@"https://www.amazon.com/");

                 var amazon = driver.FindElement(By.XPath("//*[@id=\"twotabsearchtextbox\"]"));
                 amazon.Click();
                 amazon.SendKeys(zoek);
                 amazon.Submit();
                 


                 

                 wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                 var prijs = driver.FindElement(By.XPath("//*[@id=\"p_36/14674873011\"]/span/a"));
                 prijs.Click();
                 //driver.Navigate().GoToUrl(url);

                 var l = driver.FindElement(By.ClassName("a-size-medium.a-color-base.a-text-normal"));
                 string content = l.Text;

                 Console.WriteLine("Text content: " + content);
                 Console.ReadLine();



              }




             
        }
    }
}

