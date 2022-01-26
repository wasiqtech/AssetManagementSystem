using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetManagementSystem.EntityModel
{
    [MetadataType(typeof(EmployeeInformation.MetaData))]
    public partial class EmployeeInformation
    {
        private sealed class MetaData
        {
            [Required(ErrorMessage = "This field can not be empty")]
            public string Name { get; set; }

            [Display(Name = "Father Name")]
            [Required(ErrorMessage = "This field can not be empty")]
            public string FatherName { get; set; }
            [Display(Name = "Employe Code")]
              [Required(ErrorMessage = "This field can not be empty")]
            public string EmployeCode { get; set; }
            [Display(Name = "CNIC No")]
              [Required(ErrorMessage = "This field can not be empty")]
            public string CNICNo { get; set; }
            public string Address { get; set; }
            [Required(ErrorMessage = "This field can not be empty")]
            [Display(Name = "Phone No")]
            public string PhoneNo { get; set; }
            [Display(Name = "Cell No")]
              [Required(ErrorMessage = "This field can not be empty")]
            public string CellNo { get; set; }
            [Display(Name = "Department")]
              [Required(ErrorMessage = "This field can not be empty")]
            public int FK_Department { get; set; }
            [Display(Name = "Designation")]
              [Required(ErrorMessage = "This field can not be empty")]
            public int FK_Designation { get; set; }
            public bool IsActive { get; set; }



            [DataType(DataType.Date)]
            [Display(Name = "Created Date")]
              [Required(ErrorMessage = "This field can not be empty")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime CreatedOn { get; set; }

        }
    }
}