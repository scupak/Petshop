using CRUD_menu_models;
using System;
using System.Collections.Generic;

namespace CRUD_menu_DAL
{
    public class VideoTable
    {
        public static int Id = 0;
        public static List<Video> Videos = new List<Video>();

        public static Video AddVideo(Video video) {

            Id++;
            video.Id = Id;
            Videos.Add(video);
            return video;
        
        
        
        
        }
    }
}
