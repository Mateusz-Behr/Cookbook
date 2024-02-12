using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookbook.App.Abstract;
using Cookbook.Domain.Entity;
using FluentAssertions;
using Moq;
using Xunit;
using Cookbook.App.Concrete;
using Cookbook.App.Common;

namespace Cookbook.Tests
{
    public class RecipeServiceTests
    {
        readonly List<string> ingredients1 = new()
        {
            "eggs",
            "butter"
        };

        [Fact]

        public void RemoveRecipe_RemovesRecipeFromItemsList()
        {
            //Arrange
            Recipe recipe1 = new("Scrambled eggs", 1, ingredients1, "stir in the pan", 15);

            var service = new RecipeService();
            service.Items.Add(recipe1);

            //Act
            service.RemoveRecipe(recipe1);
            
            //Assert
            service.Items.Should().NotContain(recipe1);
        }
    }
}
