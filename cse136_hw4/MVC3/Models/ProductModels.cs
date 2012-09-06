using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC3.Models
{
    public class PLProduct
    {
        [Required] // others like [StringLength] [RegularExpression] [Range] can also available.
        [DisplayName("Product ID")] // display the label when using <%: Html.DisplayForModel() %>
        public int Product_id { get; set; }
        
        [Required]
        [DisplayName("Product Name")]
        public string product_name { get; set; }
    }

    public static class ProductClientService
    {
        public static List<PLProduct> ReadAllProduct()
        {
            List<PLProduct> ProductList = new List<PLProduct>();

            SLProduct.ISLProduct SLProduct = new SLProduct.SLProductClient();

            string[] errors = new string[0];
            SLProduct.ProductInfo[] ProductsLoaded = SLProduct.ReadAllProduct(ref errors);

            foreach (SLProduct.ProductInfo s in ProductsLoaded)
            {
                PLProduct Product = DTO_to_PL_Product(s);
                ProductList.Add(Product);
            }

            return ProductList;
        }

        /// <summary>
        /// create a new student
        /// </summary>
        /// <param name="s"></param>
        public static void CreateProduct(string s)
        {
            /*SLProduct.ProductInfo newProduct = DTO_to_SL_Product(s);
            */
            SLProduct.ISLProduct SLProduct = new SLProduct.SLProductClient();
            string[] errors = new string[0];
            SLProduct.CreateProduct(s, ref errors);
        }

        /// <summary>
        /// update existing student info
        /// </summary>
        /// <param name="s"></param>
        public static void UpdateProduct(PLProduct s)
        {
            SLProduct.ProductInfo newProduct = DTO_to_SL_Product(s);

            SLProduct.ISLProduct SLProduct = new SLProduct.SLProductClient();
            string[] errors = new string[0];
            SLProduct.UpdateProduct(newProduct.product_id, newProduct.product_name, ref errors);
        }

        /// <summary>
        /// Get student detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PLProduct ReadProductDetail(int id)
        {
            SLProduct.ISLProduct SLProduct = new SLProduct.SLProductClient();

            string[] errors = new string[0];
            SLProduct.ProductInfo newProduct = SLProduct.ReadProduct(id, ref errors);

            // this is the data transfer object code...
            return DTO_to_PL_Product(newProduct);
        }


        /// <summary>
        /// This is the data transfer object for student.
        /// Converting business layer student object to presentation layer student object
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static PLProduct DTO_to_PL_Product(SLProduct.ProductInfo Product)
        {
            PLProduct PLProduct = new Models.PLProduct();
            PLProduct.Product_id = Product.product_id;
            PLProduct.product_name = Product.product_name;

            return PLProduct;
        }

        /// <summary>
        /// this is data transfer object for student.
        /// Converting from presentation layer student object to business layer student object
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static SLProduct.ProductInfo DTO_to_SL_Product(PLProduct Product)
        {
            SLProduct.ProductInfo SLProduct = new MVC3.SLProduct.ProductInfo();
            SLProduct.product_id = Product.Product_id;
            SLProduct.product_name = Product.product_name;

            return SLProduct;
        }
    }
}