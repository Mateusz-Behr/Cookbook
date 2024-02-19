using Cookbook.App.Abstract;
using Cookbook.App.Concrete;
using Cookbook.Domain.Entity;
using Cookbook.Domain.Helpers;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Tests
{
    public class ProductServiceTests
    {
        readonly Dictionary<string, List<double>> testUnits = new()
        {
            { "g", new List<double> { 1, 1, 0.004, 0.067, 0.2 } },
            { "ml", new List<double> { 1, 1, 0.004, 0.067, 0.2 } },
            { "glass", new List<double> { 250, 250, 1, 16.67, 50 } },
            { "spoon", new List<double> { 15, 15, 0.06, 1, 3 } },
            { "teaspoon", new List<double> { 5, 5, 0.02, 0.33, 1 } },
        };
        [Fact]
        public void GetUnitsListFromChosenProduct_ValidInput_ReturnsCorrectUnitsList()
        {
            //Arrange
            var mock = new Mock<IService<Product>>(MockBehavior.Strict);
            var service = new ProductService();

            var chosenProduct = 1;
            var items = new List<Product>
            {
                new ("Water", testUnits)
            };

            mock.Setup(s => s.GetAllItems()).Returns(items);

            //Act
            var result = service.GetUnitsListFromChosenProduct(chosenProduct);

            //Assert
            result.Should().BeEquivalentTo(items[chosenProduct - 1].ListOfUnits);
        }

        [Fact]
        public void GetUnitsListFromChosenProduct_InvalidInput_ReturnsEmptyDictionary()
        {
            //Arrange
            var mock = new Mock<IService<Product>>(MockBehavior.Strict);
            var service = new ProductService();

            var chosenProduct = 0;
            var items = new List<Product>
            {
                new ("Water", testUnits)
            };

            mock.Setup(s => s.GetAllItems()).Returns(items);

            //Act
            var result = service.GetUnitsListFromChosenProduct(chosenProduct);

            //Assert
            result.Should().BeEmpty();
        }

 
        [Theory]
        [InlineData(1, "g")]
        [InlineData(2, "ml")]
        [InlineData(3, "glass")]
        [InlineData(4, "spoon")]
        [InlineData(5, "teaspoon")]
        [InlineData(6, "")]
        [InlineData(0, "")]
        public void GetUnitNameByNumber_ReturnsCorrectUnit(int chosenUnitNumber, string unitName)
        {
            //Arrange
            var service = new ProductService();

            //Act
            var result = service.GetUnitNameByNumber(chosenUnitNumber);

            //Assert
            result.Should().Be(unitName);
        }

        [Theory]
        [InlineData((int)Helpers.UnitType.Grams, "gram(s)")]
        [InlineData((int)Helpers.UnitType.Milliliters, "mililiter(s)")]
        [InlineData((int)Helpers.UnitType.Glasses, "glass(es)")]
        [InlineData((int)Helpers.UnitType.Spoons, "spoon(s)")]
        [InlineData((int)Helpers.UnitType.Teaspoons, "teaspoon(s)")]
        [InlineData(6, "unknown")]
        [InlineData(0, "unknown")]
        public void GetUnitFullName_ReturnsCorrectUnitName(int chosenUnitNumber, string unitName)
        {
            //Arrange
            var service = new ProductService();

            //Act
            var result = service.GetUnitFullName(chosenUnitNumber);

            //Assert
            result.Should().Be(unitName);
        }

        [Fact]
        public void CalculateUnits_ReturnsCorrectResults()
        {
            //Arrange
            double value = 10.0;
            string unitName = "g";
            var expectedResults = new List<double> { 10.0, 10.0, 0.04, 0.67, 2.0 };

            var service = new ProductService();

            //Act
            var result = service.CalculateUnits(value, testUnits, unitName);

            //Assert
            result.Should().BeEquivalentTo(expectedResults);
        }

    }
}
