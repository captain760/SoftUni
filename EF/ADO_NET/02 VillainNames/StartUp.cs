using System;
using System.Data.SqlClient;
using System.Text;

namespace _02_VillainNames
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
            sqlConnection.Open();

            //Problem 02
            //string result = GetVilliansWithMinionsCount(sqlConnection);

            //Problem 03
            //Console.Write("Villain ID:");
            //int villainId = int.Parse(Console.ReadLine());
            //string result = GetVillainWithMinions(sqlConnection, villainId);

            //Problem 04
            //string[] minionInfo = Console.ReadLine()
            //        .Split(": ", StringSplitOptions.RemoveEmptyEntries);
            //string[] info = minionInfo[1]
            //        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            //string[] villainInfo = Console.ReadLine()
            //        .Split(": ", StringSplitOptions.RemoveEmptyEntries);
            //string villainName = villainInfo[1];
            //string minionName = info[0];
            //int minionAge = int.Parse(info[1]);
            //string minionTown = info[2];
            //string result = AddMinion(sqlConnection, villainName, minionName, minionAge, minionTown);

            //Problem 05
            string countryName = Console.ReadLine();
            string result = CapsTowns(sqlConnection, countryName);
                

            Console.WriteLine(result);
            sqlConnection.Close();
        }

        private static string CapsTowns(SqlConnection sqlConnection, string countryName)
        {
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            string townsQuery = @"SELECT
                                    t.[Name]
                                    FROM Towns AS t
                                    JOIN Countries AS c ON t.CountryCode = c.Id
                                    WHERE c.[Name] = @countryName";
            SqlCommand townsQueryCmd = new SqlCommand(townsQuery, sqlConnection,sqlTransaction);
            townsQueryCmd.Parameters.AddWithValue("@countryName", countryName);
            using SqlDataReader townsNames = townsQueryCmd.ExecuteReader();
            if (townsNames == null)
            {
                return $"No town names were affected.";
            }
           
            StringBuilder sb = new StringBuilder();
            
            try
            {
                int counter = 1;
                int secondCounter = 1;
                while (townsNames.Read())
                {
                    counter++;
                }
                townsNames.Close();
                
                sb.AppendLine($"{counter-1} town names were affected.");
                sb.Append("[");
                string updateNameQuery = @"   UPDATE Towns
                                                SET [Name] = UPPER([Name])
                                                WHERE [Name] in (SELECT
                                                t.[Name]
                                                FROM Towns AS t
                                                JOIN Countries AS c ON t.CountryCode = c.Id
                                                WHERE c.[Name] = @countryName)";
                SqlCommand updateNameCmd = new SqlCommand(updateNameQuery, sqlConnection, sqlTransaction);
                updateNameCmd.Parameters.AddWithValue("@countryName", countryName);
                updateNameCmd.ExecuteNonQuery();
                using SqlDataReader townsNames2 = townsQueryCmd.ExecuteReader();
                while (townsNames2.Read())
                {
                    sb.Append($"{townsNames2["Name"].ToString().ToUpper()}");
                    
                    if (secondCounter != counter - 1)
                    {
                        sb.Append(", ");
                    }
                    secondCounter++;
                }
                sb.Append(']');
                //sqlTransaction.Commit();
            }
            catch (Exception e)
            {
                //sqlTransaction.Rollback();
                return e.ToString();
            }
                        
            return sb.ToString().TrimEnd();
        }

        private static string AddMinion(SqlConnection sqlConnection, string villainName, string minionName, int minionAge, string minionTown)
        {
            StringBuilder sb = new StringBuilder();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                int townId = GetTownId(sqlConnection, sqlTransaction, sb, minionTown);
                int villainId = GetVillainId(sqlConnection, villainName, sb, sqlTransaction);

                
                string addMinionQuery = @"INSERT INTO Minions([Name], [Age], [TownId])
                                               VALUES
                                                      (@minionName, @minionAge,@townId)";
                SqlCommand addMinionCmd = new SqlCommand(addMinionQuery, sqlConnection, sqlTransaction);
                addMinionCmd.Parameters.AddWithValue("@minionName", minionName);
                addMinionCmd.Parameters.AddWithValue("@minionAge", minionAge);
                addMinionCmd.Parameters.AddWithValue("@townId", townId);
                addMinionCmd.ExecuteNonQuery();

                string getMinionId = @"SELECT [Id]
                                        FROM Minions
                                        WHERE [Name] = @minionName";
                SqlCommand getMinionIdCmd = new SqlCommand(getMinionId, sqlConnection, sqlTransaction);
                getMinionIdCmd.Parameters.AddWithValue("@minionName", minionName);
                int minionId = (int)getMinionIdCmd.ExecuteScalar();

                string assignMinionQuery = @"INSERT INTO MinionsVillains(MinionId, VillainId)
                                                  VALUES
                                                        (@minionId, @villainId)";
                SqlCommand assignMinionCmd = new SqlCommand(assignMinionQuery, sqlConnection, sqlTransaction);
                assignMinionCmd.Parameters.AddWithValue("@minionId", minionId);
                assignMinionCmd.Parameters.AddWithValue("@villainId", villainId);
                assignMinionCmd.ExecuteNonQuery();
                sb.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");
                sqlTransaction.Commit();
            }
            catch (Exception e)
            {
                sqlTransaction.Rollback();
                return e.ToString();
            }
            

            return sb.ToString().TrimEnd();
        }

        private static int GetVillainId(SqlConnection sqlConnection, string villainName, StringBuilder sb, SqlTransaction sqlTransaction)
        {
            string villainIdQuery = @"SELECT Id
                                            FROM Villains
                                            WHERE [Name] = @villainName";
            int villainId;
            SqlCommand villainFindCmd = new SqlCommand(villainIdQuery, sqlConnection, sqlTransaction);
            villainFindCmd.Parameters.AddWithValue("@villainName", villainName);
            object villainIdReader = villainFindCmd.ExecuteScalar();
            if (villainIdReader == null)
            {
                string addVillainQuery = @"INSERT INTO Villains ([Name], EvilnessFactorId)
                                                    VALUES
                                                    (@villainName, 4)";
                SqlCommand addVillainCmd = new SqlCommand(addVillainQuery, sqlConnection, sqlTransaction);
                addVillainCmd.Parameters.AddWithValue("@villainName", villainName);
                addVillainCmd.ExecuteNonQuery();
                sb.AppendLine($"Villain {villainName} was added to the database.");
            }
            villainId = (int)villainFindCmd.ExecuteScalar();
            return villainId;
        }

        public static int GetTownId(SqlConnection sqlConnection, SqlTransaction sqlTransaction, StringBuilder sb, string minionTown)
        {
            string townIdQuery = @"SELECT [Id]
                                   FROM Towns
                                  WHERE [Name] = @townName";
            int townId;
            SqlCommand townFindCmd = new SqlCommand(townIdQuery, sqlConnection, sqlTransaction);
            townFindCmd.Parameters.AddWithValue("@townName", minionTown);
            object townIdReader = townFindCmd.ExecuteScalar();
            if (townIdReader == null)
            {
                string addTownQuery = @"INSERT INTO [Towns]([Name]) VALUES (@townName)";
                SqlCommand addTownCmd = new SqlCommand(addTownQuery, sqlConnection, sqlTransaction);
                addTownCmd.Parameters.AddWithValue("@townName", minionTown);
                addTownCmd.ExecuteNonQuery();
                sb.AppendLine($"Town {minionTown} was added to the database.");                
            }
            townId = (int)townFindCmd.ExecuteScalar();
            return townId;
        }

        private static string GetVilliansWithMinionsCount(SqlConnection sqlConnection)
        {

            StringBuilder sb = new StringBuilder();
                string query = "SELECT v.Name,COUNT(MinionId) AS MinionCount FROM Villains AS v JOIN MinionsVillains AS mv ON v.Id = mv.VillainId GROUP BY v.Id, v.Name HAVING COUNT(MinionId)>3 ORDER BY MinionCount DESC";

            SqlCommand sqlTableCommand = new SqlCommand(query, sqlConnection);
            using SqlDataReader tableView = sqlTableCommand.ExecuteReader();
            while (tableView.Read())
            {
                string name = (string)tableView["Name"];
                int count = (int)tableView["MinionCount"];
                 sb.AppendLine($"{name} - {count}");
            }
            tableView.Close();
            return sb.ToString().TrimEnd();
        }
        private static string GetVillainWithMinions(SqlConnection sqlConnection, int villainId)
        {
            StringBuilder sb = new StringBuilder();
            string villainNameQuery = @"SELECT [Name] FROM [Villains] WHERE [Id] = @villainId";
            using SqlCommand getVillainNameQuery = new SqlCommand(villainNameQuery, sqlConnection);
            getVillainNameQuery.Parameters.AddWithValue("@villainId", villainId);
            string villainName = (string)getVillainNameQuery.ExecuteScalar();
            if (villainName == null)
            {
                return $"No villain with ID {villainId} exists in the database.";
            }
            string villainMinionsTable = @"SELECT 
                                            ROW_NUMBER() OVER (ORDER BY m.[Name]) AS RowNumber,
                                            m.[Name],
                                            m.Age
                                            FROM Minions AS m
                                            JOIN MinionsVillains AS mv ON m.Id = mv.MinionId
                                            WHERE mv.VillainId = @villainId";
            SqlCommand getVillainMinions = new SqlCommand(villainMinionsTable, sqlConnection);
            getVillainMinions.Parameters.AddWithValue("@villainId", villainId);
            using SqlDataReader VillainMinionsTable = getVillainMinions.ExecuteReader();
            
            sb.AppendLine($"Villain: {villainName}");
            if (!VillainMinionsTable.HasRows)
            {
                sb.AppendLine("(no minions)");
            }
            else
            {
                while (VillainMinionsTable.Read())
                {
                    sb.AppendLine($"{(Int64)VillainMinionsTable["RowNumber"]}. {(string)VillainMinionsTable["Name"]} {(int)VillainMinionsTable["Age"]}");
                }
            }
            VillainMinionsTable.Close();
            return sb.ToString().TrimEnd();

        }
    }
}
