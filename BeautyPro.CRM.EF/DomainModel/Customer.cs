using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPro.CRM.EF.DomainModel
{
    [Table("Tbl_Customer")]
    public partial class Customer
    {
        public Customer()
        {
            TblCustomerGiftVoucher = new HashSet<CustomerGiftVoucher>();
            TblCustomerSchedule = new HashSet<CustomerSchedule>();
        }

        public string CustomerId { get; set; }
        public string FullName { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Profession { get; set; }
        public string LoyaltyCardNo { get; set; }
        public int BranchId { get; set; }
        public bool IsDeleted { get; set; }
        public int EnteredBy { get; set; }
        public int? ModifiedBy { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual ICollection<CustomerGiftVoucher> TblCustomerGiftVoucher { get; set; }
        public virtual ICollection<CustomerSchedule> TblCustomerSchedule { get; set; }
    }
}
