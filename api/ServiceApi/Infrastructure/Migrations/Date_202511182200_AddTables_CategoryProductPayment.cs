using Domain.Delivery;
using Domain.Order;
using Domain.Payment;
using Domain.Product;
using Domain.Provider;
using Domain.User;
using FluentMigrator;

namespace Infrastructure.Migrations;

[Migration(202511182200)]
public class Date_202511182200_AddTables_CategoryProductPayment : Migration
{
    private readonly string _paymentTb = nameof(PaymentModel);
    private readonly string _categoryTb = nameof(CategoryModel);
    private readonly string _productCategoryTb = nameof(ProductCategoryModel);
    private readonly string _productImageTb = nameof(ProductImageModel);
    private readonly string _productReviewTb = nameof(ProductReviewModel);
    
    /// <inheritdoc />
    public override void Up()
    {
        if (!Schema.Table(_paymentTb).Exists())
        {
            Create.Table(_paymentTb)
                .WithColumn(nameof(PaymentModel.Id)).AsGuid().PrimaryKey()
                .WithColumn(nameof(PaymentModel.OrderId)).AsGuid().NotNullable()
                .WithColumn(nameof(PaymentModel.UserId)).AsGuid().NotNullable()
                .WithColumn(nameof(PaymentModel.Amount)).AsDecimal().NotNullable()
                .WithColumn(nameof(PaymentModel.Currency)).AsString().NotNullable()
                .WithColumn(nameof(PaymentModel.PaymentMethod)).AsInt16().NotNullable()
                .WithColumn(nameof(PaymentModel.Status)).AsInt16().NotNullable()
                .WithColumn(nameof(PaymentModel.PaymentSystemId)).AsString().Nullable()
                .WithColumn(nameof(PaymentModel.PaymentUrl)).AsString().Nullable()
                .WithColumn(nameof(PaymentModel.IsRefunded)).AsBoolean().Nullable()
                .WithColumn(nameof(PaymentModel.RefundAmount)).AsDecimal().Nullable()
                .WithColumn(nameof(PaymentModel.CreatedAt)).AsDateTime().NotNullable()
                .WithColumn(nameof(PaymentModel.UpdatedAt)).AsDateTime().Nullable();
        }
        
        if (!Schema.Table(_categoryTb).Exists())
        {
            Create.Table(_categoryTb)
                .WithColumn(nameof(CategoryModel.Id)).AsGuid().PrimaryKey()
                .WithColumn(nameof(CategoryModel.Name)).AsString(100).NotNullable()
                .WithColumn(nameof(CategoryModel.ParentId)).AsGuid().Nullable();
        }
        
        if (!Schema.Table(_productCategoryTb).Exists())
        {
            Create.Table(_productCategoryTb)
                .WithColumn(nameof(ProductCategoryModel.Id)).AsGuid().PrimaryKey()
                .WithColumn(nameof(ProductCategoryModel.ProductId)).AsGuid().NotNullable()
                .WithColumn(nameof(ProductCategoryModel.CategoryId)).AsGuid().NotNullable();
        }
        
        if (!Schema.Table(_productImageTb).Exists())
        {
            Create.Table(_productImageTb)
                .WithColumn(nameof(ProductImageModel.Id)).AsGuid().PrimaryKey()
                .WithColumn(nameof(ProductImageModel.ProductId)).AsGuid().NotNullable()
                .WithColumn(nameof(ProductImageModel.Url)).AsString().NotNullable()
                .WithColumn(nameof(ProductImageModel.SortOrder)).AsInt32().Nullable();
        }
        
        if (!Schema.Table(_productReviewTb).Exists())
        {
            Create.Table(_productReviewTb)
                .WithColumn(nameof(ProductReviewModel.Id)).AsGuid().PrimaryKey()
                .WithColumn(nameof(ProductReviewModel.UserId)).AsGuid().NotNullable()
                .WithColumn(nameof(ProductReviewModel.ProductId)).AsGuid().NotNullable()
                .WithColumn(nameof(ProductReviewModel.Rating)).AsInt32().NotNullable()
                .WithColumn(nameof(ProductReviewModel.Message)).AsString(300).Nullable()
                .WithColumn(nameof(ProductReviewModel.CreatedAt)).AsDateTime().NotNullable();
        }
        
        Create.ForeignKey("FK_Payment_Order")
            .FromTable(_paymentTb).ForeignColumn(nameof(PaymentModel.OrderId))
            .ToTable(nameof(OrderModel)).PrimaryColumn(nameof(OrderModel.Id))
            .OnDeleteOrUpdate(System.Data.Rule.Cascade);
        
        Create.ForeignKey("FK_Payment_User")
            .FromTable(_paymentTb).ForeignColumn(nameof(PaymentModel.UserId))
            .ToTable(nameof(UserModel)).PrimaryColumn(nameof(UserModel.Id))
            .OnDeleteOrUpdate(System.Data.Rule.Cascade);
        
        Create.ForeignKey("FK_CategoryParent_CategoryId")
            .FromTable(_categoryTb).ForeignColumn(nameof(CategoryModel.ParentId))
            .ToTable(_categoryTb).PrimaryColumn(nameof(CategoryModel.Id))
            .OnDeleteOrUpdate(System.Data.Rule.Cascade);
        
        Create.ForeignKey("FK_ProductCategory_Product")
            .FromTable(_productCategoryTb).ForeignColumn(nameof(ProductCategoryModel.ProductId))
            .ToTable(nameof(ProductModel)).PrimaryColumn(nameof(ProductModel.Id))
            .OnDeleteOrUpdate(System.Data.Rule.Cascade);
        
        Create.ForeignKey("FK_ProductCategory_Category")
            .FromTable(_productCategoryTb).ForeignColumn(nameof(ProductCategoryModel.CategoryId))
            .ToTable(_categoryTb).PrimaryColumn(nameof(CategoryModel.Id))
            .OnDeleteOrUpdate(System.Data.Rule.Cascade);
        
        Create.ForeignKey("FK_ProductImage_Product")
            .FromTable(_productImageTb).ForeignColumn(nameof(ProductImageModel.ProductId))
            .ToTable(nameof(ProductModel)).PrimaryColumn(nameof(ProductModel.Id))
            .OnDeleteOrUpdate(System.Data.Rule.Cascade);
        
        Create.ForeignKey("FK_ProductReview_User")
            .FromTable(_productReviewTb).ForeignColumn(nameof(ProductReviewModel.UserId))
            .ToTable(nameof(UserModel)).PrimaryColumn(nameof(UserModel.Id))
            .OnDeleteOrUpdate(System.Data.Rule.Cascade);
        
        Create.ForeignKey("FK_ProductReview_Product")
            .FromTable(_productReviewTb).ForeignColumn(nameof(ProductReviewModel.ProductId))
            .ToTable(nameof(ProductModel)).PrimaryColumn(nameof(ProductModel.Id))
            .OnDeleteOrUpdate(System.Data.Rule.Cascade);
    }

    /// <inheritdoc />
    public override void Down()
    {
        
    }
}