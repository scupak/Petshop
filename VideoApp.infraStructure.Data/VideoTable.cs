using System;
using System.Collections.Generic;
using VideoApp.core.DomainServices;
using VideoApp.Core.Entity;


namespace VideoApp.infraStructure.Data
{
    public class VideoTable : IVideoRepository
    {
        public int Id;
        public List<Video> Videos;

        public VideoTable()
        {
            Id = 0;
            Videos = new List<Video>();


        }

        public void InitData()
        {
            Id++;
            Video hulk = new Video("hulk", DateTime.Now, "smart boy get angery", "action");
            hulk.Id = Id;
            Videos.Add(hulk);

        }

        public Video AddVideo(Video video) {

            Id++;
            video.Id = Id;
            Videos.Add(video);
            return video;
        
        
        
        
        }

        public Video EditVideo(Video video, int index)
        {

            Videos[index] = video;
            return Videos[index];

        }

        public List<Video> GetVideos()
        {
            return Videos;
        }
    }
    }
