using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lib.Data.Entities
{

    [Table("ApiUrl")]
    public class ApiUrl
    {

        public Guid Id { get; set; }
        public string ApiId { get; set; }
        public string Link { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string ReturnType { get; set; }
        public string Attributes { get; set; }

    }
}
