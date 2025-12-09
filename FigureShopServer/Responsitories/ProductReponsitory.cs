
using FigureShopServer.Data;
using FigureShopSharedLibrary.Contracts;
using FigureShopSharedLibrary.Models;
using FigureShopSharedLibrary.Respones;
using Microsoft.EntityFrameworkCore;

namespace FigureShopServer.Responsitories

{
    public class ProductReponsitory : IProduct
    {
        private readonly AppDBContext appDBContext;
        public ProductReponsitory(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        //add product
        public async Task<ServiceRespone> AddProduct(Product model)
        {
            if (model is null) return new ServiceRespone(false, "model is null");
            
            // đây là destruction same destructuring on js
            var (flag,message) = await CheckName(model.Name);
            // check name trả về 1 task obj(2 giá trị), tương tự  ValueTuple --> có thể trả về nhiều giá trị, trả về obj,có thể lấy nhiều giá trị từ obj đó 
            //public (bool flag, string msg, int code) Test()
            //    {
            //        return (true, "success", 200);
            //    } --> đây là 1 valuetuple
            if (flag)
            {
                appDBContext.Products.Add(model); // auto sql create but Chỉ đánh dấu Added — chưa lưu!
                await Commit(); // thực thi sql create, save vào database
                return new ServiceRespone(true,"Product Saved");
            }
            return new ServiceRespone(flag,message);

        }
        //getallproduct
        public async Task<List<Product>> GetAllProducts(bool featuredProducts)
        {
            if (featuredProducts) 
                 return await appDBContext.Products.Where( product => product.Featured).ToListAsync();// cú pháp linq where
            else return await appDBContext.Products.ToListAsync();
        }
        // checkname
        private async Task<ServiceRespone> CheckName(string name)
        {
            var product = await appDBContext.Products.FirstOrDefaultAsync(x => x.Name.ToLower()!.Equals(name.ToLower()));
            return product is null ? new ServiceRespone(true, null!) : new ServiceRespone(false, "Product already exist");
        }
        private async Task Commit() => await appDBContext.SaveChangesAsync(); // thực thi, task thì ko có kiểu trả về nên ko cần return
        // cách viết gọn {await appDBContext.SaveChangesAsync(); }
    }
}
// task tuong tu nhu void nhung dung cho async
// task co 2: task, task<int> -> task co kieu du lieu va ko
// asysnc void chi dung cho event handle(button,..)
//