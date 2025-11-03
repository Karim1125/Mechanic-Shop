using MechanicShop.Application.Features.Billing.Mappers;
using MechanicShop.Domain.Workorders;
using MechanicShop.Domain.Workorders.Billing;
using MechanicShop.Tests.Common.Billing;
using MechanicShop.Tests.Common.Customers;
using MechanicShop.Tests.Common.WorkOrders;

using Xunit;

namespace MechanicShop.Application.UnitTests.Mappers;

public class InvoiceMapperTest
{
    [Fact]
    public void ToDto_ShouldThrowException_WhenInvoiceIsNull()
    {
        // Arrange
        Invoice invoice = null!;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => invoice.ToDto());
    }

    [Fact]
    public void ToDtos_ShouldReturnEmptyList_WhenSourceIsEmpty()
    {
        // Arrange
        var inoives = new List<Invoice>();

        // Act
        var dtos = inoives.ToDtos();

        // Assert
        Assert.NotNull(dtos);
        Assert.Empty(dtos);
    }

    [Fact]
    public void ToDto_ShouldMapCorrectly()
    {
        var invoice = InvoiceFactory.CreateInvoice();
        var dto = invoice.Value.ToDto();
        Assert.Equal(invoice.Value.Id, dto.InvoiceId);
        Assert.Equal(invoice.Value.TaxAmount, dto.TaxAmount);
        Assert.Equal(invoice.Value.DiscountAmount, dto.DiscountAmount);
        Assert.Equal(invoice.Value.WorkOrderId, dto.WorkOrderId);
        var lineItems = invoice.Value.LineItems;
        Assert.NotNull(lineItems);
        Assert.Equal(lineItems.Count(), dto.Items?.Count);
        foreach (var (v, dv) in lineItems.Zip(dto.Items!))
        {
            Assert.Equal(v.InvoiceId, dv.InvoiceId);
            Assert.Equal(v.Description, dv.Description);
            Assert.Equal(v.LineNumber, dv.LineNumber);
            Assert.Equal(v.Quantity, dv.Quantity);
            Assert.Equal(v.UnitPrice, dv.UnitPrice);
            Assert.Equal(v.LineTotal, dv.LineTotal);
        }
    }

    [Fact]
    public void ToDtos_ShouldMapListCorrectly()
    {
        var invoice = InvoiceFactory.CreateInvoice();
        var invoices = new List<Invoice> { invoice.Value };
        var dtos = invoices.ToDtos();
        Assert.Single(dtos);
        Assert.Equal(invoice.Value.Id, dtos[0].InvoiceId);
        Assert.Equal(invoice.Value.TaxAmount, dtos[0].TaxAmount);
        Assert.Equal(invoice.Value.DiscountAmount, dtos[0].DiscountAmount);
        Assert.Equal(invoice.Value.WorkOrderId, dtos[0].WorkOrderId);
        var lineItems = invoice.Value.LineItems;
        Assert.NotNull(lineItems);
        Assert.Equal(lineItems.Count(), dtos[0].Items?.Count);
        foreach (var (v, dv) in lineItems.Zip(dtos[0].Items!))
        {
            Assert.Equal(v.InvoiceId, dv.InvoiceId);
            Assert.Equal(v.Description, dv.Description);
            Assert.Equal(v.LineNumber, dv.LineNumber);
            Assert.Equal(v.Quantity, dv.Quantity);
            Assert.Equal(v.UnitPrice, dv.UnitPrice);
            Assert.Equal(v.LineTotal, dv.LineTotal);
        }
    }
}