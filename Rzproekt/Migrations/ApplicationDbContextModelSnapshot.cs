﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rzproekt.Core.Data;

namespace Rzproekt.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Rzproekt.Models.AboutDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Block")
                        .HasColumnName("block")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ButtonText")
                        .HasColumnName("button_text")
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CertUrl")
                        .HasColumnName("cert_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DopMainTitle")
                        .HasColumnName("dop_main_title")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("DopText")
                        .HasColumnName("dop_text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DopTitle")
                        .HasColumnName("dop_title")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("DopUrl")
                        .HasColumnName("dop_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainTitle")
                        .HasColumnName("main_title")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Text")
                        .HasColumnName("text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Url")
                        .HasColumnName("url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("Rzproekt.Models.AnonymousUserDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AnonymousUsers");
                });

            modelBuilder.Entity("Rzproekt.Models.AwardDto", b =>
                {
                    b.Property<int>("AwardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("award_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AwardDetail")
                        .HasColumnName("award_detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AwardName")
                        .HasColumnName("award_name")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("AwardTitle")
                        .HasColumnName("award_title")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Block")
                        .HasColumnName("block")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Url")
                        .HasColumnName("url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AwardId");

                    b.ToTable("Awards");
                });

            modelBuilder.Entity("Rzproekt.Models.CertDto", b =>
                {
                    b.Property<int>("CertId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cert_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Block")
                        .HasColumnName("block")
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CertDetail")
                        .HasColumnName("cert_detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CertName")
                        .HasColumnName("cert_name")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("CertTitle")
                        .HasColumnName("cert_title")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Url")
                        .HasColumnName("url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CertId");

                    b.ToTable("Certs");
                });

            modelBuilder.Entity("Rzproekt.Models.ClientDto", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("client_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Block")
                        .HasColumnName("block")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientName")
                        .HasColumnName("client_name")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("MainTitle")
                        .HasColumnName("main_title")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Url")
                        .HasColumnName("url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Rzproekt.Models.ContactCompanyDto", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("contact_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressCompany")
                        .HasColumnName("address_company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Block")
                        .HasColumnName("block")
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ButtonText")
                        .HasColumnName("button_text")
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("EmailCompany")
                        .HasColumnName("email_company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainTitle")
                        .HasColumnName("main_title")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("NumberCompany")
                        .HasColumnName("company_number")
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("ContactId");

                    b.ToTable("ContactsCompany");
                });

            modelBuilder.Entity("Rzproekt.Models.ContactLeadDto", b =>
                {
                    b.Property<int>("LeadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("lead_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Block")
                        .HasColumnName("block")
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("LeadEmail")
                        .HasColumnName("lead_email")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("LeadFax")
                        .HasColumnName("lead_fax")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("LeadName")
                        .HasColumnName("lead_name")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("LeadNumber")
                        .HasColumnName("lead_number")
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("LeadPosition")
                        .HasColumnName("lead_position")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("MainTitle")
                        .HasColumnName("main_title")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Url")
                        .HasColumnName("url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LeadId");

                    b.ToTable("ContactsLead");
                });

            modelBuilder.Entity("Rzproekt.Models.DialogMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DialogId")
                        .HasColumnName("dialog_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Joined")
                        .HasColumnName("joined")
                        .HasColumnType("datetime");

                    b.Property<string>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DialogMembers");
                });

            modelBuilder.Entity("Rzproekt.Models.DialogMessage", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("message_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnName("created")
                        .HasColumnType("datetime");

                    b.Property<int>("DialogId")
                        .HasColumnName("dialog_id")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasColumnName("message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("isAdmin")
                        .HasColumnName("is_admin")
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("MessageId");

                    b.ToTable("DialogMessages");
                });

            modelBuilder.Entity("Rzproekt.Models.FooterDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("footer_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Block")
                        .HasColumnName("block")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ButtonText")
                        .HasColumnName("button_text")
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CopyStr")
                        .HasColumnName("copy_str")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Url")
                        .HasColumnName("url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Footers");
                });

            modelBuilder.Entity("Rzproekt.Models.HeaderDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Background")
                        .HasColumnName("background")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Block")
                        .HasColumnName("block")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainItem")
                        .HasColumnName("manu_item")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("MainText")
                        .HasColumnName("main_text")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("MainTitle")
                        .HasColumnName("main_title")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Url")
                        .HasColumnName("logo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Headers");
                });

            modelBuilder.Entity("Rzproekt.Models.MainInfoDialog", b =>
                {
                    b.Property<int>("DialogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("dialog_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnName("created")
                        .HasColumnType("datetime");

                    b.Property<string>("DialogName")
                        .HasColumnName("dialog_name")
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("DialogId");

                    b.ToTable("MainInfoDialogs");
                });

            modelBuilder.Entity("Rzproekt.Models.MessageDto", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("message_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdminDialogId")
                        .HasColumnType("int");

                    b.Property<string>("IsAdmin")
                        .HasColumnName("is_admin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageText")
                        .HasColumnName("message_text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserCode")
                        .HasColumnName("user_code")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessageId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Rzproekt.Models.MultepleContextTable", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AboutId")
                        .HasColumnType("int");

                    b.Property<int?>("AboutsId")
                        .HasColumnType("int");

                    b.Property<int>("AnonymousUserId")
                        .HasColumnType("int");

                    b.Property<int?>("AnonymousUsersId")
                        .HasColumnType("int");

                    b.Property<int>("AwardId")
                        .HasColumnType("int");

                    b.Property<int?>("AwardsAwardId")
                        .HasColumnType("int");

                    b.Property<int>("CertId")
                        .HasColumnType("int");

                    b.Property<int?>("CertsCertId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int?>("ClientsClientId")
                        .HasColumnType("int");

                    b.Property<int>("ContactId")
                        .HasColumnType("int");

                    b.Property<int>("ContactLead")
                        .HasColumnType("int");

                    b.Property<int?>("ContactLeadsLeadId")
                        .HasColumnType("int");

                    b.Property<int?>("ContactsContactId")
                        .HasColumnType("int");

                    b.Property<int>("DMessageId")
                        .HasColumnType("int");

                    b.Property<int>("DetailId")
                        .HasColumnType("int");

                    b.Property<int?>("DetailProjectsId")
                        .HasColumnType("int");

                    b.Property<int>("DialogId")
                        .HasColumnType("int");

                    b.Property<int>("DialogMemberId")
                        .HasColumnType("int");

                    b.Property<int?>("DialogMessagesMessageId")
                        .HasColumnType("int");

                    b.Property<int>("FooterId")
                        .HasColumnType("int");

                    b.Property<int?>("FootersId")
                        .HasColumnType("int");

                    b.Property<int>("HeaderId")
                        .HasColumnType("int");

                    b.Property<int?>("HeadersId")
                        .HasColumnType("int");

                    b.Property<int?>("MainInfoDialogsDialogId")
                        .HasColumnType("int");

                    b.Property<int>("MessageId")
                        .HasColumnType("int");

                    b.Property<int?>("MessagesMessageId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("OrdersOrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectsProjectId")
                        .HasColumnType("int");

                    b.Property<int>("StatisticId")
                        .HasColumnType("int");

                    b.Property<int?>("StatisticsId")
                        .HasColumnType("int");

                    b.Property<int>("UserId1")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("AboutsId");

                    b.HasIndex("AnonymousUsersId");

                    b.HasIndex("AwardsAwardId");

                    b.HasIndex("CertsCertId");

                    b.HasIndex("ClientsClientId");

                    b.HasIndex("ContactLeadsLeadId");

                    b.HasIndex("ContactsContactId");

                    b.HasIndex("DetailProjectsId");

                    b.HasIndex("DialogMemberId");

                    b.HasIndex("DialogMessagesMessageId");

                    b.HasIndex("FootersId");

                    b.HasIndex("HeadersId");

                    b.HasIndex("MainInfoDialogsDialogId");

                    b.HasIndex("MessagesMessageId");

                    b.HasIndex("OrdersOrderId");

                    b.HasIndex("ProjectsProjectId");

                    b.HasIndex("StatisticsId");

                    b.HasIndex("UserId1");

                    b.ToTable("MultepleContextTable");
                });

            modelBuilder.Entity("Rzproekt.Models.OrderDto", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("order_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Block")
                        .HasColumnName("block")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainTitle")
                        .HasColumnName("main_title")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Text")
                        .HasColumnName("text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Url")
                        .HasColumnName("url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Rzproekt.Models.ProjectDetailDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IsMain")
                        .HasColumnName("is_main")
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("ProjectId")
                        .HasColumnName("project_id")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnName("url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProjectDetails");
                });

            modelBuilder.Entity("Rzproekt.Models.ProjectDto", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("project_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Block")
                        .HasColumnName("block")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ButtonText")
                        .HasColumnName("button_text")
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("IsMain")
                        .HasColumnName("is_main")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("MainTitle")
                        .HasColumnName("main_title")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ProjectDetail")
                        .HasColumnName("project_detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .HasColumnName("project_name")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Url")
                        .HasColumnName("url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Rzproekt.Models.StatisticDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Block")
                        .HasColumnName("block")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnName("number")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnName("text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statistic");
                });

            modelBuilder.Entity("Rzproekt.Models.UserDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnName("login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnName("password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Rzproekt.Models.MultepleContextTable", b =>
                {
                    b.HasOne("Rzproekt.Models.AboutDto", "Abouts")
                        .WithMany("MultepleContextTables")
                        .HasForeignKey("AboutsId");

                    b.HasOne("Rzproekt.Models.AnonymousUserDto", "AnonymousUsers")
                        .WithMany("MultepleContextTables")
                        .HasForeignKey("AnonymousUsersId");

                    b.HasOne("Rzproekt.Models.AwardDto", "Awards")
                        .WithMany("MultepleContextTables")
                        .HasForeignKey("AwardsAwardId");

                    b.HasOne("Rzproekt.Models.CertDto", "Certs")
                        .WithMany("MultepleContextTables")
                        .HasForeignKey("CertsCertId");

                    b.HasOne("Rzproekt.Models.ClientDto", "Clients")
                        .WithMany("MultepleContextTables")
                        .HasForeignKey("ClientsClientId");

                    b.HasOne("Rzproekt.Models.ContactLeadDto", "ContactLeads")
                        .WithMany("MultepleContextTables")
                        .HasForeignKey("ContactLeadsLeadId");

                    b.HasOne("Rzproekt.Models.ContactCompanyDto", "Contacts")
                        .WithMany("MultepleContextTables")
                        .HasForeignKey("ContactsContactId");

                    b.HasOne("Rzproekt.Models.ProjectDetailDto", "DetailProjects")
                        .WithMany("MultepleContextTables")
                        .HasForeignKey("DetailProjectsId");

                    b.HasOne("Rzproekt.Models.DialogMember", "DialogMembers")
                        .WithMany("MultepleContextTables")
                        .HasForeignKey("DialogMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rzproekt.Models.DialogMessage", "DialogMessages")
                        .WithMany("MultepleContextTables")
                        .HasForeignKey("DialogMessagesMessageId");

                    b.HasOne("Rzproekt.Models.FooterDto", "Footers")
                        .WithMany("MultepleContextTables")
                        .HasForeignKey("FootersId");

                    b.HasOne("Rzproekt.Models.HeaderDto", "Headers")
                        .WithMany("MultepleContextTables")
                        .HasForeignKey("HeadersId");

                    b.HasOne("Rzproekt.Models.MainInfoDialog", "MainInfoDialogs")
                        .WithMany("MultepleContextTables")
                        .HasForeignKey("MainInfoDialogsDialogId");

                    b.HasOne("Rzproekt.Models.MessageDto", "Messages")
                        .WithMany("MultepleContextTables")
                        .HasForeignKey("MessagesMessageId");

                    b.HasOne("Rzproekt.Models.OrderDto", "Orders")
                        .WithMany("MultepleContextTables")
                        .HasForeignKey("OrdersOrderId");

                    b.HasOne("Rzproekt.Models.ProjectDto", "Projects")
                        .WithMany("MultepleContextTables")
                        .HasForeignKey("ProjectsProjectId");

                    b.HasOne("Rzproekt.Models.StatisticDto", "Statistics")
                        .WithMany("MultepleContextTables")
                        .HasForeignKey("StatisticsId");

                    b.HasOne("Rzproekt.Models.UserDto", "User")
                        .WithMany("MultepleContextTables")
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}