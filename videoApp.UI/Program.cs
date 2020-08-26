using System;
using VideoApp.core;
using VideoApp.core.ApplicationServices;
using VideoApp.core.DomainServices;
using VideoApp.Core.Entity;
using VideoApp.infraStructure.Data;

namespace VideoApp.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            IVideoRepository videoRepository = new VideoTable();
            videoRepository.InitData();
            IVideoService videoService = new VideoService(videoRepository);
            Printer print = new Printer(videoService);
            print.PrintMenu();
        }
    }
}
