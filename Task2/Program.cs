using DAL;
using DAL.Entity;
using DAL.Repository;

namespace Task2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using (var context = new EntityDatabase())
            {
                var categoryRepository = new CategoryRepository(context);
                var productRepository = new ProductRepository(context);
                var wordRepository = new WordRepository(context);
                var keyParamsRepository = new KeyParamsRepository(context);
                var userRepository = new UserRepository(context);
                var cartRepository = new CartRepository(context);

                var electronicsCategory = new Category { Id = Guid.NewGuid(), Name = "Electronics", Icon = "icon-electronics" };
                var clothingCategory = new Category { Id = Guid.NewGuid(), Name = "Clothing", Icon = "icon-clothing" };
                var foodCategory = new Category { Id = Guid.NewGuid(), Name = "Food", Icon = "icon-food" };

                await categoryRepository.Create(electronicsCategory);
                await categoryRepository.Create(clothingCategory);
                await categoryRepository.Create(foodCategory);

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

                await productRepository.Create(laptop);
                await productRepository.Create(smartphone);

                var laptopWord = new Word { Id = Guid.NewGuid(), Header = "Laptop Header", KeyWord = "Laptop" };
                var smartphoneWord = new Word { Id = Guid.NewGuid(), Header = "Smartphone Header", KeyWord = "Smartphone" };

                await wordRepository.Create(laptopWord);
                await wordRepository.Create(smartphoneWord);

                var laptopKeyParams = new KeyParams { Id = Guid.NewGuid(), Product = laptop, KeyWord = laptopWord };
                var smartphoneKeyParams = new KeyParams { Id = Guid.NewGuid(), Product = smartphone, KeyWord = smartphoneWord };

                await keyParamsRepository.Create(laptopKeyParams);
                await keyParamsRepository.Create(smartphoneKeyParams);

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

                await userRepository.Create(user1);
                await userRepository.Create(user2);

                var laptopCart = new Cart { Id = Guid.NewGuid(), User = user1, Product = laptop };
                var smartphoneCart = new Cart { Id = Guid.NewGuid(), User = user1, Product = smartphone };

                await cartRepository.Create(laptopCart);
                await cartRepository.Create(smartphoneCart);

                var allUsers = await userRepository.Select();
                var allCategoriesWithProducts = await categoryRepository.SelectIncludeProducts();
                var allProducts = await productRepository.SelectIncludeCategory();

                Console.WriteLine("Data added and retrieved successfully!");
            }
        }
    }
}