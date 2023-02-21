﻿// <auto-generated />
using System;
using IhtApcWebServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IhtApcWebServer.Data.Migrations.APCHardware
{
    [DbContext(typeof(APCHardwareDBContext))]
    [Migration("20230216152648_Create_ConfigSettings")]
    partial class Create_ConfigSettings
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("IhtApcWebServer.Data.Models.APCHardware.APCDevice", b =>
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
                            Id = new Guid("1ceeb1b3-6f62-4653-820b-7ce1a1139fc3"),
                            Name = "APCDevice_1",
                            Num = 1
                        },
                        new
                        {
                            Id = new Guid("38983e9f-6ffa-46f9-bf81-22fa2ebe98a6"),
                            Name = "APCDevice_2",
                            Num = 2
                        },
                        new
                        {
                            Id = new Guid("15ebd362-dbda-434f-b14e-04e3f2cfc4a6"),
                            Name = "APCDevice_3",
                            Num = 3
                        },
                        new
                        {
                            Id = new Guid("ab1d393b-f220-4230-a6a1-b7f4082238f2"),
                            Name = "APCDevice_4",
                            Num = 4
                        },
                        new
                        {
                            Id = new Guid("4a562c31-79bf-4bcf-937c-b1a9d3f763ae"),
                            Name = "APCDevice_5",
                            Num = 5
                        },
                        new
                        {
                            Id = new Guid("e7923f55-433c-46ea-a75c-651e016ab89d"),
                            Name = "APCDevice_6",
                            Num = 6
                        },
                        new
                        {
                            Id = new Guid("0d86da89-cb67-4fa3-a4a4-3e48bdb3c427"),
                            Name = "APCDevice_7",
                            Num = 7
                        },
                        new
                        {
                            Id = new Guid("8bee6017-ca82-4eb3-a8d4-6f2a1316e8e2"),
                            Name = "APCDevice_8",
                            Num = 8
                        },
                        new
                        {
                            Id = new Guid("24d515a1-cb91-4314-a7db-f1c007e40e75"),
                            Name = "APCDevice_9",
                            Num = 9
                        },
                        new
                        {
                            Id = new Guid("198b12bd-9f42-41c4-a526-4d4b487f9ac3"),
                            Name = "APCDevice_10",
                            Num = 10
                        });
                });

            modelBuilder.Entity("IhtApcWebServer.Data.Models.APCHardware.ConfigSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Baudrate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ComPort")
                        .HasColumnType("TEXT");

                    b.Property<string>("ComPortLast")
                        .HasColumnType("TEXT");

                    b.Property<string>("CultureStr")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("DataBaseGuid")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DataBaseMaterialSelectedIndex")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DataBaseNozzleSelectedIndex")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DataBaseThicknessSelectedIndex")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DataBits")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("ExecReset")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Identifier")
                        .HasColumnType("TEXT");

                    b.Property<string>("IpAddr")
                        .HasColumnType("TEXT");

                    b.Property<int?>("LengthUnit")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Mode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Parity")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PressureUnit")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StopBits")
                        .HasColumnType("TEXT");

                    b.Property<string>("TcpPort")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("TorchEnabled_01")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("TorchEnabled_02")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("TorchEnabled_03")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("TorchEnabled_04")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("TorchEnabled_05")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("TorchEnabled_06")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("TorchEnabled_07")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("TorchEnabled_08")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("TorchEnabled_09")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("TorchEnabled_10")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("TorchInstalled_01")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("TorchInstalled_02")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("TorchInstalled_03")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("TorchInstalled_04")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("TorchInstalled_05")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("TorchInstalled_06")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("TorchInstalled_07")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("TorchInstalled_08")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("TorchInstalled_09")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("TorchInstalled_10")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TorchType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ConfigSettings");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8d9f5e97-adb8-4e0e-a68f-a1eb10c5f906")
                        });
                });

            modelBuilder.Entity("IhtApcWebServer.Data.Models.APCHardware.ConstParams", b =>
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

            modelBuilder.Entity("IhtApcWebServer.Data.Models.APCHardware.DynParams", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Address")
                        .HasColumnType("INTEGER");

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

            modelBuilder.Entity("IhtApcWebServer.Data.Models.APCHardware.LiveParams", b =>
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

            modelBuilder.Entity("IhtApcWebServer.Data.Models.APCHardware.ParameterData", b =>
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

            modelBuilder.Entity("IhtApcWebServer.Data.Models.APCHardware.ParameterDataInfo", b =>
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

            modelBuilder.Entity("IhtApcWebServer.Data.Models.APCHardware.ParamSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ParamId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ParamOrder")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ParamViewGroupId")
                        .HasColumnType("TEXT");

                    b.Property<int>("PasswordLevel")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ParamViewGroupId");

                    b.ToTable("ParamSettings");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fc8e4894-2455-4900-97c2-21bcf1492557"),
                            ClientId = "default",
                            ParamId = "TactileInitialPosFinding",
                            ParamOrder = 1,
                            ParamViewGroupId = "HeightCalibration",
                            PasswordLevel = 0
                        },
                        new
                        {
                            Id = new Guid("999f44f7-caa7-437d-90cc-f8e82bdf186f"),
                            ClientId = "default",
                            ParamId = "DistanceCalibration",
                            ParamOrder = 2,
                            ParamViewGroupId = "HeightCalibration",
                            PasswordLevel = 0
                        },
                        new
                        {
                            Id = new Guid("14a96817-f228-416e-8c68-60b31ed6e6fc"),
                            ClientId = "default",
                            ParamId = "LinearDrivePosition",
                            ParamOrder = 3,
                            ParamViewGroupId = "HeightCalibration",
                            PasswordLevel = 0
                        },
                        new
                        {
                            Id = new Guid("974821f5-0d6b-4e02-80c6-3da4b21a256c"),
                            ClientId = "default",
                            ParamId = "CalibrationValid",
                            ParamOrder = 4,
                            ParamViewGroupId = "HeightCalibration",
                            PasswordLevel = 0
                        },
                        new
                        {
                            Id = new Guid("4779aa90-aa21-4c0d-a4f4-2e55cf5b1bb3"),
                            ClientId = "default",
                            ParamId = "CalibrationActive",
                            ParamOrder = 5,
                            ParamViewGroupId = "HeightCalibration",
                            PasswordLevel = 0
                        },
                        new
                        {
                            Id = new Guid("37635de6-17a5-4aa8-b70e-8161768b86bb"),
                            ClientId = "default",
                            ParamId = "RetractHeight",
                            ParamOrder = 1,
                            ParamViewGroupId = "RetractPosition",
                            PasswordLevel = 0
                        },
                        new
                        {
                            Id = new Guid("502c0604-d13e-497a-92e7-d730ee5506b3"),
                            ClientId = "default",
                            ParamId = "RetractPosAtProcessEnd",
                            ParamOrder = 2,
                            ParamViewGroupId = "RetractPosition",
                            PasswordLevel = 0
                        },
                        new
                        {
                            Id = new Guid("ac41e042-cb79-4d6a-a55b-63e1744b5938"),
                            ClientId = "default",
                            ParamId = "SlagSensitivity",
                            ParamOrder = 1,
                            ParamViewGroupId = "Slag",
                            PasswordLevel = 0
                        },
                        new
                        {
                            Id = new Guid("c4cd2976-00f8-479a-b657-16afe3e54a35"),
                            ClientId = "default",
                            ParamId = "SlagPostTime",
                            ParamOrder = 2,
                            ParamViewGroupId = "Slag",
                            PasswordLevel = 1
                        },
                        new
                        {
                            Id = new Guid("b268811c-63b4-4f51-ab79-a5c34dfd6666"),
                            ClientId = "default",
                            ParamId = "SlagCuttingSpeedReduction",
                            ParamOrder = 3,
                            ParamViewGroupId = "Slag",
                            PasswordLevel = 2
                        },
                        new
                        {
                            Id = new Guid("99b8ba95-b022-4b96-94ed-d8f9eeb0ba02"),
                            ClientId = "default",
                            ParamId = "CutO2Blowout",
                            ParamOrder = 1,
                            ParamViewGroupId = "PreFlow",
                            PasswordLevel = 0
                        },
                        new
                        {
                            Id = new Guid("737a2fa0-ce94-4c98-9e25-1750dc016e0e"),
                            ClientId = "default",
                            ParamId = "CutO2BlowoutBreak",
                            ParamOrder = 2,
                            ParamViewGroupId = "PreFlow",
                            PasswordLevel = 0
                        },
                        new
                        {
                            Id = new Guid("e514a400-3133-4d3d-83d9-a6bef8dbfaea"),
                            ClientId = "default",
                            ParamId = "CutO2BlowoutActive",
                            ParamOrder = 3,
                            ParamViewGroupId = "PreFlow",
                            PasswordLevel = 0
                        },
                        new
                        {
                            Id = new Guid("36bebf5f-d789-4ae7-9dac-dec631f6460f"),
                            ClientId = "default",
                            ParamId = "CurrCutO2BlowoutTime",
                            ParamOrder = 4,
                            ParamViewGroupId = "PreFlow",
                            PasswordLevel = 0
                        },
                        new
                        {
                            Id = new Guid("3784114e-3887-4dff-89b2-a6f4b767bc52"),
                            ClientId = "default",
                            ParamId = "CutO2BlowOutTime",
                            ParamOrder = 5,
                            ParamViewGroupId = "PreFlow",
                            PasswordLevel = 1
                        },
                        new
                        {
                            Id = new Guid("d2c2d827-5e79-424c-9be6-27d0744b288c"),
                            ClientId = "default",
                            ParamId = "CutO2BlowOutPressure",
                            ParamOrder = 6,
                            ParamViewGroupId = "PreFlow",
                            PasswordLevel = 1
                        },
                        new
                        {
                            Id = new Guid("fae0c09c-1974-4a18-a974-dbb10bfda892"),
                            ClientId = "default",
                            ParamId = "CutO2BlowOutTimeOut",
                            ParamOrder = 7,
                            ParamViewGroupId = "PreFlow",
                            PasswordLevel = 1
                        },
                        new
                        {
                            Id = new Guid("8bc0182f-d820-45cd-a63b-a0f438461936"),
                            ClientId = "default",
                            ParamId = "PiercingSensorMode",
                            ParamOrder = 1,
                            ParamViewGroupId = "Piercing",
                            PasswordLevel = 0
                        },
                        new
                        {
                            Id = new Guid("0a959710-5d5d-43f5-a217-b92bf052c5cc"),
                            ClientId = "default",
                            ParamId = "Dynamic",
                            ParamOrder = 1,
                            ParamViewGroupId = "HeightControl",
                            PasswordLevel = 1
                        },
                        new
                        {
                            Id = new Guid("640b4b66-1975-4760-a27c-fcd2045f2d87"),
                            ClientId = "default",
                            ParamId = "HeightControlActive",
                            ParamOrder = 2,
                            ParamViewGroupId = "HeightControl",
                            PasswordLevel = 0
                        },
                        new
                        {
                            Id = new Guid("9be972e1-d9c1-4ec1-9662-c4c8f0549cc1"),
                            ClientId = "default",
                            ParamId = "LinearDrivePosition",
                            ParamOrder = 3,
                            ParamViewGroupId = "HeightControl",
                            PasswordLevel = 0
                        },
                        new
                        {
                            Id = new Guid("048ca680-088b-4b97-8cf9-97fe59c6def3"),
                            ClientId = "default",
                            ParamId = "StatusHeightControl",
                            ParamOrder = 4,
                            ParamViewGroupId = "HeightControl",
                            PasswordLevel = 0
                        });
                });

            modelBuilder.Entity("IhtApcWebServer.Data.Models.APCHardware.ParamViewGroup", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GroupOrder")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ParamViewGroups");

                    b.HasData(
                        new
                        {
                            Id = "HeightCalibration",
                            GroupName = "Height Calibration",
                            GroupOrder = 1
                        },
                        new
                        {
                            Id = "RetractPosition",
                            GroupName = "Retract Position",
                            GroupOrder = 2
                        },
                        new
                        {
                            Id = "Slag",
                            GroupName = "Slag",
                            GroupOrder = 3
                        },
                        new
                        {
                            Id = "PreFlow",
                            GroupName = "Pre Flow",
                            GroupOrder = 4
                        },
                        new
                        {
                            Id = "Piercing",
                            GroupName = "Piercing",
                            GroupOrder = 5
                        },
                        new
                        {
                            Id = "HeightControl",
                            GroupName = "Height Control",
                            GroupOrder = 6
                        },
                        new
                        {
                            Id = "HeightCalibration_client1",
                            GroupName = "Height Calibration",
                            GroupOrder = 1
                        },
                        new
                        {
                            Id = "RetractPosition_client1",
                            GroupName = "Retract Position",
                            GroupOrder = 3
                        },
                        new
                        {
                            Id = "Slag_client1",
                            GroupName = "Slag",
                            GroupOrder = 2
                        },
                        new
                        {
                            Id = "PreFlow_client1",
                            GroupName = "Pre Flow",
                            GroupOrder = 4
                        },
                        new
                        {
                            Id = "Piercing_client1",
                            GroupName = "Piercing",
                            GroupOrder = 5
                        },
                        new
                        {
                            Id = "HeightControl_client1",
                            GroupName = "Height Control",
                            GroupOrder = 6
                        });
                });

            modelBuilder.Entity("IhtApcWebServer.Data.Models.APCHardware.DynParams", b =>
                {
                    b.HasOne("IhtApcWebServer.Data.Models.APCHardware.ConstParams", "ConstParams")
                        .WithMany("DynParams")
                        .HasForeignKey("ConstParamsId");

                    b.HasOne("IhtApcWebServer.Data.Models.APCHardware.ParameterDataInfo", "ParameterDataInfo")
                        .WithMany("DynParams")
                        .HasForeignKey("ParameterDataInfoId");

                    b.Navigation("ConstParams");

                    b.Navigation("ParameterDataInfo");
                });

            modelBuilder.Entity("IhtApcWebServer.Data.Models.APCHardware.LiveParams", b =>
                {
                    b.HasOne("IhtApcWebServer.Data.Models.APCHardware.ParameterDataInfo", "ParameterDataInfo")
                        .WithMany()
                        .HasForeignKey("ParameterDataInfoId");

                    b.Navigation("ParameterDataInfo");
                });

            modelBuilder.Entity("IhtApcWebServer.Data.Models.APCHardware.ParameterData", b =>
                {
                    b.HasOne("IhtApcWebServer.Data.Models.APCHardware.APCDevice", "APCDevice")
                        .WithMany("ParameterDatas")
                        .HasForeignKey("APCDeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IhtApcWebServer.Data.Models.APCHardware.DynParams", "DynParams")
                        .WithMany("ParameterDatas")
                        .HasForeignKey("DynParamsId");

                    b.Navigation("APCDevice");

                    b.Navigation("DynParams");
                });

            modelBuilder.Entity("IhtApcWebServer.Data.Models.APCHardware.ParamSettings", b =>
                {
                    b.HasOne("IhtApcWebServer.Data.Models.APCHardware.ParamViewGroup", "ParamViewGroup")
                        .WithMany()
                        .HasForeignKey("ParamViewGroupId");

                    b.Navigation("ParamViewGroup");
                });

            modelBuilder.Entity("IhtApcWebServer.Data.Models.APCHardware.APCDevice", b =>
                {
                    b.Navigation("ParameterDatas");
                });

            modelBuilder.Entity("IhtApcWebServer.Data.Models.APCHardware.ConstParams", b =>
                {
                    b.Navigation("DynParams");
                });

            modelBuilder.Entity("IhtApcWebServer.Data.Models.APCHardware.DynParams", b =>
                {
                    b.Navigation("ParameterDatas");
                });

            modelBuilder.Entity("IhtApcWebServer.Data.Models.APCHardware.ParameterDataInfo", b =>
                {
                    b.Navigation("DynParams");
                });
#pragma warning restore 612, 618
        }
    }
}