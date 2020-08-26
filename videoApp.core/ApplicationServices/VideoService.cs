using System.Collections.Generic;
using VideoApp.core.DomainServices;
using VideoApp.Core.Entity;


namespace VideoApp.core.ApplicationServices
{
  public class VideoService : IVideoService
  {
        private IVideoRepository _VideoTable;
        public VideoService(IVideoRepository VideoTable)
        {
            _VideoTable = VideoTable;


        }

        public Video GetVideoById(int id)
        {
            return _VideoTable.GetVideos().Find(x => x.Id == id);
        }

        public List<Video> GetVideos()
        {
            return _VideoTable.GetVideos();
        }

        public Video CreateVideo(Video video)
        {
           return _VideoTable.AddVideo(video);


        }

        /**
         * TODO refactor so you dont have to use find twice. 
         */
        public bool DeleteVideo(int id)
        {
            if (_VideoTable.GetVideos().Find(x => x.Id == id) != null)
            {
                _VideoTable.GetVideos().Remove(_VideoTable.GetVideos().Find(x => x.Id == id));
                return true;

            }
            else
            {
                return false;
            }

        }

        public Video EditVideo(Video video)
        {
            int index = _VideoTable.GetVideos().FindLastIndex(c => c.Id == video.Id);

           return _VideoTable.EditVideo(video, index);

        }
  }
}
