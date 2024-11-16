﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.ServiceModels
{
    public class TicketServiceModel
    {
        public int TicketId { get; set; }
        public string CreatedBy { get; set; }
        public string Title { get; set; }
        public int? AssignedTo { get; set; }
        public string PriorityType { get; set; }
        public string CategoryType { get; set; }
        public string StatusType { get; set; }
        public DateTime DateCreated { get; set; }
    }
}