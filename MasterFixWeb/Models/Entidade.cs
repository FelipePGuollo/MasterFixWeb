using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterFixWeb.Models
{
    public class Entidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Required(ErrorMessage="O nome do usuário é obrigatório",AllowEmptyStrings=false)]
        [Display(Name = "Nome do Usuário")]
        public string Rua { get; set; }
        public int? Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public string Fone1 { get; set; }
        public string Fone2 { get; set; }
        public string Email { get; set; }
        public string Homepage { get; set; }
        public string Contato { get; set; }
        public string ContatoFone { get; set; }
        public string CnpjCpf { get; set; }
        public string InscRg { get; set; }
        public byte[] Obs { get; set; }
        [NotMapped]
        public byte[] ObsConv { get; set; }
        [NotMapped]
        public int IdRamoAtividade {get; set;}
        [NotMapped]
        public double Comissao {get; set;}
        [NotMapped]
        public string Fantasia {get;set;}
        [NotMapped]
        public double ComissaoFixa {get; set;}
        [NotMapped]
        public int IdTipoCadastro {get; set;}
        [NotMapped]
        public int IdPlanodeContas {get; set;}
        [NotMapped]
        public string Cuidados {get; set;}
        [NotMapped]
        public string Agencia {get; set;}
        [NotMapped]
        public string Conta { get; set; }
        [NotMapped]
        public string Banco { get; set; }
        [NotMapped]
        public string Ativo {get; set;}
        [NotMapped]
        public int IdGrupoConvenio {get; set;}
        [NotMapped]
        public int IdSupervisor {get; set;}
        [NotMapped]
        public double ComissaoSupervisor {get; set;}
        [NotMapped]
        public DateTime ComissionadoDesde {get; set;}
        [NotMapped]
        public int IdTabela {get; set;}
        [NotMapped]
        public char Husi {get; set;}
        [NotMapped]
        public string RegistroAns {get; set;}
        [NotMapped]
        public string NumeroCarteira {get; set;}
        [NotMapped]
        public int IdPlano {get;set;}
        [NotMapped]
        public DateTime ValidadeCarteira {get; set;}
        [NotMapped]
        public int CodOperadora {get; set;}
        [NotMapped]
        public int CodCnes {get; set;}
        [NotMapped]
        public string NumeroOrm { get; set; }
        [NotMapped]
        public string UfOrm {get; set;}
        [NotMapped]
        public string ConsumidorFinal {get; set;}
        [NotMapped]
        public string DadosFisNrLicenca {get; set;}
        [NotMapped]
        public string DadosFisNrAnvisa {get; set;}
        [NotMapped]
        public string DadosFisNrPratica {get; set;}
        [NotMapped]
        public DateTime DadosFisDataLicenca {get; set;}
        [NotMapped]
        public DateTime DadosFisDataPratica {get; set;}
        [NotMapped]
        public int Produto1 { get; set; }
        [NotMapped]
        public int Produto2 { get; set; }
        [NotMapped]
        public int IdVendedor { get; set; }
        [NotMapped]
        public string getObs {
            get{
                if(Obs == null)
                    return "";

                string s = "";
                foreach (var item in Obs)
                     s += Convert.ToChar(item);
                return s;
                }
            set{
                if(value != "")
                {
                    byte[] bytes = Encoding.ASCII.GetBytes(value);
                    Obs = bytes;
                }
                else
                {
                    Obs = null;
                }
                }
        }


    }
}
