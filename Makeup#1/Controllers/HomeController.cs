using Makeup_1.Database;
using Makeup_1.Extensions;
using Makeup_1.Models;
using Makeup_1.Models.ViewModels;
using Makeup_1.Models.ViewModels.CartVievModels;
using MakeupClassLibrary.DomainModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Makeup_1.Models.DTOs;

namespace Makeup_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopContext _shopContext;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> userManager;

        public HomeController(ShopContext shopContext,ILogger<HomeController> logger, UserManager<User> userManager)
        {
            _shopContext = shopContext;
            _logger = logger;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            IQueryable<Product> products = _shopContext.Products.Include(t=>t.Brand).Include(t=>t.Images);
            HomeVievModel model = new HomeVievModel();
            model.products = await products.ToListAsync();
            model.cart = GetCart();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Details(int? id, string? returnUrl)
        {
            if (id == null)
                return RedirectToAction("Index");
            Product? product = await _shopContext.Products.FindAsync(id);
            await _shopContext.Entry(product).Collection(t => t.Comments).LoadAsync();
            foreach (var item in product.Comments)
            {
                item.User = await _shopContext.Users.FindAsync(item.UserId);
            }
            CartDetailsViewModel model = new CartDetailsViewModel();
            model.Product = product;
            model.Cart = GetCart();
            model.ReturnUrl = returnUrl;
            model.comment = new Models.DTOs.CommentDTO();
            return View(model);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public List<Product> Search(string request)
        {
            return new List<Product>();
        }
        public List<Product> Sort()
        {
            return new List<Product>();
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(CommentDTO comment)
        {
            string userId = userManager.GetUserId(User);
            Comment comment1 = new Comment()
            {
                UserId = userId,
                ProductId = comment.productId,
                Title = comment.title,
                Created = DateTime.Now,
                Description = comment.content
            };
            await _shopContext.Comments.AddAsync(comment1);
            await _shopContext.SaveChangesAsync(); 
            return Redirect(comment.returnUrl);
        }
       
        //public void AddToCart(Product product,int count,string userid,CartModel cm) {
        //    cm.UserId = userid;
        //    OrderItem item = new OrderItem();
        //    item.ProductId = product.Id;
        //    item.quantity = count;
        //    item.Product = product;
        //    cm.items.Add(item);

        //}
        //public void RemoveFromCart(CartModel cm,Product product) {
        //    cm.items.ForEach(item => { if (item.ProductId == product.Id) { cm.items.Remove(item);return; } });
        //    return;
        //}
        //public async Task<IActionResult> Buy(string userid, CartModel cm) { 
        //    Order order = new Order();
        //    order.Items = cm.items;
        //    order.User = new User();
        //    order.UserId = userid;
        //    order.Date = DateTime.Now;
        //    _shopContext.Add(order);
        //    await _shopContext.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        public void Clear(CartModel cm) {
            cm.items.Clear();
        }

        public Cart GetCart()
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
        public void LogIn()
        {

        }
        public void LogOut() {
        
        }
        public void Register()
        {

        }
        public void SendPM(string message, User user) { 

        }
        public void ReadPM(string message, User user) { 

        }

    }
}