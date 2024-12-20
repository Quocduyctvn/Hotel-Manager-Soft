using Hotel.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Entities
{
    public class AppArticleCate : AppEntityBase
    {
        public AppArticleCate()
        {
            AppArticles = new HashSet<AppArticle>(); 
        }
        // Ten danh muc
        public string Name { get; set; }

        public ICollection<AppArticle> AppArticles { get; set; }
    }
}
