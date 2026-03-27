using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RTCWebApi.Model.Common;
using RTCWebApi.Model.Entities;

#nullable disable

namespace RTCWebApi.Model.Entities.Context
{
    public partial class RTCContext : DbContext
    {
        public RTCContext()
        {
        }

        public RTCContext(DbContextOptions<RTCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<ExamCategory> ExamCategories { get; set; }
        public virtual DbSet<ExamListTest> ExamListTests { get; set; }
        public virtual DbSet<ExamQuestion> ExamQuestions { get; set; }
        public virtual DbSet<ExamQuestionBank> ExamQuestionBanks { get; set; }
        public virtual DbSet<ExamQuestionListTest> ExamQuestionListTests { get; set; }
        public virtual DbSet<ExamResult> ExamResults { get; set; }
        public virtual DbSet<ExamResultAnswerDetail> ExamResultAnswerDetails { get; set; }
        public virtual DbSet<ExamResultDetail> ExamResultDetails { get; set; }
        public virtual DbSet<ExamTestResult> ExamTestResults { get; set; }
        public virtual DbSet<ExamTestResultMaster> ExamTestResultMasters { get; set; }
        public virtual DbSet<ExamTypeTest> ExamTypeTests { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.Connection());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AnCa).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AnhCbnv)
                    .HasColumnType("ntext")
                    .HasColumnName("AnhCBNV");

                entity.Property(e => e.BankAccount).HasMaxLength(550);

                entity.Property(e => e.Bhxh)
                    .HasMaxLength(550)
                    .HasColumnName("BHXH");

                entity.Property(e => e.Bhyt)
                    .HasMaxLength(550)
                    .HasColumnName("BHYT");

                entity.Property(e => e.BirthOfDate).HasColumnType("datetime");

                entity.Property(e => e.ChuVuId).HasColumnName("ChuVuID");

                entity.Property(e => e.ChucVuHdid).HasColumnName("ChucVuHDID");

