using FirstProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FirstProject.Controllers
{
    public class business
    {
        MDPEntities dc = new MDPEntities();
        public bool checkLogin(signin user)
        {
            var flag = from x in dc.Users.ToList() where (x.Username == user.username && x.Password == user.password) select x;
            if (flag.Count() == 1)
                return true;
            return false;
        }
        public int updateInfo(Information info)
        {

            int record = 0;

            string connectionString1 = ConfigurationManager.ConnectionStrings["MDPEntities"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString1))
            {
                con.Open();
                SqlCommand sqlcmd = new SqlCommand("INSERT INTO [Information] ([Id], [Salutation], [Title], [FirstName], [BusinessPhone], [MobilePhone], [FunctionalDepartment], [DepartmentRole], [Email], [InstitutionName1], [InstitutionName2], [Street1], [StreetNo], [PostalCode], [City], [Country], [State], [OtherComment], [LeadOriginator], [SourceCampaign], [Currency]) VALUES ('" + info.Salutation + "'" + info.Title + "'" + info.FirstName + "'" + info.BusinessPhone + "'" + info.MobilePhone + "'" + info.FunctionalDepartment + "'" + info.DepartmentRole + "'" + info.Email + "'" + info.InstitutionName1 + "'" + info.InstitutionName2 + "'" + info.Street1 + "'" + info.StreetNo + "'" + info.PostalCode + "'" + info.City + "'" + info.Country + "'" + info.State + "'" + info.OtherComment + "'" + info.LeadOriginator + "'" + info.SourceCampaign + "'" + info.Currency + "' where Id=" + info.Id + ")", con);
                record = sqlcmd.ExecuteNonQuery();
            }


            return record;

        }
    }
}