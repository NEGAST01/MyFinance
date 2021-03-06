using Microsoft.AspNetCore.Http;
using MyFinance.Util;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MyFinance.Models
{
    public class PlanoContaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe a Descrição")]
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public int Usuario_Id { get; set; }

        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public PlanoContaModel()
        {
        }

        public PlanoContaModel(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;

        }
        public List<PlanoContaModel> ListaPlanoContas()
        {
            List<PlanoContaModel> lista = new List<PlanoContaModel>();
            PlanoContaModel item;


            string IdUsuarioLogado = HttpContextAccessor.HttpContext.Session.GetString("IDUsuarioLogado");
            string sql = $"SELECT ID, DESCRICAO, TIPO, USUARIO_ID from PLANO_CONTAS WHERE USUARIO_ID = {IdUsuarioLogado}";
            DAL ObjDAL = new DAL();
            DataTable dt = ObjDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new PlanoContaModel();
                item.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                item.Descricao = dt.Rows[i]["DESCRICAO"].ToString();
                item.Tipo =dt.Rows[i]["TIPO"].ToString();
                item.Usuario_Id = int.Parse(dt.Rows[i]["USUARIO_ID"].ToString());
                lista.Add(item);

            }
            return lista;

        }

        public PlanoContaModel CarregarRegistro(int? id)
        {
            PlanoContaModel item = new PlanoContaModel();

            string IdUsuarioLogado = HttpContextAccessor.HttpContext.Session.GetString("IDUsuarioLogado");
            string sql = $"SELECT ID, DESCRICAO, TIPO, USUARIO_ID FROM PLANO_CONTAS WHERE USUARIO_ID = {IdUsuarioLogado} AND ID = {id}";
            DAL ObjDAL = new DAL();
            DataTable dt = ObjDAL.RetDataTable(sql);

            item.Id = int.Parse(dt.Rows[0]["ID"].ToString());
            item.Descricao = dt.Rows[0]["DESCRICAO"].ToString();
            item.Tipo = dt.Rows[0]["TIPO"].ToString();
            item.Usuario_Id = int.Parse(dt.Rows[0]["USUARIO_ID"].ToString());

            return item;

        }

        public void Insert()
        {
            string IdUsuarioLogado = HttpContextAccessor.HttpContext.Session.GetString("IDUsuarioLogado");
            string sql = "";

            if (Id == 0) { 
             sql = $"INSERT INTO PLANO_CONTAS (DESCRICAO, TIPO, USUARIO_ID) VALUES ('{Descricao}','{Tipo}','{IdUsuarioLogado}');";
            }

            else
            {
                sql = $"UPDATE PLANO_CONTAS SET DESCRICAO = '{Descricao}', TIPO = '{Tipo}' WHERE USUARIO_ID = {IdUsuarioLogado} AND ID={Id};";
            }
            DAL ObjDAL = new DAL();
            ObjDAL.ExecutarComandoSQL(sql);
        }

        public void Excluir(int Id_Conta)
        {
            new DAL().ExecutarComandoSQL("DELETE FROM PLANO_CONTAS WHERE ID =" + Id_Conta);

        }

       

    }
}
