using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetManagementSystem.EntityModel
{
    [MetadataType(typeof(Department.MetaData))]
    public partial class Department
    {
        private sealed class MetaData
        {
            [Required(ErrorMessage = "This Field Can not be Empty")]
            public string Name { get; set; }

            [DataType(DataType.Date)]
            [Display(Name = "Created Date")]
            [Required(ErrorMessage = "This Field Can not be Empty")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime CreatedOn { get; set; }

        }
    }
}