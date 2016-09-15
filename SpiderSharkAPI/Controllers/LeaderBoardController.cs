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

        [HttpPost]
        [HMACAuth]
        [ActionName("Upload")]
        public IHttpActionResult PostLeaderboardEntry(LeaderboardEntry entry)
        {
            if (ModelState.IsValid)
            {
                return Ok(entry);
            }
            else
            {
                return BadRequest("Invalid leader board entry:" + entry.ToString());
            }
        }

        [HttpGet]
        public IHttpActionResult Status(int pageSize, int pageIndex)
        {
            List<LeaderboardEntry> data = new List<LeaderboardEntry>();
            data.Add(new LeaderboardEntry());
            data.Add(new LeaderboardEntry());
            return Ok(data);
        }
    }
}
