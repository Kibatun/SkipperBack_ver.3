using SkipperBack3.EFCore;
using SkipperBack3.Model;
using SkipperWebApi.EfCore;

namespace SkipperWebApi.Model
{
    public class DbHelper
    {
        private EF_DataContext _context;

        public DbHelper(EF_DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET
        /// </summary>
        /// <returns></returns>
        public List<ProductModel> GetProducts()
        {
            List<ProductModel> response = new List<ProductModel>();
            var dataList = _context.Products.ToList();
            dataList.ForEach(row => response.Add(new ProductModel()
            {
                brand = row.brand,
                id = row.id,
                name = row.name,
                price = row.price,
                size = row.size
            }));
            return response;
        }

        public ProductModel GetProductById(int id)
        {
            ProductModel response = new ProductModel();
            var row = _context.Products.Where(d => d.id.Equals(id)).FirstOrDefault();
            return new ProductModel()
            {
                brand = row.brand,
                id = row.id,
                name = row.name,
                price = row.price,
                size = row.size
            };
        }

        /// <summary>
        /// It serves the POST/PUT/PATCH
        /// </summary>
        public void SaveOrder(OrderModel orderModel)
        {
            Order dbTable = new Order();
            if (orderModel.id > 0)
            {
                //PUT
                dbTable = _context.Orders.Where(d => d.id.Equals(orderModel.id)).FirstOrDefault();
                if (dbTable != null)
                {
                    dbTable.phone = orderModel.phone;
                    dbTable.address = orderModel.address;
                }
            }
            else
            {
                //POST
                dbTable.phone = orderModel.phone;
                dbTable.address = orderModel.address;
                dbTable.name = orderModel.name;
                dbTable.Product = _context.Products.Where(f => f.id.Equals(orderModel.product_id)).FirstOrDefault();
                _context.Orders.Add(dbTable);
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="id"></param>
        public void DeleteOrder(int id)
        {
            var order = _context.Orders.Where(d => d.id.Equals(id)).FirstOrDefault();
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

        public bool SaveUser(User user)
        {
            if (_context.Users.Any(x => x.Email.Equals(user.Email)))
                throw new Exception("Пользователь с такой почтой уже зарегестрирован");
            if (user.Uid != Guid.Empty)
            {
                if (_context.Users.Any(x => x.Uid.Equals(user.Uid)))//.FirstOrDefault() != null)
                    throw new Exception("Пользователь с такими данными существует");
                    //return false;
                else
                {
                    user.PasswordHash = Utilities.GetHashString(user.PasswordHash);
                    _context.Users.Add(user);
                    _context.SaveChanges();
                }
            }
            else
            {
                user.PasswordHash = Utilities.GetHashString(user.PasswordHash);
                _context.Users.Add(user);
                user.Uid = Guid.NewGuid();
                _context.SaveChanges();
            }
            return true;
        }
    }
}