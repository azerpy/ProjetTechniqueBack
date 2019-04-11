using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projetTechniqueBack.Models;
using System;

namespace projetTechniqueBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvenementController : ControllerBase
    {
        private readonly EvenementContext _context;

        //creation d'un user au démarrage de l'api
        public EvenementController(EvenementContext context)
        {
            _context = context;
            
        }

        // GET: api/Exercice
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EvenementItem>>> GetExerciceItems()
        {
            return await _context.EvenementItems.ToListAsync();
        }

        //POST : api/Evenement/CreateEvenement
        [HttpPost("CreateEvenement")]
        public async Task<ActionResult<EvenementItem>> PostCreateExercice(EvenementItem item)
        {
            item.Id = FindMaxId(_context.EvenementItems.ToList()) + 1;
            _context.EvenementItems.Add(item);
            await _context.SaveChangesAsync();
            return Ok(item.Id);
        }

        public long FindMaxId(List<EvenementItem> list)
        {
            if (list.Count == 0)
            {
                return 0;
            }
            long maxId = long.MinValue;
            foreach (EvenementItem type in list)
            {
                if (type.Id > maxId)
                {
                    maxId = type.Id;
                }
            }
            return maxId;
        }
    }
}