using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer
{
    public class AmazonOrders
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Cost { get; set; }
        public int ItemQty { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int AmazonId { get; set; }
        public int? AmazonID { get; set; }

        public int Sum(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}
