﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiEAP.Entity;
using apiEAP.Models;

namespace apiEAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly apiEAPContext _context;

        public MembersController(apiEAPContext context)
        {
            _context = context;
        }

        // GET: api/Members
        [HttpGet]
        public IEnumerable<Member> GetMember()
        {
            return _context.Member;
        }

        // GET: api/Members/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMember([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var member = await _context.Member.FindAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        // PUT: api/Members/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember([FromRoute] long id, [FromBody] Member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != member.Id)
            {
                return BadRequest();
            }

            _context.Entry(member).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Members
        [HttpPost]
        public async Task<IActionResult> PostMember([FromBody] Member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            member.Salt = PasswordHandle.GetInstance().GenerateSalt();
            member.Password = PasswordHandle.GetInstance().EncryPassword(member.Password,member.Salt);

            _context.Member.Add(member);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMember", new { id = member.Id }, member);
        }

        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var member = await _context.Member.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            _context.Member.Remove(member);
            await _context.SaveChangesAsync();

            return Ok(member);
        }

        private bool MemberExists(long id)
        {
            return _context.Member.Any(e => e.Id == id);
        }
    }
}