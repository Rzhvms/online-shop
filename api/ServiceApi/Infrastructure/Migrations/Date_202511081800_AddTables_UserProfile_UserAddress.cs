using Domain.User;
using FluentMigrator;

namespace Infrastructure.Migrations;

/// <summary>
/// Добавляем таблицу UserProfileModel и UserAddressModel
/// </summary>
[Migration(202511081800)]
public class Date_202511081800_AddTables_UserProfile_UserAddress : Migration
{
    public readonly string _profileTbName = nameof(UserProfileModel);
    public readonly string _addressTbName = nameof(UserAddressModel);
    
    /// <inheritdoc />
    public override void Up()
    {
        if (!Schema.Table(_profileTbName).Exists())
        {
            Create.Table(_profileTbName)
                .WithColumn(nameof(UserProfileModel.Id)).AsGuid().PrimaryKey()
                .WithColumn(nameof(UserProfileModel.UserId)).AsGuid().ForeignKey("fk_UserModel_UserId_ProfileModel", _profileTbName, nameof(UserModel.Id))
                .WithColumn(nameof(UserProfileModel.AvatarUrl)).AsString().Nullable()
                .WithColumn(nameof(UserProfileModel.BirthDate)).AsDateTime().Nullable()
                .WithColumn(nameof(UserProfileModel.Gender)).AsString().Nullable()
                .WithColumn(nameof(UserProfileModel.About)).AsString().Nullable();
        }

        if (!Schema.Table(_addressTbName).Exists())
        {
            Create.Table(_addressTbName)
                .WithColumn(nameof(UserAddressModel.Id)).AsGuid().PrimaryKey()
                .WithColumn(nameof(UserAddressModel.UserId)).AsGuid().ForeignKey("fk_UserModel_UserId_AddressModel", _addressTbName, nameof(UserModel.Id))
                .WithColumn(nameof(UserAddressModel.Country)).AsString().Nullable()
                .WithColumn(nameof(UserAddressModel.City)).AsString().Nullable()
                .WithColumn(nameof(UserAddressModel.Street)).AsString().Nullable()
                .WithColumn(nameof(UserAddressModel.House)).AsString().Nullable()
                .WithColumn(nameof(UserAddressModel.Apartment)).AsString().Nullable()
                .WithColumn(nameof(UserAddressModel.PostalCode)).AsString().Nullable()
                .WithColumn(nameof(UserAddressModel.IsDefault)).AsBoolean().NotNullable();
        }
    }

    /// <inheritdoc />
    public override void Down()
    {
        if (Schema.Table(_profileTbName).Exists())
        {
            Delete.Table(_profileTbName);
        }

        if (Schema.Table(_addressTbName).Exists())
        {
            Delete.Table(_addressTbName);
        }
    }
}