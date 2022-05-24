﻿using Microsoft.AspNetCore.Http;
using MyFinance.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MyFinance.Models
{
    public class TransacaoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe a Data")]
        public string Data { get; set; }
        public string DataFinal { get; set; }
        public string Tipo { get; set; }
        public double Valor { get; set; }

        [Required(ErrorMessage = "Informe a Descrição")]
        public string Descricao { get; set; }
        public int Conta_Id { get; set; }
        public string NomeConta { get; set; }
        public int Plano_Contas_Id { get; set; }
        public string DescricaoPlanoConta { get; set; }

        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public TransacaoModel()
        {
        }

        public TransacaoModel(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;

        }
        public List<TransacaoModel> ListaTransacao()
        {
            List<TransacaoModel> lista = new List<TransacaoModel>();
            TransacaoModel item;

            var filtro = "";
            if ((Data != null) && (DataFinal != null))
            {
                filtro += $" and t.Data >='{DateTime.Parse(Data).ToString("yyyy/MM/dd")}' and t.Data <='{DateTime.Parse(DataFinal).ToString("yyyy/MM/dd")}'";

            }

            if (Tipo != null)
            {
                if (Tipo != "A")
                {
                    filtro += $" and t.Tipo ='{Tipo}'";
                }
            }
            if (Conta_Id != 0)
            {
                filtro += $" and t.Conta_Id ='{Conta_Id}'";
            }

            string IdUsuarioLogado = HttpContextAccessor.HttpContext.Session.GetString("IDUsuarioLogado");
            string sql = "select t.Id, t.Data, t.Tipo, t.Valor, t.Descricao as historico, t.Conta_Id, c.Nome as conta, t.Plano_Contas_Id, p.Descricao as plano_conta " +
                          " from transacao as t inner join conta c " +
                          " on t.Conta_Id = c.Id inner join Plano_Contas as p " +
                          " on t.Plano_Contas_Id = p.Id " +
                          $" where t.Usuario_Id = {IdUsuarioLogado} {filtro} order by t.data desc limit 10"
                          ;
            DAL ObjDAL = new DAL();
            DataTable dt = ObjDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new TransacaoModel();
                item.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                item.Data = DateTime.Parse(dt.Rows[i]["DATA"].ToString()).ToString("dd/MM/yyyy");
                item.Tipo = dt.Rows[i]["Tipo"].ToString();
                item.Descricao = dt.Rows[i]["historico"].ToString();
                item.Valor = double.Parse(dt.Rows[i]["Valor"].ToString());
                item.Conta_Id = int.Parse(dt.Rows[i]["Conta_Id"].ToString());
                item.NomeConta = dt.Rows[i]["conta"].ToString();
                item.Plano_Contas_Id = int.Parse(dt.Rows[i]["Plano_Contas_Id"].ToString());
                item.DescricaoPlanoConta = dt.Rows[i]["plano_conta"].ToString();
                lista.Add(item);
            }
            return lista;

        }
        public void Insert()
        {
            string IdUsuarioLogado = HttpContextAccessor.HttpContext.Session.GetString("IDUsuarioLogado");
            string sql = "";

            if (Id == 0)
            {
                sql = $"INSERT INTO TRANSACAO (DATA, TIPO, DESCRICAO, VALOR, CONTA_ID, PLANO_CONTAS_ID, USUARIO_ID) VALUES ('{DateTime.Parse(Data).ToString("yyyy/MM/dd")}','{Tipo}','{Descricao}','{Valor}','{Conta_Id}','{Plano_Contas_Id}','{IdUsuarioLogado}');";
            }

            else
            {
                sql = $"UPDATE TRANSACAO SET DATA = '{DateTime.Parse(Data).ToString("yyyy/MM/dd")}', DESCRICAO = '{Descricao}', TIPO = '{Tipo}', VALOR = '{Valor}', CONTA_ID = '{Conta_Id}', PLANO_CONTAS_ID = '{Plano_Contas_Id}' WHERE USUARIO_ID = '{IdUsuarioLogado}' AND ID='{Id}';";
            }
            DAL ObjDAL = new DAL();
            ObjDAL.ExecutarComandoSQL(sql);
        }

        public TransacaoModel CarregarRegistro(int? id)
        {

            TransacaoModel item;


            string IdUsuarioLogado = HttpContextAccessor.HttpContext.Session.GetString("IDUsuarioLogado");
            string sql = "select t.Id, t.Data, t.Tipo, t.Valor, t.Descricao as historico, t.Conta_Id, c.Nome as conta, t.Plano_Contas_Id, p.Descricao as plano_conta " +
                          " from transacao as t inner join conta c " +
                          " on t.Conta_Id = c.Id inner join Plano_Contas as p " +
                          " on t.Plano_Contas_Id = p.Id " +
                          $" where t.Usuario_Id = {IdUsuarioLogado} and t.id ='{id}';"
                          ;
            DAL ObjDAL = new DAL();
            DataTable dt = ObjDAL.RetDataTable(sql);


            item = new TransacaoModel();
            item.Id = int.Parse(dt.Rows[0]["ID"].ToString());
            item.Data = DateTime.Parse(dt.Rows[0]["DATA"].ToString()).ToString("dd/MM/yyyy");
            item.Tipo = dt.Rows[0]["Tipo"].ToString();
            item.Descricao = dt.Rows[0]["historico"].ToString();
            item.Valor = double.Parse(dt.Rows[0]["Valor"].ToString());
            item.Conta_Id = int.Parse(dt.Rows[0]["Conta_Id"].ToString());
            item.NomeConta = dt.Rows[0]["conta"].ToString();
            item.Plano_Contas_Id = int.Parse(dt.Rows[0]["Plano_Contas_Id"].ToString());
            item.DescricaoPlanoConta = dt.Rows[0]["plano_conta"].ToString();

            return item;

        }
        public void Excluir(int id)
        {
            new DAL().ExecutarComandoSQL("DELETE FROM TRANSACAO WHERE ID =" + id);

        }          
        }
    public class Dashboard
    {
        public double Total { get; set; }
        public string PlanoConta { get; set; }

        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public Dashboard()
        {

        }

        //Recebe o contexto para acesso às variáveis de sessão.
        public Dashboard(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public List<Dashboard> RetornarDadosGraficoPie()
        {
            List<Dashboard> lista = new List<Dashboard>();
            Dashboard item;

            string id_usuario_logado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");

            string sql = "select sum(t.valor) as total, p.Descricao from transacao as t inner join plano_contas as p " +
                         $"on t.Plano_Contas_Id = p.Id where t.Tipo = 'D' and t.usuario_id = '{id_usuario_logado}' group by p.Descricao;";
            DAL objDAL = new DAL();
            DataTable dt = new DataTable();
            dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new Dashboard();
                item.Total = double.Parse(dt.Rows[i]["Total"].ToString());
                item.PlanoConta = dt.Rows[i]["Descricao"].ToString();
                lista.Add(item);
            }
            return lista;
        }
    }
}

