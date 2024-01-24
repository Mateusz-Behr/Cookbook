using Moq;
using Xunit;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookbook.App.Concrete;
using Cookbook.Domain.Entity;
using Cookbook.App.Abstract;

namespace Cookbook.Tests
{
    public class MenuActionServiceTests
    {
        [Fact]
        public void GetMenuActionsByMenuName_EmptyList_ReturnsEmptyList()
        {
            //Arrange
            var mock = new Mock<IService<MenuAction>>(MockBehavior.Strict);
            var service = new MenuActionService();

            mock.Setup(s => s.GetAllItems()).Returns(new List<MenuAction>());

            //Act
            List<MenuAction> result = service.GetMenuActionsByMenuName("SomeMenuName");

            //Arrange
            result.Should().BeEmpty();
        }

        [Fact]
        public void GetMenuActionByMenuName_ItemsContainMatchingMenuName_ReturnsMatchingMenuActions()
        {
            //Arrange
            var mock = new Mock<IService<MenuAction>>(MockBehavior.Strict);
            var service = new MenuActionService();

            MenuAction menuAction1 = new(1, "FirstName", "SomeMenuName");
            MenuAction menuAction2 = new(2, "SecondName", "SomeMenuName");

            service.AddItem(menuAction1);
            service.AddItem(menuAction2);


            mock.Setup(s => s.Items).Returns(service.Items);

            //Act
            List<MenuAction> result = service.GetMenuActionsByMenuName("SomeMenuName");

            //Arrange
            result.Should().HaveCount(2);
            result.Should().OnlyContain(action => action.MenuName == "SomeMenuName");
        }

    }
}
