using Domain.User;
using FluentMigrator;

namespace Infrastructure.Migrations;

[Migration(202511011900)]
public class Date_202511011900_AddTables_UserDal_ClaimDal_RefreshTokenDal : Migration
{
    private readonly string _userTableName = nameof(UserDal);
    private readonly string _claimTableName = nameof(ClaimDal);
    private readonly string _tokenTableName = nameof(RefreshTokenDal);
    
    public override void Up()
    {
        if (!Schema.Table(_userTableName).Exists())
        {
            Create.Table(_userTableName)
                .WithColumn(nameof(UserDal.Id)).AsGuid().PrimaryKey()
                .WithColumn(nameof(UserDal.Email)).AsString(50).NotNullable()
                .WithColumn(nameof(UserDal.Phone)).AsString(20).Nullable()
                .WithColumn(nameof(UserDal.Password)).AsString().NotNullable()
                .WithColumn(nameof(UserDal.Salt)).AsString().NotNullable()
                .WithColumn(nameof(UserDal.Name)).AsString(50).NotNullable()
                .WithColumn(nameof(UserDal.LastName)).AsString(50).NotNullable()
                .WithColumn(nameof(UserDal.CreateAt)).AsDateTime().NotNullable()
                .WithColumn(nameof(UserDal.UpdateAt)).AsDateTime().Nullable();
        }
        
        if (!Schema.Table(_claimTableName).Exists())
        {
            Create.Table(_claimTableName)
                .WithColumn(nameof(ClaimDal.Id)).AsGuid().PrimaryKey()
                .WithColumn(nameof(ClaimDal.UserId)).AsGuid().ForeignKey("fk_UserDal_ClaimId_ClaimDal", _userTableName, nameof(UserDal.Id))
                .WithColumn(nameof(ClaimDal.Type)).AsString().Nullable()
                .WithColumn(nameof(ClaimDal.Value)).AsString().Nullable();
        }
        
        if (!Schema.Table(_tokenTableName).Exists())
        {
            Create.Table(_tokenTableName)
                .WithColumn(nameof(RefreshTokenDal.Id)).AsGuid().PrimaryKey()
                .WithColumn(nameof(RefreshTokenDal.UserId)).AsGuid().ForeignKey("fk_UserDal_RefreshToken_RefreshTokenDal", _userTableName, nameof(UserDal.Id))
                .WithColumn(nameof(RefreshTokenDal.Value)).AsString().Nullable()
                .WithColumn(nameof(RefreshTokenDal.Active)).AsBoolean().Nullable()
                .WithColumn(nameof(RefreshTokenDal.ExpirationDate)).AsDateTime().Nullable();
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