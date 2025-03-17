using Entities.Concrete.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Revenue:IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime RevenueDate { get; set; }
        public string Description {  get; set; }
        public int CategoryId {  get; set; }
        public double Amount { get; set; }  
        public string? ImageUrl {  get; set; }
        public BalanceType BalanceType { get; set; }    

    }
}
