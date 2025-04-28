using BusinessModel.Contracts;
using DemoMvcApp.Mappers;
using DemoMvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvcApp.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipeService _recipeService;
        private readonly ILogger<RecipesController> _logger;

        public RecipesController(IRecipeService recipeService, ILogger<RecipesController> logger)
        {
            _recipeService = recipeService;
            _logger = logger;
        }

        // GET: RecipesController
        public async Task<ActionResult> Index(int pageNumber = 1, int pageSize = 12)
        {
            var paginatedList = await _recipeService.GetAll(pageNumber, pageSize);
            return View(paginatedList.Select(e => e.ToViewModel()));
        }

        // GET: RecipesController/Details/5
        public async Task<ActionResult> Details(long id)
        {
            var model = await _recipeService.GetById(id);
            return View(model?.ToViewModel());
        }

        // GET: RecipesController/Create
        public ActionResult Create()
        {
            return View(new CreateRecipeViewModel());
        }

        // POST: RecipesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateRecipeViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.Image != null)
                    {
                        var fileName = model.Image.FileName;
                        using var stream = model.Image.OpenReadStream();
                        await _recipeService.AddWithImage(model.ToDomainModel(), fileName, stream);
                    } 
                    else
                    {
                        await _recipeService.Add(model.ToDomainModel());
                    }

                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    ModelState.AddModelError("", ex.Message);
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(e => e.Errors)
                    .Select(e => e.ErrorMessage);
                ModelState.AddModelError("", string.Join(Environment.NewLine, errors));
            }

            // Wichtig: Wir geben das Model der View zurück, da ansonsten alle Daten im Formular gelöscht werden
            return View(model);
        }

        // GET: RecipesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RecipesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: RecipesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                var success = await _recipeService.Delete(id);
                if (success)
                {
                    return RedirectToAction(nameof(Index));
                } 
                else
                {
                    ModelState.AddModelError("", "Rezept konnte nicht gelöscht werden.");
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ModelState.AddModelError("", ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
