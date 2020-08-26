using System;
using System.Collections.Generic;
using System.Text;
using VideoApp.Core.Entity;

namespace VideoApp.core.DomainServices
{
   public interface IVideoRepository
   {
       public Video AddVideo(Video video);

       public Video EditVideo(Video video,int index);

       public List<Video> GetVideos();

       public void InitData();

   }
}
