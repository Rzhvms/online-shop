using Domain.User;
using FluentMigrator;

namespace Infrastructure.Migrations;

/// <summary>
/// Добавляем таблицу UserModel, ClaimModel и RefreshTokenModel
/// </summary>
[Migration(202511011900)]
public class Date_202511011900_AddTables_UserDal_ClaimDal_RefreshTokenDal : Migration
{
    private readonly string _userTableName = nameof(UserModel);
    private readonly string _claimTableName = nameof(ClaimModel);
    private readonly string _tokenTableName = nameof(RefreshTokenModel);
    
    public override void Up()
    {
        if (!Schema.Table(_userTableName).Exists())
        {
            Create.Table(_userTableName)
                .WithColumn(nameof(UserModel.Id)).AsGuid().PrimaryKey()
                .WithColumn(nameof(UserModel.Email)).AsString(50).NotNullable()
                .WithColumn(nameof(UserModel.Phone)).AsString(20).Nullable()
                .WithColumn(nameof(UserModel.Password)).AsString().NotNullable()
                .WithColumn(nameof(UserModel.Salt)).AsString().NotNullable()
                .WithColumn(nameof(UserModel.Name)).AsString(50).NotNullable()
                .WithColumn(nameof(UserModel.LastName)).AsString(50).NotNullable()
                .WithColumn(nameof(UserModel.CreateAt)).AsDateTime().NotNullable()
                .WithColumn(nameof(UserModel.UpdateAt)).AsDateTime().Nullable();
        }
        
        if (!Schema.Table(_claimTableName).Exists())
        {
            Create.Table(_claimTableName)
                .WithColumn(nameof(ClaimModel.Id)).AsGuid().PrimaryKey()
                .WithColumn(nameof(ClaimModel.UserId)).AsGuid().ForeignKey("fk_UserDal_ClaimId_ClaimDal", _userTableName, nameof(UserModel.Id))
                .WithColumn(nameof(ClaimModel.Type)).AsString().Nullable()
                .WithColumn(nameof(ClaimModel.Value)).AsString().Nullable();
        }
        
        if (!Schema.Table(_tokenTableName).Exists())
        {
            Create.Table(_tokenTableName)
                .WithColumn(nameof(RefreshTokenModel.Id)).AsGuid().PrimaryKey()
                .WithColumn(nameof(RefreshTokenModel.UserId)).AsGuid().ForeignKey("fk_UserDal_RefreshToken_RefreshTokenDal", _userTableName, nameof(UserModel.Id))
                .WithColumn(nameof(RefreshTokenModel.Value)).AsString().Nullable()
                .WithColumn(nameof(RefreshTokenModel.Active)).AsBoolean().Nullable()
                .WithColumn(nameof(RefreshTokenModel.ExpirationDate)).AsDateTime().Nullable();
        }
    }

    public override void Down()
    {
        if (Schema.Table(_claimTableName).Exists())
        {
            Delete.Table(_claimTableName);
        }
        
        if (Schema.Table(_tokenTableName).Exists())
        {
            Delete.Table(_tokenTableName);
        }
        
        if (Schema.Table(_userTableName).Exists())
        {
            Delete.Table(_userTableName);
        }
    }
}