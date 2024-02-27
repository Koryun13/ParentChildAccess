﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NestedSetsAccess.Data;

#nullable disable

namespace NestedSetsAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240226193056_InitDbWithData")]
    partial class InitDbWithData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NestedSetsAccess.Model.Node", b =>
                {
                    b.Property<int>("NodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NodeId"));

                    b.Property<int>("Left")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Right")
                        .HasColumnType("int");

                    b.HasKey("NodeId");

                    b.ToTable("Nodes");

                    b.HasData(
                        new
                        {
                            NodeId = 1,
                            Left = 1,
                            Name = "Node 1",
                            Right = 2
                        },
                        new
                        {
                            NodeId = 2,
                            Left = 3,
                            Name = "Node 2",
                            Right = 6
                        },
                        new
                        {
                            NodeId = 3,
                            Left = 7,
                            Name = "Node 3",
                            Right = 10
                        },
                        new
                        {
                            NodeId = 4,
                            Left = 11,
                            Name = "Node 4",
                            Right = 16
                        },
                        new
                        {
                            NodeId = 5,
                            Left = 17,
                            Name = "Node 5",
                            Right = 22
                        },
                        new
                        {
                            NodeId = 6,
                            Left = 23,
                            Name = "Node 6",
                            Right = 28
                        },
                        new
                        {
                            NodeId = 7,
                            Left = 29,
                            Name = "Node 7",
                            Right = 34
                        },
                        new
                        {
                            NodeId = 8,
                            Left = 35,
                            Name = "Node 8",
                            Right = 42
                        },
                        new
                        {
                            NodeId = 9,
                            Left = 43,
                            Name = "Node 9",
                            Right = 50
                        },
                        new
                        {
                            NodeId = 10,
                            Left = 51,
                            Name = "Node 10",
                            Right = 58
                        },
                        new
                        {
                            NodeId = 11,
                            Left = 59,
                            Name = "Node 11",
                            Right = 66
                        },
                        new
                        {
                            NodeId = 12,
                            Left = 67,
                            Name = "Node 12",
                            Right = 74
                        },
                        new
                        {
                            NodeId = 13,
                            Left = 75,
                            Name = "Node 13",
                            Right = 82
                        },
                        new
                        {
                            NodeId = 14,
                            Left = 83,
                            Name = "Node 14",
                            Right = 90
                        },
                        new
                        {
                            NodeId = 15,
                            Left = 91,
                            Name = "Node 15",
                            Right = 98
                        },
                        new
                        {
                            NodeId = 16,
                            Left = 99,
                            Name = "Node 16",
                            Right = 108
                        },
                        new
                        {
                            NodeId = 17,
                            Left = 109,
                            Name = "Node 17",
                            Right = 118
                        },
                        new
                        {
                            NodeId = 18,
                            Left = 119,
                            Name = "Node 18",
                            Right = 128
                        },
                        new
                        {
                            NodeId = 19,
                            Left = 129,
                            Name = "Node 19",
                            Right = 138
                        },
                        new
                        {
                            NodeId = 20,
                            Left = 139,
                            Name = "Node 20",
                            Right = 148
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
