﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Lib.Data.SharedKernel;

namespace Lib.Data.Entities
{
    [Table("ListController")]
    public class ListController : DomainEntity<long>
    {
        public ListController()
        {
        }

        public ListController(long id, string controllerName, string discription, string discriptionAction)
        {
            Id = id;
            ControllerName = controllerName;
            Discription = discription;
        }

        public string ControllerName { set; get; }
        public string Discription { set; get; }

        public virtual ICollection<ListAction> ListActions { get; set; }
    }
}