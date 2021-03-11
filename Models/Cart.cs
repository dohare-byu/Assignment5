using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem(Book boo, int quantity)
        {
            CartLine line = Lines.Where(b => b.Book.ID == boo.ID)
                .FirstOrDefault();

            if(line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = boo,
                    Quantity = quantity,
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Book boo) =>
            Lines.RemoveAll(x => x.Book.ID == boo.ID);

        public virtual void Clear() => Lines.Clear();

        public double ComputeTotalSum() =>
            Lines.Sum(e => e.Book.Price * e.Quantity);
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}
