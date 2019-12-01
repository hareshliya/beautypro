using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPro.CRM.EF.DomainModel
{
    [Table("Tbl_User")]
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int BranchId { get; set; }
        public int? DepartmentId { get; set; }
        public string FullName { get; set; }
        public string Designation { get; set; }
        public string MobNo { get; set; }
        public string UserType { get; set; }
        public bool? IsActive { get; set; }
        public bool IsPasswordChanged { get; set; }
        public DateTime? PasswordChangedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string Token { get; set; }
    }
}
