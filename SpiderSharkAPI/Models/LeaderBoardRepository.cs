using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using SpiderSharkAPI.Models;

namespace SpiderSharkAPI.Models
{
    public class LeaderBoardRepository
    {
        private List<LeaderboardEntry> entries;
        public LeaderBoardRepository()
        {
            entries = new List<LeaderboardEntry>();
        }

        public bool InsertLeaderBoardEntry(LeaderboardEntry entry)
        {
            entries.Add(entry);
            return true;
        }

        public List<LeaderboardEntry> GetEntries()
        {
            return entries;
        }
    }

}