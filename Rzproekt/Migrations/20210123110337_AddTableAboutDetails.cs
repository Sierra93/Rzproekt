using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rzproekt.Migrations
{
    public partial class AddTableAboutDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    main_title = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    title = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    block = table.Column<string>(nullable: true),
                    button_text = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    dop_main_title = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    dop_title = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    dop_text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dop_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cert_url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AnonymousUsers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnonymousUsers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Awards",
                columns: table => new
                {
                    award_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    award_detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    block = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    award_title = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    award_name = table.Column<string>(type: "nvarchar(1000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Awards", x => x.award_id);
                });

            migrationBuilder.CreateTable(
                name: "Certs",
                columns: table => new
                {
                    cert_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cert_detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    block = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    cert_title = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    cert_name = table.Column<string>(type: "nvarchar(1000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certs", x => x.cert_id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    client_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    main_title = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    block = table.Column<string>(nullable: true),
                    client_name = table.Column<string>(type: "nvarchar(1000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.client_id);
                });

            migrationBuilder.CreateTable(
                name: "ContactsCompany",
                columns: table => new
                {
                    contact_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    main_title = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    title = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    address_company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email_company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    company_number = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    button_text = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    block = table.Column<string>(type: "nvarchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactsCompany", x => x.contact_id);
                });

            migrationBuilder.CreateTable(
                name: "ContactsLead",
                columns: table => new
                {
                    lead_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    main_title = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lead_name = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    lead_position = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    lead_number = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    lead_fax = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    lead_email = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    block = table.Column<string>(type: "nvarchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactsLead", x => x.lead_id);
                });

            migrationBuilder.CreateTable(
                name: "DialogMembers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    joined = table.Column<DateTime>(type: "datetime", nullable: false),
                    dialog_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DialogMembers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DialogMessages",
                columns: table => new
                {
                    message_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dialog_id = table.Column<int>(type: "int", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: false),
                    is_admin = table.Column<string>(type: "nvarchar(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DialogMessages", x => x.message_id);
                });

            migrationBuilder.CreateTable(
                name: "Footers",
                columns: table => new
                {
                    footer_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    copy_str = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    block = table.Column<string>(nullable: true),
                    button_text = table.Column<string>(type: "nvarchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footers", x => x.footer_id);
                });

            migrationBuilder.CreateTable(
                name: "Headers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    manu_item = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    main_title = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    background = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    block = table.Column<string>(nullable: true),
                    main_text = table.Column<string>(type: "nvarchar(1000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Headers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MainInfoDialogs",
                columns: table => new
                {
                    dialog_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dialog_name = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainInfoDialogs", x => x.dialog_id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    message_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    message_text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_code = table.Column<string>(nullable: true),
                    is_admin = table.Column<string>(nullable: true),
                    AdminDialogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.message_id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    order_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    main_title = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    title = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    block = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.order_id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectDetails",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    project_id = table.Column<int>(type: "int", nullable: false),
                    is_main = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDetails", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    project_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    main_title = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    project_name = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    project_detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    block = table.Column<string>(nullable: true),
                    button_text = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    is_main = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.project_id);
                });

            migrationBuilder.CreateTable(
                name: "Statistic",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<int>(type: "int", nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    block = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistic", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    login = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MultepleContextTable",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId1 = table.Column<int>(nullable: false),
                    HeaderId = table.Column<int>(nullable: false),
                    HeadersId = table.Column<int>(nullable: true),
                    OrderId = table.Column<int>(nullable: false),
                    OrdersOrderId = table.Column<int>(nullable: true),
                    AboutId = table.Column<int>(nullable: false),
                    AboutsId = table.Column<int>(nullable: true),
                    StatisticId = table.Column<int>(nullable: false),
                    StatisticsId = table.Column<int>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false),
                    ProjectsProjectId = table.Column<int>(nullable: true),
                    ClientId = table.Column<int>(nullable: false),
                    ClientsClientId = table.Column<int>(nullable: true),
                    ContactId = table.Column<int>(nullable: false),
                    ContactsContactId = table.Column<int>(nullable: true),
                    FooterId = table.Column<int>(nullable: false),
                    FootersId = table.Column<int>(nullable: true),
                    MessageId = table.Column<int>(nullable: false),
                    MessagesMessageId = table.Column<int>(nullable: true),
                    CertId = table.Column<int>(nullable: false),
                    CertsCertId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: false),
                    DetailProjectsId = table.Column<int>(nullable: true),
                    AwardId = table.Column<int>(nullable: false),
                    AwardsAwardId = table.Column<int>(nullable: true),
                    ContactLead = table.Column<int>(nullable: false),
                    ContactLeadsLeadId = table.Column<int>(nullable: true),
                    DialogId = table.Column<int>(nullable: false),
                    MainInfoDialogsDialogId = table.Column<int>(nullable: true),
                    DMessageId = table.Column<int>(nullable: false),
                    DialogMessagesMessageId = table.Column<int>(nullable: true),
                    DialogMemberId = table.Column<int>(nullable: false),
                    AnonymousUserId = table.Column<int>(nullable: false),
                    AnonymousUsersId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultepleContextTable", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_MultepleContextTable_Abouts_AboutsId",
                        column: x => x.AboutsId,
                        principalTable: "Abouts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MultepleContextTable_AnonymousUsers_AnonymousUsersId",
                        column: x => x.AnonymousUsersId,
                        principalTable: "AnonymousUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MultepleContextTable_Awards_AwardsAwardId",
                        column: x => x.AwardsAwardId,
                        principalTable: "Awards",
                        principalColumn: "award_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MultepleContextTable_Certs_CertsCertId",
                        column: x => x.CertsCertId,
                        principalTable: "Certs",
                        principalColumn: "cert_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MultepleContextTable_Clients_ClientsClientId",
                        column: x => x.ClientsClientId,
                        principalTable: "Clients",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MultepleContextTable_ContactsLead_ContactLeadsLeadId",
                        column: x => x.ContactLeadsLeadId,
                        principalTable: "ContactsLead",
                        principalColumn: "lead_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MultepleContextTable_ContactsCompany_ContactsContactId",
                        column: x => x.ContactsContactId,
                        principalTable: "ContactsCompany",
                        principalColumn: "contact_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MultepleContextTable_ProjectDetails_DetailProjectsId",
                        column: x => x.DetailProjectsId,
                        principalTable: "ProjectDetails",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MultepleContextTable_DialogMembers_DialogMemberId",
                        column: x => x.DialogMemberId,
                        principalTable: "DialogMembers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MultepleContextTable_DialogMessages_DialogMessagesMessageId",
                        column: x => x.DialogMessagesMessageId,
                        principalTable: "DialogMessages",
                        principalColumn: "message_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MultepleContextTable_Footers_FootersId",
                        column: x => x.FootersId,
                        principalTable: "Footers",
                        principalColumn: "footer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MultepleContextTable_Headers_HeadersId",
                        column: x => x.HeadersId,
                        principalTable: "Headers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MultepleContextTable_MainInfoDialogs_MainInfoDialogsDialogId",
                        column: x => x.MainInfoDialogsDialogId,
                        principalTable: "MainInfoDialogs",
                        principalColumn: "dialog_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MultepleContextTable_Messages_MessagesMessageId",
                        column: x => x.MessagesMessageId,
                        principalTable: "Messages",
                        principalColumn: "message_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MultepleContextTable_Orders_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalTable: "Orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MultepleContextTable_Projects_ProjectsProjectId",
                        column: x => x.ProjectsProjectId,
                        principalTable: "Projects",
                        principalColumn: "project_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MultepleContextTable_Statistic_StatisticsId",
                        column: x => x.StatisticsId,
                        principalTable: "Statistic",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MultepleContextTable_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MultepleContextTable_AboutsId",
                table: "MultepleContextTable",
                column: "AboutsId");

            migrationBuilder.CreateIndex(
                name: "IX_MultepleContextTable_AnonymousUsersId",
                table: "MultepleContextTable",
                column: "AnonymousUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_MultepleContextTable_AwardsAwardId",
                table: "MultepleContextTable",
                column: "AwardsAwardId");

            migrationBuilder.CreateIndex(
                name: "IX_MultepleContextTable_CertsCertId",
                table: "MultepleContextTable",
                column: "CertsCertId");

            migrationBuilder.CreateIndex(
                name: "IX_MultepleContextTable_ClientsClientId",
                table: "MultepleContextTable",
                column: "ClientsClientId");

            migrationBuilder.CreateIndex(
                name: "IX_MultepleContextTable_ContactLeadsLeadId",
                table: "MultepleContextTable",
                column: "ContactLeadsLeadId");

            migrationBuilder.CreateIndex(
                name: "IX_MultepleContextTable_ContactsContactId",
                table: "MultepleContextTable",
                column: "ContactsContactId");

            migrationBuilder.CreateIndex(
                name: "IX_MultepleContextTable_DetailProjectsId",
                table: "MultepleContextTable",
                column: "DetailProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_MultepleContextTable_DialogMemberId",
                table: "MultepleContextTable",
                column: "DialogMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MultepleContextTable_DialogMessagesMessageId",
                table: "MultepleContextTable",
                column: "DialogMessagesMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_MultepleContextTable_FootersId",
                table: "MultepleContextTable",
                column: "FootersId");

            migrationBuilder.CreateIndex(
                name: "IX_MultepleContextTable_HeadersId",
                table: "MultepleContextTable",
                column: "HeadersId");

            migrationBuilder.CreateIndex(
                name: "IX_MultepleContextTable_MainInfoDialogsDialogId",
                table: "MultepleContextTable",
                column: "MainInfoDialogsDialogId");

            migrationBuilder.CreateIndex(
                name: "IX_MultepleContextTable_MessagesMessageId",
                table: "MultepleContextTable",
                column: "MessagesMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_MultepleContextTable_OrdersOrderId",
                table: "MultepleContextTable",
                column: "OrdersOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_MultepleContextTable_ProjectsProjectId",
                table: "MultepleContextTable",
                column: "ProjectsProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_MultepleContextTable_StatisticsId",
                table: "MultepleContextTable",
                column: "StatisticsId");

            migrationBuilder.CreateIndex(
                name: "IX_MultepleContextTable_UserId1",
                table: "MultepleContextTable",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MultepleContextTable");

            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "AnonymousUsers");

            migrationBuilder.DropTable(
                name: "Awards");

            migrationBuilder.DropTable(
                name: "Certs");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ContactsLead");

            migrationBuilder.DropTable(
                name: "ContactsCompany");

            migrationBuilder.DropTable(
                name: "ProjectDetails");

            migrationBuilder.DropTable(
                name: "DialogMembers");

            migrationBuilder.DropTable(
                name: "DialogMessages");

            migrationBuilder.DropTable(
                name: "Footers");

            migrationBuilder.DropTable(
                name: "Headers");

            migrationBuilder.DropTable(
                name: "MainInfoDialogs");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Statistic");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
