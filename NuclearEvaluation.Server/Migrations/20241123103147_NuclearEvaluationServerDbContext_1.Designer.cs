﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NuclearEvaluation.Server.Data;

#nullable disable

namespace NuclearEvaluation.Server.Migrations
{
    [DbContext(typeof(NuclearEvaluationServerDbContext))]
    [Migration("20241123103147_NuclearEvaluationServerDbContext_1")]
    partial class NuclearEvaluationServerDbContext_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Domain.Apm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<decimal?>("ErU234")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<decimal?>("ErU235")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<decimal?>("ErU236")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<decimal?>("ErU238")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<int>("SubSampleId")
                        .HasColumnType("int");

                    b.Property<decimal?>("U234")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<decimal?>("U235")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<decimal?>("U236")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<decimal?>("U238")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.HasKey("Id");

                    b.HasIndex("SubSampleId");

                    b.ToTable("Apm");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Domain.Particle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AnalysisDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<decimal?>("ErU234")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<decimal?>("ErU235")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<bool>("IsNu")
                        .HasColumnType("bit");

                    b.Property<string>("LaboratoryCode")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<decimal>("ParticleExternalId")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("SubSampleId")
                        .HasColumnType("int");

                    b.Property<decimal?>("U234")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<decimal?>("U235")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.HasKey("Id");

                    b.HasIndex("SubSampleId");

