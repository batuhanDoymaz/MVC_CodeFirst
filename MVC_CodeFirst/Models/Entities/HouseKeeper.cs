﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CodeFirst.Models.Entities
{
    public class HouseKeeper : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}