﻿// <auto-generated />
using System;
using BlazorServerHost.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorServerHost.Data.Migrations.APCHardware
{
    [DbContext(typeof(APCHardwareDBContext))]
    [Migration("20220826150953_Create_Schema_AndSeed")]
    partial class Create_Schema_AndSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("BlazorServerHost.Data.Models.APCHardware.APCDefaultData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Address")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Device")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("APCDefaultDatas");
                });

            modelBuilder.Entity("BlazorServerHost.Data.Models.APCHardware.APCDevice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Num")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("APCDevices");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9514f1e3-65b4-4e10-9aaf-4e75f4086074"),
                            Name = "APCDevice_1",
                            Num = 1
                        },
                        new
                        {
                            Id = new Guid("e5546c19-f8aa-448d-ae8f-24912d9268c8"),
                            Name = "APCDevice_2",
                            Num = 2
                        },
                        new
                        {
                            Id = new Guid("065cbd72-41cb-48c6-9cf0-085f93529ccf"),
                            Name = "APCDevice_3",
                            Num = 3
                        },
                        new
                        {
                            Id = new Guid("6ef6ede2-4372-4fff-9326-4b94af83b436"),
                            Name = "APCDevice_4",
                            Num = 4
                        },
                        new
                        {
                            Id = new Guid("827801d3-27e1-4361-8463-2f1c93c7ed4b"),
                            Name = "APCDevice_5",
                            Num = 5
                        },
                        new
                        {
                            Id = new Guid("10475279-6c70-49ca-8f20-8651530a64be"),
                            Name = "APCDevice_6",
                            Num = 6
                        },
                        new
                        {
                            Id = new Guid("b9975371-5d2a-414f-bce8-f521b11bb173"),
                            Name = "APCDevice_7",
                            Num = 7
                        },
                        new
                        {
                            Id = new Guid("1ef416ab-d390-45ab-8673-98bb7d07cbd9"),
                            Name = "APCDevice_8",
                            Num = 8
                        },
                        new
                        {
                            Id = new Guid("7e6d91ff-3dcc-4c53-b77f-6513022cca94"),
                            Name = "APCDevice_9",
                            Num = 9
                        },
                        new
                        {
                            Id = new Guid("e0806ed0-cf44-42fb-bed7-da4861e3c1b8"),
                            Name = "APCDevice_10",
                            Num = 10
                        });
                });

            modelBuilder.Entity("BlazorServerHost.Data.Models.APCHardware.ConstParams", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Max")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Min")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Step")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ConstParams");
                });

            modelBuilder.Entity("BlazorServerHost.Data.Models.APCHardware.DynParams", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ConstParamsId")
                        .HasColumnType("TEXT");

                    b.Property<int>("ParamId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("ParameterDataInfoId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ConstParamsId");

                    b.HasIndex("ParameterDataInfoId");

                    b.ToTable("DynParams");
                });

            modelBuilder.Entity("BlazorServerHost.Data.Models.APCHardware.LiveParams", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("ParamId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("ParameterDataInfoId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ParameterDataInfoId");

                    b.ToTable("LiveParams");
                });

            modelBuilder.Entity("BlazorServerHost.Data.Models.APCHardware.ParameterData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("APCDeviceId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("DynParamsId")
                        .HasColumnType("TEXT");

                    b.Property<int>("ParamGroupId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ParamName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("APCDeviceId");

                    b.HasIndex("DynParamsId");

                    b.ToTable("ParameterDatas");
                });

            modelBuilder.Entity("BlazorServerHost.Data.Models.APCHardware.ParameterDataInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Format")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaxDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("MinDescription")
                        .HasColumnType("TEXT");

                    b.Property<double>("Multiplier")
                        .HasColumnType("REAL");

                    b.Property<string>("StepDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("Unit")
                        .HasColumnType("TEXT");

                    b.Property<string>("ValueDescription")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ParameterDataInfos");
                });

            modelBuilder.Entity("BlazorServerHost.Data.Models.APCHardware.DynParams", b =>
                {
                    b.HasOne("BlazorServerHost.Data.Models.APCHardware.ConstParams", "ConstParams")
                        .WithMany("DynParams")
                        .HasForeignKey("ConstParamsId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.HasOne("BlazorServerHost.Data.Models.APCHardware.ParameterDataInfo", "ParameterDataInfo")
                        .WithMany("DynParams")
                        .HasForeignKey("ParameterDataInfoId");

                    b.Navigation("ConstParams");

                    b.Navigation("ParameterDataInfo");
                });

            modelBuilder.Entity("BlazorServerHost.Data.Models.APCHardware.LiveParams", b =>
                {
                    b.HasOne("BlazorServerHost.Data.Models.APCHardware.ParameterDataInfo", "ParameterDataInfo")
                        .WithMany()
                        .HasForeignKey("ParameterDataInfoId");

                    b.Navigation("ParameterDataInfo");
                });

            modelBuilder.Entity("BlazorServerHost.Data.Models.APCHardware.ParameterData", b =>
                {
                    b.HasOne("BlazorServerHost.Data.Models.APCHardware.APCDevice", "APCDevice")
                        .WithMany("ParameterDatas")
                        .HasForeignKey("APCDeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorServerHost.Data.Models.APCHardware.DynParams", "DynParams")
                        .WithMany("ParameterDatas")
                        .HasForeignKey("DynParamsId");

                    b.Navigation("APCDevice");

                    b.Navigation("DynParams");
                });

            modelBuilder.Entity("BlazorServerHost.Data.Models.APCHardware.APCDevice", b =>
                {
                    b.Navigation("ParameterDatas");
                });

            modelBuilder.Entity("BlazorServerHost.Data.Models.APCHardware.ConstParams", b =>
                {
                    b.Navigation("DynParams");
                });

            modelBuilder.Entity("BlazorServerHost.Data.Models.APCHardware.DynParams", b =>
                {
                    b.Navigation("ParameterDatas");
                });

            modelBuilder.Entity("BlazorServerHost.Data.Models.APCHardware.ParameterDataInfo", b =>
                {
                    b.Navigation("DynParams");
                });
#pragma warning restore 612, 618
        }
    }
}
