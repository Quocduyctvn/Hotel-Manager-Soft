using Hotel.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Entities
{
    public class AppContact : AppEntityBase
    {
        // Id, ho ten, so dien thoai, email, sdt, noi dung, trang thai
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }

    }
}
