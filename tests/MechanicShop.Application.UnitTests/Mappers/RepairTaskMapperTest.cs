using MechanicShop.Application.Features.RepairTasks.Mappers;
using MechanicShop.Domain.RepairTasks;
using MechanicShop.Tests.Common.RepaireTasks;
using Xunit;

namespace MechanicShop.Application.UnitTests.Mappers;

public class RepairTaskMapperTest
{
    [Fact]
    public void ToDto_ShouldMapCorrectly()
    {
        var task = RepairTaskFactory.CreateRepairTask();
        var dto = task.Value.ToDto();
        Assert.Equal(task.Value.Id, dto.RepairTaskId);
        Assert.Equal(task.Value.Name, dto.Name);
        Assert.Equal(task.Value.EstimatedDurationInMins, dto.EstimatedDurationInMins);
        Assert.Equal(task.Value.LaborCost, dto.LaborCost);
        Assert.Equal(task.Value.TotalCost, dto.TotalCost);
        var parts = task.Value.Parts;
        Assert.NotNull(parts);
        Assert.Equal(parts.Count(), dto.Parts?.Count);
        foreach (var (p, dp) in parts.Zip(dto.Parts!))
        {
            Assert.Equal(p.Id, dp.PartId);
            Assert.Equal(p.Name, dp.Name);
            Assert.Equal(p.Cost, dp.Cost);
            Assert.Equal(p.Quantity, dp.Quantity);
        }
    }

    [Fact]
    public void ToDtos_ShouldMapListCorrectly()
    {
        var task = RepairTaskFactory.CreateRepairTask();
        var tasks = new List<RepairTask> { task.Value };
        var dtos = tasks.ToDtos();
        Assert.Single(dtos);
        Assert.Equal(task.Value.Id, dtos[0].RepairTaskId);
        Assert.Equal(task.Value.Name, dtos[0].Name);
        Assert.Equal(task.Value.EstimatedDurationInMins, dtos[0].EstimatedDurationInMins);
        Assert.Equal(task.Value.LaborCost, dtos[0].LaborCost);
        Assert.Equal(task.Value.TotalCost, dtos[0].TotalCost);
        var parts = task.Value.Parts;
        Assert.NotNull(parts);
        Assert.Equal(parts.Count(), dtos[0].Parts?.Count);
        foreach (var (p, dp) in parts.Zip(dtos[0].Parts!))
        {
            Assert.Equal(p.Id, dp.PartId);
            Assert.Equal(p.Name, dp.Name);
            Assert.Equal(p.Cost, dp.Cost);
            Assert.Equal(p.Quantity, dp.Quantity);
        }
    }

    [Fact]
    public void ToDto_ShouldThrowException_WhentaskIsNull()
    {
        // Arrange
        RepairTask task = null!;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => task.ToDto());
    }

    [Fact]
    public void ToDto_ShouldMapCorrectly_WhenpartsIsEmpty()
    {
        // Arrange
        var taskResult = RepairTaskFactory.CreateRepairTask(parts: []);
        var task = taskResult.Value;

        Assert.NotNull(task.Parts);
        Assert.Empty(task.Parts);

        // Act
        var dto = task.ToDto();

        // Assert
        Assert.NotNull(dto.Parts);
        Assert.Empty(dto.Parts);
        Assert.Equal(task.Name, dto.Name);
    }

    [Fact]
    public void ToDtos_ShouldReturnEmptyList_WhenSourceIsEmpty()
    {
        // Arrange
        var tasks = new List<RepairTask>();

        // Act
        var dtos = tasks.ToDtos();

        // Assert
        Assert.NotNull(dtos);
        Assert.Empty(dtos);
    }
}