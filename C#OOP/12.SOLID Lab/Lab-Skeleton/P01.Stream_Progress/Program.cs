using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            IFile file = new File("bobo", 100, 25);
            StreamProgressInfo progress = new StreamProgressInfo(file);
            Console.WriteLine(progress.CalculateCurrentPercent());
            IFile audio = new Music("bobo", "First", 50, 25);
            StreamProgressInfo progressAudio = new StreamProgressInfo(audio);
            Console.WriteLine(progressAudio.CalculateCurrentPercent());
            IFile video = new Video("toto", 200, 135);
            StreamProgressInfo progressVideo = new StreamProgressInfo(video);
            Console.WriteLine(progressVideo.CalculateCurrentPercent());
        }
    }
}
