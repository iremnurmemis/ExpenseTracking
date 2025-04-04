﻿using Entities.Concrete.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Expense : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double ExpenseAmount { get; set; }
        public int CategoryId {  get; set; }
        public string Description { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string? ImageUrl { get; set; }
        public BalanceType BalanceType { get; set; }
        public int UserId {  get; set; }

    }
}
