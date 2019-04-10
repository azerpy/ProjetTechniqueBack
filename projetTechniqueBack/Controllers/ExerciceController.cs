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
    public class ExerciceController : ControllerBase
    {
        private readonly ExerciceContext _context;

        //creation d'un user au démarrage de l'api
        public ExerciceController(ExerciceContext context)
        {
            _context = context;

            if (_context.ExerciceItems.Count() == 0)
            {
                _context.ExerciceItems.Add(new ExerciceItem { Id = 1, Titre = "Abdos", Type="Musculation", Description="description", Image= "https://medias.lequipe.fr/img-ilosport-jpg/abdominaux/1500000000607686/39:72,764:589-850-550-75/56e3e.jpg" });
                _context.SaveChanges();
            }
        }

        // GET: api/Exercice
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExerciceItem>>> GetExerciceItems()
        {
            return await _context.ExerciceItems.ToListAsync();
        }

        //POST : api/Exercices/CreateExercice
        [HttpPost("CreateExercice")] 
        public async Task<ActionResult<UserItem>> PostCreateExercice(ExerciceItem item)
        {
            //var AuthentificationItem = await _context.ExerciceItems.FindAsync(item.Id);

            //if (AuthentificationItem == null)
            //{
                item.Id = FindMaxId(_context.ExerciceItems.ToList()) +1;
                _context.ExerciceItems.Add(item);
                await _context.SaveChangesAsync();
                return Ok(item.Id);
            //}
            //else
            //{
            //    return BadRequest();
            //}
        }

        public long FindMaxId(List<ExerciceItem> list)
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Empty list");
            }
            long maxId = long.MinValue;
            foreach (ExerciceItem type in list)
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