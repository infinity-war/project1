using FirstProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstProject
{
    public partial class Display : System.Web.UI.Page
    {
        MDPEntities db = new MDPEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = db.Leads.ToList();
                GridView2.DataSource = db.Information.ToList();
                var x = from rang in db.Leads.ToList() select (new { rang.Id, rang.Fname });
                DropDownList1.DataSource = x;
                var y = from rang in db.Leads.ToList() select (new { rang.Id, rang.MobileNo });
                DropDownList2.DataSource = y;
                GridView1.DataBind();
                GridView2.DataBind();
                DropDownList1.DataBind();
                DropDownList2.DataBind();
                DropDownList1.Items.Insert(0, "Select any");
                DropDownList2.Items.Insert(0, "Select any");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool b;
            int id;

            b = Int32.TryParse(DropDownList1.SelectedValue, out id);

            if (b)
            {
                var x = from rang in db.Leads.ToList() where (id == rang.Id) select rang;
                GridView1.DataSource = x;
                GridView1.DataBind();

                var y = from rang in db.Information.ToList() where (id == rang.LeadId) select rang;
                GridView2.DataSource = y;
                GridView2.DataBind();
            }
            else
            {
                GridView1.DataSource = db.Leads.ToList();
                GridView2.DataSource = db.Information.ToList();
                GridView1.DataBind();
                GridView2.DataBind();
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool b;
            int id;

            b = Int32.TryParse(DropDownList2.SelectedValue, out id);

            if (b)
            {
                var x = from rang in db.Leads.ToList() where (id == rang.Id) select rang;
                GridView1.DataSource = x;
                GridView1.DataBind();

                var y = from rang in db.Information.ToList() where (id == rang.LeadId) select rang;
                GridView2.DataSource = y;
                GridView2.DataBind();

            }
            else
            {
                GridView1.DataSource = db.Leads.ToList();
                GridView2.DataSource = db.Information.ToList();
                GridView1.DataBind();
                GridView2.DataBind();
            }
        }
    }
}