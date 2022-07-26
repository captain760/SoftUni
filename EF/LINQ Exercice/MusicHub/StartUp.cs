namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            //Problem 02
            
            //Console.WriteLine(ExportAlbumsInfo(context,9));

            //Don't Give Up
            //Problem 03
            Console.WriteLine(ExportSongsAboveDuration(context, 240));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var allAlbums = context
                .Albums
                .Where(a => a.ProducerId == producerId)               
                .Include(a=>a.Producer)
                .Include(a=>a.Songs)
                .ThenInclude(a=>a.Writer)
                .ToArray()
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy",CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    TotalAlbumPrice = a.Songs.Sum(a => a.Price),
                    AlbumSongs = a
                        .Songs
                        .Select(s => new
                        {
                            SongName = s.Name,
                            SongPrice = s.Price,
                            SongWriterName = s.Writer.Name
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.SongWriterName)
                        .ToArray()
                })
                .OrderByDescending(a => a.TotalAlbumPrice)
                .ToArray();
            var sb = new StringBuilder();
            foreach (var album in allAlbums)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine($"-Songs:");
                int songsCounter = 1;
                foreach (var sg in album.AlbumSongs)
                {
                    sb.AppendLine($"---#{songsCounter++}");
                    sb.AppendLine($"---SongName: {sg.SongName}");
                    sb.AppendLine($"---Price: {sg.SongPrice:f2}");
                    sb.AppendLine($"---Writer: {sg.SongWriterName}");
                }
                sb.AppendLine($"-AlbumPrice: {album.TotalAlbumPrice:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            
           var songsAbove = context
                .Songs
                .Include(s=>s.SongPerformers)
                .ThenInclude(s=>s.Performer)
                .Include(s=>s.Writer)
                .Include(s=>s.Album)
                .ThenInclude(s=>s.Producer)
                .ToArray()
                .Where(s => s.Duration.TotalSeconds > duration)
                
                .Select(s => new
                {
                    s.Name,
                    
                    PerformerName = s.SongPerformers.Select(sp=>$"{sp.Performer.FirstName} {sp.Performer.LastName}").FirstOrDefault(),                    
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    DurationTime = s.Duration.ToString("c")
                })
                .OrderBy(s => s.Name)
                .ThenBy(s=>s.WriterName)
                .ThenBy(s=>s.PerformerName)
                .ToArray();
            var sb = new StringBuilder();
            int songCounter = 1;
            foreach (var s in songsAbove)
            {
                sb.AppendLine($"-Song #{songCounter++}");
                sb.AppendLine($"---SongName: {s.Name}");
                sb.AppendLine($"---Writer: {s.WriterName}");
                sb.AppendLine($"---Performer: {s.PerformerName}");
                sb.AppendLine($"---AlbumProducer: {s.AlbumProducer}");
                sb.AppendLine($"---Duration: {s.DurationTime}");               
            }
            return sb.ToString().TrimEnd();
        }
    }
}
