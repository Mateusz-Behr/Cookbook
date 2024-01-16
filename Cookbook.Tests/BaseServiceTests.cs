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
        public void AddItem_AddNewItemToListAndReturnItemId()
        {
            //Arrange


            var mock = new Mock<IService<Recipe>>(MockBehavior.Strict);
            var service = new BaseService<Recipe>();

            Recipe recipe = new (1, "Scrambled eggs", 1, ingredients1, "stir in the pan", 15);

            mock.Setup(s => s.Items).Returns(service.Items); //ustawienie pozornego obiektu kolekcji Items

            //Act
            var result = service.AddItem(recipe);

            //Assert
            service.Items.Should().HaveCount(1); //czy element zosta³ dodany do kolekcji
            result.Should().Be(1);  //czy metoda zwróci³a prawid³owe Id dodanego elementu
        }

        [Fact]
        public void GetAllItems_ReturnListOfItems()
        {
            //Arrange
            var mock = new Mock<IService<Recipe>>(MockBehavior.Strict);
            var service = new BaseService<Recipe>();

            Recipe recipe1 = new (1, "Scrambled eggs", 1, ingredients1, "stir in the pan", 15);
            Recipe recipe2 = new (2, "Pancakes", 2, ingredients2, "mix ingredients and cook", 20);

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
        public void GetItemById_ReturnItemByGivenId()
        {
            //Arrange
            var mock = new Mock<IService<Recipe>>(MockBehavior.Strict);
            var service = new BaseService<Recipe>();

            Recipe recipe = new(1, "Scrambled eggs", 1, ingredients1, "stir in the pan", 15);

            mock.Setup(s => s.GetItemById(1)).Returns(recipe);

            //Act
            var result = mock.Object.GetItemById(recipe.Id);

            //Assert
            result.Should().BeSameAs(recipe);
        }

        //[Fact]
        //public void GetFreeId_ReturnAvailableFreeId()
        //{
        //    //Arrange
        //    var mock = new Mock<IService<Recipe>>(MockBehavior.Strict);
        //    var service = new BaseService<Recipe>();
            
        //    //int nextId = 1;
            
        //    List<int> freeIds = new() { 5 };
        //    //int searchedId = 0;

        //    mock.Setup(s => s.GetFreeId()).Returns(() => service.GetFreeId());

        //    //Act
        //    var result = service.GetFreeId();

        //    //Arange
        //    result.Should().Be(5);
        //    freeIds.Should().NotContain(5);

        //    var nextResult = service.GetFreeId();
        //    nextResult.Should().Be(1);
        //}
    }
}