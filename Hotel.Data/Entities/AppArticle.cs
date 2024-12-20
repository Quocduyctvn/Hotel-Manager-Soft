using Hotel.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Entities
{
    public class AppArticle : AppEntityBase
    {
        // Tieu de, mo ta, noi dung, hinh anh
        public string Title { get; set; }
        public string? Summary { get; set; }
        public string Content { get; set; }
        public string Images { get; set; }
        
        public int IdCategory { get; set; }
        public AppArticleCate AppArticleCate { get; set; }
    }
}
