using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace ProjectManager.Models
{
    public class TreeConstructorModel
    {
        [Key]
        public int ID { get; set; }

        //MasterItemID
        //0 - initial
        //any other - parent ItemTypeID

        [Required]
        public int MasterItemID { get; set; }

        [Required]
        public int Level { get; set; }

        //IsBranch:
        //true - branch
        //false - parameter

        [Required]
        public bool IsBranch { get; set; }

        [Required]
        [StringLength(255)]
        public string ItemName { get; set; }

        //unneeded - should be calculated based on MasterItemID
        //[Required]
        //public int Level;

        [Required]
        public bool AutoCreate { get; set; }

        [StringLength(255)]
        public string ItemDescription { get; set; }

        //private readonly ApplicationDbContext dbConnection;

        //public TreeConstructorModel(ApplicationDbContext db)
        //{
        //    this.dbConnection = db;
        //}

        //[NotMapped]
        //public List<TreeConstructorModel> TreeConstructor { get; set; }

        //public TreeConstructorModel()
        //{
        //    TreeConstructor = new List<TreeConstructorModel>();
        //}

        //public static TreeConstructorModel Find(TreeConstructorModel treeConstruct, int itemID)
        //{
        //    if (treeConstruct == null) return null;
        //    return treeConstruct.ID == itemID ? treeConstruct : treeConstruct.TreeConstructor.Select(child => Find(child, itemID)).FirstOrDefault(found => found != null);
        //}

    }
}