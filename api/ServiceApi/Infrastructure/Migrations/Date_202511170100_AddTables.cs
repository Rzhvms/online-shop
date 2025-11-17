using Domain.Delivery;
using Domain.Order;
using Domain.Product;
using Domain.Provider;
using Domain.User;
using FluentMigrator;

namespace Infrastructure.Migrations;

/// <summary>
/// Миграция для создания таблиц и внешних ключей
/// </summary>
[Migration(202511170100)]
public class Date_202511170100_AddTables : Migration
{
    private readonly string _productTb = nameof(ProductModel);
    private readonly string _providerTb = nameof(ProviderModel);
    private readonly string _orderProductTb = nameof(OrderProductModel);
    private readonly string _orderTb = nameof(OrderModel);
    private readonly string _deliveryTb = nameof(DeliveryModel);
    private readonly string _userTb = nameof(UserModel);
    
    /// <inheritdoc />
    public override void Up()
    {
        // Продукты
        if (!Schema.Table(_productTb).Exists())
        {
            Create.Table(_productTb)
                .WithColumn(nameof(ProductModel.Id)).AsGuid().PrimaryKey()
                .WithColumn(nameof(ProductModel.Name)).AsString(150).NotNullable()
                .WithColumn(nameof(ProductModel.ProviderId)).AsGuid().Nullable()
                .WithColumn(nameof(ProductModel.Description)).AsString().Nullable()
                .WithColumn(nameof(ProductModel.Price)).AsDecimal().NotNullable()
                .WithColumn(nameof(ProductModel.Quantity)).AsInt32().NotNullable();
        }
        
        // Поставщик
        if (!Schema.Table(_providerTb).Exists())
        {
            Create.Table(_providerTb)
                .WithColumn(nameof(ProviderModel.Id)).AsGuid().PrimaryKey()
                .WithColumn(nameof(ProviderModel.Name)).AsString(150).NotNullable()
                .WithColumn(nameof(ProviderModel.Phone)).AsString(20).Nullable()
                .WithColumn(nameof(ProviderModel.Email)).AsString(50).Nullable()
                .WithColumn(nameof(ProviderModel.Address)).AsString().Nullable();
        }
        
        // Товары в заказе
        if (!Schema.Table(_orderProductTb).Exists())
        {
            Create.Table(_orderProductTb)
                .WithColumn(nameof(OrderProductModel.Id)).AsGuid().PrimaryKey()
                .WithColumn(nameof(OrderProductModel.OrderId)).AsGuid().Nullable()
                .WithColumn(nameof(OrderProductModel.ProductId)).AsGuid().Nullable()
                .WithColumn(nameof(OrderProductModel.Quantity)).AsInt32().NotNullable();
        }
        
        // Заказ
        if (!Schema.Table(_orderTb).Exists())
        {
            Create.Table(_orderTb)
                .WithColumn(nameof(OrderModel.Id)).AsGuid().PrimaryKey()
                .WithColumn(nameof(OrderModel.CustomerId)).AsGuid().NotNullable()
                .WithColumn(nameof(OrderModel.State)).AsInt16().NotNullable()
                .WithColumn(nameof(OrderModel.DeliveryId)).AsGuid().Nullable()
                .WithColumn(nameof(OrderModel.TotalSum)).AsDecimal().NotNullable()
                .WithColumn(nameof(OrderModel.OrderDate)).AsDateTime().NotNullable();
        }
        
        // Доставка
        if (!Schema.Table(_deliveryTb).Exists())
        {
            Create.Table(_deliveryTb)
                .WithColumn(nameof(DeliveryModel.Id)).AsGuid().PrimaryKey()
                .WithColumn(nameof(DeliveryModel.Date)).AsDateTime().NotNullable()
                .WithColumn(nameof(DeliveryModel.Address)).AsString().NotNullable()
                .WithColumn(nameof(DeliveryModel.Price)).AsDecimal().NotNullable();
        }
        
        Create.ForeignKey("FK_OrderProduct_Product")
            .FromTable(_orderProductTb).ForeignColumn(nameof(OrderProductModel.ProductId))
            .ToTable(_productTb).PrimaryColumn(nameof(ProductModel.Id))
            .OnDeleteOrUpdate(System.Data.Rule.Cascade);
        
        Create.ForeignKey("FK_Product_Provider")
            .FromTable(_productTb).ForeignColumn(nameof(ProductModel.ProviderId))
            .ToTable(_providerTb).PrimaryColumn(nameof(ProviderModel.Id))
            .OnDeleteOrUpdate(System.Data.Rule.Cascade);
        
        Create.ForeignKey("FK_OrderProduct_Order")
            .FromTable(_orderProductTb).ForeignColumn(nameof(OrderProductModel.OrderId))
            .ToTable(_orderTb).PrimaryColumn(nameof(OrderModel.Id))
            .OnDeleteOrUpdate(System.Data.Rule.Cascade);
        
        Create.ForeignKey("FK_Order_Delivery")
            .FromTable(_orderTb).ForeignColumn(nameof(OrderModel.DeliveryId))
            .ToTable(_deliveryTb).PrimaryColumn(nameof(DeliveryModel.Id))
            .OnDeleteOrUpdate(System.Data.Rule.Cascade);
        
        Create.ForeignKey("FK_Order_User")
            .FromTable(_orderTb).ForeignColumn(nameof(OrderModel.CustomerId))
            .ToTable(_userTb).PrimaryColumn(nameof(UserModel.Id))
            .OnDeleteOrUpdate(System.Data.Rule.Cascade);
    }

    /// <inheritdoc />
    public override void Down()
    {
        Delete.ForeignKey("FK_OrderProduct_Product").OnTable(_orderProductTb);
        Delete.ForeignKey("FK_Product_Provider").OnTable(_productTb);
        Delete.ForeignKey("FK_OrderProduct_Order").OnTable(_orderProductTb);
        Delete.ForeignKey("FK_Order_Delivery").OnTable(_orderTb);
        Delete.ForeignKey("FK_Order_User").OnTable(_orderTb);
        
        if (Schema.Table(_productTb).Exists()) Delete.Table(_productTb);
        if (Schema.Table(_providerTb).Exists()) Delete.Table(_providerTb);
        if (Schema.Table(_orderTb).Exists()) Delete.Table(_orderTb);
        if (Schema.Table(_orderProductTb).Exists()) Delete.Table(_orderProductTb);
        if (Schema.Table(_deliveryTb).Exists()) Delete.Table(_deliveryTb);
    }
}