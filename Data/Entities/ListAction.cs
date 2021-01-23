using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Lib.Data.SharedKernel;

namespace Lib.Data.Entities
{
    [Table("ListAction")]
    public class ListAction : DomainEntity<long>
    {
        public ListAction()
        {
            //AspNetUserActions = new List<AppUserActions>();
        }

        public ListAction(long id, string controllerName, string discription, long idController)
        {
            Id = id;
            ActionName = controllerName;
            Discription = discription;
            IdController = idController;
        }

        [StringLength(128)]
        [Required]
        public string ActionId { get; set; }
        public string ActionName { set; get; }
        public string Discription { set; get; }

        public string ControllerName { set; get; }

        public string AreaName { set; get; }

        public long IdController { set; get; }

        [ForeignKey("IdController")]
        public ListController ListController { get; set; }

        public virtual ICollection<AppUserActions> AspNetUserActions { get; set; }
    }
}