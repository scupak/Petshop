using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using VideoApp.core;
using VideoApp.core.ApplicationServices;
using VideoApp.Core.Entity;

namespace VideoApp.UI
{
  public  class Printer
  {
         private IVideoService _videoService;
         private Video editedVideo; 
        public Printer(IVideoService videoService)
        {
            _videoService = videoService;

        }

        public void PrintMenu()
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
            while (selection != 6)
            {


                selection = ShowMenu(menuItems);
                int idSelection;
                Console.ReadLine();

                switch (selection)
                {

                    case 1:
                        Console.WriteLine("List all videos");
                        for (int i = 0; i < _videoService.GetVideos().Count; i++)
                        {
                            //Console.WriteLine((i +1) + ":" + menuItems[i]);
                            Console.WriteLine($"{(i + 1)}:{_videoService.GetVideos()[i]}");

                        }

                        Console.ReadLine();
                        break;
                    case 2:

                        Console.WriteLine("show single video by id");
                        Console.Write("write id of the video you want:");

                        while (!int.TryParse(Console.ReadLine(), out idSelection))
                        {
                            Console.WriteLine("You need to select an id");

                        }


                        // int showid = selection;

                        if (_videoService.GetVideoById(idSelection) == null)
                        {
                            Console.WriteLine("could not find video");
                            Console.ReadLine();
                        }
                        else
                        {


                            Console.WriteLine(_videoService.GetVideoById(idSelection));
                            Console.ReadLine();
                        }


                        break;
                    case 3:
                        // TODO: add input validation
                        Console.WriteLine("Add video");
                        Console.WriteLine("Enter title");
                        string title = Console.ReadLine();
                        DateTime date;

                        Console.WriteLine("Enter release date, day/month/year");
                        while (!DateTime.TryParse(Console.ReadLine(), out date))
                        {
                            Console.WriteLine("You need to select a valid date");

                        }

                      

                        Console.ReadLine();
                        Console.WriteLine("Enter storyline");
                        string storyline = Console.ReadLine();

                        Console.ReadLine();
                        Console.WriteLine("Enter genre");
                        string action = Console.ReadLine();

                        _videoService.CreateVideo(new Video(title, date, storyline, action));

                        Console.ReadLine();
                        break;
                    case 4:
                        // TODO: finish creating deletion. 
                        Console.WriteLine("Delete video");
                        Console.Write("write the id of the video you wish to delete:");
                        while (!int.TryParse(Console.ReadLine(), out idSelection))
                        {
                            Console.WriteLine("You need to select an id");

                        }

                        Console.WriteLine(_videoService.DeleteVideo(idSelection)
                            ? "video was deleted successfully"
                            : "video could not be deleted or the wrong id was typed");
                        Console.ReadLine();

                        break;
                    case 5:
                        Console.WriteLine("Edit video");
                        Console.Write("write the id of the video you wish to edit:");
                        while (!int.TryParse(Console.ReadLine(), out idSelection))
                        {
                            Console.WriteLine("You need to select an id");

                        }

                        Video selectedVideo;
                        selectedVideo = _videoService.GetVideoById(idSelection);


                        if (selectedVideo == null)
                        {
                            Console.WriteLine("could not find video");
                            Console.ReadLine();
                        }
                        else
                        {


                            Console.WriteLine(_videoService.GetVideoById(idSelection));
                            Console.ReadLine();
                            Console.WriteLine("Select what part of the video you want to edit");

                            string[] updateMenuItems =
                            {
                                "Edit Title",
                                "Edit ReleaseDate",
                                "Edit Storyline",
                                "Edit Genre",
                                "Exit"
                            };
                            var editSelection = 0;

                            while (editSelection != 5)
                            {
                                

                                editSelection = ShowMenu(updateMenuItems);
                                //int editIdSelection;
                                Console.ReadLine();

                                
                                switch (editSelection)
                                {
                                        

                                    case 1:
                                        string editTitle;
                                        Console.WriteLine("Edit Title");
                                        Console.Write("write new title:");
                                        editTitle = Console.ReadLine();

                                        while (editTitle == null || editTitle.Length <= 0)
                                        {
                                            Console.Write("title has to have a length higher then 0:");
                                            editTitle = Console.ReadLine();
                                        }

                                        editedVideo = selectedVideo;
                                        editedVideo.Title = editTitle;

                                        if (_videoService.EditVideo(editedVideo) != null)
                                        {
                                            Console.WriteLine("the update was successful");
                                            Console.WriteLine(_videoService.GetVideoById(idSelection)); 
                                            Console.ReadLine();

                                        }
                                        else
                                        {
                                            Console.Write("the update was unsuccessful");
                                            Console.ReadLine();
                                        }

                                        break;

                                    case 2:
                                        DateTime editReleaseDate;
                                        Console.WriteLine("Edit releasedate");

                                        Console.WriteLine("Enter release date, day/month/year");
                                        while (!DateTime.TryParse(Console.ReadLine(), out editReleaseDate))
                                        {
                                            Console.WriteLine("You need to select a valid date");

                                        }


                                        editedVideo = selectedVideo;
                                        editedVideo.ReleaseDate = editReleaseDate;

                                        if (_videoService.EditVideo(editedVideo) != null)
                                        {
                                            Console.WriteLine("the update was successful");
                                            Console.WriteLine(_videoService.GetVideoById(idSelection)); 
                                            Console.ReadLine();

                                        }
                                        else
                                        {
                                            Console.Write("the update was unsuccessful"); 
                                            Console.ReadLine();
                                        }

                                        break;

                                    case 3:
                                        string editStoryline;
                                        Console.WriteLine("Edit Storyline");
                                        Console.Write("write new Storyline:");
                                        editStoryline = Console.ReadLine();

                                        while (editStoryline == null || editStoryline.Length <= 0)
                                        {
                                            Console.Write("the storyline has to have a length higher then 0:");
                                            editStoryline = Console.ReadLine();
                                        }

                                        editedVideo = selectedVideo;
                                        editedVideo.Storyline = editStoryline;

                                        if (_videoService.EditVideo(editedVideo) != null)
                                        {
                                            Console.WriteLine("the update was successful");
                                            Console.WriteLine(_videoService.GetVideoById(idSelection));
                                            Console.ReadLine();

                                        }
                                        else
                                        {
                                            Console.Write("the update was unsuccessful");
                                            Console.ReadLine();
                                        }

                                        break;

                                    case 4:
                                        string editGenre;
                                        Console.WriteLine("Edit Genre");
                                        Console.Write("write new Genre:");
                                        editGenre = Console.ReadLine();

                                        while (editGenre == null || editGenre.Length <= 0)
                                        {
                                            Console.Write("the genre has to have a length higher then 0:");
                                            editGenre = Console.ReadLine();
                                        }

                                        editedVideo = selectedVideo;
                                        editedVideo.Genre = editGenre;

                                        if (_videoService.EditVideo(editedVideo) != null)
                                        {
                                            Console.WriteLine("the update was successful");
                                            Console.WriteLine(_videoService.GetVideoById(idSelection));
                                            Console.ReadLine();

                                        }
                                        else
                                        {
                                            Console.Write("the update was unsuccessful");
                                            Console.ReadLine();
                                        }

                                        break;



                                }


                             

                            }

                        }

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
            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > menuItems.Length)
            {
                Console.WriteLine("You need to select a menu item");

            }
            Console.WriteLine("Selection " + selection);
            return selection;
        }
    }
}
