using System;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Project5.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

//Aubrey Farnbach (Wright) Section 2 Group 1
// Subclasses the Cart class and overrides the AddItem, RemoveLine, and Clear methods so they call the base implementations
// and then store the updated state in the session using the extension methods on the Issession interface.The static
// GetCart method is a factory for creating SessionCart objects and providing them with an Isession object so they can
// store themselves.

namespace Project5.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart")
                ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession Session {get;set;}
        public override void AddItem(Book bk, int qty)
        {
            base.AddItem(bk, qty);
            Session.SetJson("Cart", this);
        }

        public override void RemoveLine(Book bk)
        {
            base.RemoveLine(bk); 
            Session.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear(); {
                base.Clear();
                Session.Remove("Cart");
            }
        }
    }
}
