using Markdig;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace GhostPublishCLI
{
    class Program
    {
        static string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        static string apiPath = ConfigurationManager.AppSettings["ApiPath"];

        static void Main(string[] args)
        {


            Console.ForegroundColor = ConsoleColor.Gray;

            if (!string.IsNullOrEmpty(apiPath.Trim()) && !string.IsNullOrEmpty(apiKey.Trim()))
            {
                if (args.Length == 1)
                {
                    Publish(args[0]);
                }
                else if (args.Length < 1)
                {
                    Console.Write("Please enter the filepath: ");
                    var path = Console.ReadLine();
                    Publish(path.Replace("\"", ""));
                }
                else
                {
                    ErrorMessage("Too many arguments");
                }
            }
            else
            {
                ErrorMessage("API Key or Path empty");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }

        public static void Publish(string filePath)
        {
            FileInfo file = new FileInfo(filePath);
            if (file.Extension.ToLower().StartsWith(".md"))
            {
                Ghost ghost = new Ghost(apiKey);

                var fileText = File.ReadAllText(filePath);
                fileText = fileText.Substring(fileText.IndexOf("---") + 3);
                var headerEndIndex = fileText.IndexOf("---");
                var header = fileText.Substring(0, headerEndIndex);
                var post = MdFile.ParseHeaderToPost(header);
                post.Html = Markdown.ToHtml(fileText.Substring(headerEndIndex + 3));
                if (ghost.CreatePost(new GhostData() { Posts = new Post[] { post } }, "https://nyasaki.dev"))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Post sucessfully created!");
                }

            }
            else
            {
                ErrorMessage("The file is no markdown file!");
            }
        }

        public static void ErrorMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
        }

    }
}
