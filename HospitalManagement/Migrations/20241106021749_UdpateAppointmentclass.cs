using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.Migrations
{
    /// <inheritdoc />
    public partial class UdpateAppointmentclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_PatientInfo_PatientInfoPatientId",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_PatientInfoPatientId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "PatientInfoPatientId",
                table: "Appointment");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "Appointment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientId",
                table: "Appointment",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_PatientInfo_PatientId",
                table: "Appointment",
                column: "PatientId",
                principalTable: "PatientInfo",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_PatientInfo_PatientId",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_PatientId",
                table: "Appointment");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Appointment",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientInfoPatientId",
                table: "Appointment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientInfoPatientId",
                table: "Appointment",
                column: "PatientInfoPatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_PatientInfo_PatientInfoPatientId",
                table: "Appointment",
                column: "PatientInfoPatientId",
                principalTable: "PatientInfo",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
