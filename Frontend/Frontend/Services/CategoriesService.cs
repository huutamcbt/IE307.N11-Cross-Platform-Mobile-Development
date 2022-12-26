using System;
using System.Collections.Generic;
using System.Text;
using Frontend.Models;
using System.Threading.Tasks;

namespace Frontend.Services
{
    public class CategoriesService
    {
        readonly List<Category> categories;
        public CategoriesService()
        {
            
            categories = new List<Category>
            {
                new Category{ID= 1, Image= "icon_noodle.png",Name="Đồ nước" },
                new Category{ID= 2, Image= "icon_rice.png",Name="Cơm" },
                new Category{ID= 3, Image= "icon_drink.png",Name="Đồ uống" },
                new Category{ID= 4, Image= "icon_snack.png", Name="Đồ ăn vặt"}
            };
        }
        public async Task<List<Category>> GetAllCategory()
        {
            return await Task.FromResult(categories);
        }

    }
}
