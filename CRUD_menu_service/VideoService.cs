using System;
using System.Collections.Generic;
using System.Text;
using CRUD_menu_DAL;
using CRUD_menu_models;

namespace CRUD_menu_BLL
{
  public class VideoService
    {
        public static List<Video> GetVideos()
        {
            return VideoTable.Videos;
        }

        public static Video CreateVideo(Video video)
        {
           return VideoTable.AddVideo(video);


        }


    }
}
