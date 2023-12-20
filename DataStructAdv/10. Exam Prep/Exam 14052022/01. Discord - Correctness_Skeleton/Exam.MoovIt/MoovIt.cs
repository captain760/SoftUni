using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MoovIt
{
    public class MoovIt : IMoovIt
    {
        Dictionary<string, Route> routes = new Dictionary<string, Route>(); 
       
       

        public int Count => routes.Count;

        public void AddRoute(Route route)
        {
            if (Contains(route))
            {
                throw new ArgumentException();
            }
            routes.Add(route.Id, route);
        }

        public void ChooseRoute(string routeId)
        {
            if (!routes.ContainsKey(routeId))
            {
                throw new ArgumentException();
            }
            var rt = routes[routeId];
            rt.Popularity++;
        }

        public bool Contains(Route route)
        {
            string start = route.LocationPoints[0];
            string end = route.LocationPoints[route.LocationPoints.Count-1];
            double dist = route.Distance;
            if (routes.ContainsKey(route.Id))
            {
                return true;
            }
            bool isCont = false;
            foreach (var rt in routes.Values)
            {
                if (rt.Distance == dist && rt.LocationPoints[0] == start && rt.LocationPoints[rt.LocationPoints.Count - 1] == end)
                {
                    isCont = true;
                    break;
                }
            }
            return isCont;
            
        }

        public IEnumerable<Route> GetFavoriteRoutes(string destinationPoint)
        {
            return routes.Values.Where(x=>x.IsFavorite==true && x.LocationPoints.IndexOf(destinationPoint)>0)
                                .OrderBy(x=>x.Distance)
                                .ThenByDescending(x=>x.Popularity);
        }

        public Route GetRoute(string routeId)
        {
            if (!routes.ContainsKey(routeId))
            {
                throw new ArgumentException();
            }
            return routes[routeId];
        }

        public IEnumerable<Route> GetTop5RoutesByPopularityThenByDistanceThenByCountOfLocationPoints()
        {
            return routes.Values.OrderByDescending(x=>x.Popularity)
                                .ThenBy(x=>x.Distance)
                                .ThenBy(x=>x.LocationPoints.Count)
                                .Take(5);
        }

        public void RemoveRoute(string routeId)
        {
            if (!routes.ContainsKey(routeId))
            {
                throw new ArgumentException();
            }
            routes.Remove(routeId);
        }

        public IEnumerable<Route> SearchRoutes(string startPoint, string endPoint)
        {

           return routes.Values.Where(route => route.LocationPoints.Contains(startPoint) 
                                               && route.LocationPoints.Contains(endPoint) 
                                               && route.LocationPoints.IndexOf(startPoint) < route.LocationPoints.IndexOf(endPoint))
                .OrderBy(x => x.IsFavorite)
                .ThenBy(x => x.LocationPoints.IndexOf(endPoint) - x.LocationPoints.IndexOf(startPoint))
                .ThenByDescending(x => x.Popularity);
        }
    }
}
