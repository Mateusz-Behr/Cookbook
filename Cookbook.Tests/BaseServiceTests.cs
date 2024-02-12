using System.Collections.Generic;
using Cookbook.App.Common;
using Cookbook.Domain.Entity;
using Cookbook.App.Abstract;
using FluentAssertions;
using Moq;
using Xunit;
using Cookbook.App.Concrete;

namespace Cookbook.Tests
{
    public class BaseServiceTests
    {
        readonly List<string> ingredients1 = new()
        {
            "eggs",
            "butter"
        };
        readonly List<string> ingredients2 = new()
        {
            "flour",
            "sugar"
        };

        [Fact]
        public void AddItem_AddsNewItemToListAndReturnsItemId()
        {
            //Arrange

            var mock = new Mock<IService<Recipe>>(MockBehavior.Strict);
            var service = new BaseService<Recipe>();

            Recipe recipe = new ("Scrambled eggs", 1, ingredients1, "stir in the pan", 15);

            mock.Setup(s => s.Items).Returns(service.Items);

            //Act
            var result = service.AddItem(recipe);

            //Assert
            service.Items.Should().HaveCount(1);
            result.Should().Be(1);
        }

        [Fact]
        public void GetAllItems_ReturnsListOfItems()
        {
            //Arrange
            var mock = new Mock<IService<Recipe>>(MockBehavior.Strict);
            var service = new BaseService<Recipe>();

            Recipe recipe1 = new ("Scrambled eggs", 1, ingredients1, "stir in the pan", 15);
            Recipe recipe2 = new ("Pancakes", 2, ingredients2, "mix ingredients and cook", 20);

            service.AddItem(recipe1);
            service.AddItem(recipe2);

            mock.Setup(s => s.Items).Returns(service.Items);

            //Act
            var result = service.GetAllItems();

            //Assert
            result.Should().HaveCount(2);
            result.Should().Contain(recipe1);
            result.Should().Contain(recipe2);

        }

        [Fact]
        public void GetItemById_ReturnsItemByGivenId()
        {
            //Arrange
            var mock = new Mock<IService<Recipe>>(MockBehavior.Strict);
            var service = new BaseService<Recipe>();

            Recipe recipe = new("Scrambled eggs", 1, ingredients1, "stir in the pan", 15);

            mock.Setup(s => s.GetItemById(1)).Returns(recipe);

            //Act
            var result = mock.Object.GetItemById(recipe.Id);

            //Assert
            result.Should().BeSameAs(recipe);
        }
    }
}