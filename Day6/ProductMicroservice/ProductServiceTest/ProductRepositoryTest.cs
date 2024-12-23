

 using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Contexts;
using ProductMicroservice.Interfaces;
using ProductMicroservice.Models;
using ProductMicroservice.Repositories;


namespace ProductServiceTest
{
    public class ProductRepositoryTest
    {
        IRepository<int, Product> _productRepository;
        ProductContext context;

        [TearDown]
        //teardown cleans up and disposes of resources after each test to prevent memory leaks or other issues related to leftover state
        public void teardown()
        {
            context.Dispose();
        }

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ProductContext>()
                .UseInMemoryDatabase(databaseName: "ProductMicroService")
                .Options;
            context = new ProductContext(options);
            _productRepository = new ProductRepository(context);
        }

        [Test]
        public async Task AddTest()
        {
            // Arrange
            Product product = new Product
            {
                Title = "Test Product",
                PricePerUnit = 100,
                StockAvailable = 10,
                Description = "Test Description",
                ImageUrl = "Test Image Url",
            };
            //Act
            var result = await _productRepository.Add(product);
            //Assert
            Assert.That(result.Title, Is.EqualTo(product.Title));
        }

        //methodnameTese
        [Test]
        public async Task GetAllTest()
        {
            //Arrange
            Product product = new Product
            {
                Title = "Test Product",
                PricePerUnit = 100,
                StockAvailable = 10,
                Description = "Test Description",
                ImageUrl = "Test Image Url",
            };
            await _productRepository.Add(product);
            //Act
            var result = await _productRepository.GetAll();
            //Assert
            Assert.That(result.Count(), Is.EqualTo(1));
        }
        //test for failure cases
        [Test]
        public async Task GetAllExceptionTest()
        {
            //Assert.CatchAsync<Exception>(async () => await _productRepository.GetAll());
            Assert.ThrowsAsync<Exception>(() => _productRepository.GetAll());
        }
    }
}
   