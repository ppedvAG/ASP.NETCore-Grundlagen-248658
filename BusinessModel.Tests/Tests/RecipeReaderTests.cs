using BusinessModel.Data;

namespace BusinessModel.Tests.Tests
{
    [TestClass]
    public sealed class RecipeReaderTests
    {
        /// <summary>
        /// Benamung der Testmethoden:
        /// ZuTestendeMethode_Szenorio_ErwartetesErgebnis
        /// </summary>
        [TestMethod]
        public void FromJsonFile_ReadFromFile_ReturnsListOfRecipes()
        {
            List<Models.Recipe>? result = RecipeReader.FromJsonFile();

            // Assertions auf das Ergebnis
            Assert.IsNotNull(result, "Die Liste mit Rezepten sollte nicht null sein.");
            Assert.IsTrue(result.Count > 0, "Die Liste mit Rezepten sollte nicht leer sein.");
            Assert.IsTrue(result[0].MealType.Length > 0, "Das erste Rezept sollte einen MealType enthalten.");
            Assert.IsTrue(result[0].ImageUrl.Length > 0, "Das erste Rezept sollte eine ImageUrl enthalten.");
        }
    }
}
