using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstDataDrivenWebApplication
{
    public partial class GadgetStoreView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new Entities())
            {
                this.gadgetStoreRepeater.DataSource = db.GadgetStores.ToList();
                this.gadgetStoreRepeater.DataBind();
            }
        }
    }
}