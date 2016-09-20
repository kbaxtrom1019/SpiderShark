using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpiderSharkAPI.Models;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Threading.Tasks;

namespace SpiderSharkAPI.Models
{
    public class LeaderBoardRepository
    {
        private const string uri = "pub-redis-11176.us-east-1-2.5.ec2.garantiadata.com:11176";
        private const string password = "sprinter0*";
        private ConnectionMultiplexer redis;
        private IDatabase db;

        public LeaderBoardRepository()
        {
            ConfigurationOptions config = new ConfigurationOptions
            {
                EndPoints = { uri },
                Password = password
            };

            try
            {
                redis = ConnectionMultiplexer.Connect(config);
                db = redis.GetDatabase();
            }
            catch(Exception e)
            {
                Console.Write(e);
            }
        }

        public bool UploadScore(LeaderboardEntry entry)
        {
            if(db != null)
            {
                var result = db.SortedSetAdd("leaderboard", JsonConvert.SerializeObject(entry), entry.Score);
                return result;
            }
            return false;
        }

        //public List<LeaderboardEntry> GetAllScores(string accoundId)
        //{
        //    if(db != null)
        //    {
        //        List<LeaderboardEntry> items = new List<LeaderboardEntry>();
        //        var result = db.SortedSetRangeByRank("leaderboard", order:Order.Descending);
        //        foreach(RedisValue item in result)
        //        {
        //            items.Add(JsonConvert.DeserializeObject<LeaderboardEntry>(item.ToString()));
        //        }
        //        return items;
        //    }
            
        //    return null;
        //}

        public List<LeaderboardEntry> GetTopTen()
        {
            if(db != null)
            {
                List<LeaderboardEntry> items = new List<LeaderboardEntry>();
                var result = db.SortedSetRangeByRank("leaderboard", order: Order.Descending, start:0, stop : 9);
                foreach (RedisValue item in result)
                {
                    items.Add(JsonConvert.DeserializeObject<LeaderboardEntry>(item.ToString()));
                }
                return items;
            }

            return null;
        }
    }

}