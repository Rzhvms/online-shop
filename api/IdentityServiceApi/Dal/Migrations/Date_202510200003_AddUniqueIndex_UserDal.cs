using Dal.DalEntities;
using FluentMigrator;

namespace Dal.Migrations;

/// <summary>
/// Создание уникальнго индекса для UserName в таблице UserDal
/// </summary>
[Migration(202510200003)]
public class Date_202510200003_AddUniqueIndex_UserDal : Migration
{
    private readonly string _tableName = nameof(UserDal);
    private readonly string _colName = nameof(UserDal.UserName);
    private readonly string _indexName = "IX_UserDal_Unique_UserName";

    /// <inheritdoc />
    public override void Up()
    {
        if (Schema.Table(_tableName).Exists())
        {
            Create.Index(_indexName).OnTable(_tableName).OnColumn(_colName);
        }
    }

    /// <inheritdoc />
    public override void Down()
    {
        if (Schema.Table(_tableName).Exists())
        {
            Delete.Index(_indexName);
        }
    }
}