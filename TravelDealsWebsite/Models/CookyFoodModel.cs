using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthTrainingWebsite.Models
{
    // Root myDeserializedClass = JsonConvert.Deserializestring<Root>(myJsonResponse);
    public class Price
    {
        public double unit_price { get; set; }
        public double sale_price { get; set; }
        public string discount_unit { get; set; }
        public double discount_price { get; set; }
    }

    public class Review
    {
        public int total_like { get; set; }
        public int total_dislike { get; set; }
    }

    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool is_default { get; set; }
        public int unit_price { get; set; }
        public int sale_price { get; set; }
        public int item_type { get; set; }
        public int coin { get; set; }
    }

    public class Option
    {
        public bool can_multiple { get; set; }
        public int max_quantity { get; set; }
        public int min_quantity { get; set; }
        public string name { get; set; }
        public List<Item> items { get; set; }
    }

    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class SubCategory
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class PreservationGuide
    {
        public string description { get; set; }
        public string title { get; set; }
    }

    public class RecipeStep
    {
        public int step { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

    public class ProductKind
    {
        public int product_kind_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

    public class Seller
    {
        public int seller_id { get; set; }
        public string name { get; set; }
        public string rewrite_url { get; set; }
    }

    public class Photo
    {
        public int width { get; set; }
        public int height { get; set; }
        public int? id { get; set; }
        public string url { get; set; }
    }

    public class Brand
    {
        public int brand_id { get; set; }
        public int total_product { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public List<Photo> photos { get; set; }
    }

    public class Origin
    {
        public string description { get; set; }
    }

    public class Service
    {
        public string description { get; set; }
        public string title { get; set; }
        public List<Photo> photos { get; set; }
    }

    public class ReturnPolicy
    {
        public string title { get; set; }
        public string detail { get; set; }
    }

    public class Promotion
    {
        public int promotion_id { get; set; }
        public int type { get; set; }
        public string promotion_name { get; set; }
        public string description { get; set; }
        public string short_description { get; set; }
        public bool is_flash_sale { get; set; }
        public List<string> icons { get; set; }
    }

    public class CookyFoodMarket
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string rewrite_url { get; set; }
        public bool is_pre_order { get; set; }
        public Price price { get; set; }
        public List<List<Photo>> photos { get; set; }
        public Review review { get; set; }
        public int total_sell { get; set; }
        public int status { get; set; }
        public int preparing_time { get; set; }
        public int total_save { get; set; }
        public double avg_rating { get; set; }
        public int combo_type { get; set; }
        public int coin { get; set; }
        public bool is_out_of_stock { get; set; }
        public bool cooky_app { get; set; }
        public string description { get; set; }
        public string short_description { get; set; }
        public int remaining_quantity { get; set; }
        public List<Option> options { get; set; }
        public List<Category> categories { get; set; }
        public List<SubCategory> sub_categories { get; set; }
        public List<PreservationGuide> preservation_guides { get; set; }
        public List<RecipeStep> recipe_steps { get; set; }
        public List<ProductKind> product_kinds { get; set; }
        public List<string> product_combos { get; set; }
        public Seller seller { get; set; }
        public Brand brand { get; set; }
        public string video_url { get; set; }
        public Origin origin { get; set; }
        public List<Service> services { get; set; }
        public string weight_serving { get; set; }
        public ReturnPolicy return_policy { get; set; }
        public Promotion promotion { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.Deserializestring<Root>(myJsonResponse);
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string UrlRewrite { get; set; }
        public int? CookyFoodId { get; set; }
    }

    public class CookyFood
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MetaTitle { get; set; }
        public int TotalTime { get; set; }
        public string Level { get; set; }
        public int LevelId { get; set; }
        public int TotalView { get; set; }
        public int TotalReviews { get; set; }
        public double AvgRating { get; set; }
        public string Img { get; set; }
        public string ImgMeta { get; set; }
        public string Video { get; set; }
        public int TotalCook { get; set; }
        public string UrlRewrite { get; set; }
        public string DetailUrl { get; set; }
        public bool IsLiked { get; set; }
        public int TotalLiked { get; set; }
        public List<Ingredient> MainIngredients { get; set; } = new List<Ingredient>();
        public string AvgRatingToString { get; set; }
        public string TotalTimeString { get; set; }
        public string TotalViewString { get; set; }
        public int PrepareTime { get; set; }
        public int CookTime { get; set; }
        public int TotalIngredients { get; set; }
        public string CourseName { get; set; }

    }
    public class CookyFoodRoot
    {
        public List<CookyFood> recipes { get; set; }
        public List<string> suggestKeywords { get; set; }
        public int totalResults { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class Step
    {
        public string content { get; set; }
        public int id { get; set; }
        public int? CookyFoodId { get; set; }
        public List<List<Photo>> photos { get; set; }
    }

    public class CookyFoodDetail
    {
        public double avgRating { get; set; }
        public int servings { get; set; }
        public int totalRating { get; set; }
        public int totalView { get; set; }
        public List<Ingredient> ingredients { get; set; }
        public List<Step> steps { get; set; }
        public bool hasCooked { get; set; }
        public int totalCook { get; set; }
        public int totalLike { get; set; }
        public int createdOn { get; set; }
        public int totalTime { get; set; }
        public List<List<Photo>> photos { get; set; }
        public string url { get; set; }
        public bool hasLiked { get; set; }
        public bool hasVideo { get; set; }
        public int id { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string urlRewrite { get; set; }
        public string videoUrl { get; set; }
    }

    public class CookyFoodDetailRoot
    {
        public int code { get; set; }
        public CookyFoodDetail data { get; set; }
        public string message { get; set; }
        public string checksum { get; set; }
    }


}
