using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using SpiderSharkAPI.Models;

namespace SpiderSharkAPI.Models
{
    public class LeaderBoardRepository
    {
        const string uri = "mongodb://root:sprinter0*@ds033106.mlab.com:33106/race_leaderboard_db";

        private MongoClient client;
        private IMongoDatabase db;
        public LeaderBoardRepository()
        {
            try
            {
                client = new MongoClient(uri);
                db = client.GetDatabase("race_leaderboard_db");
            }
            catch (MongoConfigurationException configEx)
            {
                Console.Write(configEx.ToString());
            }
            catch
            {

            }


        }

        public bool UploadScore(LeaderboardEntry entry)
        {
            if(db != null)
            {
                var collection = db.GetCollection<LeaderboardEntry>("scores");

                collection.InsertOneAsync(entry);

                return true;
            }
            return false;
        }

        public  List<LeaderboardEntry> GetAllScores(string accoundId)
        {
            if(db != null)
            {
                var collection = db.GetCollection<LeaderboardEntry>("scores");
                var filter = Builders<LeaderboardEntry>.Filter.Eq<string>("AccoundID", accoundId);
                var results = collection.Find(filter);
                return results.ToList();
            }
            
            return null;
        }

        public List<LeaderboardEntry> GetTopTen()
        {

            return null;
        }
    }

}