using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Location.Service.Api.Controllers
{
    public class UpdateParentOfLocationRequest
    {
        public int ParentLocationId { get; set; }
        public int LocationId { get; set; }
    }
}
