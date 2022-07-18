﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Urchin.Api.Persistence;

#nullable disable

namespace Urchin.Api.Migrations
{
    [DbContext(typeof(UrchinContext))]
    [Migration("20220718172913_Migration7")]
    partial class Migration7
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("urchin")
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PresidentVoter", b =>
                {
                    b.Property<int>("PresidentsId")
                        .HasColumnType("int");

                    b.Property<int>("VotersId")
                        .HasColumnType("int");

                    b.HasKey("PresidentsId", "VotersId");

                    b.HasIndex("VotersId");

                    b.ToTable("PresidentVoter", "urchin");
                });

            modelBuilder.Entity("Urchin.Api.Persistence.Entities.Ethnicity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ethnicities", "urchin");
                });

            modelBuilder.Entity("Urchin.Api.Persistence.Entities.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genders", "urchin");
                });

            modelBuilder.Entity("Urchin.Api.Persistence.Entities.Party", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Parties", "urchin");
                });

            modelBuilder.Entity("Urchin.Api.Persistence.Entities.President", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EthnicityId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EthnicityId");

                    b.HasIndex("GenderId");

                    b.HasIndex("PartyId");

                    b.ToTable("Presidents", "urchin");
                });

            modelBuilder.Entity("Urchin.Api.Persistence.Entities.Voter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Voters", "urchin");
                });

            modelBuilder.Entity("PresidentVoter", b =>
                {
                    b.HasOne("Urchin.Api.Persistence.Entities.President", null)
                        .WithMany()
                        .HasForeignKey("PresidentsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Urchin.Api.Persistence.Entities.Voter", null)
                        .WithMany()
                        .HasForeignKey("VotersId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Urchin.Api.Persistence.Entities.President", b =>
                {
                    b.HasOne("Urchin.Api.Persistence.Entities.Ethnicity", "Ethnicity")
                        .WithMany()
                        .HasForeignKey("EthnicityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Urchin.Api.Persistence.Entities.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Urchin.Api.Persistence.Entities.Party", "Party")
                        .WithMany()
                        .HasForeignKey("PartyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Ethnicity");

                    b.Navigation("Gender");

                    b.Navigation("Party");
                });
#pragma warning restore 612, 618
        }
    }
}
