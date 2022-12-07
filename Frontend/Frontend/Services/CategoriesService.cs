using System;
using System.Collections.Generic;
using System.Text;
using Frontend.Models;
using System.Threading.Tasks;

namespace Frontend.Services
{
    class CategoriesService
    {
        readonly List<Category> categories;
        public CategoriesService()
        {
            categories = new List<Category>
            {

                new Category{ID= 1, Image= "./icon_noodle.png",Name="Đồ nước" },
                new Category{ID= 2, Image= "./icon_noodle.png",Name="Đồ nước" },
                new Category{ID= 3, Image= "./icon_noodle.png",Name="Đồ nước" },
            };
        }





        public async Task<List<Category>> GetAllCategory()
        {
            return await Task.FromResult(categories);
        }

    }
}
