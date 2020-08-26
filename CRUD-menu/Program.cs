using System;
using System.Collections.Generic;
using System.ComponentModel;
using CRUD_menu_models;
using CRUD_menu_BLL;

namespace CRUD_menu
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Video> videos = new List<Video>();
           
            string[] menuItems =
            {
                "List all videos",
                "show one video by id",
                "Add video",
                "Delete video",
                "Edit video",
                "Exit"


            }; 

            var selection = 0;
            while (selection != 5)
            {
                
            
                selection = ShowMenu(menuItems); 
                Console.ReadLine();

                switch (selection)
                {

                    case 1:
                        Console.WriteLine("List all videos");
                        for (int i = 0; i < VideoService.GetVideos().Count; i++)
                        {
                            //Console.WriteLine((i +1) + ":" + menuItems[i]);
                            Console.WriteLine($"{(i + 1)}:{VideoService.GetVideos()[i]}");

                        }

                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("show single video by id");
                        Console.Write("write id of the video you want:");

                        while (!int.TryParse(Console.ReadLine(), out selection))
                        {
                            Console.WriteLine("You need to select an id");

                        }


                        int showid = selection;

                        if (VideoService.GetVideos().Find(x => x.Id == selection) == null)
                        {
                            Console.WriteLine("could not find video");
                            Console.ReadLine();
                        }

                        Console.WriteLine(VideoService.GetVideos().Find(x => x.Id == selection));
                        Console.ReadLine();



                        break;
                    case 3:
                        // TODO: add input validation
                        Console.WriteLine("Add video");
                        Console.WriteLine("Enter title");
                        string title = Console.ReadLine();

                        Console.WriteLine("Enter release date");
                        Console.ReadLine();
                        Console.WriteLine("Enter year");
                        int year = int.Parse(Console.ReadLine());
                        Console.ReadLine();
                        Console.WriteLine("Enter month");
                        int month = int.Parse(Console.ReadLine());

                        Console.ReadLine();
                        Console.WriteLine("Enter day");
                        int day = int.Parse(Console.ReadLine());

                        DateTime date = new DateTime(year,month,day);

                        Console.ReadLine();
                        Console.WriteLine("Enter storyline");
                        string storyline = Console.ReadLine();

                        Console.ReadLine();
                        Console.WriteLine("Enter genre");
                        string action = Console.ReadLine();

                        VideoService.CreateVideo(new Video(title, date, storyline, action));

                        Console.ReadLine();
                        break;
                    case 4:
                        // TODO: finish creating deletion. 
                        Console.WriteLine("Delete video");
                        Console.ReadLine();
                        Console.Write("write the id of the video you wish to delete:");
                     

                        break;
                    case 5:
                        Console.WriteLine("Edit video");
                        Console.ReadLine();
                        break;
                    case 6:
                        Console.WriteLine("Exit");
                        Console.ReadLine();
                        break;

                }






            }

        }

        private static int ShowMenu(string[] menuItems)
        {
           Console.Clear();


           Console.WriteLine("Select what you want to  do");
           Console.WriteLine("");
           /*
           foreach (var menuItem in menuItems)
           {
               Console.WriteLine(menuItem);
               
           }
           */

           for (int i = 0; i < menuItems.Length; i++)
           {
               //Console.WriteLine((i +1) + ":" + menuItems[i]);
               Console.WriteLine($"{(i + 1)}:{menuItems[i]}");

            }

           int selection;
           while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > 6)
           {
               Console.WriteLine("You need to select a menu item");

           }
           Console.WriteLine("Selection " + selection);
           return selection;
        }
    }
}
