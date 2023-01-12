using Frontend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Frontend.Services
{
    public static class CategoriesService
    {
        static readonly List<Category> categories;
        static CategoriesService()
        {

            categories = new List<Category>
            {
                new Category{ID= 1, Image= "icon_noodle.png",Name="Đồ nước" },
                new Category{ID= 2, Image= "icon_rice.png",Name="Cơm" },
                new Category{ID= 3, Image= "icon_drink.png",Name="Đồ uống" },
                new Category{ID= 4, Image= "icon_snack.png", Name="Đồ ăn vặt"},
                new Category{ID=5,Image="icon_banhmi.png", Name = "Bánh mì"}
                
            };
        }
        public static async Task<List<Category>> GetAllCategory()
        {
            return await Task.FromResult(categories);
        }

    }
}
