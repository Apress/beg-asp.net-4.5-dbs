using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataSourceControls
{
    public partial class Orders : System.Web.UI.Page
    {
        StoreEntities context = new StoreEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        public IEnumerable<DataSourceControls.Order> StoreDataSourceRepeater_GetData([QueryString("qty")] int? quantity)
        {
            if(quantity.HasValue)
                return context.Orders.Where(order => order.Quantity > quantity).AsEnumerable();
            return context.Orders.AsEnumerable();
        }
        
    }
}