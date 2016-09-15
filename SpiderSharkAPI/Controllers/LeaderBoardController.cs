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
        static LeaderBoardRepository repository;
        public LeaderboardController()
        {
            if(repository == null)
            {
                repository = new LeaderBoardRepository();
            }

        }

        [HttpPost]
        [HMACAuth]
        [ActionName("Upload")]
        public IHttpActionResult PostLeaderboardEntry(LeaderboardEntry entry)
        {
            if (ModelState.IsValid)
            {
                bool success = repository.InsertLeaderBoardEntry(entry);
                return Ok(success);                
            }
            else
            {
                return BadRequest("Invalid leader board entry:" + entry.ToString());
            }
        }

        [HttpGet]
        public IHttpActionResult Status(int pageSize, int pageIndex)
        {
            List<LeaderboardEntry> data = repository.GetEntries();
            return Ok(data);
        }
    }
}
