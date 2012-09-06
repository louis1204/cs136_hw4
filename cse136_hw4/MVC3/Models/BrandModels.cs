using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC3.Models
{
    public class PLBrand
    {
        [Required] // others like [StringLength] [RegularExpression] [Range] can also available.
        [DisplayName("Brand ID")] // display the label when using <%: Html.DisplayForModel() %>
        public int Brand_id { get; set; }

        [Required]
        [DisplayName("Brand Name")]
        public string Brand_name { get; set; }
    }

    public static class BrandClientService
    {
        public static List<PLBrand> ReadAllBrand()
        {
            List<PLBrand> BrandList = new List<PLBrand>();

            SLBrand.ISLBrand SLBrand = new SLBrand.SLBrandClient();

            string[] errors = new string[0];
            SLBrand.BrandInfo[] BrandsLoaded = SLBrand.ReadAllBrand(ref errors);

            foreach (SLBrand.BrandInfo s in BrandsLoaded)
            {
                PLBrand Brand = DTO_to_PL_Brand(s);
                BrandList.Add(Brand);
            }

            return BrandList;
        }

        /// <summary>
        /// create a new student
        /// </summary>
        /// <param name="s"></param>
        public static void CreateBrand(string s)
        {
            /*SLBrand.BrandInfo newBrand = DTO_to_SL_Brand(s);
            */
            SLBrand.ISLBrand SLBrand = new SLBrand.SLBrandClient();
            string[] errors = new string[0];
            SLBrand.CreateBrand(s, ref errors);
        }

        /// <summary>
        /// update existing student info
        /// </summary>
        /// <param name="s"></param>
        public static void UpdateBrand(PLBrand s)
        {
            SLBrand.BrandInfo newBrand = DTO_to_SL_Brand(s);

            SLBrand.ISLBrand SLBrand = new SLBrand.SLBrandClient();
            string[] errors = new string[0];
            SLBrand.UpdateBrand(newBrand.brand_id, newBrand.brand_name, ref errors);
        }

        /// <summary>
        /// Get student detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PLBrand ReadBrandDetail(int id)
        {
            SLBrand.ISLBrand SLBrand = new SLBrand.SLBrandClient();

            string[] errors = new string[0];
            SLBrand.BrandInfo newBrand = SLBrand.ReadBrand(id, ref errors);

            // this is the data transfer object code...
            return DTO_to_PL_Brand(newBrand);
        }


        /// <summary>
        /// This is the data transfer object for student.
        /// Converting business layer student object to presentation layer student object
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static PLBrand DTO_to_PL_Brand(SLBrand.BrandInfo Brand)
        {
            PLBrand PLBrand = new Models.PLBrand();
            PLBrand.Brand_id = Brand.brand_id;
            PLBrand.Brand_name = Brand.brand_name;

            return PLBrand;
        }

        /// <summary>
        /// this is data transfer object for student.
        /// Converting from presentation layer student object to business layer student object
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static SLBrand.BrandInfo DTO_to_SL_Brand(PLBrand Brand)
        {
            SLBrand.BrandInfo SLBrand = new MVC3.SLBrand.BrandInfo();
            SLBrand.brand_id = Brand.Brand_id;
            SLBrand.brand_name = Brand.Brand_name;

            return SLBrand;
        }
    }
}