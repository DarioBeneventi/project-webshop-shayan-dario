using System;

namespace WebShop.BLL.DTOs.Customers
{
    public class EditOrderDTO : OrderDTO
    {
        public DateTime UpdatedDate { get; set; }
    }
}
