using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_bán_hàng__đồ_án_.Models.ViewModel;

namespace Web_bán_hàng__đồ_án_.Models.ViewModel
{
    public class CartService
    {
        private readonly HttpSessionStateBase session;

        // Constructor to initialize session
        public CartService(HttpSessionStateBase session)
        {
            this.session = session ?? throw new ArgumentNullException(nameof(session), "Session cannot be null.");
        }

        // Get the cart from the session, or create a new one if it doesn't exist
        public Cart GetCart()
        {
            if (session == null)
            {
                throw new InvalidOperationException("Session is not available.");
            }

            var cart = (Cart)session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                session["Cart"] = cart;
            }

            return cart;
        }

        // Clear the cart from the session
        public void ClearCart()
        {
            if (session == null)
            {
                throw new InvalidOperationException("Session is not available.");
            }

            session["Cart"] = null;
        }
    }
}