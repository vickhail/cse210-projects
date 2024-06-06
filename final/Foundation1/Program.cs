using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    public class Comment
    {
        private string commenterName;
        private string commentText;

        public Comment(string commenterName, string commentText)
        {
            this.commenterName = commenterName;
            this.commentText = commentText;
        }

        public string GetCommenterName()
        {
            return commenterName;
        }

        public string GetCommentText()
        {
            return commentText;
        }
    }

    public class Video
    {
        private string title;
        private string author;
        private int lengthInSeconds;
        private List<Comment> comments;

        public Video(string title, string author, int lengthInSeconds)
        {
            this.title = title;
            this.author = author;
            this.lengthInSeconds = lengthInSeconds;
            this.comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            comments.Add(comment);
        }

        public int GetNumberOfComments()
        {
            return comments.Count;
        }

        public void DisplayVideoInfo()
        {
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Author: " + author);
            Console.WriteLine("Length: " + lengthInSeconds + " seconds");
            Console.WriteLine("Number of Comments: " + GetNumberOfComments());
            Console.WriteLine("Comments:");
            foreach (Comment comment in comments)
            {
                Console.WriteLine("- " + comment.GetCommenterName() + ": " + comment.GetCommentText());
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Video> videos = new List<Video>();

            Video video1 = new Video("10 Tips for a Productive Morning Routine", "SillySocksGuru", 300);
            Video video2 = new Video("Exploring the Haunted Mansion at Midnight", "CaptainPineapple", 450);
            Video video3 = new Video("Crazy Stunt Jumps Gone Wrong!", "LaughingLlama", 600);

            video1.AddComment(new Comment("OrdinaryPotato", "Wow, these tips really helped me start my day on the right foot! Thank you for sharing!"));
            video1.AddComment(new Comment("BoringUsername123", "Sorry, but these tips are just common sense. Nothing groundbreaking here"));
            video1.AddComment(new Comment("TheMasterofCupcakes", "OMG, I tried these tips and now my mornings are so productive that I accidentally invented a time machine!"));

            video2.AddComment(new Comment("SeriousSunglasses", "This video gave me the chills! You're so brave for exploring the haunted mansion alone. Great content!"));
            video2.AddComment(new Comment("AverageJoesVlogs", "Seriously? Another fake paranormal investigation video? These are getting old and boring."));
            video2.AddComment(new Comment("FunkyMonkeyDoodle", "LOL, I can't believe you got scared by a ghost that was clearly just a bedsheet with googly eyes!"));

            video3.AddComment(new Comment("QuirkyPenguin", "Wow, your jumps were incredible! So glad to see you're okay after that crazy crash. Keep pushing the limits!"));
            video3.AddComment(new Comment("PlainWhiteWallpaper", "Sorry, but these stunts are just reckless and dangerous. You're setting a bad example for your viewers."));
            video3.AddComment(new Comment("ZanyZebraInvasion", "Haha, you should try jumping over a herd of unicorns next time! That would be epic!"));

            videos.Add(video1);
            videos.Add(video2);
            videos.Add(video3);

            foreach (Video video in videos)
            {
                video.DisplayVideoInfo();
            }
        }
    }
}