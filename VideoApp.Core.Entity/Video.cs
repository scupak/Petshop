using System;

namespace VideoApp.Core.Entity
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Storyline { get; set; }
        public string Genre { get; set; }

        public Video(string title, DateTime releaseDate, string storyline , string genre)
        {
            Title = title;
            ReleaseDate = releaseDate;
            Storyline = storyline;
            Genre = genre;

        }

        public override string ToString()
        {
            return ($"{Id}:{Title}:{ReleaseDate}:{Storyline}: {Genre}");
        }
    }
}