                entity.Property(e => e.ChuyenCan).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CmndorCccd).HasColumnName("CMNDorCCCD");

                entity.Property(e => e.Cmtnd)
                    .HasMaxLength(550)
                    .HasColumnName("CMTND");

                entity.Property(e => e.Code).HasMaxLength(550);

                entity.Property(e => e.Communication).HasMaxLength(550);

                entity.Property(e => e.CreatedBy).HasMaxLength(550);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Cv).HasColumnName("CV");

                entity.Property(e => e.DanToc).HasMaxLength(550);

                entity.Property(e => e.DcTamTru).HasMaxLength(550);

                entity.Property(e => e.DcThuongTru).HasMaxLength(550);

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DgchuyenHd).HasColumnName("DGChuyenHD");

                entity.Property(e => e.DgchuyenHdyear).HasColumnName("DGChuyenHDYear");

                entity.Property(e => e.Dgtv).HasColumnName("DGTV");

                entity.Property(e => e.DiaDiemLamViec).HasMaxLength(550);

                entity.Property(e => e.DienThoai).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DuongDcTamTru).HasMaxLength(150);

                entity.Property(e => e.DuongDcThuongTru).HasMaxLength(150);

                entity.Property(e => e.DvBhxh)
                    .HasMaxLength(550)
                    .HasColumnName("DvBHXH");

                entity.Property(e => e.Dxv).HasColumnName("DXV");

                entity.Property(e => e.Email).HasMaxLength(550);

                entity.Property(e => e.EmailCaNhan).HasMaxLength(550);

                entity.Property(e => e.EmailCom).HasMaxLength(550);

                entity.Property(e => e.EmailCongTy).HasMaxLength(550);

                entity.Property(e => e.EndWorking).HasColumnType("datetime");

                entity.Property(e => e.FullName).HasMaxLength(550);

                entity.Property(e => e.GiamTruBanThan).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.GiayKs).HasColumnName("GiayKS");

                entity.Property(e => e.GiayKsk).HasColumnName("GiayKSK");

                entity.Property(e => e.HandPhone).HasMaxLength(550);

                entity.Property(e => e.Hdldkxdth).HasColumnName("HDLDKXDTH");

                entity.Property(e => e.Hdldxdth).HasColumnName("HDLDXDTH");

                entity.Property(e => e.Hdldxdthyear).HasColumnName("HDLDXDTHYear");

                entity.Property(e => e.Hdtv).HasColumnName("HDTV");

                entity.Property(e => e.HomeAddress).HasMaxLength(550);

                entity.Property(e => e.IdchamCongCu)
                    .HasMaxLength(550)
                    .HasColumnName("IDChamCongCu");

                entity.Property(e => e.IdchamCongMoi)
                    .HasMaxLength(550)
                    .HasColumnName("IDChamCongMoi");

                entity.Property(e => e.ImagePath).HasMaxLength(550);

                entity.Property(e => e.IsAdminSale).HasColumnName("isAdminSale");

                entity.Property(e => e.IsSetupFunction).HasDefaultValueSql("((0))");

                entity.Property(e => e.JobDescription).HasMaxLength(550);

                entity.Property(e => e.Khac).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Leader).HasDefaultValueSql("((0))");

                entity.Property(e => e.LoaiHdldid).HasColumnName("LoaiHDLDID");

                entity.Property(e => e.LuongCoBan).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LuongThuViec).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MainViewId).HasColumnName("MainViewID");

                entity.Property(e => e.MoiQuanHe).HasMaxLength(150);

                entity.Property(e => e.Mst)
                    .HasMaxLength(550)
                    .HasColumnName("MST");

                entity.Property(e => e.MucDongBhxhhienTai)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("MucDongBHXHHienTai");

                entity.Property(e => e.NgayBatDauBhxh)
                    .HasColumnType("datetime")
                    .HasColumnName("NgayBatDauBHXH");

                entity.Property(e => e.NgayBatDauBhxhcty)
                    .HasColumnType("datetime")
                    .HasColumnName("NgayBatDauBHXHCty");

                entity.Property(e => e.NgayBatDauHd)
                    .HasColumnType("datetime")
                    .HasColumnName("NgayBatDauHD");

                entity.Property(e => e.NgayBatDauHdxdth)
                    .HasColumnType("datetime")
                    .HasColumnName("NgayBatDauHDXDTH");

                entity.Property(e => e.NgayBatDauThuViec).HasColumnType("datetime");

                entity.Property(e => e.NgayCap).HasColumnType("datetime");

                entity.Property(e => e.NgayHieuLucHdkxdth)
                    .HasColumnType("datetime")
                    .HasColumnName("NgayHieuLucHDKXDTH");

                entity.Property(e => e.NgayKetThucBhxh)
                    .HasColumnType("datetime")
                    .HasColumnName("NgayKetThucBHXH");

                entity.Property(e => e.NgayKetThucHd)
                    .HasColumnType("datetime")
                    .HasColumnName("NgayKetThucHD");

                entity.Property(e => e.NgayKetThucHdxdth)
                    .HasColumnType("datetime")
                    .HasColumnName("NgayKetThucHDXDTH");

                entity.Property(e => e.NgayKetThucThuViec).HasColumnType("datetime");

                entity.Property(e => e.NguoiGiuSoBhxh).HasColumnName("NguoiGiuSoBHXH");

                entity.Property(e => e.NguoiLienHeKhiCan).HasMaxLength(150);

                entity.Property(e => e.NhaO).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.NoiCap).HasMaxLength(150);

                entity.Property(e => e.NoiSinh).HasMaxLength(550);

                entity.Property(e => e.PassExpireDate).HasColumnType("datetime");

                entity.Property(e => e.PhuongDcTamTru).HasMaxLength(150);

                entity.Property(e => e.PhuongDcThuongTru).HasMaxLength(150);

                entity.Property(e => e.Position).HasMaxLength(550);

                entity.Property(e => e.PostalCode).HasMaxLength(550);

                entity.Property(e => e.Qdtd).HasColumnName("QDTD");

                entity.Property(e => e.Qualifications).HasMaxLength(550);

                entity.Property(e => e.QuanDcTamTru).HasMaxLength(150);

                entity.Property(e => e.QuanDcThuongTru).HasMaxLength(150);

                entity.Property(e => e.QuocTich).HasMaxLength(550);

                entity.Property(e => e.Resident).HasMaxLength(550);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.SdtcaNhan)
                    .HasMaxLength(50)
                    .HasColumnName("SDTCaNhan");

                entity.Property(e => e.SdtcongTy)
                    .HasMaxLength(50)
                    .HasColumnName("SDTCongTy");

                entity.Property(e => e.SdtnguoiThan)
                    .HasMaxLength(50)
                    .HasColumnName("SDTNguoiThan");

                entity.Property(e => e.SoCmtnd)
                    .HasMaxLength(250)
                    .HasColumnName("SoCMTND");

                entity.Property(e => e.SoHd)
                    .HasMaxLength(150)
                    .HasColumnName("SoHD");

                entity.Property(e => e.SoHdkxdth)
                    .HasMaxLength(100)
                    .HasColumnName("SoHDKXDTH");

                entity.Property(e => e.SoHdtv)
                    .HasMaxLength(100)
                    .HasColumnName("SoHDTV");

                entity.Property(e => e.SoHdxdth)
                    .HasMaxLength(100)
                    .HasColumnName("SoHDXDTH");

                entity.Property(e => e.SoHk).HasColumnName("SoHK");

                entity.Property(e => e.SoNguoiPt).HasColumnName("SoNguoiPT");

                entity.Property(e => e.SoNhaDcTamTru).HasMaxLength(150);

                entity.Property(e => e.SoNhaDcThuongTru).HasMaxLength(150);

                entity.Property(e => e.SoSoBhxh)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("SoSoBHXH");

                entity.Property(e => e.StartWorking).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");

                entity.Property(e => e.StkchuyenLuong)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STKChuyenLuong");

                entity.Property(e => e.Syll).HasColumnName("SYLL");

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.Property(e => e.Telephone).HasMaxLength(550);

                entity.Property(e => e.TinhDcTamTru).HasMaxLength(150);

                entity.Property(e => e.TinhDcThuongTru).HasMaxLength(150);

                entity.Property(e => e.TinhTrangHonNhanId).HasColumnName("TinhTrangHonNhanID");

                entity.Property(e => e.TinhTrangKyHd)
                    .HasMaxLength(150)
                    .HasColumnName("TinhTrangKyHD")
                    .HasComment("1: ");

                entity.Property(e => e.ToTrinhTd).HasColumnName("ToTrinhTD");

                entity.Property(e => e.TonGiao).HasMaxLength(550);

                entity.Property(e => e.TongLuong).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TongPhuCap).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TongTien).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TrangPhuc).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(550);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserGroupId).HasColumnName("UserGroupID");

                entity.Property(e => e.UserGroupSxid).HasColumnName("UserGroupSXID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.XangXe).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Xnns).HasColumnName("XNNS");
            });

            modelBuilder.Entity<ExamCategory>(entity =>
            {
                entity.ToTable("ExamCategory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CatCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CatName).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(150);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ExamListTest>(entity =>
            {
                entity.ToTable("ExamListTest");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CodeTest).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ExamCategoryId).HasColumnName("ExamCategoryID");

                entity.Property(e => e.ExamTypeTestId).HasColumnName("ExamTypeTestID");

                entity.Property(e => e.NameTest).HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ExamQuestion>(entity =>
            {
                entity.ToTable("ExamQuestion");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CorrectAnswer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExamQuestionTypeId).HasColumnName("ExamQuestionTypeID");

                entity.Property(e => e.Image)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Stt).HasColumnName("STT");
            });

            modelBuilder.Entity<ExamQuestionBank>(entity =>
            {
                entity.ToTable("ExamQuestionBank");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CorrectAnswer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExamListTestId).HasColumnName("ExamListTestID");

                entity.Property(e => e.ExamQuestionTypeId).HasColumnName("ExamQuestionTypeID");

                entity.Property(e => e.Image)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Stt).HasColumnName("STT");
            });

            modelBuilder.Entity<ExamQuestionListTest>(entity =>
            {
                entity.ToTable("ExamQuestionListTest");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ExamListTestId).HasColumnName("ExamListTestID");

                entity.Property(e => e.ExamQuestionId).HasColumnName("ExamQuestionID");

                entity.Property(e => e.Stt).HasColumnName("STT");
            });

            modelBuilder.Entity<ExamResult>(entity =>
            {
                entity.ToTable("ExamResult");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Season).HasComment("Quý");

                entity.Property(e => e.TestType).HasComment("1=Vision, 2=Điện, 3=PM, 4=Nội Quy");

                entity.Property(e => e.TotalMarks).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdatedBy).HasMaxLength(150);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ExamResultAnswerDetail>(entity =>
            {
                entity.ToTable("ExamResultAnswerDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CourseAnswerId).HasColumnName("CourseAnswerID");

                entity.Property(e => e.CourseQuestionId).HasColumnName("CourseQuestionID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(150)
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ExamResultDetailId).HasColumnName("ExamResultDetailID");

                entity.Property(e => e.Stt).HasColumnName("STT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(150)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ExamResultDetail>(entity =>
            {
                entity.ToTable("ExamResultDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CourseQuestionId).HasColumnName("CourseQuestionID");

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ExamResultId).HasColumnName("ExamResultID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(150);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ExamTestResult>(entity =>
            {
                entity.ToTable("ExamTestResult");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CandidateName).HasMaxLength(150);

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ExamCategoryId).HasColumnName("ExamCategoryID");

                entity.Property(e => e.ExamListTestId).HasColumnName("ExamListTestID");

                entity.Property(e => e.ExamQuestionBankId).HasColumnName("ExamQuestionBankID");

                entity.Property(e => e.ResultChose)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateBy).HasMaxLength(150);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ExamTestResultMaster>(entity =>
            {
                entity.ToTable("ExamTestResultMaster");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ExamCategoryId).HasColumnName("ExamCategoryID");

                entity.Property(e => e.ExamListTestId).HasColumnName("ExamListTestID");

                entity.Property(e => e.TotalMarks).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdateBy).HasMaxLength(150);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ExamTypeTest>(entity =>
            {
                entity.ToTable("ExamTypeTest");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TypeCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.LoginName, "Index_Users_LoginName");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BankAccount).HasMaxLength(250);

                entity.Property(e => e.Bhxh)
                    .HasMaxLength(250)
                    .HasColumnName("BHXH");

                entity.Property(e => e.Bhyt)
                    .HasMaxLength(250)
                    .HasColumnName("BHYT");

                entity.Property(e => e.BirthOfDate).HasColumnType("datetime");

                entity.Property(e => e.Cmtnd)
                    .HasMaxLength(250)
                    .HasColumnName("CMTND");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Communication).HasMaxLength(100);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.EmailCom).HasMaxLength(250);

                entity.Property(e => e.FullName).HasMaxLength(250);

                entity.Property(e => e.HandPhone).HasMaxLength(100);

                entity.Property(e => e.HomeAddress).HasMaxLength(100);

                entity.Property(e => e.ImagePath).HasColumnType("ntext");

                entity.Property(e => e.IsAdmin).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsAdminSale).HasColumnName("isAdminSale");

                entity.Property(e => e.IsSetupFunction).HasDefaultValueSql("((0))");

                entity.Property(e => e.JobDescription).HasMaxLength(200);

                entity.Property(e => e.Leader).HasDefaultValueSql("((0))");

                entity.Property(e => e.LoginName).HasMaxLength(50);

                entity.Property(e => e.MainViewId).HasColumnName("MainViewID");

                entity.Property(e => e.Mst)
                    .HasMaxLength(250)
                    .HasColumnName("MST");

                entity.Property(e => e.PassExpireDate).HasColumnType("datetime");

                entity.Property(e => e.PasswordHash).HasMaxLength(250);

                entity.Property(e => e.Position).HasMaxLength(50);

                entity.Property(e => e.PostalCode).HasMaxLength(50);

                entity.Property(e => e.Qualifications).HasMaxLength(250);

                entity.Property(e => e.Resident).HasMaxLength(100);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.StartWorking).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasDefaultValueSql("((0))")
                    .HasComment("Trạng thái hoạt động 0: hoạt động, 1: ngừng hoạt động");

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.Property(e => e.Telephone).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserGroupId).HasColumnName("UserGroupID");

                entity.Property(e => e.UserGroupSxid).HasColumnName("UserGroupSXID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
