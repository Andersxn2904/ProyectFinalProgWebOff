using DanderiTV.Layer.DataAccess.Enums;
using FluentMigrator;
    
namespace DanderiTV.Layer.DataAccess.Migrations
{
    [Migration(2410230001)]

    public class _2410230001_Migration : Migration
    {
        public override void Up()
        {
            //Based on Class Movie,Producer,Genre defined on DanderiTV.Layer.DataAccess.Entities
            #region Tables
            Create.Table(Tables.Series.ToString())
                .WithColumn("ID").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(100)
                .WithColumn("CoverUrl").AsString(int.MaxValue)
                .WithColumn("VideoUrl").AsString(int.MaxValue)
                .WithColumn("ProducerID").AsInt32()
                .WithColumn("MainGenreID").AsInt32()
                .WithColumn("SecondaryGenreID").AsInt32()
                .WithColumn("Created").AsDateTime();

            Create.Table(Tables.Producers.ToString())
               .WithColumn("ID").AsInt32().PrimaryKey().Identity()
               .WithColumn("Name").AsString(100)
               .WithColumn("Created").AsDateTime();

            Create.Table(Tables.Genres.ToString())
               .WithColumn("ID").AsInt32().PrimaryKey().Identity()
               .WithColumn("Name").AsString(100)
               .WithColumn("Created").AsDateTime();



            #endregion

            #region RelationShips

            #region Series
            Create.ForeignKey("FK_Producer_Serie")
                .FromTable(Tables.Series.ToString()).ForeignColumn("ProducerID")
                .ToTable(Tables.Producers.ToString()).PrimaryColumn("ID");

            Create.ForeignKey("FK_Serie_Genre_MainG")
                .FromTable(Tables.Series.ToString()).ForeignColumn("MainGenreID")
                .ToTable(Tables.Genres.ToString()).PrimaryColumn("ID");

            Create.ForeignKey("FK_Serie_Genre_SecG")
               .FromTable(Tables.Series.ToString()).ForeignColumn("SecondaryGenreID")
               .ToTable(Tables.Genres.ToString()).PrimaryColumn("ID");

            #endregion

            #endregion
        }

        public override void Down()
        {
            Delete.Table("Producto");
        }
    }
}
