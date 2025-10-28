using Xunit;
using ContosoPizza.Services;
using ContosoPizza.Models;
using System.Text.Json;
using System.Reflection;

namespace tests;

public class PizzaServiceTests
{
    public PizzaServiceTests()
    {
      PizzaService.Reset();  // 每个测试前重置静态状态
    }


    [Fact]
    public void GetAll_ShouldReturnInitialTwoPizzas()
    {
      // Act
      var pizzas = PizzaService.GetAll();

      Console.WriteLine(JsonSerializer.Serialize(PizzaService.GetAll()));


      // Assert
      Assert.NotNull(pizzas);
      Assert.Equal(2, pizzas.Count);
      Assert.Contains(pizzas, p => p.Name == "Classic Italian");
      Assert.Contains(pizzas, p => p.Name == "Veggie");
    }

    [Fact]
    public void Add_ShouldIncreaseCountByOne()
    {
        // Arrange
        var newPizza = new Pizza { Name = "Hawaiian", IsGlutenFree = false };
        int oldCount = PizzaService.GetAll().Count;

        // Act
        PizzaService.Add(newPizza);

        // Assert
        Assert.Equal(oldCount + 1, PizzaService.GetAll().Count);
        Assert.Contains(PizzaService.GetAll(), p => p.Name == "Hawaiian");
    }

    [Fact]
    public void Delete_ShouldRemovePizzaById()
    {
        // Arrange
        var pizza = new Pizza { Name = "Temp", IsGlutenFree = true };
        PizzaService.Add(pizza);
        var added = PizzaService.GetAll().Last();

        // Act
        PizzaService.Delete(added.Id);

        // Assert
        Assert.DoesNotContain(PizzaService.GetAll(), p => p.Id == added.Id);
    }

    [Fact]
    public void Update_ShouldChangePizzaName()
    {
        // Arrange
        var pizza = PizzaService.GetAll().First();
        var updated = new Pizza
        {
            Id = pizza.Id,
            Name = "Updated Name",
            IsGlutenFree = pizza.IsGlutenFree
        };

        // Act
        PizzaService.Update(updated);
        var result = PizzaService.Get(pizza.Id);

        // Assert
        Assert.Equal("Updated Name", result!.Name);
    }
}
