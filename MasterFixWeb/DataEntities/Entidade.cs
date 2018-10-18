using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterFixWeb.DataEntities
{
    public class Entidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
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

        // public string getObs { get
        //     {
        //         string s = "";
        //         foreach (var item in Obs)
        //         {
        //             s += Convert.ToChar(item);
        //         }
        //         return s;
        //     } }
    }
}
