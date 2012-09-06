using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC3.Models
{
    public class PLProductColor
    {
        [Required] // others like [StringLength] [RegularExpression] [Range] can also available.
        [DisplayName("ProductColor ID")] // display the label when using <%: Html.DisplayForModel() %>
        public int ProductColor_id { get; set; }

        [Required]
        [DisplayName("ProductColor Name")]
        public string ProductColor_name { get; set; }
    }

    public static class ProductColorClientService
    {
        public static List<PLProductColor> ReadAllProductColor()
        {
            List<PLProductColor> ProductColorList = new List<PLProductColor>();

            SLProductColor.ISLProductColor SLProductColor = new SLProductColor.SLProductColorClient();

            string[] errors = new string[0];
            SLProductColor.ProductColorInfo[] ProductColorsLoaded = SLProductColor.ReadAllProductColor(ref errors);

            foreach (SLProductColor.ProductColorInfo s in ProductColorsLoaded)
            {
                PLProductColor ProductColor = DTO_to_PL_ProductColor(s);
                ProductColorList.Add(ProductColor);
            }

            return ProductColorList;
        }

        /// <summary>
        /// create a new student
        /// </summary>
        /// <param name="s"></param>
        public static void CreateProductColor(string s)
        {
            /*SLProductColor.ProductColorInfo newProductColor = DTO_to_SL_ProductColor(s);
            */
            SLProductColor.ISLProductColor SLProductColor = new SLProductColor.SLProductColorClient();
            string[] errors = new string[0];
            SLProductColor.CreateProductColor(s, ref errors);
        }

        /// <summary>
        /// update existing student info
        /// </summary>
        /// <param name="s"></param>
        public static void UpdateProductColor(PLProductColor s)
        {
            SLProductColor.ProductColorInfo newProductColor = DTO_to_SL_ProductColor(s);

            SLProductColor.ISLProductColor SLProductColor = new SLProductColor.SLProductColorClient();
            string[] errors = new string[0];
            SLProductColor.UpdateProductColor(newProductColor.product_color_id, newProductColor.product_color_name, ref errors);
        }

        /// <summary>
        /// Get student detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PLProductColor ReadProductColorDetail(int id)
        {
            SLProductColor.ISLProductColor SLProductColor = new SLProductColor.SLProductColorClient();

            string[] errors = new string[0];
            SLProductColor.ProductColorInfo newProductColor = SLProductColor.ReadProductColor(id, ref errors);

            // this is the data transfer object code...
            return DTO_to_PL_ProductColor(newProductColor);
        }


        /// <summary>
        /// This is the data transfer object for student.
        /// Converting business layer student object to presentation layer student object
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static PLProductColor DTO_to_PL_ProductColor(SLProductColor.ProductColorInfo ProductColor)
        {
            PLProductColor PLProductColor = new Models.PLProductColor();
            PLProductColor.ProductColor_id = ProductColor.product_color_id;
            PLProductColor.ProductColor_name = ProductColor.product_color_name;

            return PLProductColor;
        }

        /// <summary>
        /// this is data transfer object for student.
        /// Converting from presentation layer student object to business layer student object
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static SLProductColor.ProductColorInfo DTO_to_SL_ProductColor(PLProductColor ProductColor)
        {
            SLProductColor.ProductColorInfo SLProductColor = new MVC3.SLProductColor.ProductColorInfo();
            SLProductColor.product_color_id = ProductColor.ProductColor_id;
            SLProductColor.product_color_name = ProductColor.ProductColor_name;

            return SLProductColor;
        }
    }
}