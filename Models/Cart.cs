using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project5.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        
        //Add item to cart, this is a list of CartLine objects
        public virtual void AddItem (Book bk, int qty)
        {
            CartLine line = Lines
                //Where the isbn's match update quantity
                .Where(b => b.Book.Isbn == bk.Isbn)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = bk,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        //Remove Book from cart
        public virtual void RemoveLine(Book bk) =>
        Lines.RemoveAll(x => x.Book.Isbn == bk.Isbn);

        //Empty Cart
        public virtual void Clear() => Lines.Clear();

        //return total value of cart
        //I am using a double instead of a decimal becuse that is how I set up the data originally. I will change that if I need to.
        public double ComputeTotalSum()
        {
            return Lines.Sum(e => e.Book.Price * e.Quantity);
        }

        //this is what will be stored for each line item in the cart
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }

    }
    
}
