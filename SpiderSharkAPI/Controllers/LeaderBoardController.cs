using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SpiderSharkAPI.Models;
using SpiderSharkAPI.Filters;

namespace SpiderSharkAPI.Controllers
{
    public class LeaderboardController : ApiController
    {
        LeaderBoardRepository repository;
        public LeaderboardController()
        {
            if(repository == null)
            {
                repository = new LeaderBoardRepository();
            }

        }

        [HttpPost]
        [HMACAuth]
        [ActionName("upload")]
        public IHttpActionResult PostLeaderboardEntry(LeaderboardEntry entry)
        {
            if (ModelState.IsValid)
            {
                bool success = repository.UploadScore(entry);
                return Ok(success);                
            }
            else
            {
                return BadRequest("Invalid leader board entry:" + entry.ToString());
            }
        }



        [HttpGet]
        [ActionName("all_scores")]
        public IHttpActionResult GetScores(string acccoundId)
        {
            if(acccoundId != null && acccoundId.Length > 0)
            {
                List<LeaderboardEntry> data = repository.GetAllScores(acccoundId);
                return Ok(data);
            }
            else
            {
                return BadRequest("Invalid accoundId:" + acccoundId.ToString());
            }

        }

        [HttpGet]
        [ActionName("top_10")]
        public IHttpActionResult GetTopTen()
        {
            List<LeaderboardEntry> data = repository.GetTopTen();
            return Ok(data);
        }
    }
}
