using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IOrderService
    {
        List<Order> GetAll();
        Order GetById(int orderId);
    }
}
