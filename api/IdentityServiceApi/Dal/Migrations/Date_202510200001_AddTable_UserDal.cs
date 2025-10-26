using Dal.DalEntities;
using FluentMigrator;

/// <summary>
/// Создание таблицы UserDal
/// </summary>
[Migration(202510200001)]
public class Date_202510200001_AddTable_UserDal : Migration
{
    private readonly string _tableName = nameof(UserDal);
    
    /// <inheritdoc />
    public override void Up()
    {
        if (!Schema.Table(_tableName).Exists())
        {
            Create.Table(_tableName)
                .WithColumn(nameof(UserDal.Id)).AsGuid().PrimaryKey().Identity().NotNullable()
                .WithColumn(nameof(UserDal.UserName)).AsString(50).NotNullable()
                .WithColumn(nameof(UserDal.PasswordHash)).AsString().NotNullable()
                .WithColumn(nameof(UserDal.Name)).AsString(50).Nullable()
                .WithColumn(nameof(UserDal.Surname)).AsString(50).Nullable()
                .WithColumn(nameof(UserDal.MiddleName)).AsString(50).Nullable()
                .WithColumn(nameof(UserDal.Email)).AsString(50).Nullable()
                .WithColumn(nameof(UserDal.Phone)).AsString(20).Nullable()
                .WithColumn(nameof(UserDal.EmailConfirmed)).AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn(nameof(UserDal.PhoneConfirmed)).AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn(nameof(UserDal.IsBlocked)).AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn(nameof(UserDal.CreatedAt)).AsDateTime().NotNullable()
                .WithColumn(nameof(UserDal.UpdatedAt)).AsDateTime().Nullable();
        }
    }

    /// <inheritdoc />
    public override void Down()
    {
        if (Schema.Table(_tableName).Exists())
        {
            Delete.Table(_tableName);
        }
    }
}