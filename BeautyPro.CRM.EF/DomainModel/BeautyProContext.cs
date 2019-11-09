using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BeautyPro.CRM.EF.DomainModel
{
    public partial class BeautyProContext : DbContext
    {
        public BeautyProContext()
        {
        }

        public BeautyProContext(DbContextOptions<BeautyProContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Branch> TblBranch { get; set; }
        public virtual DbSet<TblCompany> TblCompany { get; set; }
        public virtual DbSet<TblConfig> TblConfig { get; set; }
        public virtual DbSet<Customer> TblCustomer { get; set; }
        public virtual DbSet<CustomerGiftVoucher> TblCustomerGiftVoucher { get; set; }
        public virtual DbSet<TblCustomerInvoiceHeader> TblCustomerInvoiceHeader { get; set; }
        public virtual DbSet<TblCustomerInvoiceProducts> TblCustomerInvoiceProducts { get; set; }
        public virtual DbSet<TblCustomerInvoiceTreatment> TblCustomerInvoiceTreatment { get; set; }
        public virtual DbSet<CustomerSchedule> TblCustomerSchedule { get; set; }
        public virtual DbSet<CustomerScheduleTreatment> TblCustomerScheduleTreatment { get; set; }
        public virtual DbSet<TblEmployeeAllowances> TblEmployeeAllowances { get; set; }
        public virtual DbSet<TblEmployeeAttendance> TblEmployeeAttendance { get; set; }
        public virtual DbSet<TblEmployeeBasicSalary> TblEmployeeBasicSalary { get; set; }
        public virtual DbSet<TblEmployeeCommision> TblEmployeeCommision { get; set; }
        public virtual DbSet<TblEmployeeDeduction> TblEmployeeDeduction { get; set; }
        public virtual DbSet<EmployeeDetail> TblEmployeeDetail { get; set; }
        public virtual DbSet<TblEmployeeLeave> TblEmployeeLeave { get; set; }
        public virtual DbSet<TblEmployeeRoster> TblEmployeeRoster { get; set; }
        public virtual DbSet<TblEmployeeSalarySupport> TblEmployeeSalarySupport { get; set; }
        public virtual DbSet<TblMastAllowances> TblMastAllowances { get; set; }
        public virtual DbSet<TblMastBank> TblMastBank { get; set; }
        public virtual DbSet<TblMastCommission> TblMastCommission { get; set; }
        public virtual DbSet<TblMastDeduction> TblMastDeduction { get; set; }
        public virtual DbSet<Department> TblMastDepartment { get; set; }
        public virtual DbSet<TblMastDesignation> TblMastDesignation { get; set; }
        public virtual DbSet<TblMastLeaveType> TblMastLeaveType { get; set; }
        public virtual DbSet<TblMastNationality> TblMastNationality { get; set; }
        public virtual DbSet<TblMastOriginCountry> TblMastOriginCountry { get; set; }
        public virtual DbSet<TblMastPaymentType> TblMastPaymentType { get; set; }
        public virtual DbSet<TblMastProductCategory> TblMastProductCategory { get; set; }
        public virtual DbSet<TblMastProductUnits> TblMastProductUnits { get; set; }
        public virtual DbSet<TblMastSuppliers> TblMastSuppliers { get; set; }
        public virtual DbSet<TreatmentType> TblMastTreatmentType { get; set; }
        public virtual DbSet<TblMonth> TblMonth { get; set; }
        public virtual DbSet<TblProduct> TblProduct { get; set; }
        public virtual DbSet<TblProductGindetails> TblProductGindetails { get; set; }
        public virtual DbSet<TblProductGinheader> TblProductGinheader { get; set; }
        public virtual DbSet<TblProductGrndetails> TblProductGrndetails { get; set; }
        public virtual DbSet<TblProductGrnheader> TblProductGrnheader { get; set; }
        public virtual DbSet<TblProductPondetails> TblProductPondetails { get; set; }
        public virtual DbSet<TblProductPonheader> TblProductPonheader { get; set; }
        public virtual DbSet<TblProductReceptionGrndetail> TblProductReceptionGrndetail { get; set; }
        public virtual DbSet<TblProductReceptionGrnheader> TblProductReceptionGrnheader { get; set; }
        public virtual DbSet<TblProductSellingPrice> TblProductSellingPrice { get; set; }
        public virtual DbSet<TblProductSrndetails> TblProductSrndetails { get; set; }
        public virtual DbSet<TblProductSrnheader> TblProductSrnheader { get; set; }
        public virtual DbSet<TblRptTempProductSaleIncomeMonthBase> TblRptTempProductSaleIncomeMonthBase { get; set; }
        public virtual DbSet<TblSystemAutoNo> TblSystemAutoNo { get; set; }
        public virtual DbSet<User> TblUser { get; set; }

        // Unable to generate entity type for table 'dbo.Tbl_Rpt_TempCurrentStock'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Tbl_Rpt_TempProductMovement'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Tbl_Rpt_TempStock'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Tbl_Rpt_TempStockBalance_v3'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\;Database=BeautyPro_COCO;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.HasKey(e => e.BranchId);

                entity.ToTable("Tbl_Branch");

                entity.Property(e => e.BranchId).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Tp1)
                    .IsRequired()
                    .HasColumnName("TP1")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Tp2)
                    .HasColumnName("TP2")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.TblBranch)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Branch_Tbl_Company");
            });

            modelBuilder.Entity<TblCompany>(entity =>
            {
                entity.HasKey(e => e.CompanyId)
                    .HasName("PK_Tbl_Master_Company");

                entity.ToTable("Tbl_Company");

                entity.Property(e => e.CompanyId).ValueGeneratedNever();

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(350)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblConfig>(entity =>
            {
                entity.HasKey(e => e.ConfigId);

                entity.ToTable("Tbl_Config");

                entity.Property(e => e.ConfigId).ValueGeneratedNever();

                entity.Property(e => e.AbsentDeductionRatio).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PresentAllawancesRatio).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK_Tbl_Master_Customer");

                entity.ToTable("Tbl_Customer");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.LoyaltyCardNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Profession)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.TblCustomer)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Customer_Tbl_Branch");
            });

            modelBuilder.Entity<CustomerGiftVoucher>(entity =>
            {
                entity.HasKey(e => e.GvinvoiceNo);

                entity.ToTable("Tbl_CustomerGiftVoucher");

                entity.Property(e => e.GvinvoiceNo)
                    .HasColumnName("GVInvoiceNo")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CancelReason)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CanceledDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DueAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.InvDateTime).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Ptid).HasColumnName("PTId");

                entity.Property(e => e.SubTotalAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TransType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ttid).HasColumnName("TTId");

                entity.Property(e => e.VoucherNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TblCustomerGiftVoucher)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CustomerGiftVoucher_Tbl_Customer");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.TblCustomerGiftVoucher)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CustomerGiftVoucher_Tbl_Mast_Department");

                entity.HasOne(d => d.Pt)
                    .WithMany(p => p.TblCustomerGiftVoucher)
                    .HasForeignKey(d => d.Ptid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CustomerGiftVoucher_Tbl_Mast_PaymentType");

                entity.HasOne(d => d.Tt)
                    .WithMany(p => p.TblCustomerGiftVoucher)
                    .HasForeignKey(d => d.Ttid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CustomerGiftVoucher_Tbl_Mast_TreatmentType");
            });

            modelBuilder.Entity<TblCustomerInvoiceHeader>(entity =>
            {
                entity.HasKey(e => e.InvoiceNo);

                entity.ToTable("Tbl_CustomerInvoiceHeader");

                entity.Property(e => e.InvoiceNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CancelReason)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CanceledDate).HasColumnType("datetime");

                entity.Property(e => e.Cstid).HasColumnName("CSTId");

                entity.Property(e => e.CustomerId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DueAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.GvinvoiceNo)
                    .HasColumnName("GVInvoiceNo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.InvDateTime).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Ptid).HasColumnName("PTId");

                entity.Property(e => e.SubTotalAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TransType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cst)
                    .WithMany(p => p.TblCustomerInvoiceHeader)
                    .HasForeignKey(d => d.Cstid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CustomerInvoiceHeader_Tbl_CustomerScheduleTreatment");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.TblCustomerInvoiceHeader)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CustomerInvoiceHeader_Tbl_Mast_Department");

                entity.HasOne(d => d.Pt)
                    .WithMany(p => p.TblCustomerInvoiceHeader)
                    .HasForeignKey(d => d.Ptid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CustomerInvoiceHeader_Tbl_Mast_PaymentType");
            });

            modelBuilder.Entity<TblCustomerInvoiceProducts>(entity =>
            {
                entity.HasKey(e => e.Cipid);

                entity.ToTable("Tbl_CustomerInvoiceProducts");

                entity.Property(e => e.Cipid)
                    .HasColumnName("CIPId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InvoiceNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Qty).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.InvoiceNoNavigation)
                    .WithMany(p => p.TblCustomerInvoiceProducts)
                    .HasForeignKey(d => d.InvoiceNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CustomerInvoiceProducts_Tbl_CustomerInvoiceHeader");
            });

            modelBuilder.Entity<TblCustomerInvoiceTreatment>(entity =>
            {
                entity.HasKey(e => e.Citid);

                entity.ToTable("Tbl_CustomerInvoiceTreatment");

                entity.Property(e => e.Citid)
                    .HasColumnName("CITId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Empno).HasColumnName("EMPNo");

                entity.Property(e => e.InvoiceNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Ttid).HasColumnName("TTId");

                entity.HasOne(d => d.EmpnoNavigation)
                    .WithMany(p => p.TblCustomerInvoiceTreatment)
                    .HasForeignKey(d => d.Empno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CustomerInvoiceTreatment_Tbl_EmployeeDetail");

                entity.HasOne(d => d.InvoiceNoNavigation)
                    .WithMany(p => p.TblCustomerInvoiceTreatment)
                    .HasForeignKey(d => d.InvoiceNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CustomerInvoiceTreatment_Tbl_CustomerInvoiceHeader");

                entity.HasOne(d => d.Tt)
                    .WithMany(p => p.TblCustomerInvoiceTreatment)
                    .HasForeignKey(d => d.Ttid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CustomerInvoiceTreatment_Tbl_Mast_TreatmentType");
            });

            modelBuilder.Entity<CustomerSchedule>(entity =>
            {
                entity.HasKey(e => e.Csid);

                entity.ToTable("Tbl_CustomerSchedule");

                entity.Property(e => e.Csid).HasColumnName("CSId");

                entity.Property(e => e.BookedDate).HasColumnType("date");

                entity.Property(e => e.CustomerId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TblCustomerSchedule)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CustomerSchedule_Tbl_Customer");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.TblCustomerSchedule)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CustomerSchedule_Tbl_Mast_Department");
            });

            modelBuilder.Entity<CustomerScheduleTreatment>(entity =>
            {
                entity.HasKey(e => e.Cstid);

                entity.ToTable("Tbl_CustomerScheduleTreatment");

                entity.Property(e => e.Cstid)
                    .HasColumnName("CSTId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Csid).HasColumnName("CSId");

                entity.Property(e => e.Empno).HasColumnName("EMPNo");

                entity.Property(e => e.Ttid).HasColumnName("TTId");

                entity.HasOne(d => d.Cs)
                    .WithMany(p => p.TblCustomerScheduleTreatment)
                    .HasForeignKey(d => d.Csid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CustomerScheduleTreatment_Tbl_CustomerSchedule");

                entity.HasOne(d => d.EmpnoNavigation)
                    .WithMany(p => p.TblCustomerScheduleTreatment)
                    .HasForeignKey(d => d.Empno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CustomerScheduleTreatment_Tbl_EmployeeDetail");

                entity.HasOne(d => d.Tt)
                    .WithMany(p => p.TblCustomerScheduleTreatment)
                    .HasForeignKey(d => d.Ttid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CustomerScheduleTreatment_Tbl_Mast_TreatmentType");
            });

            modelBuilder.Entity<TblEmployeeAllowances>(entity =>
            {
                entity.HasKey(e => e.Eaid)
                    .HasName("PK_Tbl_EmployeeAllowances_1");

                entity.ToTable("Tbl_EmployeeAllowances");

                entity.Property(e => e.Eaid).HasColumnName("EAId");

                entity.Property(e => e.AllowanceValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Empno).HasColumnName("EMPNo");

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Allowance)
                    .WithMany(p => p.TblEmployeeAllowances)
                    .HasForeignKey(d => d.AllowanceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_EmployeeAllowances_Tbl_Mast_Allowances1");

                entity.HasOne(d => d.EmpnoNavigation)
                    .WithMany(p => p.TblEmployeeAllowances)
                    .HasForeignKey(d => d.Empno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_EmployeeAllowances_Tbl_EmployeeDetail1");
            });

            modelBuilder.Entity<TblEmployeeAttendance>(entity =>
            {
                entity.HasKey(e => e.AttendanceId);

                entity.ToTable("Tbl_EmployeeAttendance");

                entity.Property(e => e.AttendanceId).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Empno).HasColumnName("EMPNo");

                entity.Property(e => e.InTime).HasColumnType("datetime");

                entity.Property(e => e.LateMins).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Ot1)
                    .HasColumnName("OT1")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OutTime).HasColumnType("datetime");

                entity.Property(e => e.Shift)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WorkedHrs).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<TblEmployeeBasicSalary>(entity =>
            {
                entity.HasKey(e => e.Ebsid);

                entity.ToTable("Tbl_EmployeeBasicSalary");

                entity.Property(e => e.Ebsid).HasColumnName("EBSId");

                entity.Property(e => e.BasicSalaryValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Empno).HasColumnName("EMPNo");

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.EmpnoNavigation)
                    .WithMany(p => p.TblEmployeeBasicSalary)
                    .HasForeignKey(d => d.Empno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_EmployeeBasicSalary_Tbl_EmployeeDetail");
            });

            modelBuilder.Entity<TblEmployeeCommision>(entity =>
            {
                entity.HasKey(e => e.Ecid)
                    .HasName("PK_Tbl_EmployeeCommision_1");

                entity.ToTable("Tbl_EmployeeCommision");

                entity.Property(e => e.Ecid).HasColumnName("ECId");

                entity.Property(e => e.CommisionValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Empno).HasColumnName("EMPNo");

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Commission)
                    .WithMany(p => p.TblEmployeeCommision)
                    .HasForeignKey(d => d.CommissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_EmployeeCommision_Tbl_Mast_Commission1");

                entity.HasOne(d => d.EmpnoNavigation)
                    .WithMany(p => p.TblEmployeeCommision)
                    .HasForeignKey(d => d.Empno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_EmployeeCommision_Tbl_EmployeeDetail1");
            });

            modelBuilder.Entity<TblEmployeeDeduction>(entity =>
            {
                entity.HasKey(e => e.Edid)
                    .HasName("PK_Tbl_EmployeeDeduction_1");

                entity.ToTable("Tbl_EmployeeDeduction");

                entity.Property(e => e.Edid).HasColumnName("EDId");

                entity.Property(e => e.DeductionValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Empno).HasColumnName("EMPNo");

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Deduction)
                    .WithMany(p => p.TblEmployeeDeduction)
                    .HasForeignKey(d => d.DeductionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_EmployeeDeduction_Tbl_Mast_Deduction1");

                entity.HasOne(d => d.EmpnoNavigation)
                    .WithMany(p => p.TblEmployeeDeduction)
                    .HasForeignKey(d => d.Empno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_EmployeeDeduction_Tbl_EmployeeDetail1");
            });

            modelBuilder.Entity<EmployeeDetail>(entity =>
            {
                entity.HasKey(e => e.Empno);

                entity.ToTable("Tbl_EmployeeDetail");

                entity.Property(e => e.Empno)
                    .HasColumnName("EMPNo")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(350);

                entity.Property(e => e.BankAccountNo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BasicSalary).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfJoin).HasColumnType("date");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmergencyContactNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EmergencyContactPerson).HasMaxLength(100);

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.Gender).HasMaxLength(20);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.PassportNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasMaxLength(200);

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.TblEmployeeDetail)
                    .HasForeignKey(d => d.BankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_EmployeeDetail_Tbl_Mast_Bank");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TblEmployeeDetail)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_EmployeeDetail_Tbl_Mast_OriginCountry");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.EmployeeDetail)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_EmployeeDetail_Tbl_Mast_Department");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.TblEmployeeDetail)
                    .HasForeignKey(d => d.DesignationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_EmployeeDetail_Tbl_Mast_Designation");

                entity.HasOne(d => d.Nationality)
                    .WithMany(p => p.TblEmployeeDetail)
                    .HasForeignKey(d => d.NationalityId)
                    .HasConstraintName("FK_Tbl_EmployeeDetail_Tbl_Mast_Nationality");
            });

            modelBuilder.Entity<TblEmployeeLeave>(entity =>
            {
                entity.HasKey(e => e.EmployeeLeaveId);

                entity.ToTable("Tbl_EmployeeLeave");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Empno).HasColumnName("EMPNo");

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Remark).HasMaxLength(150);

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.HasOne(d => d.EmpnoNavigation)
                    .WithMany(p => p.TblEmployeeLeave)
                    .HasForeignKey(d => d.Empno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_EmployeeLeave_Tbl_EmployeeDetail");

                entity.HasOne(d => d.LeaveType)
                    .WithMany(p => p.TblEmployeeLeave)
                    .HasForeignKey(d => d.LeaveTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_EmployeeLeave_Tbl_Mast_LeaveType");
            });

            modelBuilder.Entity<TblEmployeeRoster>(entity =>
            {
                entity.HasKey(e => e.RosterId)
                    .HasName("PK_Tbl_RosterDetail");

                entity.ToTable("Tbl_EmployeeRoster");

                entity.Property(e => e.RosterId).ValueGeneratedNever();

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Empno).HasColumnName("EMPNo");

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.WorkingDate).HasColumnType("date");

                entity.HasOne(d => d.EmpnoNavigation)
                    .WithMany(p => p.TblEmployeeRoster)
                    .HasForeignKey(d => d.Empno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_RosterDetail_Tbl_EmployeeDetail");
            });

            modelBuilder.Entity<TblEmployeeSalarySupport>(entity =>
            {
                entity.HasKey(e => e.Essid);

                entity.ToTable("Tbl_EmployeeSalarySupport");

                entity.Property(e => e.Essid).HasColumnName("ESSid");

                entity.Property(e => e.ChequNo)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Empno).HasColumnName("EMPNo");

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<TblMastAllowances>(entity =>
            {
                entity.HasKey(e => e.AllowanceId)
                    .HasName("PK_Tbl_Mast_SalaryDetail");

                entity.ToTable("Tbl_Mast_Allowances");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblMastBank>(entity =>
            {
                entity.HasKey(e => e.BankId);

                entity.ToTable("Tbl_Mast_Bank");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblMastCommission>(entity =>
            {
                entity.HasKey(e => e.CommissionId)
                    .HasName("PK_Tbl_Mast_CommissionDetail");

                entity.ToTable("Tbl_Mast_Commission");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Ratio).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<TblMastDeduction>(entity =>
            {
                entity.HasKey(e => e.DeductionId)
                    .HasName("PK_Tbl_Mast_DeductionDetail");

                entity.ToTable("Tbl_Mast_Deduction");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Ratio).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.ToTable("Tbl_Mast_Department");

                entity.Property(e => e.DepartmentId).ValueGeneratedNever();

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.TblMastDepartment)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Mast_Department_Tbl_Branch");
            });

            modelBuilder.Entity<TblMastDesignation>(entity =>
            {
                entity.HasKey(e => e.DesignationId);

                entity.ToTable("Tbl_Mast_Designation");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.TblMastDesignation)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Mast_Designation_Tbl_Branch");
            });

            modelBuilder.Entity<TblMastLeaveType>(entity =>
            {
                entity.HasKey(e => e.LeaveTypeId);

                entity.ToTable("Tbl_Mast_LeaveType");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<TblMastNationality>(entity =>
            {
                entity.HasKey(e => e.NationalityId);

                entity.ToTable("Tbl_Mast_Nationality");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(10);

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblMastOriginCountry>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.ToTable("Tbl_Mast_OriginCountry");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblMastPaymentType>(entity =>
            {
                entity.HasKey(e => e.Ptid);

                entity.ToTable("Tbl_Mast_PaymentType");

                entity.Property(e => e.Ptid)
                    .HasColumnName("PTId")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Ptname)
                    .IsRequired()
                    .HasColumnName("PTName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblMastProductCategory>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("PK_Category");

                entity.ToTable("Tbl_Mast_ProductCategory");

                entity.Property(e => e.CatId).HasColumnName("CatID");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.CatName).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblMastProductUnits>(entity =>
            {
                entity.HasKey(e => e.UnitId)
                    .HasName("PK_Units");

                entity.ToTable("Tbl_Mast_ProductUnits");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.UnitName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblMastSuppliers>(entity =>
            {
                entity.HasKey(e => e.SupplierId)
                    .HasName("PK_Suppliers");

                entity.ToTable("Tbl_Mast_Suppliers");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPersonName).HasMaxLength(100);

                entity.Property(e => e.ContactPersonTelNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.SupplierName).HasMaxLength(100);
            });

            modelBuilder.Entity<TreatmentType>(entity =>
            {
                entity.HasKey(e => e.Ttid)
                    .HasName("PK_Tbl_Master_TreatmentType");

                entity.ToTable("Tbl_Mast_TreatmentType");

                entity.Property(e => e.Ttid).HasColumnName("TTId");

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Ttname)
                    .IsRequired()
                    .HasColumnName("TTName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.TblMastTreatmentType)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Mast_TreatmentType_Tbl_Branch");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.TreatmentTypes)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Mast_TreatmentType_Tbl_Mast_Department");
            });

            modelBuilder.Entity<TblMonth>(entity =>
            {
                entity.HasKey(e => e.MonthId);

                entity.ToTable("Tbl_Month");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.EnteredDate).HasColumnType("datetime");

                entity.Property(e => e.FinMonth)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.FinYear)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK_Items");

                entity.ToTable("Tbl_Product");

                entity.Property(e => e.ItemId)
                    .HasColumnName("ItemID")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Barcode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.CatId).HasColumnName("CatID");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(100);

                entity.Property(e => e.LastPurchasePrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LeadTime).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.MaxQty).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MinQty).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ReOrderLevel).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ReOrderQty).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");
            });

            modelBuilder.Entity<TblProductGindetails>(entity =>
            {
                entity.HasKey(e => new { e.Ginno, e.ItemNo })
                    .HasName("PK_GINDetails");

                entity.ToTable("Tbl_ProductGINDetails");

                entity.Property(e => e.Ginno)
                    .HasColumnName("GINNO")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ItemNo)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Qty).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblProductGinheader>(entity =>
            {
                entity.HasKey(e => e.Ginno)
                    .HasName("PK_GINHeader");

                entity.ToTable("Tbl_ProductGINHeader");

                entity.Property(e => e.Ginno)
                    .HasColumnName("GINNo")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.Gindate)
                    .HasColumnName("GINDate")
                    .HasColumnType("date");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SysDate).HasColumnType("datetime");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<TblProductGrndetails>(entity =>
            {
                entity.HasKey(e => new { e.Grnno, e.ItemId })
                    .HasName("PK_GRNDetails");

                entity.ToTable("Tbl_ProductGRNDetails");

                entity.Property(e => e.Grnno)
                    .HasColumnName("GRNNo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ItemId)
                    .HasColumnName("ItemID")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.PriceVarianceValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Qty).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Remarks).HasMaxLength(50);

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<TblProductGrnheader>(entity =>
            {
                entity.HasKey(e => e.Grnno)
                    .HasName("PK_GRNHeader");

                entity.ToTable("Tbl_ProductGRNHeader");

                entity.Property(e => e.Grnno)
                    .HasColumnName("GRNNo")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.Grndate)
                    .HasColumnName("GRNDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Pono)
                    .HasColumnName("PONo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks).HasMaxLength(50);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.SupplierInvoiceNo).HasMaxLength(50);

                entity.Property(e => e.SupplierIvoiceDate).HasColumnType("date");

                entity.Property(e => e.SysDate).HasColumnType("datetime");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<TblProductPondetails>(entity =>
            {
                entity.HasKey(e => new { e.Pono, e.ItemId })
                    .HasName("PK_PurchasedOrder_Details");

                entity.ToTable("Tbl_ProductPONDetails");

                entity.Property(e => e.Pono)
                    .HasColumnName("PONo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ItemId)
                    .HasColumnName("ItemID")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Qty).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Remarks).HasMaxLength(50);

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<TblProductPonheader>(entity =>
            {
                entity.HasKey(e => e.Pono)
                    .HasName("PK_PurchasedOrder_Header");

                entity.ToTable("Tbl_ProductPONHeader");

                entity.Property(e => e.Pono)
                    .HasColumnName("PONo")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.IsPurchased).HasDefaultValueSql("((0))");

                entity.Property(e => e.Podate)
                    .HasColumnName("PODate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(50);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.SysDate).HasColumnType("datetime");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<TblProductReceptionGrndetail>(entity =>
            {
                entity.HasKey(e => new { e.ReceptionGrnno, e.ItemId })
                    .HasName("PK_ReceptionGRNDetail");

                entity.ToTable("Tbl_ProductReceptionGRNDetail");

                entity.Property(e => e.ReceptionGrnno)
                    .HasColumnName("ReceptionGRNNo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ItemId)
                    .HasColumnName("ItemID")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Qty).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<TblProductReceptionGrnheader>(entity =>
            {
                entity.HasKey(e => e.ReceptionGrnno)
                    .HasName("PK_ReceptionGRNHeader");

                entity.ToTable("Tbl_ProductReceptionGRNHeader");

                entity.Property(e => e.ReceptionGrnno)
                    .HasColumnName("ReceptionGRNNo")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.Grndate)
                    .HasColumnName("GRNDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(50);

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<TblProductSellingPrice>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK_ItemSellingPrice");

                entity.ToTable("Tbl_ProductSellingPrice");

                entity.Property(e => e.ItemId)
                    .HasColumnName("ItemID")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.SellingPrice).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<TblProductSrndetails>(entity =>
            {
                entity.HasKey(e => new { e.Srnno, e.ItemId })
                    .HasName("PK_SRNDetails");

                entity.ToTable("Tbl_ProductSRNDetails");

                entity.Property(e => e.Srnno)
                    .HasColumnName("SRNNo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ItemId)
                    .HasColumnName("ItemID")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Qry).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Remarks).HasMaxLength(50);

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<TblProductSrnheader>(entity =>
            {
                entity.HasKey(e => e.Srnno)
                    .HasName("PK_SRNHeader");

                entity.ToTable("Tbl_ProductSRNHeader");

                entity.Property(e => e.Srnno)
                    .HasColumnName("SRNNo")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.Grnno)
                    .HasColumnName("GRNNo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks).HasMaxLength(50);

                entity.Property(e => e.Srndate)
                    .HasColumnName("SRNDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.SupplierInvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.SupplierInvoiceNo).HasMaxLength(50);

                entity.Property(e => e.SysDate).HasColumnType("datetime");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<TblRptTempProductSaleIncomeMonthBase>(entity =>
            {
                entity.HasKey(e => e.AutoId)
                    .HasName("PK__Tbl_Rpt___6B2329055935D4F4");

                entity.ToTable("Tbl_Rpt_Temp_ProductSaleIncomeMonthBase");

                entity.Property(e => e.AprilCount).HasColumnName("April_Count");

                entity.Property(e => e.AprilIncome)
                    .HasColumnName("April_Income")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FebruaryCount).HasColumnName("February_Count");

                entity.Property(e => e.FebruaryIncome)
                    .HasColumnName("February_Income")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ItemId)
                    .HasColumnName("ItemID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.JanuaryCount).HasColumnName("January_Count");

                entity.Property(e => e.JanuaryIncome)
                    .HasColumnName("January_Income")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.JulyCount).HasColumnName("July_Count");

                entity.Property(e => e.JulyIncome)
                    .HasColumnName("July_Income")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.JuneCount).HasColumnName("June_Count");

                entity.Property(e => e.JuneIncome)
                    .HasColumnName("June_Income")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MarchCount).HasColumnName("March_Count");

                entity.Property(e => e.MarchIncome)
                    .HasColumnName("March_Income")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MayCount).HasColumnName("May_Count");

                entity.Property(e => e.MayIncome)
                    .HasColumnName("May_Income")
                    .HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<TblSystemAutoNo>(entity =>
            {
                entity.HasKey(e => e.FormType)
                    .HasName("PK_SystemAutoNo");

                entity.ToTable("Tbl_SystemAutoNo");

                entity.Property(e => e.FormType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.IsDateUpdated).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsEveningUpdated).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsMorningUpdated).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastModifiedDate).HasColumnType("date");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserName);

                entity.ToTable("Tbl_User");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Designation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.MobNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordChangedDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).ValueGeneratedOnAdd();

                entity.Property(e => e.UserType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
