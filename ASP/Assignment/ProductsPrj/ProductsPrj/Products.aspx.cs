using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductsPrj
{
    public partial class Products : System.Web.UI.Page
    {
        private Dictionary<string, (string ImageUrl, decimal Price)> products = new Dictionary<string, (string ImageUrl, decimal Price)>
        {
            { "Studytable", (@"C:\batch 2024 June\\ASP\\Assignment\\ProductsPrj\\ProductsPrj\\wwwroot\\Images\\Studytable.jpg",3000) },
            { "Trolley Bag", (@"C:\batch 2024 June\\ASP\\Assignment\\ProductsPrj\\ProductsPrj\\wwwroot\\Images\\Trolley Bag.jpg",2500) },
            { "Rack", (@"C:\batch 2024 June\\ASP\\Assignment\\ProductsPrj\\ProductsPrj\\wwwroot\\Images\\Rack.jpg",1500) }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlProducts.DataSource = products.Keys;
                ddlProducts.DataBind();
            }
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProduct = ddlProducts.SelectedValue;
            imgProduct.ImageUrl = products[selectedProduct].ImageUrl;
            lblPrice.Text = ""; 
        }

        protected void btnGetPrice_Click(object sender, EventArgs e)
        {
            string selectedProduct = ddlProducts.SelectedValue;
            lblPrice.Text = "Price: $" + products[selectedProduct].Price.ToString("F2");
        }
    }
}
    
