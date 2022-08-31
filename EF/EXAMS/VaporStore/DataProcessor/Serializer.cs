namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
            var genres = context
              .Genres
              .Where(i => genreNames.Contains(i.Name) )
              .ToArray()
              .Select(x => new
              {
                  Id = x.Id,
                  Genre = x.Name,
                  Games = x.Games
                  .Where(i=>i.Purchases.Any())
                      .Select(y => new
                        {
                            Id =y.Id,
                            Title = y.Name,
                            Developer = y.Developer.Name,
                            Tags = String.Join(", ",y.GameTags.Select(q=>q.Tag.Name)),
                            Players = y.Purchases.Count                      
                        })
                      .OrderByDescending(p=>p.Players)
                      .ThenBy(g=>g.Id),
                   TotalPlayers =x.Games.Sum(w=>w.Purchases.Count)
              })
              .OrderByDescending(k => k.TotalPlayers)
              .ThenBy(i => i.Id)
              .ToArray();
            string json = JsonConvert.SerializeObject(genres, Formatting.Indented);
            return json;
        }

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
            PurchaseType ptEnum = Enum.Parse<PurchaseType>(storeType);
            List<ExportUsersDto> usersDto = context
                .Users
                .Where(q => q.Cards.Any(p => p.Purchases.Any()) )
                .ToList()
                .Select(x => new ExportUsersDto
                {
                    Username = x.Username,
                    Purchases = context
                        .Purchases
                        .Where(p=>p.Type == ptEnum && p.Card.User.Username == x.Username)
                        .ToList()
                        .OrderBy(x => x.Date)
                        .Select(y => new ExportPurchaseDto
                        {
                            CardNumber = y.Card.Number,
                            CardCvc = y.Card.Cvc,
                            PurDate = y.Date.ToString("yyyy-MM-dd HH:mm",CultureInfo.InvariantCulture),
                            GameDetails = new ExportGameDto
                                            {
                                                GameName = y.Game.Name,
                                                Genre = y.Game.Genre.Name,
                                                GamePrice = y.Game.Price
                                            }
                                            
                        })               
                        .ToList(),
                    TotalSpent = context
                    .Purchases
                    .Where(z=>z.Card.User.Username == x.Username && z.Type==ptEnum)
                    .Sum(e=>e.Game.Price)
                })
                .Where(o=>o.Purchases.Count>0)
                .OrderByDescending(n => n.TotalSpent)
                .ThenBy(i => i.Username)
                .ToList();
            string result = SerializeIt<ExportUsersDto>(usersDto, "Users");
            return result;
        }

		private static string SerializeIt<T>(List<T> DtoT, string rootName)
		{
			XmlRootAttribute xmlRootAttribute = new XmlRootAttribute(rootName);
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>), xmlRootAttribute);
			StringBuilder SBOutput = new StringBuilder();
			using StringWriter writer = new StringWriter(SBOutput);
			XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
			namespaces.Add("", "");
			xmlSerializer.Serialize(writer, DtoT, namespaces);

			return SBOutput.ToString().TrimEnd();

		}
	}
}