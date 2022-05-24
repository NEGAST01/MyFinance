using MyFinance.Util;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MyFinance.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Preencha o Nome!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Preencha o Email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o Senha!")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Preencha a Data de nascimento!")]
        public string Data_Nascimento { get; set; }


        public Boolean ValidarLogin()
        {

            string sql = $"SELECT ID, NOME, DATA_NASCIMENTO FROM USUARIO WHERE EMAIL='{Email}' AND SENHA = '{Senha}'";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            if (dt != null)
            {

                if (dt.Rows.Count == 1)
                {
                    Id = int.Parse(dt.Rows[0]["ID"].ToString());
                    Name = dt.Rows[0]["NOME"].ToString();
                    Data_Nascimento = dt.Rows[0]["DATA_NASCIMENTO"].ToString();
                    return true;
                } 
            }
            return false;
        }

    public void RegistrarUsuario()
        {
            string dataNascimento = DateTime.Parse (Data_Nascimento).ToString("yyyy/MM/dd"); 
            string sql = $"INSERT INTO USUARIO (NOME, EMAIL, SENHA, DATA_NASCIMENTO) VALUES ('{Name}','{Email}','{Senha}','{dataNascimento}')";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
        }
    }
}
