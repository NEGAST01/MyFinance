using MyFinance.Util;
using System.Data;

namespace MyFinance.Models
{
    public class HomeModel
    {

        public string LerNome()
        {
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable("select * from Usuario;");
            if (dt != null)
            {

                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["Nome"].ToString();

                }

            }

            return "Sem nome";
        }
    }
}
