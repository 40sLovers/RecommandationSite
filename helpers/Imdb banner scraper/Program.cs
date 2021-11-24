using System;
using System.Collections.Generic;
using System.IO;
using HtmlAgilityPack;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.VisualBasic;

namespace TestScraper 
{
    public class Program
    {
        private static string xpath =
            "//*[@id=\"__next\"]/main/div/section[1]/section/div[3]/section/section/div[3]/div[1]/div/div[1]/div/a";

        private static string BannerPath = Path.Combine(Environment.CurrentDirectory, "Banners");

        private static WebClient client = new WebClient();
        
        //Pls don't judge this shti code, I'm a lazy fker
        public static void Main(string[] args)
        {
            HtmlWeb web = new HtmlWeb();
            
            string[] ids = File.ReadAllLines("ids.txt");

            if (!Directory.Exists(BannerPath))
                Directory.CreateDirectory(BannerPath);

            HtmlDocument doc;
            foreach (var id in ids)
            {
                //If invalid id
                if (id.Length<3) continue;
                
                //First page url
                doc = web.Load($"https://www.imdb.com/title/{id}/");
                //Select the node that has the banner
                HtmlNode node = doc.DocumentNode.SelectSingleNode(xpath);

                //Make the link for the page that has the high-res version
                string page2link = stringutils.RemoveEverythingBeforeFirst(node.OuterHtml, "href=\"");
                page2link = stringutils.RemoveEverythingAfterFirst(page2link,"?");
                page2link = $"https://www.imdb.com/{page2link}";
                
                Console.WriteLine(page2link);
                
                doc = web.Load(page2link);
                
                string imgLink;
                
                //Bad code
                //Why do I do this? Because I don't know how to get the correct image in another way
                //That's a lie, I could just search for Image-sc-1qk433p-0 as the class type but im a lazy fk
                //Apparently I wasn't lazy enough to ignore my brain telling me to fix this
                // for (int i = 0; i < 9999; i++)
                // {
                //     string xpath2 = $"//*[@id=\"__next\"]/main/div[2]/div[3]/div[{i}]/img";
                //     node = doc.DocumentNode.SelectSingleNode(xpath2);
                //     if (node is null) continue;
                //     //If this class is the img src, then it's the banner image
                //     if (node.OuterHtml.Contains("Image-sc-1qk433p-0")) break;
                // }
                // //
                
                //I hope this doesn't break while we need it :/
                string xpath2 = "//*[contains(@class, 'MediaViewerImagestyles__PortraitImage-sc-1qk433p-0')]";
                node = doc.DocumentNode.SelectSingleNode(xpath2);
                Console.WriteLine(node.OuterHtml);
                
                imgLink = stringutils.RemoveEverythingBeforeFirst(node.OuterHtml, "src=\"");
                imgLink = stringutils.RemoveEverythingAfterFirst(imgLink, "\"");

                //Download img and move it in the correct dir
                string filename = $"{id}.jpeg";
                client.DownloadFile(imgLink,filename);
                try { File.Move(filename,Path.Join(BannerPath,filename));} catch{File.Delete(filename);}
            }
        }
    }
    
    
}