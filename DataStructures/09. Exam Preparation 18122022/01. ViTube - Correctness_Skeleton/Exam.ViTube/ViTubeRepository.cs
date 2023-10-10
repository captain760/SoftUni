using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.ViTube
{
    public class ViTubeRepository : IViTubeRepository
    {
        private Dictionary<string, User> users = new Dictionary<string, User>();
        private Dictionary<string, Video> videos = new Dictionary<string, Video>();
        public bool Contains(User user)
        {
            return users.ContainsKey(user.Id);
        }

        public bool Contains(Video video)
        {
           return videos.ContainsKey(video.Id); 
        }

        public void DislikeVideo(User user, Video video)
        {
            if (!users.ContainsKey(user.Id) || !videos.ContainsKey(video.Id))
            {
                throw new ArgumentException();
            }
            users[user.Id].Videos.Add(video);
            //users[user.Id].Videos.FirstOrDefault(x=>x.Id==video.Id).Dislikes++;
            videos[video.Id].Dislikes++;
        }

        public IEnumerable<User> GetPassiveUsers()
        {
            var pu = new List<User>();
            
            foreach (var user in users.Values)
            {
                bool isNotPassive = false;
                foreach (var v in user.Videos)
                {
                    if (v.Dislikes!=0 || v.Likes!=0 || v.Views!=0)
                    {
                        isNotPassive = true;
                        break;
                    }
                }
                if (!isNotPassive)
                {
                    pu.Add(user);
                }
            }
            return pu;
        }

        public IEnumerable<User> GetUsersByActivityThenByName()
        {
            var us = users.Values.OrderByDescending(x => x.Videos.Sum(z => z.Views)).ThenByDescending(x => x.Videos.Sum(y => y.Likes + y.Dislikes)).ThenBy(x => x.Username);
            return us;
        }

        public IEnumerable<Video> GetVideos()
        {
            return videos.Values;
        }

        public IEnumerable<Video> GetVideosOrderedByViewsThenByLikesThenByDislikes()
        {
            var vo = videos.Values.OrderByDescending(x => x.Views).ThenByDescending(x => x.Likes).ThenBy(x => x.Dislikes);
            return vo;
        }

        public void LikeVideo(User user, Video video)
        {
            if (!users.ContainsKey(user.Id) || !videos.ContainsKey(video.Id))
            {
                throw new ArgumentException();
            }
            users[user.Id].Videos.Add(video);
            //users[user.Id].Videos.FirstOrDefault(x => x.Id == video.Id).Likes++;
            videos[video.Id].Likes++;
        }

        public void PostVideo(Video video)
        {
            if (!videos.ContainsKey(video.Id))
            {
                videos.Add(video.Id, video);

            }
        }

        public void RegisterUser(User user)
        {
            if (!users.ContainsKey(user.Id))
            {
                users.Add(user.Id, user);

            }
        }

        public void WatchVideo(User user, Video video)
        {
            if (!users.ContainsKey(user.Id) || !videos.ContainsKey(video.Id))
            {
                throw new ArgumentException();
            }
            users[user.Id].Videos.Add(video);
            //users[user.Id].Videos.FirstOrDefault(x => x.Id == video.Id).Views++;
            videos[video.Id].Views++;
        }
    }
}
