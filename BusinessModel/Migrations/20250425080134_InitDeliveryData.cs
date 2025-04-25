using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class InitDeliveryData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrepTimeMinutes = table.Column<int>(type: "int", nullable: false),
                    CookTimeMinutes = table.Column<int>(type: "int", nullable: false),
                    Servings = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    Cuisine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaloriesPerServing = table.Column<int>(type: "int", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    ReviewCount = table.Column<int>(type: "int", nullable: false),
                    MealType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeId);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<long>(type: "bigint", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "OrderDate", "Rating", "Status", "UserName" },
                values: new object[] { 1L, new DateTime(2023, 1, 1, 16, 12, 59, 0, DateTimeKind.Unspecified), 6.8f, 0, "John Doe" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "RecipeId", "CaloriesPerServing", "CookTimeMinutes", "Cuisine", "Difficulty", "ImageUrl", "Ingredients", "Instructions", "MealType", "Name", "PrepTimeMinutes", "Rating", "ReviewCount", "Servings", "Tags", "UserId" },
                values: new object[,]
                {
                    { 1L, 300, 15, "Italian", 0, "https://cdn.dummyjson.com/recipe-images/1.webp", "[\"Pizza dough\",\"Tomato sauce\",\"Fresh mozzarella cheese\",\"Fresh basil leaves\",\"Olive oil\",\"Salt and pepper to taste\"]", "[\"Preheat the oven to 475\\u00B0F (245\\u00B0C).\",\"Roll out the pizza dough and spread tomato sauce evenly.\",\"Top with slices of fresh mozzarella and fresh basil leaves.\",\"Drizzle with olive oil and season with salt and pepper.\",\"Bake in the preheated oven for 12-15 minutes or until the crust is golden brown.\",\"Slice and serve hot.\"]", "[\"Dinner\"]", "Classic Margherita Pizza", 20, 4.6f, 98, 4, "[\"Pizza\",\"Italian\"]", 166 },
                    { 2L, 250, 20, "Asian", 1, "https://cdn.dummyjson.com/recipe-images/2.webp", "[\"Tofu, cubed\",\"Broccoli florets\",\"Carrots, sliced\",\"Bell peppers, sliced\",\"Soy sauce\",\"Ginger, minced\",\"Garlic, minced\",\"Sesame oil\",\"Cooked rice for serving\"]", "[\"In a wok, heat sesame oil over medium-high heat.\",\"Add minced ginger and garlic, saut\\u00E9 until fragrant.\",\"Add cubed tofu and stir-fry until golden brown.\",\"Add broccoli, carrots, and bell peppers. Cook until vegetables are tender-crisp.\",\"Pour soy sauce over the stir-fry and toss to combine.\",\"Serve over cooked rice.\"]", "[\"Lunch\"]", "Vegetarian Stir-Fry", 15, 4.7f, 26, 3, "[\"Vegetarian\",\"Stir-fry\",\"Asian\"]", 143 },
                    { 3L, 150, 10, "American", 0, "https://cdn.dummyjson.com/recipe-images/3.webp", "[\"All-purpose flour\",\"Butter, softened\",\"Brown sugar\",\"White sugar\",\"Eggs\",\"Vanilla extract\",\"Baking soda\",\"Salt\",\"Chocolate chips\"]", "[\"Preheat the oven to 350\\u00B0F (175\\u00B0C).\",\"In a bowl, cream together softened butter, brown sugar, and white sugar.\",\"Beat in eggs one at a time, then stir in vanilla extract.\",\"Combine flour, baking soda, and salt. Gradually add to the wet ingredients.\",\"Fold in chocolate chips.\",\"Drop rounded tablespoons of dough onto ungreased baking sheets.\",\"Bake for 10-12 minutes or until edges are golden brown.\",\"Allow cookies to cool on the baking sheet for a few minutes before transferring to a wire rack.\"]", "[\"Snack\",\"Dessert\"]", "Chocolate Chip Cookies", 15, 4.9f, 13, 24, "[\"Cookies\",\"Dessert\",\"Baking\"]", 34 },
                    { 4L, 500, 20, "Italian", 1, "https://cdn.dummyjson.com/recipe-images/4.webp", "[\"Fettuccine pasta\",\"Chicken breast, sliced\",\"Heavy cream\",\"Parmesan cheese, grated\",\"Garlic, minced\",\"Butter\",\"Salt and pepper to taste\",\"Fresh parsley for garnish\"]", "[\"Cook fettuccine pasta according to package instructions.\",\"In a pan, saut\\u00E9 sliced chicken in butter until fully cooked.\",\"Add minced garlic and cook until fragrant.\",\"Pour in heavy cream and grated Parmesan cheese. Stir until the cheese is melted.\",\"Season with salt and pepper to taste.\",\"Combine the Alfredo sauce with cooked pasta.\",\"Garnish with fresh parsley before serving.\"]", "[\"Lunch\",\"Dinner\"]", "Chicken Alfredo Pasta", 15, 4.9f, 82, 4, "[\"Pasta\",\"Chicken\"]", 136 },
                    { 5L, 380, 25, "Mexican", 0, "https://cdn.dummyjson.com/recipe-images/5.webp", "[\"Chicken thighs\",\"Mango, diced\",\"Red onion, finely chopped\",\"Cilantro, chopped\",\"Lime juice\",\"Jalape\\u00F1o, minced\",\"Salt and pepper to taste\",\"Cooked rice for serving\"]", "[\"Season chicken thighs with salt and pepper.\",\"Grill or bake chicken until fully cooked.\",\"In a bowl, combine diced mango, chopped red onion, cilantro, minced jalape\\u00F1o, and lime juice.\",\"Dice the cooked chicken and mix it with the mango salsa.\",\"Serve over cooked rice.\"]", "[\"Dinner\"]", "Mango Salsa Chicken", 15, 4.9f, 63, 3, "[\"Chicken\",\"Salsa\"]", 26 },
                    { 6L, 280, 15, "Mediterranean", 0, "https://cdn.dummyjson.com/recipe-images/6.webp", "[\"Quinoa, cooked\",\"Avocado, diced\",\"Cherry tomatoes, halved\",\"Cucumber, diced\",\"Red bell pepper, diced\",\"Feta cheese, crumbled\",\"Lemon vinaigrette dressing\",\"Salt and pepper to taste\"]", "[\"In a large bowl, combine cooked quinoa, diced avocado, halved cherry tomatoes, diced cucumber, diced red bell pepper, and crumbled feta cheese.\",\"Drizzle with lemon vinaigrette dressing and toss to combine.\",\"Season with salt and pepper to taste.\",\"Chill in the refrigerator before serving.\"]", "[\"Lunch\",\"Side Dish\"]", "Quinoa Salad with Avocado", 20, 4.4f, 59, 4, "[\"Salad\",\"Quinoa\"]", 197 },
                    { 7L, 120, 10, "Italian", 0, "https://cdn.dummyjson.com/recipe-images/7.webp", "[\"Baguette, sliced\",\"Tomatoes, diced\",\"Fresh basil, chopped\",\"Garlic cloves, minced\",\"Balsamic glaze\",\"Olive oil\",\"Salt and pepper to taste\"]", "[\"Preheat the oven to 375\\u00B0F (190\\u00B0C).\",\"Place baguette slices on a baking sheet and toast in the oven until golden brown.\",\"In a bowl, combine diced tomatoes, chopped fresh basil, minced garlic, and a drizzle of olive oil.\",\"Season with salt and pepper to taste.\",\"Top each toasted baguette slice with the tomato-basil mixture.\",\"Drizzle with balsamic glaze before serving.\"]", "[\"Appetizer\"]", "Tomato Basil Bruschetta", 15, 4.7f, 95, 6, "[\"Bruschetta\",\"Italian\"]", 137 },
                    { 8L, 380, 15, "Asian", 1, "https://cdn.dummyjson.com/recipe-images/8.webp", "[\"Beef sirloin, thinly sliced\",\"Broccoli florets\",\"Soy sauce\",\"Oyster sauce\",\"Sesame oil\",\"Garlic, minced\",\"Ginger, minced\",\"Cornstarch\",\"Cooked white rice for serving\"]", "[\"In a bowl, mix soy sauce, oyster sauce, sesame oil, and cornstarch to create the sauce.\",\"In a wok, stir-fry thinly sliced beef until browned. Remove from the wok.\",\"Stir-fry broccoli florets, minced garlic, and minced ginger in the same wok.\",\"Add the cooked beef back to the wok and pour the sauce over the mixture.\",\"Stir until everything is coated and heated through.\",\"Serve over cooked white rice.\"]", "[\"Dinner\"]", "Beef and Broccoli Stir-Fry", 20, 4.7f, 58, 4, "[\"Beef\",\"Stir-fry\",\"Asian\"]", 18 },
                    { 9L, 200, 0, "Italian", 0, "https://cdn.dummyjson.com/recipe-images/9.webp", "[\"Tomatoes, sliced\",\"Fresh mozzarella cheese, sliced\",\"Fresh basil leaves\",\"Balsamic glaze\",\"Extra virgin olive oil\",\"Salt and pepper to taste\"]", "[\"Arrange alternating slices of tomatoes and fresh mozzarella on a serving platter.\",\"Tuck fresh basil leaves between the slices.\",\"Drizzle with balsamic glaze and extra virgin olive oil.\",\"Season with salt and pepper to taste.\",\"Serve immediately as a refreshing salad.\"]", "[\"Lunch\"]", "Caprese Salad", 10, 4.6f, 82, 2, "[\"Salad\",\"Caprese\"]", 128 },
                    { 10L, 400, 20, "Italian", 1, "https://cdn.dummyjson.com/recipe-images/10.webp", "[\"Linguine pasta\",\"Shrimp, peeled and deveined\",\"Garlic, minced\",\"White wine\",\"Lemon juice\",\"Red pepper flakes\",\"Fresh parsley, chopped\",\"Salt and pepper to taste\"]", "[\"Cook linguine pasta according to package instructions.\",\"In a skillet, saut\\u00E9 minced garlic in olive oil until fragrant.\",\"Add shrimp and cook until pink and opaque.\",\"Pour in white wine and lemon juice. Simmer until the sauce slightly thickens.\",\"Season with red pepper flakes, salt, and pepper.\",\"Toss cooked linguine in the shrimp scampi sauce.\",\"Garnish with chopped fresh parsley before serving.\"]", "[\"Dinner\"]", "Shrimp Scampi Pasta", 15, 4.3f, 5, 3, "[\"Pasta\",\"Shrimp\"]", 114 },
                    { 11L, 550, 45, "Pakistani", 1, "https://cdn.dummyjson.com/recipe-images/11.webp", "[\"Basmati rice\",\"Chicken, cut into pieces\",\"Onions, thinly sliced\",\"Tomatoes, chopped\",\"Yogurt\",\"Ginger-garlic paste\",\"Biryani masala\",\"Green chilies, sliced\",\"Fresh coriander leaves\",\"Mint leaves\",\"Ghee\",\"Salt to taste\"]", "[\"Marinate chicken with yogurt, ginger-garlic paste, biryani masala, and salt.\",\"In a pot, saut\\u00E9 sliced onions until golden brown. Remove half for later use.\",\"Layer marinated chicken, chopped tomatoes, half of the fried onions, and rice in the pot.\",\"Top with ghee, green chilies, fresh coriander leaves, mint leaves, and the remaining fried onions.\",\"Cover and cook on low heat until the rice is fully cooked and aromatic.\",\"Serve hot, garnished with additional coriander and mint leaves.\"]", "[\"Lunch\",\"Dinner\"]", "Chicken Biryani", 30, 5f, 32, 6, "[\"Biryani\",\"Chicken\",\"Main course\",\"Indian\",\"Pakistani\",\"Asian\"]", 133 },
                    { 12L, 420, 30, "Pakistani", 0, "https://cdn.dummyjson.com/recipe-images/12.webp", "[\"Chicken, cut into pieces\",\"Tomatoes, chopped\",\"Green chilies, sliced\",\"Ginger, julienned\",\"Garlic, minced\",\"Coriander powder\",\"Cumin powder\",\"Red chili powder\",\"Garam masala\",\"Cooking oil\",\"Fresh coriander leaves\",\"Salt to taste\"]", "[\"In a wok (karahi), heat cooking oil and saut\\u00E9 minced garlic until golden brown.\",\"Add chicken pieces and cook until browned on all sides.\",\"Add chopped tomatoes, green chilies, ginger, and spices. Cook until tomatoes are soft.\",\"Cover and simmer until the chicken is tender and the oil separates from the masala.\",\"Garnish with fresh coriander leaves and serve hot with naan or rice.\"]", "[\"Lunch\",\"Dinner\"]", "Chicken Karahi", 20, 4.8f, 68, 4, "[\"Chicken\",\"Karahi\",\"Main course\",\"Indian\",\"Pakistani\",\"Asian\"]", 49 },
                    { 13L, 380, 35, "Pakistani", 1, "https://cdn.dummyjson.com/recipe-images/13.webp", "[\"Ground beef\",\"Potatoes, peeled and diced\",\"Onions, finely chopped\",\"Tomatoes, chopped\",\"Ginger-garlic paste\",\"Cumin powder\",\"Coriander powder\",\"Turmeric powder\",\"Red chili powder\",\"Cooking oil\",\"Fresh coriander leaves\",\"Salt to taste\"]", "[\"In a pan, heat cooking oil and saut\\u00E9 chopped onions until golden brown.\",\"Add ginger-garlic paste and saut\\u00E9 until fragrant.\",\"Add ground beef and cook until browned. Drain excess oil if needed.\",\"Add diced potatoes, chopped tomatoes, and spices. Mix well.\",\"Cover and simmer until the potatoes are tender and the masala is well-cooked.\",\"Garnish with fresh coriander leaves and serve hot with naan or rice.\"]", "[\"Lunch\",\"Dinner\"]", "Aloo Keema", 25, 4.6f, 53, 5, "[\"Keema\",\"Potatoes\",\"Main course\",\"Pakistani\",\"Asian\"]", 152 },
                    { 14L, 320, 20, "Pakistani", 1, "https://cdn.dummyjson.com/recipe-images/14.webp", "[\"Ground beef\",\"Onions, finely chopped\",\"Tomatoes, finely chopped\",\"Green chilies, chopped\",\"Coriander leaves, chopped\",\"Pomegranate seeds\",\"Ginger-garlic paste\",\"Cumin powder\",\"Coriander powder\",\"Red chili powder\",\"Egg\",\"Cooking oil\",\"Salt to taste\"]", "[\"In a large bowl, mix ground beef, chopped onions, tomatoes, green chilies, coriander leaves, and pomegranate seeds.\",\"Add ginger-garlic paste, cumin powder, coriander powder, red chili powder, and salt. Mix well.\",\"Add an egg to bind the mixture and form into round flat kebabs.\",\"Heat cooking oil in a pan and shallow fry the kebabs until browned on both sides.\",\"Serve hot with naan or mint chutney.\"]", "[\"Lunch\",\"Dinner\",\"Snacks\"]", "Chapli Kebabs", 30, 4.7f, 98, 4, "[\"Kebabs\",\"Beef\",\"Indian\",\"Pakistani\",\"Asian\"]", 152 },
                    { 15L, 280, 30, "Pakistani", 1, "https://cdn.dummyjson.com/recipe-images/15.webp", "[\"Mustard greens, washed and chopped\",\"Spinach, washed and chopped\",\"Cornmeal (makki ka atta)\",\"Onions, finely chopped\",\"Green chilies, chopped\",\"Ginger, grated\",\"Ghee\",\"Salt to taste\"]", "[\"Boil mustard greens and spinach until tender. Drain and blend into a coarse paste.\",\"In a pan, saut\\u00E9 chopped onions, green chilies, and grated ginger in ghee until golden brown.\",\"Add the greens paste and cook until it thickens.\",\"Meanwhile, knead cornmeal with water to make a dough. Roll into rotis (flatbreads).\",\"Cook the rotis on a griddle until golden brown.\",\"Serve hot saag with makki di roti and a dollop of ghee.\"]", "[\"Breakfast\",\"Lunch\",\"Dinner\"]", "Saag (Spinach) with Makki di Roti", 40, 4.3f, 86, 3, "[\"Saag\",\"Roti\",\"Main course\",\"Indian\",\"Pakistani\",\"Asian\"]", 43 },
                    { 16L, 480, 25, "Japanese", 1, "https://cdn.dummyjson.com/recipe-images/16.webp", "[\"Ramen noodles\",\"Chicken broth\",\"Soy sauce\",\"Mirin\",\"Sesame oil\",\"Shiitake mushrooms, sliced\",\"Bok choy, chopped\",\"Green onions, sliced\",\"Soft-boiled eggs\",\"Grilled chicken slices\",\"Norwegian seaweed (nori)\"]", "[\"Cook ramen noodles according to package instructions and set aside.\",\"In a pot, combine chicken broth, soy sauce, mirin, and sesame oil. Bring to a simmer.\",\"Add sliced shiitake mushrooms and chopped bok choy. Cook until vegetables are tender.\",\"Divide the cooked noodles into serving bowls and ladle the hot broth over them.\",\"Top with green onions, soft-boiled eggs, grilled chicken slices, and nori.\",\"Serve hot and enjoy the authentic Japanese ramen!\"]", "[\"Dinner\"]", "Japanese Ramen Soup", 20, 4.9f, 38, 2, "[\"Ramen\",\"Japanese\",\"Soup\",\"Asian\"]", 85 },
                    { 17L, 320, 30, "Moroccan", 0, "https://cdn.dummyjson.com/recipe-images/17.webp", "[\"Chickpeas, cooked\",\"Tomatoes, chopped\",\"Carrots, diced\",\"Onions, finely chopped\",\"Garlic, minced\",\"Cumin\",\"Coriander\",\"Cinnamon\",\"Paprika\",\"Vegetable broth\",\"Olives\",\"Fresh cilantro, chopped\"]", "[\"In a tagine or large pot, saut\\u00E9 chopped onions and minced garlic until softened.\",\"Add diced carrots, chopped tomatoes, and cooked chickpeas.\",\"Season with cumin, coriander, cinnamon, and paprika. Stir to coat.\",\"Pour in vegetable broth and bring to a simmer. Cook until carrots are tender.\",\"Stir in olives and garnish with fresh cilantro before serving.\",\"Serve this flavorful Moroccan dish with couscous or crusty bread.\"]", "[\"Dinner\"]", "Moroccan Chickpea Tagine", 15, 4.5f, 50, 4, "[\"Tagine\",\"Chickpea\",\"Moroccan\"]", 207 },
                    { 18L, 550, 20, "Korean", 1, "https://cdn.dummyjson.com/recipe-images/18.webp", "[\"Cooked white rice\",\"Beef bulgogi (marinated and grilled beef slices)\",\"Carrots, julienned and saut\\u00E9ed\",\"Spinach, blanched and seasoned\",\"Zucchini, sliced and grilled\",\"Bean sprouts, blanched\",\"Fried egg\",\"Gochujang (Korean red pepper paste)\",\"Sesame oil\",\"Toasted sesame seeds\"]", "[\"Arrange cooked white rice in a bowl.\",\"Top with beef bulgogi, saut\\u00E9ed carrots, seasoned spinach, grilled zucchini, and blanched bean sprouts.\",\"Place a fried egg on top and drizzle with gochujang and sesame oil.\",\"Sprinkle with toasted sesame seeds before serving.\",\"Mix everything together before enjoying this delicious Korean bibimbap!\",\"Feel free to customize with additional vegetables or protein.\"]", "[\"Dinner\"]", "Korean Bibimbap", 30, 4.9f, 56, 2, "[\"Bibimbap\",\"Korean\",\"Rice\"]", 121 },
                    { 19L, 420, 45, "Greek", 1, "https://cdn.dummyjson.com/recipe-images/19.webp", "[\"Eggplants, sliced\",\"Ground lamb or beef\",\"Onions, finely chopped\",\"Garlic, minced\",\"Tomatoes, crushed\",\"Red wine\",\"Cinnamon\",\"Allspice\",\"Nutmeg\",\"Olive oil\",\"Milk\",\"Flour\",\"Parmesan cheese\",\"Egg yolks\"]", "[\"Preheat oven to 375\\u00B0F (190\\u00B0C).\",\"Saut\\u00E9 sliced eggplants in olive oil until browned. Set aside.\",\"In the same pan, cook chopped onions and minced garlic until softened.\",\"Add ground lamb or beef and brown. Stir in crushed tomatoes, red wine, and spices.\",\"In a separate saucepan, make b\\u00E9chamel sauce: melt butter, whisk in flour, add milk, and cook until thickened.\",\"Remove from heat and stir in Parmesan cheese and egg yolks.\",\"In a baking dish, layer eggplants and meat mixture. Top with b\\u00E9chamel sauce.\",\"Bake for 40-45 minutes until golden brown. Let it cool before slicing.\",\"Serve slices of moussaka warm and enjoy this Greek classic!\"]", "[\"Dinner\"]", "Greek Moussaka", 45, 4.3f, 26, 6, "[\"Moussaka\",\"Greek\"]", 173 },
                    { 20L, 480, 25, "Pakistani", 1, "https://cdn.dummyjson.com/recipe-images/20.webp", "[\"Chicken thighs, boneless and skinless\",\"Yogurt\",\"Ginger-garlic paste\",\"Garam masala\",\"Kashmiri red chili powder\",\"Tomato puree\",\"Butter\",\"Heavy cream\",\"Kasuri methi (dried fenugreek leaves)\",\"Sugar\",\"Salt to taste\"]", "[\"Marinate chicken thighs in a mixture of yogurt, ginger-garlic paste, garam masala, and Kashmiri red chili powder.\",\"In a pan, melt butter and saut\\u00E9 the marinated chicken until browned.\",\"Add tomato puree and cook until the oil separates. Stir in heavy cream.\",\"Sprinkle kasuri methi, sugar, and salt. Simmer until the chicken is fully cooked.\",\"Serve this creamy butter chicken over rice or with naan for an authentic Pakistani/Indian experience.\"]", "[\"Dinner\"]", "Butter Chicken (Murgh Makhani)", 30, 4.5f, 44, 4, "[\"Butter chicken\",\"Curry\",\"Indian\",\"Pakistani\",\"Asian\"]", 138 },
                    { 21L, 480, 30, "Thai", 1, "https://cdn.dummyjson.com/recipe-images/21.webp", "[\"Chicken thighs, boneless and skinless\",\"Green curry paste\",\"Coconut milk\",\"Fish sauce\",\"Sugar\",\"Eggplant, sliced\",\"Bell peppers, sliced\",\"Basil leaves\",\"Jasmine rice for serving\"]", "[\"In a pot, simmer green curry paste in coconut milk.\",\"Add chicken, fish sauce, and sugar. Cook until chicken is tender.\",\"Stir in sliced eggplant and bell peppers. Simmer until vegetables are cooked.\",\"Garnish with fresh basil leaves.\",\"Serve hot over jasmine rice and enjoy this Thai classic!\"]", "[\"Dinner\"]", "Thai Green Curry", 20, 4.2f, 18, 4, "[\"Curry\",\"Thai\"]", 153 },
                    { 22L, 180, 0, "Indian", 0, "https://cdn.dummyjson.com/recipe-images/22.webp", "[\"Ripe mango, peeled and diced\",\"Yogurt\",\"Milk\",\"Honey\",\"Cardamom powder\",\"Ice cubes\"]", "[\"In a blender, combine diced mango, yogurt, milk, honey, and cardamom powder.\",\"Blend until smooth and creamy.\",\"Add ice cubes and blend again until the lassi is chilled.\",\"Pour into glasses and garnish with a sprinkle of cardamom.\",\"Enjoy this refreshing Mango Lassi!\"]", "[\"Beverage\"]", "Mango Lassi", 10, 4.7f, 15, 2, "[\"Lassi\",\"Mango\",\"Indian\",\"Pakistani\",\"Asian\"]", 76 },
                    { 23L, 350, 0, "Italian", 1, "https://cdn.dummyjson.com/recipe-images/23.webp", "[\"Espresso, brewed and cooled\",\"Ladyfinger cookies\",\"Mascarpone cheese\",\"Heavy cream\",\"Sugar\",\"Cocoa powder\"]", "[\"In a bowl, whip heavy cream until stiff peaks form.\",\"In another bowl, mix mascarpone cheese and sugar until smooth.\",\"Gently fold the whipped cream into the mascarpone mixture.\",\"Dip ladyfinger cookies into brewed espresso and layer them in a serving dish.\",\"Spread a layer of the mascarpone mixture over the cookies.\",\"Repeat layers and finish with a dusting of cocoa powder.\",\"Chill in the refrigerator for a few hours before serving.\",\"Indulge in the decadence of this classic Italian Tiramisu!\"]", "[\"Dessert\"]", "Italian Tiramisu", 30, 4.6f, 0, 6, "[\"Tiramisu\",\"Italian\"]", 130 },
                    { 24L, 280, 15, "Turkish", 0, "https://cdn.dummyjson.com/recipe-images/24.webp", "[\"Ground lamb or beef\",\"Onions, grated\",\"Garlic, minced\",\"Parsley, finely chopped\",\"Cumin\",\"Coriander\",\"Red pepper flakes\",\"Salt and pepper to taste\",\"Flatbread for serving\",\"Tahini sauce\"]", "[\"In a bowl, mix ground meat, grated onions, minced garlic, chopped parsley, and spices.\",\"Form the mixture into kebab shapes and grill until fully cooked.\",\"Serve the kebabs on flatbread with a drizzle of tahini sauce.\",\"Enjoy these flavorful Turkish Kebabs with your favorite sides.\"]", "[\"Dinner\"]", "Turkish Kebabs", 25, 4.6f, 78, 4, "[\"Kebabs\",\"Turkish\",\"Grilling\"]", 26 },
                    { 25L, 220, 0, "Smoothie", 0, "https://cdn.dummyjson.com/recipe-images/25.webp", "[\"Blueberries, fresh or frozen\",\"Banana, peeled and sliced\",\"Greek yogurt\",\"Almond milk\",\"Honey\",\"Chia seeds (optional)\"]", "[\"In a blender, combine blueberries, banana, Greek yogurt, almond milk, and honey.\",\"Blend until smooth and creamy.\",\"Add chia seeds for extra nutrition and blend briefly.\",\"Pour into a glass and enjoy this nutritious Blueberry Banana Smoothie!\"]", "[\"Breakfast\",\"Beverage\"]", "Blueberry Banana Smoothie", 10, 4.8f, 30, 1, "[\"Smoothie\",\"Blueberry\",\"Banana\"]", 16 },
                    { 26L, 180, 15, "Mexican", 0, "https://cdn.dummyjson.com/recipe-images/26.webp", "[\"Corn on the cob\",\"Mayonnaise\",\"Cotija cheese, crumbled\",\"Chili powder\",\"Lime wedges\"]", "[\"Grill or roast corn on the cob until kernels are charred.\",\"Brush each cob with mayonnaise, then sprinkle with crumbled Cotija cheese and chili powder.\",\"Serve with lime wedges for squeezing over the top.\",\"Enjoy this delicious and flavorful Mexican Street Corn!\"]", "[\"Snack\",\"Side Dish\"]", "Mexican Street Corn (Elote)", 15, 4.6f, 2, 4, "[\"Elote\",\"Mexican\",\"Street food\"]", 93 },
                    { 27L, 220, 40, "Russian", 1, "https://cdn.dummyjson.com/recipe-images/27.webp", "[\"Beets, peeled and shredded\",\"Cabbage, shredded\",\"Potatoes, diced\",\"Onions, finely chopped\",\"Carrots, grated\",\"Tomato paste\",\"Beef or vegetable broth\",\"Garlic, minced\",\"Bay leaves\",\"Sour cream for serving\"]", "[\"In a pot, saut\\u00E9 chopped onions and garlic until softened.\",\"Add shredded beets, cabbage, diced potatoes, grated carrots, and tomato paste.\",\"Pour in broth and add bay leaves. Simmer until vegetables are tender.\",\"Serve hot with a dollop of sour cream on top.\",\"Enjoy the hearty and comforting flavors of Russian Borscht!\"]", "[\"Dinner\"]", "Russian Borscht", 30, 4.3f, 39, 6, "[\"Borscht\",\"Russian\",\"Soup\"]", 1 },
                    { 28L, 320, 20, "Indian", 1, "https://cdn.dummyjson.com/recipe-images/28.webp", "[\"Dosa batter (fermented rice and urad dal batter)\",\"Potatoes, boiled and mashed\",\"Onions, finely chopped\",\"Mustard seeds\",\"Cumin seeds\",\"Curry leaves\",\"Turmeric powder\",\"Green chilies, chopped\",\"Ghee\",\"Coconut chutney for serving\"]", "[\"In a pan, heat ghee and add mustard seeds, cumin seeds, and curry leaves.\",\"Add chopped onions, green chilies, and turmeric powder. Saut\\u00E9 until onions are golden brown.\",\"Mix in boiled and mashed potatoes. Cook until well combined and seasoned.\",\"Spread dosa batter on a hot griddle to make thin pancakes.\",\"Place a spoonful of the potato mixture in the center, fold, and serve hot.\",\"Pair with coconut chutney for a delicious South Indian meal.\"]", "[\"Breakfast\"]", "South Indian Masala Dosa", 40, 4.4f, 96, 4, "[\"Dosa\",\"Indian\",\"Asian\"]", 138 },
                    { 29L, 400, 10, "Lebanese", 0, "https://cdn.dummyjson.com/recipe-images/29.webp", "[\"Falafel balls\",\"Whole wheat or regular wraps\",\"Tomatoes, diced\",\"Cucumbers, sliced\",\"Red onions, thinly sliced\",\"Lettuce, shredded\",\"Tahini sauce\",\"Fresh parsley, chopped\"]", "[\"Warm falafel balls according to package instructions.\",\"Place a generous serving of falafel in the center of each wrap.\",\"Top with diced tomatoes, sliced cucumbers, red onions, shredded lettuce, and fresh parsley.\",\"Drizzle with tahini sauce and wrap tightly.\",\"Enjoy this Lebanese Falafel Wrap filled with fresh and flavorful ingredients!\"]", "[\"Lunch\"]", "Lebanese Falafel Wrap", 15, 4.7f, 84, 2, "[\"Falafel\",\"Lebanese\",\"Wrap\"]", 110 },
                    { 30L, 150, 0, "Brazilian", 0, "https://cdn.dummyjson.com/recipe-images/30.webp", "[\"Cacha\\u00E7a (Brazilian sugarcane spirit)\",\"Lime, cut into wedges\",\"Granulated sugar\",\"Ice cubes\"]", "[\"In a glass, muddle lime wedges with granulated sugar to release the juice.\",\"Fill the glass with ice cubes.\",\"Pour cacha\\u00E7a over the ice and stir well.\",\"Sip and enjoy the refreshing taste of the Brazilian Caipirinha!\",\"Adjust sugar and lime to suit your taste preferences.\"]", "[\"Beverage\"]", "Brazilian Caipirinha", 5, 4.4f, 55, 1, "[\"Caipirinha\",\"Brazilian\",\"Cocktail\"]", 134 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "OrderId", "Quantity", "Rating", "RecipeId" },
                values: new object[,]
                {
                    { 1L, 1L, 2, 5f, 1L },
                    { 2L, 1L, 1, 8.2f, 3L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_RecipeId",
                table: "OrderItems",
                column: "RecipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
