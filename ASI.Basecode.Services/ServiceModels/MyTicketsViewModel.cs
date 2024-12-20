﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.ServiceModels
{
    public class MyTicketsViewModel
    {
        // List of tickets to be displayed in the "My Tickets" view
        public List<TicketViewModel> Tickets { get; set; }

        // Filter options
        public IEnumerable<CategoryViewModel> Categories { get; set; }
        public IEnumerable<StatusViewModel> Statuses { get; set; }
        public IEnumerable<PriorityViewModel> Priorities { get; set; }
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
        public int PriorityId { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
