using System;
using System.Linq;

namespace Exam.ViTube
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ViTuRe = new ViTubeRepository();
            Video video1 = new Video("1","v1",12.5,0,0,0);  
            Video video2 = new Video("2", "v2", 11.5, 0, 0, 0);
            Video video3 = new Video("3", "v3", 13.5, 0, 0, 0);

            User user1 = new User("1", "u1");
            User user2 = new User("2", "u2");
            User user3 = new User("3", "u3");

            ViTuRe.RegisterUser(user1);
            ViTuRe.RegisterUser(user2);
            ViTuRe.RegisterUser(user3);
            ViTuRe.PostVideo(video1);
            ViTuRe.PostVideo(video2);
            ViTuRe.PostVideo(video3);

            ViTuRe.DislikeVideo(user3, video3);
            ViTuRe.DislikeVideo(user2, video3);
            //ViTuRe.DislikeVideo(user1, video3);
            ViTuRe.LikeVideo(user2, video1);
            ViTuRe.LikeVideo(user1, video1);
            ViTuRe.WatchVideo(user1, video2);
            ViTuRe.WatchVideo(user2, video2);
            ViTuRe.WatchVideo(user3, video2);

            Console.WriteLine(String.Join(" ,", ViTuRe.GetVideosOrderedByViewsThenByLikesThenByDislikes().Select(x=>x.Title)));
            Console.WriteLine(String.Join(" ,", ViTuRe.GetUsersByActivityThenByName().Select(x=>x.Username)));
        }
    }
}
