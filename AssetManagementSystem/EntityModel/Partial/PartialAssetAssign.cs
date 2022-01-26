using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetManagementSystem.EntityModel
{

        [MetadataType(typeof(AssetAssign.MetaData))]
        public partial class AssetAssign
        {
            private sealed class MetaData
            {

            public int Id { get; set; }
            [Required(ErrorMessage = "This Field Can not be Empty")]
            public Nullable<int> FK_EmployeeInformation { get; set; }
            [Required(ErrorMessage = "This Field Can not be Empty")]
            public Nullable<int> FK_Asset { get; set; }

            public string Description { get; set; }
            public bool IsActive { get; set; }
            [Display(Name = "Created Date")]
            [DataType(DataType.Date)]
            [Required(ErrorMessage = "This Field Can not be Empty")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public System.DateTime CreatedOn { get; set; }
            public Nullable<System.DateTime> ModifiedOn { get; set; }

        }
        }
    }
