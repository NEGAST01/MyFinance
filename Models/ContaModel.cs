using Microsoft.AspNetCore.Http;
using MyFinance.Util;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MyFinance.Models
{
    public class ContaModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Informe o Nome da Conta")]
        public string Nome { get; set; }
        [Required (ErrorMessage = "Informe o Saldo")]
        public double Saldo { get; set; }
        public int Usuario_Id { get; set; }

        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public ContaModel()
        {
        }

        public ContaModel(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;

        }

        public List<ContaModel> ListaConta()
        {
            List<ContaModel> lista = new List<ContaModel>();
            ContaModel item;
            

            string IdUsuarioLogado = HttpContextAccessor.HttpContext.Session.GetString("IDUsuarioLogado");
            string sql = $"SELECT ID, NOME, SALDO, USUARIO_ID from CONTA WHERE USUARIO_ID = {IdUsuarioLogado}";
            DAL ObjDAL = new DAL();
            DataTable dt = ObjDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item  = new ContaModel();
                item.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                item.Nome = dt.Rows[i]["NOME"].ToString();
                item.Saldo = float.Parse(dt.Rows[i]["SALDO"].ToString());
                item.Usuario_Id = int.Parse(dt.Rows[i]["USUARIO_ID"].ToString());
                lista.Add(item);

            }
            return lista;

        }

        public void Insert()
        {
            string IdUsuarioLogado = HttpContextAccessor.HttpContext.Session.GetString("IDUsuarioLogado");
            string sql = $"INSERT INTO CONTA (NOME, SALDO, USUARIO_ID) VALUES ('{Nome}','{Saldo}','{IdUsuarioLogado}');";
            DAL ObjDAL = new DAL();
            ObjDAL.ExecutarComandoSQL(sql);
        }

        public void Excluir (int Id_Conta)
        {
            new DAL().ExecutarComandoSQL("DELETE FROM CONTA WHERE ID =" + Id_Conta);

        }

    }
}
