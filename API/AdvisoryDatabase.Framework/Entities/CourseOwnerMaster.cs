﻿using AdvisoryDatabase.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.Framework.Entities
{
    public class CourseOwnerMaster: BaseEntity<Int32>
    {
        public string CourseOwner { get; set; }
    }
}
