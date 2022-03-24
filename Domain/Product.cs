using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {
        public int Id { get; set; }
        /// <summary>
        /// Product's barcode
        /// </summary>
        public string Barcode { get; set; }
        /// <summary>
        /// Product's name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Year production
        /// </summary>
        public string Category { get; set; }
        public int YearProduction { get; set; }
        /// <summary>
        /// Expiration date
        /// </summary>
        public DateTime ExpirationDate { get; set; }
        /// <summary>
        /// A little summary of the product
        /// </summary>
        public string Review { get; set; }
    }
}
