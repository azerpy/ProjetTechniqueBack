﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projetTechniqueBack.Models;

namespace projetTechniqueBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;

        //creation d'un user au démarrage de l'api
        public UserController(UserContext context)
        {
            _context = context;

            if (_context.AuthentificationItems.Count() == 0)
            {
                _context.AuthentificationItems.Add(new UserItem { Id = "toto@gmail.com", Mdp="toto",
                    Nom="toto" ,
                    Prenom= "toto",
                    Age = 26,
                    Poids= 73,
                    Taille= 176,
                    IsCoach = false
                });
                _context.AuthentificationItems.Add(new UserItem
                {
                    Id = "toto_coach@gmail.com",
                    Mdp = "toto",
                    Nom = "totoCoach",
                    Prenom = "totoCoach",
                    Age = 35,
                    Poids = 85,
                    Taille = 192,
                    IsCoach = true
                });
                _context.SaveChanges();
            }
        }

        // POST: api/Authentification/Login
        [HttpPost("Login")]
        public async Task<ActionResult<UserItem>> PostLogin(UserItem user)
        {
            var AuthentificationItem = await _context.AuthentificationItems.FindAsync(user.Id);

            if (AuthentificationItem == null)
            {
                return NotFound();
            } else
            {
                if (AuthentificationItem.Mdp.Equals(user.Mdp))
                {
                    return AuthentificationItem;
                }
                else
                {
                    return BadRequest();
                }  
            }
        }

        //TODO : A supprimer
        // GET: api/Authentification
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserItem>>> GetAuthentificationItems()
        {
            return await _context.AuthentificationItems.ToListAsync();
        }

        // POST: api/Authentification/Register
        [HttpPost("Register")]
        public async Task<ActionResult<UserItem>> PostAuthentificationItem(UserItem item)
        {
            var AuthentificationItem = await _context.AuthentificationItems.FindAsync(item.Id);

            if (AuthentificationItem == null)
            {
                _context.AuthentificationItems.Add(item);
                await _context.SaveChangesAsync();
                return await _context.AuthentificationItems.FindAsync(item.Id);
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/Authentification/Modification
        [HttpPost("Modification")]
        public async Task<ActionResult<UserItem>> PostModifUserItem(UserItem item)
        {
            var AuthentificationItem = await _context.AuthentificationItems.FindAsync(item.Id);

            if (AuthentificationItem == null)
            {
                _context.AuthentificationItems.Add(item);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        
        //TODO: vérification si personne a le droit 
        // GET: api/Authentification/id
        [HttpPost("GetInfo")]
        public async Task<ActionResult<UserItem>> getUserItem(UserItem user)
        {
            var UserItem = await _context.AuthentificationItems.FindAsync(user.Id);

            if (UserItem == null)
            {
                return BadRequest();
            }
            else
            {
                return UserItem;
            }
        }
    }
}