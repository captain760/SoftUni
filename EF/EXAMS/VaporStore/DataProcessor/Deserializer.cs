namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
        private const string ErrorMessage = "Invalid Data";
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
            StringBuilder sb = new StringBuilder();
            List<Developer> developers = new List<Developer>();
            List<Genre> genres = new List<Genre>();
            List<Tag> tags = new List<Tag>();

            var games = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);
            List<Game> validGames = new List<Game>();
            foreach (var game in games)
            {
                if (!IsValid(game))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                DateTime relDate;
                bool isRelDateValid = DateTime.TryParseExact(game.ReleaseDate, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out relDate);
                if (!isRelDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                };
                Developer d = new Developer()
                {
                    Name = game.Developer
                };
                if (!developers.Any(x => x.Name == game.Developer))
                {
                    developers.Add(d);
                }
                
                Genre g = new Genre()
                {
                    Name=game.Genre
                };
                if (!genres.Any(x => x.Name == game.Genre))
                {             
                    genres.Add(g);
                }

                Game validGame = new Game()
                {
                    Name = game.Name,
                    Price = game.Price,
                    ReleaseDate = relDate,
                    Developer = developers.First(y=>y.Name == game.Developer),
                    Genre = genres.First(y=>y.Name == game.Genre)
                };
                if (game.Tags.Count==0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                foreach (var t in game.Tags)
                {
                    if (String.IsNullOrEmpty(t))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    Tag tag = new Tag()
                    {
                        Name = t
                    };
                    if (!tags.Any(x => x.Name == t))
                    {
                        tags.Add(tag);
                    }
                    GameTag gt = new GameTag()
                    {
                        Tag = tags.First(y=>y.Name==t)
                    };
                    validGame.GameTags.Add(gt);
                }
                
                validGames.Add(validGame);
                sb.AppendLine($"Added {validGame.Name} ({validGame.Genre.Name}) with {validGame.GameTags.Count} tags");
            }

            context.Games.AddRange(validGames);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
            StringBuilder sb = new StringBuilder();
            var users = JsonConvert.DeserializeObject<ImportUsersDto[]>(jsonString);
            List<User> validUsers = new List<User>();
            foreach (var user in users)
            {
                if (!IsValid(user))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
               
                User validUser = new User()
                {
                    FullName = user.FullName,
                    Username = user.Username,
                    Email = user.Email,
                    Age = user.Age
                };
                if (user.Cards.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                foreach (var c in user.Cards)
                {
                    if (!IsValid(c))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    bool isTypeValid = Enum.TryParse(typeof(CardType), c.Type, out object typeObj);
                    if (!isTypeValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    Card card = new Card()
                    {
                        Number = c.Number,
                        Cvc = c.Cvc,
                        Type = (CardType)typeObj
                    };
                    
                    validUser.Cards.Add(card);
                }

                validUsers.Add(validUser);
                sb.AppendLine($"Imported {validUser.Username} with {validUser.Cards.Count} cards");
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
            List<ImportPurchaseDto> dtoPurchases = DeserializeIt<ImportPurchaseDto>(xmlString, "Purchases");
            StringBuilder sb = new StringBuilder();
            List<Purchase> validPurchases = new List<Purchase>();
            foreach (ImportPurchaseDto pDto in dtoPurchases)
            {
                if (!IsValid(pDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Game g = context.Games.FirstOrDefault(z => z.Name == pDto.Title);
                Card card = context.Cards.FirstOrDefault(z => z.Number == pDto.CardNumber);
                if (g == null || card == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                bool isPurTypeValid = Enum.TryParse(typeof(PurchaseType), pDto.Type, out object purTypeObj);
                if (!isPurTypeValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                DateTime purDate;
                bool isPurDateValid = DateTime.TryParseExact(pDto.Date, "dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out purDate);
                if (!isPurDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Purchase p = new Purchase()
                {
                    Game = g,
                    Type = (PurchaseType)purTypeObj,
                    ProductKey = pDto.ProductKey,
                    Card = card,
                    GameId = g.Id,
                    Date = purDate

                };
                validPurchases.Add(p);
                sb.AppendLine($"Imported {p.Game.Name} for {p.Card.User.Username}");
            }
            context.Purchases.AddRange(validPurchases);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
		private static List<T> DeserializeIt<T>(string inputXml, string rootName)
		{
			XmlRootAttribute xmlRootAttribute = new XmlRootAttribute(rootName);
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>), xmlRootAttribute);

			using StringReader reader = new StringReader(inputXml);

			List<T> DtoT = (List<T>)xmlSerializer.Deserialize(reader);

			return DtoT;
		}
	}
}