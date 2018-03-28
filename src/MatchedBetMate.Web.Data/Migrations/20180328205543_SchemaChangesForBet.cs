using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MatchedBetMate.WebApi.Data.Migrations
{
    public partial class SchemaChangesForBet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_AspNetUsers_UserId",
                table: "Bets");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bets",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Bets",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BackCommission",
                table: "Bets",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BackOdds",
                table: "Bets",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BackStake",
                table: "Bets",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LayCommission",
                table: "Bets",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LayOdds",
                table: "Bets",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LayStake",
                table: "Bets",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Liability",
                table: "Bets",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_AspNetUsers_UserId",
                table: "Bets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_AspNetUsers_UserId",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "BackCommission",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "BackOdds",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "BackStake",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "LayCommission",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "LayOdds",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "LayStake",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "Liability",
                table: "Bets");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bets",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Bets",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_AspNetUsers_UserId",
                table: "Bets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
