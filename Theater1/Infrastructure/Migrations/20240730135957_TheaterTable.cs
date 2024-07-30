using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations;

/// <inheritdoc />
public partial class TheaterTable : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Composition_Author_IdAuthor",
            table: "Composition");

        migrationBuilder.DropForeignKey(
            name: "FK_Play_Composition_IdComposition",
            table: "Play");

        migrationBuilder.DropForeignKey(
            name: "FK_Play_Theater_IdTheater",
            table: "Play");

        migrationBuilder.DropColumn(
            name: "WorkTime",
            table: "Theater");

        migrationBuilder.AddColumn<TimeSpan>(
            name: "EndTime",
            table: "Theater",
            type: "time",
            nullable: false,
            defaultValue: new TimeSpan(0, 0, 0, 0, 0));

        migrationBuilder.AddColumn<TimeSpan>(
            name: "StartTime",
            table: "Theater",
            type: "time",
            nullable: false,
            defaultValue: new TimeSpan(0, 0, 0, 0, 0));

        migrationBuilder.AddForeignKey(
            name: "FK_Composition_Author_IdAuthor",
            table: "Composition",
            column: "IdAuthor",
            principalTable: "Author",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_Play_Composition_IdComposition",
            table: "Play",
            column: "IdComposition",
            principalTable: "Composition",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_Play_Theater_IdTheater",
            table: "Play",
            column: "IdTheater",
            principalTable: "Theater",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Composition_Author_IdAuthor",
            table: "Composition");

        migrationBuilder.DropForeignKey(
            name: "FK_Play_Composition_IdComposition",
            table: "Play");

        migrationBuilder.DropForeignKey(
            name: "FK_Play_Theater_IdTheater",
            table: "Play");

        migrationBuilder.DropColumn(
            name: "EndTime",
            table: "Theater");

        migrationBuilder.DropColumn(
            name: "StartTime",
            table: "Theater");

        migrationBuilder.AddColumn<string>(
            name: "WorkTime",
            table: "Theater",
            type: "nvarchar(100)",
            maxLength: 100,
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddForeignKey(
            name: "FK_Composition_Author_IdAuthor",
            table: "Composition",
            column: "IdAuthor",
            principalTable: "Author",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_Play_Composition_IdComposition",
            table: "Play",
            column: "IdComposition",
            principalTable: "Composition",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_Play_Theater_IdTheater",
            table: "Play",
            column: "IdTheater",
            principalTable: "Theater",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}
