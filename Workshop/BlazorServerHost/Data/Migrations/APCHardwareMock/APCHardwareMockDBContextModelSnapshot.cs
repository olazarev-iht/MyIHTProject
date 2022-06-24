﻿// <auto-generated />
using System;
using BlazorServerHost.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorServerHost.Data.Migrations.APCHardwareMock
{
    [DbContext(typeof(APCHardwareMockDBContext))]
    partial class APCHardwareMockDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("BlazorServerHost.Data.Models.APCHardwareMock.APCDevice", b =>
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
                            Id = new Guid("fe67c069-534a-4896-a021-9b1279d740b6"),
                            Name = "APCDevice_1",
                            Num = 1
                        },
                        new
                        {
                            Id = new Guid("c13121b4-9d76-48f8-80c7-b93ca268ed87"),
                            Name = "APCDevice_2",
                            Num = 2
                        },
                        new
                        {
                            Id = new Guid("8eed3876-5034-4ed0-b1dd-5ca9128c492c"),
                            Name = "APCDevice_3",
                            Num = 3
                        });
                });

            modelBuilder.Entity("BlazorServerHost.Data.Models.APCHardwareMock.ConstParams", b =>
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("6c689014-f5eb-4ff5-9b60-29803ab45c23"),
                            Max = 5000,
                            Min = 500,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("4165a408-2f9b-495a-9dc7-914678ef7e55"),
                            Max = 5000,
                            Min = 500,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("05638997-6a4a-479c-b700-68bfcaf18892"),
                            Max = 5000,
                            Min = 500,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("d1e48584-8ec2-4271-9bb9-b839065b0e9b"),
                            Max = 5000,
                            Min = 500,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("2ee575ad-5cfe-4bbb-abf1-f19a184ddffe"),
                            Max = 1000,
                            Min = 0,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("2114653a-d33e-4af0-8967-894d3c2ec318"),
                            Max = 1000,
                            Min = 0,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("a6e5bccd-b6de-41b7-a5fb-a1b8bfa5815f"),
                            Max = 1000,
                            Min = 0,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("8ab3af88-03c9-469e-9de6-d4c2108dfe7d"),
                            Max = 1000,
                            Min = 0,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("ffd80daf-bf7b-4e31-be10-f4758669d1f6"),
                            Max = 1000,
                            Min = 0,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("0be65824-c49c-491d-92c4-ba267ff6fc23"),
                            Max = 1000,
                            Min = 0,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("38b6095f-2336-496e-99fb-aa046d3fa9b6"),
                            Max = 5000,
                            Min = 500,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("83351af8-96d9-4e42-aa4e-287edf375e88"),
                            Max = 5000,
                            Min = 500,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("d3d0df5d-d888-4cd4-a31b-cf1da813d085"),
                            Max = 5000,
                            Min = 500,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("bbdb3bdb-fb02-4aa3-837d-49e43b185bec"),
                            Max = 5000,
                            Min = 500,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("4d99581c-5963-43fa-9b31-053ac74a1e38"),
                            Max = 1000,
                            Min = 0,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("bace22bf-74ee-4a21-9eaa-f5164a63fa2f"),
                            Max = 1000,
                            Min = 0,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("95c3c24a-c652-4655-b9f9-015b4167aaaa"),
                            Max = 1000,
                            Min = 0,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("734c9d13-02d0-41af-be0e-39d52315ced3"),
                            Max = 1000,
                            Min = 0,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("a7b54bae-d9a2-4058-9a5c-5862ffa4522b"),
                            Max = 1000,
                            Min = 0,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("1f3329a6-8737-4b99-9213-8b835d3325aa"),
                            Max = 1000,
                            Min = 0,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("c3a5db6a-981b-4038-bd56-c30abccc32f7"),
                            Max = 5000,
                            Min = 500,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("e93a1f12-eb6c-4b73-b5c6-17516e80f56a"),
                            Max = 5000,
                            Min = 500,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("e4a87cb0-21af-4ed5-89fd-3946c5589cf6"),
                            Max = 5000,
                            Min = 500,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("2c5c86ef-ec34-4780-b3cd-2b8ed9300bd3"),
                            Max = 5000,
                            Min = 500,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("897f59ef-effa-49f1-b461-33d90be610f5"),
                            Max = 1000,
                            Min = 0,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("df10ccb1-3393-4bb2-8b83-6fa719537de6"),
                            Max = 1000,
                            Min = 0,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("c8884f45-14b4-469d-b65f-e980bc1b301d"),
                            Max = 1000,
                            Min = 0,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("cb0e3c1f-924d-47cb-82e6-fd791c714e7e"),
                            Max = 1000,
                            Min = 0,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("c7bb414f-c75e-4af3-b25c-4ccbb3883fc9"),
                            Max = 1000,
                            Min = 0,
                            Step = 10
                        },
                        new
                        {
                            Id = new Guid("a04d178c-5cc7-4c54-b0cd-7671a7be03a3"),
                            Max = 1000,
                            Min = 0,
                            Step = 10
                        });
                });

            modelBuilder.Entity("BlazorServerHost.Data.Models.APCHardwareMock.DynParams", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ConstParamsId")
                        .HasColumnType("TEXT");

                    b.Property<int>("ParamId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ConstParamsId");

                    b.ToTable("DynParams");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d3ca04d4-0de0-4d19-b457-2a56ee530311"),
                            ConstParamsId = new Guid("6c689014-f5eb-4ff5-9b60-29803ab45c23"),
                            ParamId = 3,
                            Value = 2000
                        },
                        new
                        {
                            Id = new Guid("de91886d-6282-4b69-a277-5b19ab154327"),
                            ConstParamsId = new Guid("4165a408-2f9b-495a-9dc7-914678ef7e55"),
                            ParamId = 4,
                            Value = 2000
                        },
                        new
                        {
                            Id = new Guid("6b387293-f29e-4d3d-a09d-ea47fc80fcb9"),
                            ConstParamsId = new Guid("05638997-6a4a-479c-b700-68bfcaf18892"),
                            ParamId = 5,
                            Value = 4000
                        },
                        new
                        {
                            Id = new Guid("f2eab00d-03a4-4251-bd47-a582fb16d77f"),
                            ConstParamsId = new Guid("d1e48584-8ec2-4271-9bb9-b839065b0e9b"),
                            ParamId = 6,
                            Value = 2000
                        },
                        new
                        {
                            Id = new Guid("41048045-21a6-4716-8f0b-bb06b8576fb0"),
                            ConstParamsId = new Guid("2ee575ad-5cfe-4bbb-abf1-f19a184ddffe"),
                            ParamId = 9,
                            Value = 200
                        },
                        new
                        {
                            Id = new Guid("f82d0ca8-fc83-4fdc-bff1-679fe8dd08af"),
                            ConstParamsId = new Guid("2114653a-d33e-4af0-8967-894d3c2ec318"),
                            ParamId = 10,
                            Value = 200
                        },
                        new
                        {
                            Id = new Guid("55ad7f74-b073-4486-8626-50c21280cbef"),
                            ConstParamsId = new Guid("a6e5bccd-b6de-41b7-a5fb-a1b8bfa5815f"),
                            ParamId = 11,
                            Value = 200
                        },
                        new
                        {
                            Id = new Guid("555773d5-ad08-4f69-8aa6-144246a27b7e"),
                            ConstParamsId = new Guid("8ab3af88-03c9-469e-9de6-d4c2108dfe7d"),
                            ParamId = 12,
                            Value = 200
                        },
                        new
                        {
                            Id = new Guid("2ba8691a-470b-485a-a9ce-4b1110319284"),
                            ConstParamsId = new Guid("ffd80daf-bf7b-4e31-be10-f4758669d1f6"),
                            ParamId = 7,
                            Value = 1500
                        },
                        new
                        {
                            Id = new Guid("ceb35341-afb3-4d6b-84e7-8eef8385317a"),
                            ConstParamsId = new Guid("0be65824-c49c-491d-92c4-ba267ff6fc23"),
                            ParamId = 8,
                            Value = 6000
                        },
                        new
                        {
                            Id = new Guid("41087314-d54f-451d-9db1-ac398a0bcc3d"),
                            ConstParamsId = new Guid("38b6095f-2336-496e-99fb-aa046d3fa9b6"),
                            ParamId = 3,
                            Value = 2000
                        },
                        new
                        {
                            Id = new Guid("2825d4ce-1b5b-45a8-bbc1-3ebb187ced3d"),
                            ConstParamsId = new Guid("83351af8-96d9-4e42-aa4e-287edf375e88"),
                            ParamId = 4,
                            Value = 2000
                        },
                        new
                        {
                            Id = new Guid("a89e95c6-a65d-4467-897a-aa89a227c23a"),
                            ConstParamsId = new Guid("d3d0df5d-d888-4cd4-a31b-cf1da813d085"),
                            ParamId = 5,
                            Value = 4000
                        },
                        new
                        {
                            Id = new Guid("a957ba4b-5ce1-4deb-ba66-34597c14b9f8"),
                            ConstParamsId = new Guid("bbdb3bdb-fb02-4aa3-837d-49e43b185bec"),
                            ParamId = 6,
                            Value = 2000
                        },
                        new
                        {
                            Id = new Guid("c0ad4a76-f5c7-4800-869b-614d943bae4b"),
                            ConstParamsId = new Guid("4d99581c-5963-43fa-9b31-053ac74a1e38"),
                            ParamId = 9,
                            Value = 200
                        },
                        new
                        {
                            Id = new Guid("8b98b54d-a48b-4c18-a632-84b7b48930b0"),
                            ConstParamsId = new Guid("bace22bf-74ee-4a21-9eaa-f5164a63fa2f"),
                            ParamId = 10,
                            Value = 200
                        },
                        new
                        {
                            Id = new Guid("aec4fba4-594f-4250-aa9a-dbf7df3cf84d"),
                            ConstParamsId = new Guid("95c3c24a-c652-4655-b9f9-015b4167aaaa"),
                            ParamId = 11,
                            Value = 200
                        },
                        new
                        {
                            Id = new Guid("071b8fc5-0685-4f1e-b115-7111f4bdd123"),
                            ConstParamsId = new Guid("734c9d13-02d0-41af-be0e-39d52315ced3"),
                            ParamId = 12,
                            Value = 200
                        },
                        new
                        {
                            Id = new Guid("cf1d0a44-5113-44ee-8aeb-7362c858e14a"),
                            ConstParamsId = new Guid("a7b54bae-d9a2-4058-9a5c-5862ffa4522b"),
                            ParamId = 7,
                            Value = 1500
                        },
                        new
                        {
                            Id = new Guid("bfa9cd27-9d13-4527-81a9-70433ebb4a26"),
                            ConstParamsId = new Guid("1f3329a6-8737-4b99-9213-8b835d3325aa"),
                            ParamId = 8,
                            Value = 6000
                        },
                        new
                        {
                            Id = new Guid("64f632f2-a1c9-4f36-8223-c400beeecaaf"),
                            ConstParamsId = new Guid("c3a5db6a-981b-4038-bd56-c30abccc32f7"),
                            ParamId = 3,
                            Value = 2000
                        },
                        new
                        {
                            Id = new Guid("ccccadcd-ab4b-455d-b617-d81d66ec3f67"),
                            ConstParamsId = new Guid("e93a1f12-eb6c-4b73-b5c6-17516e80f56a"),
                            ParamId = 4,
                            Value = 2000
                        },
                        new
                        {
                            Id = new Guid("da5cc717-8e7b-406f-a1b3-563134496754"),
                            ConstParamsId = new Guid("e4a87cb0-21af-4ed5-89fd-3946c5589cf6"),
                            ParamId = 5,
                            Value = 4000
                        },
                        new
                        {
                            Id = new Guid("980479ff-6fe1-4af4-a565-9fdf22ddecc9"),
                            ConstParamsId = new Guid("2c5c86ef-ec34-4780-b3cd-2b8ed9300bd3"),
                            ParamId = 6,
                            Value = 2000
                        },
                        new
                        {
                            Id = new Guid("b54159e0-cc52-4f93-950b-39e1b25b9876"),
                            ConstParamsId = new Guid("897f59ef-effa-49f1-b461-33d90be610f5"),
                            ParamId = 9,
                            Value = 200
                        },
                        new
                        {
                            Id = new Guid("11bbded8-2af1-446e-8d3e-a5176dc8940e"),
                            ConstParamsId = new Guid("df10ccb1-3393-4bb2-8b83-6fa719537de6"),
                            ParamId = 10,
                            Value = 200
                        },
                        new
                        {
                            Id = new Guid("e719756c-e021-42d2-a288-ea92ca837f6f"),
                            ConstParamsId = new Guid("c8884f45-14b4-469d-b65f-e980bc1b301d"),
                            ParamId = 11,
                            Value = 200
                        },
                        new
                        {
                            Id = new Guid("838d37e0-65aa-4d9e-9522-4e8cda89eb64"),
                            ConstParamsId = new Guid("cb0e3c1f-924d-47cb-82e6-fd791c714e7e"),
                            ParamId = 12,
                            Value = 200
                        },
                        new
                        {
                            Id = new Guid("aeed17c8-1a4d-442d-b5f0-5862033c191d"),
                            ConstParamsId = new Guid("c7bb414f-c75e-4af3-b25c-4ccbb3883fc9"),
                            ParamId = 7,
                            Value = 1500
                        },
                        new
                        {
                            Id = new Guid("5d93d009-d1f9-4225-8954-c8862fad48d8"),
                            ConstParamsId = new Guid("a04d178c-5cc7-4c54-b0cd-7671a7be03a3"),
                            ParamId = 8,
                            Value = 6000
                        });
                });

            modelBuilder.Entity("BlazorServerHost.Data.Models.APCHardwareMock.LiveParams", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("ParamId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("LiveParams");
                });

            modelBuilder.Entity("BlazorServerHost.Data.Models.APCHardwareMock.ParameterData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("APCDeviceId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("DynParamsId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ParamName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("APCDeviceId");

                    b.HasIndex("DynParamsId");

                    b.ToTable("ParameterDatas");

                    b.HasData(
                        new
                        {
                            Id = new Guid("aaa2fd9a-6270-4bfd-b253-0471b5bc1926"),
                            APCDeviceId = new Guid("fe67c069-534a-4896-a021-9b1279d740b6"),
                            DynParamsId = new Guid("d3ca04d4-0de0-4d19-b457-2a56ee530311"),
                            ParamName = "Device1_HeatO2Ignition"
                        },
                        new
                        {
                            Id = new Guid("47690af8-a850-4e98-8aa6-6d02cc4ff4a2"),
                            APCDeviceId = new Guid("fe67c069-534a-4896-a021-9b1279d740b6"),
                            DynParamsId = new Guid("de91886d-6282-4b69-a277-5b19ab154327"),
                            ParamName = "Device1_HeatO2PreHeat"
                        },
                        new
                        {
                            Id = new Guid("74ff28f5-a1dc-4d80-93d1-84ac46468085"),
                            APCDeviceId = new Guid("fe67c069-534a-4896-a021-9b1279d740b6"),
                            DynParamsId = new Guid("6b387293-f29e-4d3d-a09d-ea47fc80fcb9"),
                            ParamName = "Device1_HeatO2Pierce"
                        },
                        new
                        {
                            Id = new Guid("bf04516f-2fc6-46f1-8605-8c4384d1c11c"),
                            APCDeviceId = new Guid("fe67c069-534a-4896-a021-9b1279d740b6"),
                            DynParamsId = new Guid("f2eab00d-03a4-4251-bd47-a582fb16d77f"),
                            ParamName = "Device1_HeatO2Cut"
                        },
                        new
                        {
                            Id = new Guid("ca3d7c69-6682-4c99-9ffb-40d3da62d12b"),
                            APCDeviceId = new Guid("fe67c069-534a-4896-a021-9b1279d740b6"),
                            DynParamsId = new Guid("41048045-21a6-4716-8f0b-bb06b8576fb0"),
                            ParamName = "Device1_FuelGasIgnition"
                        },
                        new
                        {
                            Id = new Guid("a6594eed-7f11-4c56-830c-54364a030fba"),
                            APCDeviceId = new Guid("fe67c069-534a-4896-a021-9b1279d740b6"),
                            DynParamsId = new Guid("f82d0ca8-fc83-4fdc-bff1-679fe8dd08af"),
                            ParamName = "Device1_FuelGasPreHeat"
                        },
                        new
                        {
                            Id = new Guid("632bb5f9-83af-4540-8554-ffc57670a37c"),
                            APCDeviceId = new Guid("fe67c069-534a-4896-a021-9b1279d740b6"),
                            DynParamsId = new Guid("55ad7f74-b073-4486-8626-50c21280cbef"),
                            ParamName = "Device1_FuelGasPierce"
                        },
                        new
                        {
                            Id = new Guid("7b736df4-c63a-447e-96be-ccc57e73d469"),
                            APCDeviceId = new Guid("fe67c069-534a-4896-a021-9b1279d740b6"),
                            DynParamsId = new Guid("555773d5-ad08-4f69-8aa6-144246a27b7e"),
                            ParamName = "Device1_FuelGasCut"
                        },
                        new
                        {
                            Id = new Guid("0896e1ad-eb97-495c-9e23-31fac38338ae"),
                            APCDeviceId = new Guid("fe67c069-534a-4896-a021-9b1279d740b6"),
                            DynParamsId = new Guid("2ba8691a-470b-485a-a9ce-4b1110319284"),
                            ParamName = "Device1_CutO2Pierce"
                        },
                        new
                        {
                            Id = new Guid("d259ce56-dcea-4c81-832a-b463a098d4a5"),
                            APCDeviceId = new Guid("fe67c069-534a-4896-a021-9b1279d740b6"),
                            DynParamsId = new Guid("ceb35341-afb3-4d6b-84e7-8eef8385317a"),
                            ParamName = "Device1_CutO2Cut"
                        },
                        new
                        {
                            Id = new Guid("436b8f76-2c13-4c86-b88c-9f56ad04cb88"),
                            APCDeviceId = new Guid("c13121b4-9d76-48f8-80c7-b93ca268ed87"),
                            DynParamsId = new Guid("41087314-d54f-451d-9db1-ac398a0bcc3d"),
                            ParamName = "Device2_HeatO2Ignition"
                        },
                        new
                        {
                            Id = new Guid("63a7fad2-0ca7-41f3-89f2-d39d2753b07c"),
                            APCDeviceId = new Guid("c13121b4-9d76-48f8-80c7-b93ca268ed87"),
                            DynParamsId = new Guid("2825d4ce-1b5b-45a8-bbc1-3ebb187ced3d"),
                            ParamName = "Device2_HeatO2PreHeat"
                        },
                        new
                        {
                            Id = new Guid("062d87d6-abbf-47fe-be59-e18cf85e2ac7"),
                            APCDeviceId = new Guid("c13121b4-9d76-48f8-80c7-b93ca268ed87"),
                            DynParamsId = new Guid("a89e95c6-a65d-4467-897a-aa89a227c23a"),
                            ParamName = "Device2_HeatO2Pierce"
                        },
                        new
                        {
                            Id = new Guid("b772226f-7556-4229-a49b-14854139381d"),
                            APCDeviceId = new Guid("c13121b4-9d76-48f8-80c7-b93ca268ed87"),
                            DynParamsId = new Guid("a957ba4b-5ce1-4deb-ba66-34597c14b9f8"),
                            ParamName = "Device2_HeatO2Cut"
                        },
                        new
                        {
                            Id = new Guid("999cd36e-34a2-46d2-8d97-34ddba8aa1a0"),
                            APCDeviceId = new Guid("c13121b4-9d76-48f8-80c7-b93ca268ed87"),
                            DynParamsId = new Guid("c0ad4a76-f5c7-4800-869b-614d943bae4b"),
                            ParamName = "Device2_FuelGasIgnition"
                        },
                        new
                        {
                            Id = new Guid("c370f21c-80f0-4099-944c-6e5faa95359f"),
                            APCDeviceId = new Guid("c13121b4-9d76-48f8-80c7-b93ca268ed87"),
                            DynParamsId = new Guid("8b98b54d-a48b-4c18-a632-84b7b48930b0"),
                            ParamName = "Device2_FuelGasPreHeat"
                        },
                        new
                        {
                            Id = new Guid("0348419b-97ab-4d04-ab04-270cf98d4f78"),
                            APCDeviceId = new Guid("c13121b4-9d76-48f8-80c7-b93ca268ed87"),
                            DynParamsId = new Guid("aec4fba4-594f-4250-aa9a-dbf7df3cf84d"),
                            ParamName = "Device2_FuelGasPierce"
                        },
                        new
                        {
                            Id = new Guid("1ad303a0-5f5e-4eb5-a61a-9a7e4327219a"),
                            APCDeviceId = new Guid("c13121b4-9d76-48f8-80c7-b93ca268ed87"),
                            DynParamsId = new Guid("071b8fc5-0685-4f1e-b115-7111f4bdd123"),
                            ParamName = "Device2_FuelGasCut"
                        },
                        new
                        {
                            Id = new Guid("5c9c4d19-db3c-4b38-8bbb-f2cc3704b854"),
                            APCDeviceId = new Guid("c13121b4-9d76-48f8-80c7-b93ca268ed87"),
                            DynParamsId = new Guid("cf1d0a44-5113-44ee-8aeb-7362c858e14a"),
                            ParamName = "Device2_CutO2Pierce"
                        },
                        new
                        {
                            Id = new Guid("fbf513d0-320c-4cb2-ab53-fef16c4fdbcb"),
                            APCDeviceId = new Guid("c13121b4-9d76-48f8-80c7-b93ca268ed87"),
                            DynParamsId = new Guid("bfa9cd27-9d13-4527-81a9-70433ebb4a26"),
                            ParamName = "Device2_CutO2Cut"
                        },
                        new
                        {
                            Id = new Guid("0f6c936e-95ca-441e-aca8-cbf61edac47e"),
                            APCDeviceId = new Guid("8eed3876-5034-4ed0-b1dd-5ca9128c492c"),
                            DynParamsId = new Guid("64f632f2-a1c9-4f36-8223-c400beeecaaf"),
                            ParamName = "Device3_HeatO2Ignition"
                        },
                        new
                        {
                            Id = new Guid("7b532663-d537-47c2-b463-5a5924de7221"),
                            APCDeviceId = new Guid("8eed3876-5034-4ed0-b1dd-5ca9128c492c"),
                            DynParamsId = new Guid("ccccadcd-ab4b-455d-b617-d81d66ec3f67"),
                            ParamName = "Device3_HeatO2PreHeat"
                        },
                        new
                        {
                            Id = new Guid("a71aca2d-7b8f-49f6-8452-de40611bd1d8"),
                            APCDeviceId = new Guid("8eed3876-5034-4ed0-b1dd-5ca9128c492c"),
                            DynParamsId = new Guid("da5cc717-8e7b-406f-a1b3-563134496754"),
                            ParamName = "Device3_HeatO2Pierce"
                        },
                        new
                        {
                            Id = new Guid("8bbc8bca-f271-4063-9c37-306820696c1d"),
                            APCDeviceId = new Guid("8eed3876-5034-4ed0-b1dd-5ca9128c492c"),
                            DynParamsId = new Guid("980479ff-6fe1-4af4-a565-9fdf22ddecc9"),
                            ParamName = "Device3_HeatO2Cut"
                        },
                        new
                        {
                            Id = new Guid("5771a89a-6ad5-49b3-86f1-54a2de5d126a"),
                            APCDeviceId = new Guid("8eed3876-5034-4ed0-b1dd-5ca9128c492c"),
                            DynParamsId = new Guid("b54159e0-cc52-4f93-950b-39e1b25b9876"),
                            ParamName = "Device3_FuelGasIgnition"
                        },
                        new
                        {
                            Id = new Guid("e47c05e3-cb4a-4311-aac9-032dde0cefac"),
                            APCDeviceId = new Guid("8eed3876-5034-4ed0-b1dd-5ca9128c492c"),
                            DynParamsId = new Guid("11bbded8-2af1-446e-8d3e-a5176dc8940e"),
                            ParamName = "Device3_FuelGasPreHeat"
                        },
                        new
                        {
                            Id = new Guid("8d6462d1-6520-471a-ab2c-21efdee20710"),
                            APCDeviceId = new Guid("8eed3876-5034-4ed0-b1dd-5ca9128c492c"),
                            DynParamsId = new Guid("e719756c-e021-42d2-a288-ea92ca837f6f"),
                            ParamName = "Device3_FuelGasPierce"
                        },
                        new
                        {
                            Id = new Guid("70819535-94e3-4674-807b-27dab04c8750"),
                            APCDeviceId = new Guid("8eed3876-5034-4ed0-b1dd-5ca9128c492c"),
                            DynParamsId = new Guid("838d37e0-65aa-4d9e-9522-4e8cda89eb64"),
                            ParamName = "Device3_FuelGasCut"
                        },
                        new
                        {
                            Id = new Guid("8890c57c-3bb6-4fd7-9ae3-0c86b3daf276"),
                            APCDeviceId = new Guid("8eed3876-5034-4ed0-b1dd-5ca9128c492c"),
                            DynParamsId = new Guid("aeed17c8-1a4d-442d-b5f0-5862033c191d"),
                            ParamName = "Device3_CutO2Pierce"
                        },
                        new
                        {
                            Id = new Guid("b97a844c-e975-443f-abe8-3e755291405d"),
                            APCDeviceId = new Guid("8eed3876-5034-4ed0-b1dd-5ca9128c492c"),
                            DynParamsId = new Guid("5d93d009-d1f9-4225-8954-c8862fad48d8"),
                            ParamName = "Device3_CutO2Cut"
                        });
                });

            modelBuilder.Entity("BlazorServerHost.Data.Models.APCHardwareMock.DynParams", b =>
                {
                    b.HasOne("BlazorServerHost.Data.Models.APCHardwareMock.ConstParams", "ConstParams")
                        .WithMany()
                        .HasForeignKey("ConstParamsId");

                    b.Navigation("ConstParams");
                });

            modelBuilder.Entity("BlazorServerHost.Data.Models.APCHardwareMock.ParameterData", b =>
                {
                    b.HasOne("BlazorServerHost.Data.Models.APCHardwareMock.APCDevice", "APCDevice")
                        .WithMany()
                        .HasForeignKey("APCDeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorServerHost.Data.Models.APCHardwareMock.DynParams", "DynParams")
                        .WithMany()
                        .HasForeignKey("DynParamsId");

                    b.Navigation("APCDevice");

                    b.Navigation("DynParams");
                });
#pragma warning restore 612, 618
        }
    }
}