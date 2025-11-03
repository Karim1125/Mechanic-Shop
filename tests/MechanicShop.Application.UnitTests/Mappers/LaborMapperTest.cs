using MechanicShop.Application.Features.Labors.Dtos;
using MechanicShop.Application.Features.Labors.Mappers;
using MechanicShop.Domain.Customers;
using MechanicShop.Domain.Employees;
using MechanicShop.Tests.Common.Customers;
using MechanicShop.Tests.Common.Employees;

using Xunit;

namespace MechanicShop.Application.UnitTests.Mappers;

public class LaborMapperTest
{
    [Fact]
    public void ToDto_ShouldMapCorrectly()
    {
        var labor = EmployeeFactory.CreateLabor().Value;
        var dto = labor.ToDto();
        Assert.Equal(dto.LaborId, labor.Id);
        Assert.Equal(dto.Name, labor.FullName);
    }

    [Fact]
    public void ToDtos_ShouldMapListCorrectly()
    {
        var labor = EmployeeFactory.CreateLabor().Value;
        var labors = new List<Employee> { labor };
        var dtos = labors.ToDtos();
        Assert.Single(dtos);
        Assert.Equal(dtos.Count, labors.Count);
        Assert.Equal(dtos[0].Name, labor.FullName);
        Assert.Equal(dtos[0].LaborId, labor.Id);
    }

    [Fact]
    public void ToDto_ShouldThrowException_WhenCustomerIsNull()
    {
        // Arrange
        Employee labor = null!;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => labor.ToDto());
    }
}