                    b.ToTable("Particle");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Domain.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Conclusions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DecayCorrectionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FollowUpActionsRecommended")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Project");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Domain.ProjectSeries", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("SeriesId")
                        .HasColumnType("int");

                    b.HasKey("ProjectId", "SeriesId");

                    b.HasIndex("SeriesId");

                    b.ToTable("ProjectSeries");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Domain.Sample", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ExternalCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<decimal?>("Latitude")
                        .HasPrecision(11, 8)
                        .HasColumnType("decimal(11,8)");

                    b.Property<decimal?>("Longitude")
                        .HasPrecision(11, 8)
                        .HasColumnType("decimal(11,8)");

                    b.Property<string>("SampleClass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("SampleType")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("tinyint")
                        .HasComputedColumnSql("CASE WHEN SampleClass LIKE 'PIC%' THEN 3 WHEN SampleClass LIKE '%QC%' THEN 4 ELSE 2 END");

                    b.Property<DateTime>("SamplingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SeriesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SeriesId");

                    b.ToTable("Sample");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Domain.Series", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 10000L);

                    b.Property<DateTime?>("AnalysisCompleteDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDu")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNu")
                        .HasColumnType("bit");

                    b.Property<int>("SeriesType")
                        .HasColumnType("int");

                    b.Property<string>("SgasComment")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("WorkingPaperLink")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Domain.SubSample", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ActivityNotes")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("ExternalCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<bool>("IsFromLegacySystem")
                        .HasColumnType("bit");

                    b.Property<int>("SampleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ScreeningDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrackingNumber")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<DateTime?>("UploadResultDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SampleId");

                    b.ToTable("SubSample");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Filters.PresetFilter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("PresetFilter");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Filters.PresetFilterEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("LogicalFilterOperator")
                        .HasColumnType("int");

                    b.Property<int>("PresetFilterEntryType")
                        .HasColumnType("int");

                    b.Property<int>("PresetFilterId")
                        .HasColumnType("int");

                    b.Property<string>("SerializedDescriptors")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PresetFilterId");

                    b.ToTable("PresetFilterEntry");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Views.ApmView", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<decimal?>("ErU234")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<decimal?>("ErU235")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<decimal?>("ErU236")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<decimal?>("ErU238")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<int>("SubSampleId")
                        .HasColumnType("int");

                    b.Property<decimal?>("U234")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<decimal?>("U235")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<decimal?>("U236")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<decimal?>("U238")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.HasKey("Id");

                    b.HasIndex("SubSampleId");

                    b.ToTable((string)null);

                    b.ToView("ApmView", (string)null);
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Views.ParticleView", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("AnalysisDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<decimal?>("ErU234")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<decimal?>("ErU235")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<bool>("IsNu")
                        .HasColumnType("bit");

                    b.Property<string>("LaboratoryCode")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<decimal>("ParticleExternalId")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("SubSampleId")
                        .HasColumnType("int");

                    b.Property<decimal?>("U234")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<decimal?>("U235")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.HasKey("Id");

                    b.HasIndex("SubSampleId");

                    b.ToTable((string)null);

                    b.ToView("ParticleView", (string)null);
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Views.ProjectDecayCorrectedApmView", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<decimal?>("ErU234")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<decimal?>("ErU235")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<decimal?>("ErU236")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<decimal?>("ErU238")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("SubSampleId")
                        .HasColumnType("int");

                    b.Property<decimal?>("U234")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<decimal?>("U235")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<decimal?>("U236")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<decimal?>("U238")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.HasKey("Id");

                    b.HasIndex("SubSampleId");

                    b.ToTable((string)null);

                    b.ToView("ProjectDecayCorrectedApmView", (string)null);
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Views.ProjectDecayCorrectedParticleView", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("AnalysisDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<decimal?>("ErU234")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<decimal?>("ErU235")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<bool>("IsNu")
                        .HasColumnType("bit");

                    b.Property<string>("LaboratoryCode")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<decimal>("ParticleExternalId")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("SubSampleId")
                        .HasColumnType("int");

                    b.Property<decimal?>("U234")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.Property<decimal?>("U235")
                        .HasPrecision(38, 15)
                        .HasColumnType("decimal(38,15)");

                    b.HasKey("Id");

                    b.HasIndex("SubSampleId");

                    b.ToTable((string)null);

                    b.ToView("ProjectDecayCorrectedParticleView", (string)null);
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Views.ProjectView", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Conclusions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DecayCorrectionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FollowUpActionsRecommended")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SampleCount")
                        .HasColumnType("int");

                    b.Property<string>("SeriesIds")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.ToView("ProjectView", (string)null);
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Views.ProjectViewSeriesView", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("SeriesId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("ProjectId", "SeriesId");

                    b.HasIndex("SeriesId");

                    b.ToTable((string)null);

                    b.ToView("ProjectViewSeriesView", (string)null);
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Views.SampleView", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("ExternalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Latitude")
                        .HasPrecision(11, 8)
                        .HasColumnType("decimal(11,8)");

                    b.Property<decimal?>("Longitude")
                        .HasPrecision(11, 8)
                        .HasColumnType("decimal(11,8)");

                    b.Property<string>("SampleClass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SampleType")
                        .HasColumnType("int");

                    b.Property<DateTime>("SamplingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Sequence")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeriesId")
                        .HasColumnType("int");

                    b.Property<int>("SubSampleCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SeriesId");

                    b.ToTable((string)null);

                    b.ToView("SampleView", (string)null);
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Views.SeriesView", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AnalysisCompleteDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDu")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNu")
                        .HasColumnType("bit");

                    b.Property<int>("SampleCount")
                        .HasColumnType("int");

                    b.Property<string>("SampleExternalCodes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeriesType")
                        .HasColumnType("int");

                    b.Property<string>("SgasComment")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("WorkingPaperLink")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.ToView("SeriesView", (string)null);
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Views.SubSampleView", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("ActivityNotes")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("ExternalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFromLegacySystem")
                        .HasColumnType("bit");

                    b.Property<int>("SampleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ScreeningDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Sequence")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrackingNumber")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<DateTime?>("UploadResultDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SampleId");

                    b.ToTable((string)null);

                    b.ToView("SubSampleView", (string)null);
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Domain.Apm", b =>
                {
                    b.HasOne("NuclearEvaluation.Library.Models.Domain.SubSample", "SubSample")
                        .WithMany("Apms")
                        .HasForeignKey("SubSampleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SubSample");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Domain.Particle", b =>
                {
                    b.HasOne("NuclearEvaluation.Library.Models.Domain.SubSample", "SubSample")
                        .WithMany("Particles")
                        .HasForeignKey("SubSampleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SubSample");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Domain.ProjectSeries", b =>
                {
                    b.HasOne("NuclearEvaluation.Library.Models.Domain.Project", "Project")
                        .WithMany("ProjectSeries")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("NuclearEvaluation.Library.Models.Domain.Series", "Series")
                        .WithMany("ProjectSeries")
                        .HasForeignKey("SeriesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Series");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Domain.Sample", b =>
                {
                    b.HasOne("NuclearEvaluation.Library.Models.Domain.Series", "Series")
                        .WithMany("Samples")
                        .HasForeignKey("SeriesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Series");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Domain.SubSample", b =>
                {
                    b.HasOne("NuclearEvaluation.Library.Models.Domain.Sample", "Sample")
                        .WithMany("SubSamples")
                        .HasForeignKey("SampleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Sample");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Filters.PresetFilterEntry", b =>
                {
                    b.HasOne("NuclearEvaluation.Library.Models.Filters.PresetFilter", "PresetFilter")
                        .WithMany("Entries")
                        .HasForeignKey("PresetFilterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PresetFilter");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Views.ApmView", b =>
                {
                    b.HasOne("NuclearEvaluation.Library.Models.Views.SubSampleView", "SubSample")
                        .WithMany("Apms")
                        .HasForeignKey("SubSampleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SubSample");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Views.ParticleView", b =>
                {
                    b.HasOne("NuclearEvaluation.Library.Models.Views.SubSampleView", "SubSample")
                        .WithMany("Particles")
                        .HasForeignKey("SubSampleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SubSample");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Views.ProjectDecayCorrectedApmView", b =>
                {
                    b.HasOne("NuclearEvaluation.Library.Models.Views.SubSampleView", "SubSample")
                        .WithMany()
                        .HasForeignKey("SubSampleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SubSample");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Views.ProjectDecayCorrectedParticleView", b =>
                {
                    b.HasOne("NuclearEvaluation.Library.Models.Views.SubSampleView", "SubSample")
                        .WithMany()
                        .HasForeignKey("SubSampleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SubSample");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Views.ProjectViewSeriesView", b =>
                {
                    b.HasOne("NuclearEvaluation.Library.Models.Views.ProjectView", "Project")
                        .WithMany("ProjectSeries")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("NuclearEvaluation.Library.Models.Views.SeriesView", "Series")
                        .WithMany("ProjectSeries")
                        .HasForeignKey("SeriesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Series");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Views.SampleView", b =>
                {
                    b.HasOne("NuclearEvaluation.Library.Models.Views.SeriesView", "Series")
                        .WithMany("Samples")
                        .HasForeignKey("SeriesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Series");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Views.SubSampleView", b =>
                {
                    b.HasOne("NuclearEvaluation.Library.Models.Views.SampleView", "Sample")
                        .WithMany("SubSamples")
                        .HasForeignKey("SampleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Sample");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Domain.Project", b =>
                {
                    b.Navigation("ProjectSeries");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Domain.Sample", b =>
                {
                    b.Navigation("SubSamples");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Domain.Series", b =>
                {
                    b.Navigation("ProjectSeries");

                    b.Navigation("Samples");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Domain.SubSample", b =>
                {
                    b.Navigation("Apms");

                    b.Navigation("Particles");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Filters.PresetFilter", b =>
                {
                    b.Navigation("Entries");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Views.ProjectView", b =>
                {
                    b.Navigation("ProjectSeries");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Views.SampleView", b =>
                {
                    b.Navigation("SubSamples");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Views.SeriesView", b =>
                {
                    b.Navigation("ProjectSeries");

                    b.Navigation("Samples");
                });

            modelBuilder.Entity("NuclearEvaluation.Library.Models.Views.SubSampleView", b =>
                {
                    b.Navigation("Apms");

                    b.Navigation("Particles");
                });
#pragma warning restore 612, 618
        }
    }
}
