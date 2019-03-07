using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectManager.Models
{
    public class BranchModel
    {

        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string ItemName { get; set; }

        [Required]
        [ForeignKey("ID")]
        public TreeConstructorModel TreeConstruct { get; set; }
        [Required]
        public int MasterID { get; set; }
        public int StateID { get; set; }
        [StringLength(255)]
        public string Comment { get; set; }


        //[NotMapped]
        //public List<BranchModel> ChildActivities { get; set; }

        //public BranchModel()
        //{
        //    ChildActivities = new List<BranchModel>();
        //}

        //public static BranchModel Find(BranchModel branchModel, int nodeID)
        //{
        //    if (branchModel == null) return null;
        //    return branchModel.ID == nodeID ? branchModel : branchModel.ChildActivities.Select(child => Find(child, nodeID)).FirstOrDefault(found => found != null);
        //}
    }
}