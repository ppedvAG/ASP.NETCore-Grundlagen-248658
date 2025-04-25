using BusinessLogic.Models.Enums;
using BusinessModel.Contracts;
using BusinessModel.Data;
using BusinessModel.Models;
using BusinessModel.Services;
using Microsoft.Extensions.Options;
using Moq;

namespace BusinessModel.Tests.Tests
{
    [TestClass]
    public sealed class RecipeServiceTests
    {
        private readonly Mock<IFileService> _mockFileService = new Mock<IFileService>();
        private DeliveryDbContext _context;

        public IFileService FileService => _mockFileService.Object;

        [TestInitialize]
        public void Setup()
        {
            _context = new TestDatabase().Context;
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            await _context.DisposeAsync();
        }


        /// <summary>
        /// Benamung: ZuTestendeMethode_Szenario_ErwartetesErgebnis
        /// </summary>
        [TestMethod]
        public async Task GetAll_LoadFromDatabase_ReturnsListOfRecipes()
        {
            // Arrange
            var recipeService = new RecipeService(_context, FileService);

            // Act 
            var result = await recipeService.GetAll();

            // Assertions auf das Ergebnis
            Assert.IsNotNull(result, "Die Liste mit Rezepten sollte nicht null sein.");
            Assert.IsTrue(result.Count > 0, "Die Liste mit Rezepten sollte nicht leer sein.");
            Assert.IsTrue(result[0].MealType.Length > 0, "Das erste Rezept sollte einen MealType enthalten.");
            Assert.IsTrue(result[0].ImageUrl.Length > 0, "Das erste Rezept sollte eine ImageUrl enthalten.");
        }

        [TestMethod]
        public async Task GetById_LoadFromDatabase_ReturnsRecipeWithGivenId()
        {
            // Arrange
            var recipeService = new RecipeService(_context, FileService);

            // Act
            var result = await recipeService.GetById(Seed.DEFAULT_RECIPE_ID);

            // Assert
            Assert.IsNotNull(result, "Das Rezept sollte nicht null sein.");
            Assert.AreEqual(Seed.DEFAULT_RECIPE_ID, result.Id, "Die Id des Rezepts sollte gleich sein.");
        }

        [TestMethod]
        public async Task Add_NewRecipe_IncreasesRecipeCount()
        {
            // Arrange
            string expectedName = "Test Recipe";
            var recipeService = new RecipeService(_context, FileService);
            var newRecipe = new Recipe
            {
                Name = expectedName,
                MealType = [MealType.Snack.ToString()],
                Cuisine = Cuisine.Indian.ToString(),
                ImageUrl = "https://example.com/test-recipe.jpg",
                Ingredients = [],
                Instructions = [],
                Tags = [],
            };

            // Act
            await recipeService.Add(newRecipe);
            var result = _context.Recipes.Any(r => r.Name == expectedName);

            // Assert
            Assert.IsTrue(result, "Das neue Rezept sollte in der Liste sein.");
        }

        [TestMethod]
        public async Task Add_NewRecipeWithImage_IncreasesRecipeCount()
        {
            // Arrange
            string expectedName = "Test Recipe";
            string fileName = "test-image.jpg";
            var stream = new MemoryStream();

            _mockFileService
                .Setup(x => x.UploadFile(fileName, It.IsAny<Stream>()))
                // Alternative: Beliebigen FileName als Argument akzeptieren mit It.IsAny<string>()
                //.Setup(x => x.UploadFile(It.IsAny<string>(), It.IsAny<Stream>()))
                .ReturnsAsync($"https://example.com/files/{fileName}");

            var recipeService = new RecipeService(_context, FileService);
            var newRecipe = new Recipe
            {
                Name = expectedName,
                MealType = [MealType.Snack.ToString()],
                Cuisine = Cuisine.Indian.ToString(),
                Ingredients = [],
                Instructions = [],
                Tags = [],
            };

            // Act
            await recipeService.AddWithImage(newRecipe, fileName, stream);
            var result = _context.Recipes.Any(r => r.Name == expectedName);

            // Assert
            Assert.IsTrue(result, "Das neue Rezept sollte in der Liste sein.");
            _mockFileService.Verify(x => x.UploadFile(fileName, stream), Times.Once, "Die Datei sollte hochgeladen werden.");
        }

        [TestMethod]
        public async Task Add_InvalidFileServiceUrl_ThrowsHttpRequestException()
        {
            // Arrange
            var options = new Mock<IOptions<FileServiceOptions>>();
            options.Setup(x => x.Value).Returns(new FileServiceOptions
            {
                BaseUrl = "https://example.com"
            });

            var fileService = new RemoteFileService(options.Object, new HttpClient());
            var recipeService = new RecipeService(_context, fileService);

            // Act
            var task = recipeService.AddWithImage(new Recipe(), "abc", new MemoryStream());

            // Assert
            var ex = await Assert.ThrowsExceptionAsync<HttpRequestException>(async () => await task);
            //Assert.IsTrue(ex.Message.StartsWith("File could not be uploaded."), ex.Message);
        }

        [TestMethod]
        public async Task Update_ExistingRecipe_UpdatesRecipeDetails()
        {
            // Arrange
            var recipeService = new RecipeService(_context, FileService);
            var existingRecipe = _context.Recipes.First();
            existingRecipe.Name = "Updated Recipe Name";

            // Act
            var updateResult = await recipeService.Update(existingRecipe);
            var updatedRecipe = await recipeService.GetById(existingRecipe.Id);

            // Assert
            Assert.IsTrue(updateResult, "Das Rezept sollte erfolgreich aktualisiert werden.");
            Assert.AreEqual("Updated Recipe Name", updatedRecipe.Name, "Der Name des Rezepts sollte aktualisiert sein.");
        }

        [TestMethod]
        public async Task Delete_ExistingRecipe_RemovesRecipeFromDatabase()
        {
            // Arrange
            var recipeService = new RecipeService(_context, FileService);
            var existingRecipe = _context.Recipes.First();

            // Act
            var deleteResult = await recipeService.Delete(existingRecipe.Id);
            var result = await recipeService.GetAll();

            // Assert
            Assert.IsTrue(deleteResult, "Das Rezept sollte erfolgreich gelöscht werden.");
            Assert.IsFalse(result.Any(r => r.Id == existingRecipe.Id), "Das Rezept sollte nicht mehr in der Liste sein.");
        }
    }
}
