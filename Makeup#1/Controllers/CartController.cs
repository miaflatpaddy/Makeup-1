using Makeup_1.Database;
using Makeup_1.Extensions;
using Makeup_1.Serivces;
using MakeupClassLibrary.DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Makeup_1.Models;
using Makeup_1.Models.ViewModels.CartVievModels;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;

namespace Makeup_1.Controllers
{
    public class CartController : Controller
    {
        private readonly ShopContext context;
        private readonly IEmailService emailService;
        private readonly UserManager<User> userManager;

        public CartController(ShopContext context, IEmailService emailService, UserManager<User> userManager)
        {
            this.context = context;
            this.emailService = emailService;
            this.userManager = userManager;
        }
        public IActionResult Index(string returnUrl)
        {
            Cart cart = GetCart();
            return View(new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl });
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(int id, Cart cart, string returnUrl)
        {
            Product product = await context.Products.FindAsync(id);
            if (product != null)
            {
                await context.Entry(product).Collection(t => t.Images).LoadAsync();
                cart.AddItem(product, 1);
                UpdateCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id, Cart cart, string returnUrl)
        {
            Product? product = await context.Products.FindAsync(id);
            if (product != null)
            {
                cart.RemoveItem(product);
                UpdateCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> IncCount(int id, Cart cart)
        {
            Product? product = await context.Products.FindAsync(id);
            if (product != null)
            {
                await context.Entry(product).Collection(t => t.Images).LoadAsync();
                cart.AddItem(product, 1);
                UpdateCart(cart);
                int quantity = cart.CartItems.First(t => t.Product.Id == id).Quantity;
                return Ok(new
                {
                    quantity,
                    Sum = cart.GetSumByProduct(product)
                });
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DecCount(int id, Cart cart)
        {
            Product? product = await context.Products.FindAsync(id);
            if (product != null)
            {
                await context.Entry(product).Collection(t => t.Images).LoadAsync();
                cart.RemoveItem(product, 1);
                UpdateCart(cart);
                int quantity = cart.CartItems.First(t => t.Product.Id == id).Quantity;
                return Ok(new
                {
                    quantity,
                    Sum = cart.GetSumByProduct(product)
                });
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult GetTotalSum(Cart cart)
        {
            double totalSum = cart.GetTotalSum();
            return Ok(new {totalSum });
        }
        public IActionResult SetCart()
        {
            Cart cart = new Cart();
            Product product1 = context.Products.Find(1);
            Product product2 = context.Products.Find(2);
            cart.AddItem(product1, 2);
            cart.AddItem(product2, 1);
            HttpContext.Session.Set<IEnumerable<CartItem>>("cart", cart.CartItems);
            return RedirectToAction("Index");
        }


        private Cart GetCart()
        {
            IEnumerable<CartItem> items = HttpContext.Session.Get<IEnumerable<CartItem>>("cart");
            if (items == null)
            {
                items = new List<CartItem>();
                HttpContext.Session.Set<IEnumerable<CartItem>>("cart", items);
            }
            Cart cart = new Cart();
            cart.AddItems(items);
            return cart;
        }

        private void UpdateCart(Cart cart)
        {
            HttpContext.Session.Set<IEnumerable<CartItem>>("cart", cart.CartItems);
        }
        [HttpPost]

        public async Task<IActionResult> ConfirmOrder( string returnUrl)
        {
            string password = "nfvdhoufxntbhlbk";
            Cart cart = GetCart();
            StringBuilder builder = new StringBuilder();
            User user = await userManager.FindByNameAsync(User.Identity.Name);
            string emailTo = user.Email;
            builder.Append("<h3>Ваш заказ: </h3><ul>");
            builder.Append("<ul>");
            int i = 0;
            //Order order = new Order();
            //order.Items = new List<OrderItem>();
            Order order = new Order();
            order.UserId = user.Id;
            order.Date = DateTime.Now;
            foreach (CartItem item in cart.CartItems)
            {
                builder.Append($"<li>{++i}. {item.Product.Name} - {item.Quantity} шт: {item.Product.Price} грн. </li>");
               
                OrderItem orderItem = new OrderItem();
                orderItem.ProductId = item.Product.Id;
                orderItem.quantity = item.Quantity;
                order.Items.Add(orderItem);
                //orderItem.Product = item.Product;
                //orderItem.quantity = item.Quantity;
                //orderItem.ProductId = item.Product.Id;
                //context.OrderItems.Add(orderItem);
                //await context.SaveChangesAsync();
                //order.Items.Add(orderItem);
            }
            builder.Append("</ul>");
            builder.Append($"<h4>Итого:{cart.GetTotalSum()} грн. </h4>");
            await emailService.SendAsync("kurisumakise33@gmail.com", emailTo, "Ваш заказан №237815 подтвержден", builder.ToString());
            //order.User = user;
            //order.UserId = user.Id;
            //order.Date = DateTime.Now;
            context.Orders.Add(order);
            await context.SaveChangesAsync();
            cart.Clear();

            return Redirect(returnUrl);
        }
    }
}
