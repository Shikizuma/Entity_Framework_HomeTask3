using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.PortableExecutable;

namespace Entity_Framework_HomeTask3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ContextApp db = new ContextApp())
            {
                db.RemoveRange(db.KeyParams);
                db.RemoveRange(db.Words);
                db.RemoveRange(db.Carts);
                db.RemoveRange(db.Users);
                db.RemoveRange(db.Products);
                db.RemoveRange(db.Categories);
                db.SaveChanges();

               
                var electronicsCategory = new Category { Id = Guid.NewGuid(), Name = "Electronics", Icon = "icon-electronics" };
                var clothingCategory = new Category { Id = Guid.NewGuid(), Name = "Clothing", Icon = "icon-clothing" };
                var foodCategory = new Category { Id = Guid.NewGuid(), Name = "Food", Icon = "icon-food" };

                db.Categories.AddRange(new List<Category> { electronicsCategory, clothingCategory, foodCategory });
                db.SaveChanges();

           
                var laptop = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop",
                    Price = 999.99,
                    ActionPrice = 899.99,
                    Description = "Powerful laptop for your needs",
                    ImageUrl = "laptop-image-url",
                    Category = electronicsCategory
                };

                var smartphone = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone",
                    Price = 499.99,
                    ActionPrice = 449.99,
                    Description = "Latest smartphone with great features",
                    ImageUrl = "smartphone-image-url",
                    Category = electronicsCategory
                };

                var shirt = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Casual Shirt",
                    Price = 29.99,
                    ActionPrice = 24.99,
                    Description = "Comfortable and stylish shirt",
                    ImageUrl = "shirt-image-url",
                    Category = clothingCategory
                };

                var chocolate = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Chocolate",
                    Price = 4.99,
                    ActionPrice = 3.99,
                    Description = "Delicious chocolate treat",
                    ImageUrl = "chocolate-image-url",
                    Category = foodCategory
                };

                var headphone = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Wireless Headphones",
                    Price = 79.99,
                    ActionPrice = 69.99,
                    Description = "High-quality wireless headphones",
                    ImageUrl = "headphone-image-url",
                    Category = electronicsCategory
                };

                var jeans = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Blue Jeans",
                    Price = 49.99,
                    ActionPrice = 39.99,
                    Description = "Classic blue jeans for everyday wear",
                    ImageUrl = "jeans-image-url",
                    Category = clothingCategory
                };

                var pizza = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Margherita Pizza",
                    Price = 12.99,
                    ActionPrice = 9.99,
                    Description = "Delicious Margherita pizza",
                    ImageUrl = "pizza-image-url",
                    Category = foodCategory
                };

                db.Products.AddRange(new List<Product> { laptop, smartphone, shirt, chocolate, headphone, jeans, pizza });
                db.SaveChanges();


                var laptopWord = new Word { Id = Guid.NewGuid(), Header = "Laptop Header", KeyWord = "Laptop" };
                var smartphoneWord = new Word { Id = Guid.NewGuid(), Header = "Smartphone Header", KeyWord = "Smartphone" };
                var shirtWord = new Word { Id = Guid.NewGuid(), Header = "Shirt Header", KeyWord = "Shirt" };
                var chocolateWord = new Word { Id = Guid.NewGuid(), Header = "Chocolate Header", KeyWord = "Chocolate" };
                var headphoneWord = new Word { Id = Guid.NewGuid(), Header = "Headphone Header", KeyWord = "Headphones" };
                var jeansWord = new Word { Id = Guid.NewGuid(), Header = "Jeans Header", KeyWord = "Jeans" };
                var pizzaWord = new Word { Id = Guid.NewGuid(), Header = "Pizza Header", KeyWord = "Pizza" };
                var pizzaWord1 = new Word { Id = Guid.NewGuid(), Header = "Tasty Header", KeyWord = "Tasty" };


                db.Words.AddRange(new List<Word> { laptopWord, smartphoneWord, shirtWord, chocolateWord, headphoneWord, jeansWord, pizzaWord, pizzaWord1 });
                db.SaveChanges();

                var laptopKeyParams = new KeyParams { Id = Guid.NewGuid(), Product = laptop, KeyWord = laptopWord };
                var smartphoneKeyParams = new KeyParams { Id = Guid.NewGuid(), Product = smartphone, KeyWord = smartphoneWord };
                var shirtKeyParams = new KeyParams { Id = Guid.NewGuid(), Product = shirt, KeyWord = shirtWord };
                var chocolateKeyParams = new KeyParams { Id = Guid.NewGuid(), Product = chocolate, KeyWord = chocolateWord };
                var headphoneKeyParams = new KeyParams { Id = Guid.NewGuid(), Product = headphone, KeyWord = headphoneWord };
                var jeansKeyParams = new KeyParams { Id = Guid.NewGuid(), Product = jeans, KeyWord = jeansWord };
                var pizzaKeyParams = new KeyParams { Id = Guid.NewGuid(), Product = pizza, KeyWord = pizzaWord };
                var pizzaKeyParams1 = new KeyParams { Id = Guid.NewGuid(), Product = pizza, KeyWord = pizzaWord1 };


                db.KeyParams.AddRange(new List<KeyParams> { laptopKeyParams, smartphoneKeyParams, shirtKeyParams, chocolateKeyParams, headphoneKeyParams, jeansKeyParams, pizzaKeyParams, pizzaKeyParams1 });
                db.SaveChanges();

                var user1 = new User
                {
                    Id = Guid.NewGuid(),
                    Name = "John Doe",
                    Login = "john.doe",
                    Password = "password123",
                    Email = "john.doe@example.com",
                    Carts = new List<Cart>()
                };

                var user2 = new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Jane Smith",
                    Login = "jane.smith",
                    Password = "pass456",
                    Email = "jane.smith@example.com",
                    Carts = new List<Cart>()
                };

                db.Users.AddRange(new List<User> { user1, user2 });
                db.SaveChanges();

                var laptopCart = new Cart { Id = Guid.NewGuid(), User = user1, Product = laptop };
                var smartphoneCart = new Cart { Id = Guid.NewGuid(), User = user1, Product = smartphone };
                var shirtCart = new Cart { Id = Guid.NewGuid(), User = user2, Product = shirt };
                var chocolateCart = new Cart { Id = Guid.NewGuid(), User = user2, Product = chocolate };
                var headphoneCart = new Cart { Id = Guid.NewGuid(), User = user1, Product = headphone };
                var jeansCart = new Cart { Id = Guid.NewGuid(), User = user2, Product = jeans };
                var pizzaCart = new Cart { Id = Guid.NewGuid(), User = user1, Product = pizza };


                db.Carts.AddRange(new List<Cart> { laptopCart, smartphoneCart, shirtCart, chocolateCart, headphoneCart, jeansCart, pizzaCart });
                db.SaveChanges();


                var usersWithProductsAndCategories = db.Users.Include(u => u.Carts)
                    .ThenInclude(c => c.Product)
                    .ThenInclude(p => p.Category)
                    .Include(u => u.Carts)
                    .ThenInclude(c => c.Product)
                    .ThenInclude(p => p.KeyWords)
                    .ThenInclude(k => k.KeyWord)
                    .ToList();

                Console.WriteLine("Users, Products, and Categories:");
                foreach (var user in usersWithProductsAndCategories)
                {
                    Console.WriteLine($"User: {user.Name}");

                    foreach (var cart in user.Carts)
                    {

                        Console.WriteLine($"    Product Name: {cart.Product.Name}");

                        var category = cart.Product.Category;
                        Console.WriteLine($"    Category: {category.Name}");

                        Console.Write("    Keywords: ");
                        var keywords = cart.Product.KeyWords.Select(k => k.KeyWord.KeyWord);
                        Console.WriteLine(string.Join(", ", keywords));

                        Console.WriteLine();
                    }
                }

            }
        }
    }
}