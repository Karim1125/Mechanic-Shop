using MechanicShop.Application.Features.Customers.Mappers;
using MechanicShop.Domain.Customers;
using MechanicShop.Tests.Common.Customers;
using Xunit;

namespace MechanicShop.Application.UnitTests.Mappers;

public class CustomerMapperTest
{
    [Fact]
    public void ToDto_ShouldMapCorrectly()
    {
        var customer = CustomerFactory.CreateCustomer();
        var dto = customer.Value.ToDto();
        Assert.Equal(customer.Value.Name, dto.Name);
        Assert.Equal(customer.Value.Email, dto.Email);
        Assert.Equal(customer.Value.Id, dto.CustomerId);
        Assert.Equal(customer.Value.PhoneNumber, dto.PhoneNumber);
        var vehicles = customer.Value.Vehicles;
        Assert.NotNull(vehicles);
        Assert.Equal(vehicles.Count(), dto.Vehicles?.Count);
        foreach (var (v, dv) in vehicles.Zip(dto.Vehicles!))
        {
            Assert.Equal(v.Id, dv.VehicleId);
            Assert.Equal(v.Make, dv.Make);
            Assert.Equal(v.Model, dv.Model);
            Assert.Equal(v.Year, dv.Year);
            Assert.Equal(v.LicensePlate, dv.LicensePlate);
        }
    }

    [Fact]
    public void ToDtos_ShouldMapListCorrectly()
    {
        var customer = CustomerFactory.CreateCustomer();
        var customers = new List<Customer> { customer.Value };
        var dtos = customers.ToDtos();
        Assert.Single(dtos);
        Assert.Equal(customer.Value.Name, dtos[0].Name);
        Assert.Equal(customer.Value.Email, dtos[0].Email);
        Assert.Equal(customer.Value.Id, dtos[0].CustomerId);
        Assert.Equal(customer.Value.PhoneNumber, dtos[0].PhoneNumber);
        var vehicles = customer.Value.Vehicles;
        Assert.NotNull(vehicles);
        Assert.Equal(vehicles.Count(), dtos[0].Vehicles?.Count);
        foreach (var (v, dv) in vehicles.Zip(dtos[0].Vehicles!))
        {
            Assert.Equal(v.Id, dv.VehicleId);
            Assert.Equal(v.Make, dv.Make);
            Assert.Equal(v.Model, dv.Model);
            Assert.Equal(v.Year, dv.Year);
            Assert.Equal(v.LicensePlate, dv.LicensePlate);
        }
    }

    [Fact]
    public void ToDto_ShouldThrowException_WhenCustomerIsNull()
    {
        // Arrange
        Customer customer = null!;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => customer.ToDto());
    }

    [Fact]
    public void ToDto_ShouldMapCorrectly_WhenVehiclesIsEmpty()
    {
        // Arrange
        var customerResult = CustomerFactory.CreateCustomer(vehicles: new List<Domain.Customers.Vehicles.Vehicle>());
        var customer = customerResult.Value;

        Assert.NotNull(customer.Vehicles);
        Assert.Empty(customer.Vehicles);

        // Act
        var dto = customer.ToDto();

        // Assert
        Assert.NotNull(dto.Vehicles);
        Assert.Empty(dto.Vehicles);
        Assert.Equal(customer.Name, dto.Name);
    }

    [Fact]
    public void ToDtos_ShouldReturnEmptyList_WhenSourceIsEmpty()
    {
        // Arrange
        var customers = new List<Customer>();

        // Act
        var dtos = customers.ToDtos();

        // Assert
        Assert.NotNull(dtos);
        Assert.Empty(dtos);
    }
}