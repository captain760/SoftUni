using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            //input of the three elements
            Dictionary<string, List<string>> playerPositionSkill = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();
            while (input != "Season end")
            {
                if (input.Contains("->"))
                {


                    string[] token = input.Split(" -> ");
                    string player = token[0];
                    string position = token[1];
                    string skill = token[2];


                    if (playerPositionSkill.ContainsKey(player))
                    {
                        if (playerPositionSkill[player].Contains(position))
                        {
                            if (int.Parse(playerPositionSkill[player][playerPositionSkill[player].IndexOf(position) + 1]) < int.Parse(skill))
                            {
                                playerPositionSkill[player][playerPositionSkill[player].IndexOf(position) + 1] = skill;
                            }

                        }
                        else
                        {
                            playerPositionSkill[player].Add(position);
                            playerPositionSkill[player].Add(skill);

                        }
                    }
                    else
                    {
                        List<string> userPointList = new List<string>();
                        userPointList.Add(position);
                        userPointList.Add(skill);

                        playerPositionSkill.Add(player, userPointList);
                    }
                }
                else
                {
                    string[] token = input.Split(" vs ");
                    string player1 = token[0];
                    string player2 = token[1];
                    // current total points summation
                    Dictionary<string, int> currentListPlayerPoints = new Dictionary<string, int>();
                    foreach (var cont in playerPositionSkill)
                    {

                        int pts = 0;
                        for (int m = 0; m < cont.Value.Count - 1; m += 2)
                        {
                            
                            pts += int.Parse(cont.Value[m + 1]);
                                             
                        }
                        currentListPlayerPoints.Add(cont.Key,pts);
                    }

                    if (currentListPlayerPoints.ContainsKey(player1) && currentListPlayerPoints.ContainsKey(player2))
                    {

                        for (int j = 0; j < playerPositionSkill[player1].Count ; j += 2)
                        {
                            string currentPosition = playerPositionSkill[player1][j];
                            if (playerPositionSkill[player2].Contains(currentPosition))
                            {
                                if (currentListPlayerPoints[player1]>currentListPlayerPoints[player2])
                                {
                                    playerPositionSkill.Remove(player2);
                                    break;
                                }
                                else if (currentListPlayerPoints[player2] > currentListPlayerPoints[player1])
                                {
                                    playerPositionSkill.Remove(player1);
                                    break;
                                }
                                
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }
            // current total points summation
            Dictionary<string, int> playerPointsFinal = new Dictionary<string, int>();
            foreach (var cont in playerPositionSkill)
            {

                int pts = 0;
                for (int m = 0; m < cont.Value.Count - 1; m += 2)
                {

                    pts += int.Parse(cont.Value[m + 1]);

                }
                playerPointsFinal.Add(cont.Key, pts);
            }
            
            //printing individual statistics
            playerPointsFinal = playerPointsFinal.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            
            int i = 1;
            foreach (var item in playerPointsFinal)
            {

                Console.WriteLine($"{item.Key}: {item.Value} skill");
                // all the positions and skills for a player
                Dictionary<string, int> positionSkills = new Dictionary<string, int>();
                
                    for (int m = 0; m < playerPositionSkill[item.Key].Count - 1; m += 2)
                    {
                        string position = playerPositionSkill[item.Key][m];
                        int skill = int.Parse(playerPositionSkill[item.Key][m + 1]);

                        positionSkills.Add(position, skill);

                    }
                positionSkills = positionSkills.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
                foreach (var posit in positionSkills)
                {
                    Console.WriteLine($"- {posit.Key} <::> {posit.Value}");
                }

                i++;
            }
        }
    }
}
