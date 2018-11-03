using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiEAP.Entity;
using apiEAP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiEAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberLoginController : ControllerBase
    {
        private readonly apiEAPContext _context;

        public MemberLoginController(apiEAPContext context)
        {
            _context = context;
        }
        // POST: api/Members
        [HttpPost]
        public async Task<IActionResult> PostMember([FromBody] MemberLogin member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Member existMember = _context.Member.FirstOrDefault(m => m.Email == member.Email);
            if (existMember == null)
            {
                return NotFound();
            }

            if (PasswordHandle.GetInstance().EncryPassword(member.Password, existMember.Salt) == null)
            {
                return StatusCode(403, new { status = 403, message = "Invalid" });
            }

            ShCredential credential = ShCredential.GenerateCredential(existMember.Id, CredentialScope.Basic);
            _context.ShCredentials.Add(credential);
            _context.SaveChanges();
            return new JsonResult(credential);
        }
    

    }
}