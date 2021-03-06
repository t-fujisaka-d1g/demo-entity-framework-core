// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using app;

namespace app.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20211026022104_CustomizeColumnType")]
    partial class CustomizeColumnType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("app.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("X001BOOKID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("X001BOOKNAME");

                    b.Property<DateTime?>("ReleasedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("X001RELEASEAT");

                    b.HasKey("Id");

                    b.ToTable("X001BOOKS");
                });

            modelBuilder.Entity("app.Qr", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("X002QRCODE");

                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("X002BOOKID_X001BOOKS");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("X002URL");

                    b.HasKey("Code");

                    b.HasIndex("BookId");

                    b.ToTable("X002QRS");
                });

            modelBuilder.Entity("app.Qr", b =>
                {
                    b.HasOne("app.Book", "Book")
                        .WithMany("Qrs")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("app.Book", b =>
                {
                    b.Navigation("Qrs");
                });
#pragma warning restore 612, 618
        }
    }
}
