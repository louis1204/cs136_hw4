using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC3.Models
{
    public class PLProductCutting
    {
        [Required] // others like [StringLength] [RegularExpression] [Range] can also available.
        [DisplayName("ProductCutting ID")] // display the label when using <%: Html.DisplayForModel() %>
        public int ProductCutting_id { get; set; }

        [Required]
        [DisplayName("ProductCutting Name")]
        public string ProductCutting_name { get; set; }
    }

    public static class ProductCuttingClientService
    {
        public static List<PLProductCutting> ReadAllProductCutting()
        {
            List<PLProductCutting> ProductCuttingList = new List<PLProductCutting>();

            SLProductCutting.ISLProductCutting SLProductCutting = new SLProductCutting.SLProductCuttingClient();

            string[] errors = new string[0];
            SLProductCutting.ProductCuttingInfo[] ProductCuttingsLoaded = SLProductCutting.ReadAllProductCutting(ref errors);

            foreach (SLProductCutting.ProductCuttingInfo s in ProductCuttingsLoaded)
            {
                PLProductCutting ProductCutting = DTO_to_PL_ProductCutting(s);
                ProductCuttingList.Add(ProductCutting);
            }

            return ProductCuttingList;
        }

        /// <summary>
        /// create a new student
        /// </summary>
        /// <param name="s"></param>
        public static void CreateProductCutting(string s)
        {
            /*SLProductCutting.ProductCuttingInfo newProductCutting = DTO_to_SL_ProductCutting(s);
            */
            SLProductCutting.ISLProductCutting SLProductCutting = new SLProductCutting.SLProductCuttingClient();
            string[] errors = new string[0];
            SLProductCutting.CreateProductCutting(s, ref errors);
        }

        /// <summary>
        /// update existing student info
        /// </summary>
        /// <param name="s"></param>
        public static void UpdateProductCutting(PLProductCutting s)
        {
            SLProductCutting.ProductCuttingInfo newProductCutting = DTO_to_SL_ProductCutting(s);

            SLProductCutting.ISLProductCutting SLProductCutting = new SLProductCutting.SLProductCuttingClient();
            string[] errors = new string[0];
            SLProductCutting.UpdateProductCutting(newProductCutting.product_cutting_id, newProductCutting.product_cutting_name, ref errors);
        }

        /// <summary>
        /// Get student detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PLProductCutting ReadProductCuttingDetail(int id)
        {
            SLProductCutting.ISLProductCutting SLProductCutting = new SLProductCutting.SLProductCuttingClient();

            string[] errors = new string[0];
            SLProductCutting.ProductCuttingInfo newProductCutting = SLProductCutting.ReadProductCutting(id, ref errors);

            // this is the data transfer object code...
            return DTO_to_PL_ProductCutting(newProductCutting);
        }


        /// <summary>
        /// This is the data transfer object for student.
        /// Converting business layer student object to presentation layer student object
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static PLProductCutting DTO_to_PL_ProductCutting(SLProductCutting.ProductCuttingInfo ProductCutting)
        {
            PLProductCutting PLProductCutting = new Models.PLProductCutting();
            PLProductCutting.ProductCutting_id = ProductCutting.product_cutting_id;
            PLProductCutting.ProductCutting_name = ProductCutting.product_cutting_name;

            return PLProductCutting;
        }

        /// <summary>
        /// this is data transfer object for student.
        /// Converting from presentation layer student object to business layer student object
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static SLProductCutting.ProductCuttingInfo DTO_to_SL_ProductCutting(PLProductCutting ProductCutting)
        {
            SLProductCutting.ProductCuttingInfo SLProductCutting = new MVC3.SLProductCutting.ProductCuttingInfo();
            SLProductCutting.product_cutting_id = ProductCutting.ProductCutting_id;
            SLProductCutting.product_cutting_name = ProductCutting.ProductCutting_name;

            return SLProductCutting;
        }
    }
}