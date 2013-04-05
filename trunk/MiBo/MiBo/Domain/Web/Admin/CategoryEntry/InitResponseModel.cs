﻿using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.CategoryEntry
{
    public class InitResponseModel : MessageResponse
    {
        public IList<OutputDetailsModel> Details { get; set; }
    }
}