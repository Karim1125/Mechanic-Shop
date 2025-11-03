using MechanicShop.Domain.Common.Results;
using MechanicShop.Domain.Customers;
using MechanicShop.Domain.Customers.Vehicles;
using MechanicShop.Domain.RepairTasks;
using MechanicShop.Domain.RepairTasks.Enums;
using MechanicShop.Domain.Workorders;
using MechanicShop.Domain.Workorders.Billing;
using MechanicShop.Domain.Workorders.Enums;

namespace MechanicShop.Tests.Common.Billing;

public static class InvoiceFactory
{
    public static Result<Invoice> CreateInvoice(
        Guid? id = null,
        Guid? workOrderId = null,
        List<InvoiceLineItem>? items = null,
        decimal? discount = null,
        decimal? taxAmount = null,
        TimeProvider? timeProvider = null)
    {
        var vehicle = Vehicle.Create(
            Guid.NewGuid(),
            make: "Toyota",
            model: "Corolla",
            year: 2020,
            licensePlate: "ABC-123").Value;

        var customer = Customer.Create(
            Guid.NewGuid(),
            name: "John Doe",
            phoneNumber: "+201234567890",
            email: "john@example.com",
            vehicles: [vehicle]).Value;

        vehicle.Customer = customer;

        var repairTask = RepairTask.Create(
            Guid.NewGuid(),
            "Oil Change",
            30m,
            RepairDurationInMinutes.Min30,
            parts: []);

        var repairTasks = repairTask.IsError
            ? []
            : new List<RepairTask> { repairTask.Value };

        var workOrderResult = WorkOrder.Create(
            workOrderId ?? Guid.NewGuid(),
            vehicle.Id,
            DateTimeOffset.UtcNow,
            DateTimeOffset.UtcNow.AddHours(2),
            Guid.NewGuid(),
            Spot.A,
            repairTasks);

        if (workOrderResult.IsError)
        {
            throw new InvalidOperationException($"WorkOrder creation failed: {string.Join(", ", workOrderResult.Errors.Select(e => e.Description))}");
        }

        var workOrder = workOrderResult.Value;

        workOrder.Vehicle = vehicle;
        workOrder.Vehicle.Customer = customer;

        var invoice = Invoice.Create(
            id ?? Guid.NewGuid(),
            workOrder.Id,
            items ?? [InvoiceLineItem.Create(Guid.NewGuid(), 1, "Oil Change", 2, 50).Value],
            discount ?? 0,
            taxAmount ?? 0,
            timeProvider ?? TimeProvider.System);

        if (invoice.IsError)
        {
            return invoice;
        }

        var invoiceValue = invoice.Value;

        invoiceValue.WorkOrder = workOrder;

        return invoiceValue;
    }
}


