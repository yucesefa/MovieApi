﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS.Commands.CategoryCommands
{
    public class RemoveCategoryCommand
    {
        public int CategoryId { get; set; }
    }
}
