using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGame.Data;
using VideoGame.Data.Entities;
using System.Threading;
using VideoGame.Models;

namespace VideoGame.Controllers
{
    public class GamesController : Controller
    {
        private readonly DataContext _context;

        public GamesController(DataContext context)
        {
            _context = context;
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            return View(await _context.Games.ToListAsync());
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                ViewBag.Message = "El videojuego fue creado exitosamente";
            }            
            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Games.FindAsync(id);
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.Id == id);
        }

        // GET: Games/Riesgo
        public async Task<IActionResult> Riesgo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            var riesgo = await _context.Riesgos
                .FirstOrDefaultAsync(m => m.gameId == id);
            if (riesgo == null)
            {
                var soloJuego = new RiesgoViewModel
                {
                    Games = game

                };
                return View(soloJuego);
            }
            var model = new RiesgoViewModel
            {
                Games = game,
                Riesgos = riesgo

            };
            return View(model);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Riesgo(int id,  RiesgoViewModel riesgoViewModel )
        {
            riesgoViewModel.Riesgos.gameId = id;

            var riesgo = new Riesgo
            {
                Nombre = riesgoViewModel.Riesgos.Nombre, 
                Descripcion = riesgoViewModel.Riesgos.Descripcion,
                TipoRiesgo = riesgoViewModel.Riesgos.TipoRiesgo,
                gameId = riesgoViewModel.Riesgos.gameId
            };

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(riesgo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(riesgoViewModel.Games.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(riesgoViewModel);
        }


        public async Task<IActionResult> Mejora(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            var mejora = await _context.OpcionesMejoras
                .FirstOrDefaultAsync(m => m.gameId == id);
            if (mejora == null)
            {
                var soloJuego = new MejoraViewModel
                {
                    Games = game

                };
                return View(soloJuego);
            }
            var model = new MejoraViewModel
            {
                Games = game,
                Mejoras = mejora

            };
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Mejora(int id, MejoraViewModel mejoraViewModel)
        {
            mejoraViewModel.Mejoras.gameId = id;

            var mejora = new OpcionesMejora
            {
                Descripcion = mejoraViewModel.Mejoras.Descripcion,
                TipoOpcionMejora = mejoraViewModel.Mejoras.TipoOpcionMejora,
                gameId = mejoraViewModel.Mejoras.gameId
            };

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mejora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(mejoraViewModel.Games.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mejoraViewModel);
        }

    }
}
