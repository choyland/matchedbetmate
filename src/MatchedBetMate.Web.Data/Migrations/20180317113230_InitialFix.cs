using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MatchedBetMate.WebApi.Data.Migrations
{
    public partial class InitialFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_AspNetUsers_UserId1",
                table: "Bets");

            migrationBuilder.DropIndex(
                name: "IX_Bets_UserId1",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Bets");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bets",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Bets_UserId",
                table: "Bets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_AspNetUsers_UserId",
                table: "Bets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_AspNetUsers_UserId",
                table: "Bets");

            migrationBuilder.DropIndex(
                name: "IX_Bets_UserId",
                table: "Bets");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Bets",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Bets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bets_UserId1",
                table: "Bets",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_AspNetUsers_UserId1",
                table: "Bets",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
