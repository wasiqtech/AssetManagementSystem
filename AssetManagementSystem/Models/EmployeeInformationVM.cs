using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetManagementSystem.EntityModel
{
    public class EmployeeInformationVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name= "Father Name")]
        public string FatherName { get; set; }
        [Display(Name = "Employe Code")]
        public string EmployeCode { get; set; }
        [Display(Name = "CNIC No")]
        public string CNICNo { get; set; }
        public string Address { get; set; }

 
        [Display(Name = "Phone No")]
        public string PhoneNo { get; set; }
        [Display(Name = "Cell No")]
        public string CellNo { get; set; }
        [Display(Name = "Department")]
        public string  Department { get; set; }
        [Display(Name = "Designation")]
        public string  Designation { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [Display(Name = "Created Date")]
        public System.DateTime CreatedOn { get; set; }
        [Display(Name = "Modified Date")]
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    }
}