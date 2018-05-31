using FirstProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
                //DataControlField n = GridView2.Columns[1];
                //GridView2.Columns.Remove("Fax");
               // DataControlField n = GridView2.Columns[1];
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
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView2' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }
        protected void GetRecord_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Records AT " + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridView2.GridLines = GridLines.Both;
            GridView2.HeaderStyle.Font.Bold = true;
           
            GridView2.RenderControl(htmltextwrtter);
            
            Response.Write(strwritter.ToString());
            Response.End();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool b;
            int id;

            b = Int32.TryParse(DropDownList1.SelectedValue, out id);
            DropDownList2.SelectedIndex = 0;
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
            DropDownList1.SelectedIndex=0;
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