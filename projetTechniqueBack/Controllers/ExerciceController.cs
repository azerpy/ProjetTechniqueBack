using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projetTechniqueBack.Models;

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
                _context.ExerciceItems.Add(new ExerciceItem { Id = 1, Titre = "Exercie1", Type="Type1", Description="description", Image="img1" });
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
            var AuthentificationItem = await _context.ExerciceItems.FindAsync(item.Id);

            if (AuthentificationItem == null)
            {
                _context.ExerciceItems.Add(item);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}