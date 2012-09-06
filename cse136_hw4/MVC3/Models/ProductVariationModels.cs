using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC3.Models
{
  public class PLProductVariation
  {
    [Required] // others like [StringLength] [RegularExpression] [Range] can also available.
    [DisplayName("Product Variation ID")] // display the label when using <%: Html.DisplayForModel() %>
    public int pv_id { get; set; }

    [Required]
    [DisplayName("Product ID")]
    public int product_id { get; set; }

    [Required]
    [DisplayName("Brand ID")]
    public int brand_id { get; set; }

    [Required]
    [DisplayName("Product Color ID")]
    public int product_color_id { get; set; }

    [Required]
    [DisplayName("Product Cutting ID")] // you could use [RegularExpression]
    // [RegularExpression("regex pattern goes here...")]
    public int product_cutting_id { get; set; }

    [Required]
    [DisplayName("Product Type ID")]
    public int product_type_id { get; set; }

    [Required]
    [DisplayName("sex")]
    public char sex { get; set; }

    [Required]
    [DisplayName("size")]
    public string size { get; set; }

    [Required]
    [DisplayName("stock")]
    public int stock { get; set; }

    [Required]
    [DisplayName("price")]
    public float price { get; set; }

    [Required]
    [DisplayName("condition")]
    public char condition { get; set; }
  }

  public static class ProductVariationClientService
  {
      public static List<PLProductVariation> ReadAllPV()
      {
          List<PLProductVariation> ProductVariationList = new List<PLProductVariation>();

          SLProductVariation.ISLProductVariation SLProductVariation = new SLProductVariation.SLProductVariationClient();

          string[] errors = new string[0];
          SLProductVariation.ProductVariationInfo[] ProductVariationsLoaded = SLProductVariation.ReadAllPV(ref errors);

          foreach (SLProductVariation.ProductVariationInfo s in ProductVariationsLoaded)
          {
              PLProductVariation ProductVariation = DTO_to_PL(s);
              ProductVariationList.Add(ProductVariation);
          }

          return ProductVariationList;
      }

      /// <summary>
      /// create a new student
      /// </summary>
      /// <param name="s"></param>
      public static void CreateProductVariation(PLProductVariation s)
      {
          SLProductVariation.ProductVariationInfo newProductVariation = DTO_to_SL(s);

          SLProductVariation.ISLProductVariation SLProductVariation = new SLProductVariation.SLProductVariationClient();
          string[] errors = new string[0];
          SLProductVariation.CreatePV(newProductVariation, ref errors);
      }

      /// <summary>
      /// update existing student info
      /// </summary>
      /// <param name="s"></param>
      public static void UpdateProductVariation(PLProductVariation s)
      {
          SLProductVariation.ProductVariationInfo newProductVariation = DTO_to_SL(s);

          SLProductVariation.ISLProductVariation SLProductVariation = new SLProductVariation.SLProductVariationClient();
          string[] errors = new string[0];
          SLProductVariation.UpdatePV(newProductVariation, ref errors);
      }

      /// <summary>
      /// Get student detail
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public static PLProductVariation ReadProductVariationDetail(int id)
      {
          SLProductVariation.ISLProductVariation SLProductVariation = new SLProductVariation.SLProductVariationClient();

          string[] errors = new string[0];
          SLProductVariation.ProductVariationInfo newProductVariation = SLProductVariation.ReadPV(id, ref errors);

          // this is the data transfer object code...
          return DTO_to_PL(newProductVariation);
      }

      /// <summary>
      /// call service layer's delete student method
      /// </summary>
      /// <param name="id"></param>
      public static void DeletePV(int id)
      {
          SLProductVariation.ISLProductVariation SLProductVariation = new SLProductVariation.SLProductVariationClient();
          string[] errors = new string[0];
          SLProductVariation.DeletePV(id, ref errors);
      }

      /// <summary>
      /// This is the data transfer object for student.
      /// Converting business layer student object to presentation layer student object
      /// </summary>
      /// <param name="student"></param>
      /// <returns></returns>
      public static PLProductVariation DTO_to_PL(SLProductVariation.ProductVariationInfo pv)
      {
          PLProductVariation PLProductVariation = new Models.PLProductVariation();
          PLProductVariation.pv_id = pv.product_variation_id;
          PLProductVariation.product_id = pv.product_id;
          PLProductVariation.brand_id = pv.product_brand_id;
          PLProductVariation.product_color_id = pv.product_color_id;
          PLProductVariation.product_cutting_id = pv.product_cutting_id;
          PLProductVariation.product_type_id = pv.product_type_id;
          PLProductVariation.sex = pv.sex;
          PLProductVariation.size = pv.size;
          PLProductVariation.stock = pv.stock;
          PLProductVariation.price = pv.stock;
          PLProductVariation.condition = pv.condition;

          return PLProductVariation;
      }

      /// <summary>
      /// this is data transfer object for student.
      /// Converting from presentation layer student object to business layer student object
      /// </summary>
      /// <param name="student"></param>
      /// <returns></returns>
      public static SLProductVariation.ProductVariationInfo DTO_to_SL(PLProductVariation pv)
      {
          SLProductVariation.ProductVariationInfo SLProductVariation = new MVC3.SLProductVariation.ProductVariationInfo();
          SLProductVariation.product_variation_id = pv.pv_id;
          SLProductVariation.product_id = pv.product_id;
          SLProductVariation.product_brand_id = pv.brand_id;
          SLProductVariation.product_color_id = pv.product_color_id;
          SLProductVariation.product_cutting_id = pv.product_cutting_id;
          SLProductVariation.product_type_id = pv.product_type_id;
          SLProductVariation.sex = pv.sex;
          SLProductVariation.size = pv.size;
          SLProductVariation.stock = pv.stock;
          SLProductVariation.price = pv.stock;
          SLProductVariation.condition = pv.condition;

          return SLProductVariation;
      }
  }
}