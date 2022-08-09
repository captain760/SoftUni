namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";


        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("Plays");
            XmlSerializer serializer = new XmlSerializer(typeof(PlayImportDto[]),root);
            PlayImportDto[] plays;
            List<Play> validPlays = new List<Play>();

            using (StringReader reader = new StringReader(xmlString))
            {
                plays = (PlayImportDto[])serializer.Deserialize(reader);
            }

            foreach (var play in plays)
            {
                if (!IsValid(play))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                TimeSpan duration = TimeSpan.ParseExact(play.Duration, "c", CultureInfo.InvariantCulture);

                if (duration.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!Enum.TryParse(typeof(Genre), play.Genre, out var genre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validPlays.Add(new Play() 
                {
                    Description = play.Description,
                    Duration = duration,
                    Genre = (Genre)genre,
                    Rating = play.Rating,
                    Screenwriter = play.Screenwriter,
                    Title = play.Title
                });

                sb.AppendLine(String.Format(SuccessfulImportPlay, play.Title, play.Genre, play.Rating.ToString(CultureInfo.InvariantCulture)));
            }

            context.Plays.AddRange(validPlays);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("Casts");
            XmlSerializer serializer = new XmlSerializer(typeof(CastImportDto[]), root);
            CastImportDto[] casts;
            List<Cast> validCasts = new List<Cast>();

            using (StringReader reader = new StringReader(xmlString))
            {
                casts = (CastImportDto[])serializer.Deserialize(reader);
            }

            foreach (var cast in casts)
            {
                if (!IsValid(cast))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validCasts.Add(new Cast()
                {
                    FullName = cast.FullName,
                    IsMainCharacter = cast.IsMainCharacter,
                    PhoneNumber = cast.PhoneNumber,
                    PlayId = cast.PlayId
                });

                sb.AppendLine(String.Format(SuccessfulImportActor, cast.FullName, cast.IsMainCharacter ? "main" : "lesser"));
            }

            context.Casts.AddRange(validCasts);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            List<Theatre> validTheatres = new List<Theatre>();

            var theatres = JsonConvert.DeserializeObject<ProjectionImportDto[]>(jsonString);

            foreach (var theatre in theatres)
            {
                if (!IsValid(theatre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Theatre validTheatre = new Theatre()
                {
                    Director = theatre.Director,
                    Name = theatre.Name,
                    NumberOfHalls = theatre.NumberOfHalls
                };

                foreach (var ticket in theatre.Tickets)
                {
                    if (!IsValid(ticket))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    validTheatre.Tickets.Add(new Ticket() 
                    {
                        PlayId = ticket.PlayId,
                        Price = ticket.Price,
                        RowNumber = ticket.RowNumber
                    });
                }

                validTheatres.Add(validTheatre);
                sb.AppendLine(String.Format(SuccessfulImportTheatre, validTheatre.Name, validTheatre.Tickets.Count));
            }

            context.Theatres.AddRange(validTheatres);
            context.SaveChanges();

            return sb.ToString().Trim();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
