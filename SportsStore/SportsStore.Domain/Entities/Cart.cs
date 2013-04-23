using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsStore.Domain.Entities
{
    class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            CartLine lineItem = lineCollection.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();

            if (lineItem == null)
            {
                lineCollection.Add(new CartLine() { Product = product, Quantity = quantity });
            }
            else
            {
                lineItem.Quantity += quantity;
            }
            
        }

        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(l => l.Quantity * l.Product.Price);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }

    }




    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
