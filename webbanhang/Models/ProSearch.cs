using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webbanhang.Context;

namespace webbanhang.Models
{
    public class ProSearch
    {
        webbanhangEntities objwebbanhangEntities = new webbanhangEntities();
        public List<Product> SearchByKey(string key)
        {
            return objwebbanhangEntities.Products.SqlQuery("Select * From Products Where Name like '%" + key + "%'").ToList();
        }
    }
}