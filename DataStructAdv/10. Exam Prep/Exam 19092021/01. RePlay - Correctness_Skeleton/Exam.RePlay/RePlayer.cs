using System;
using System.Collections.Generic;

namespace Exam.RePlay
{
    public class RePlayer : IRePlayer
    {
        public int Count => throw new NotImplementedException();

        public void AddToQueue(string trackName, string albumName)
        {
            throw new NotImplementedException();
        }

        public void AddTrack(Track track, string album)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Track track)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Track> GetAlbum(string albumName)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, List<Track>> GetDiscography(string artistName)
        {
            throw new NotImplementedException();
        }

        public Track GetTrack(string title, string albumName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Track> GetTracksInDurationRangeOrderedByDurationThenByPlaysDescending(int lowerBound, int upperBound)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Track> GetTracksOrderedByAlbumNameThenByPlaysDescendingThenByDurationDescending()
        {
            throw new NotImplementedException();
        }

        public Track Play()
        {
            throw new NotImplementedException();
        }

        public void RemoveTrack(string trackTitle, string albumName)
        {
            throw new NotImplementedException();
        }
    }
}
