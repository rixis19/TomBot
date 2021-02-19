﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TomBot.Database;

namespace TomBot.Migrations
{
    [DbContext(typeof(TomBotEntities))]
    [Migration("20210212072835_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6");

            modelBuilder.Entity("TomBot.Database.EightBallAnswer", b =>
                {
                    b.Property<long>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AnswerColor")
                        .HasColumnType("TEXT");

                    b.Property<string>("AnswerText")
                        .HasColumnType("TEXT");

                    b.HasKey("AnswerId");

                    b.ToTable("EightBallAnswer");
                });

            modelBuilder.Entity("TomBot.Database.RememberThis", b =>
                {
                    b.Property<long>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AnswerAuthor")
                        .HasColumnType("TEXT");

                    b.Property<string>("AnswerText")
                        .HasColumnType("TEXT");

                    b.HasKey("AnswerId");

                    b.ToTable("RememberThis");
                });

            modelBuilder.Entity("TomBot.Database.TomQuotes", b =>
                {
                    b.Property<long>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AnswerText")
                        .HasColumnType("TEXT");

                    b.HasKey("AnswerId");

                    b.ToTable("TomQuotes");
                });
#pragma warning restore 612, 618
        }
    }
}
