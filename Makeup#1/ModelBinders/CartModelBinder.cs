using Makeup_1.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Makeup_1.Extensions;

namespace Makeup_1.ModelBinders
{
    public class CartModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            string sessionKey = "cart";
            Cart cart = new Cart();
            IEnumerable<CartItem>? cartItems = null;
            if (bindingContext.HttpContext.Session != null)
            {
                cartItems = bindingContext.HttpContext.Session.Get<IEnumerable<CartItem>>(sessionKey);
            }
            if (cartItems == null)
            {
                cartItems = new List<CartItem>();
                bindingContext.HttpContext.Session.Set(sessionKey, cartItems);
            }
            cart.AddItems(cartItems);
            bindingContext.Result = ModelBindingResult.Success(cart);
            return Task.CompletedTask;
        }
    }
}
