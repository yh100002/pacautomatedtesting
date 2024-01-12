using Microsoft.AspNetCore.Mvc;
using POC.AutomatedTesting.DTOs;
using System.Net;

namespace POC.AutomatedTesting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacPlatformTeamMembersController : ControllerBase
    {
        private static List<TeamMember> _teamMembers = new List<TeamMember>()
        {
            new TeamMember() { Id = 1, Name = "Gertjan", Email = "aaa@paclp.com", Role = "Team Leader1" },
            new TeamMember() { Id = 2, Name = "Youngho", Email = "young@paclp.com", Role = "Team Leader2" },
            new TeamMember() { Id = 3, Name = "Jesvin",Email= "jes@paclp.com", Role = "Team Leader3" },
            new TeamMember() { Id = 4, Name = "Jaap", Email = "jap@htec.com", Role = "Team Leader4" },
            new TeamMember() { Id = 5, Name = "Irena", Email = "irena@htec.com", Role = "Team Leader5" },
            new TeamMember() { Id = 6, Name = "Miodrag", Email = "md@htec.com", Role = "Team Leader6" },
            new TeamMember() { Id = 7, Name = "Darko", Email = "dk@htec.com", Role = "Team Leader7" }
        };

        public PacPlatformTeamMembersController() { }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<TeamMember> GetTeamMember(int id)
        {
            TeamMember teamMember = _teamMembers.Find(p => p.Id == id);

            if (teamMember == null)
                return NotFound(id);
            else
                return Ok(teamMember);
        }
        
        [HttpGet]
        [Route("[action]")]
        public ActionResult<IEnumerable<TeamMember>> GetMembersByRole(string search)
        {
            var items = _teamMembers.Where(p => p.Role.Contains(search));
            if (items.ToList().Count > 0)
                return Ok(items);
            else
                return NotFound(search);         
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<IEnumerable<TeamMember>> GetAllCurrentTeamMembers()
        {
            return Ok(_teamMembers);
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<TeamMember> AddTeamMember(TeamMember p)
        {
            if (p == null) return NotFound(p);

            _teamMembers.Add(p);

            return CreatedAtAction("AddTeamMember", p);
        }

        [HttpDelete]
        [Route("[action]")]
        public ActionResult<IEnumerable<TeamMember>> DeleteTeamMember(int id)
        {
            TeamMember pro = _teamMembers.Find(p => p.Id == id);

            if(pro == null) return NotFound(id);

            _teamMembers.Remove(pro);            

            return Ok(_teamMembers);
        }

        [HttpPut]
        [Route("[action]")]
        public ActionResult<TeamMember> UpdateTeamMember(TeamMember p)
        {
            TeamMember pro = _teamMembers.Find(pr => pr.Id == p.Id);

            if (pro == null)
                return NotFound(p);

            pro.Id = p.Id; 
            pro.Name = p.Name; 
            pro.Role = p.Role;
            pro.Email = p.Email;

            return Ok(pro);
        }


    }
}
