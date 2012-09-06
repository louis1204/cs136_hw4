using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC3.Models
{
    public class PLProductType
    {
        [Required] // others like [StringLength] [RegularExpression] [Range] can also available.
        [DisplayName("ProductType ID")] // display the label when using <%: Html.DisplayForModel() %>
        public int ProductType_id { get; set; }

        [Required]
        [DisplayName("ProductType Name")]
        public string ProductType_name { get; set; }
    }

    public static class ProductTypeClientService
    {
        public static List<PLProductType> ReadAllProductType()
        {
            List<PLProductType> ProductTypeList = new List<PLProductType>();

            SLProductType.ISLProductType SLProductType = new SLProductType.SLProductTypeClient();

            string[] errors = new string[0];
            SLProductType.ProductTypeInfo[] ProductTypesLoaded = SLProductType.ReadAllProductType(ref errors);

            foreach (SLProductType.ProductTypeInfo s in ProductTypesLoaded)
            {
                PLProductType ProductType = DTO_to_PL_ProductType(s);
                ProductTypeList.Add(ProductType);
            }

            return ProductTypeList;
        }

        /// <summary>
        /// create a new student
        /// </summary>
        /// <param name="s"></param>
        public static void CreateProductType(string s)
        {
            /*SLProductType.ProductTypeInfo newProductType = DTO_to_SL_ProductType(s);
            */
            SLProductType.ISLProductType SLProductType = new SLProductType.SLProductTypeClient();
            string[] errors = new string[0];
            SLProductType.CreateProductType(s, ref errors);
        }

        /// <summary>
        /// update existing student info
        /// </summary>
        /// <param name="s"></param>
        public static void UpdateProductType(PLProductType s)
        {
            SLProductType.ProductTypeInfo newProductType = DTO_to_SL_ProductType(s);

            SLProductType.ISLProductType SLProductType = new SLProductType.SLProductTypeClient();
            string[] errors = new string[0];
            SLProductType.UpdateProductType(newProductType.product_type_id, newProductType.product_type_name, ref errors);
        }

        /// <summary>
        /// Get student detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PLProductType ReadProductTypeDetail(int id)
        {
            SLProductType.ISLProductType SLProductType = new SLProductType.SLProductTypeClient();

            string[] errors = new string[0];
            SLProductType.ProductTypeInfo newProductType = SLProductType.ReadProductType(id, ref errors);

            // this is the data transfer object code...
            return DTO_to_PL_ProductType(newProductType);
        }


        /// <summary>
        /// This is the data transfer object for student.
        /// Converting business layer student object to presentation layer student object
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static PLProductType DTO_to_PL_ProductType(SLProductType.ProductTypeInfo ProductType)
        {
            PLProductType PLProductType = new Models.PLProductType();
            PLProductType.ProductType_id = ProductType.product_type_id;
            PLProductType.ProductType_name = ProductType.product_type_name;

            return PLProductType;
        }

        /// <summary>
        /// this is data transfer object for student.
        /// Converting from presentation layer student object to business layer student object
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static SLProductType.ProductTypeInfo DTO_to_SL_ProductType(PLProductType ProductType)
        {
            SLProductType.ProductTypeInfo SLProductType = new MVC3.SLProductType.ProductTypeInfo();
            SLProductType.product_type_id = ProductType.ProductType_id;
            SLProductType.product_type_name = ProductType.ProductType_name;

            return SLProductType;
        }
    }
}