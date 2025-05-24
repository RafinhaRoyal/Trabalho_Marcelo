using TRABALHO_DO_MARCELO;
using System;
using System.Security.Cryptography.X509Certificates;

namespace console
{

    public class Programa
    {

        public static void Main()
        {
            Banco bancos = new Banco();

            bancos.conectar();

            VEICULO veiculo = new VEICULO("volkswagen", "Fusca");
            bancos.inserir(veiculo);

            bancos.ler();
            bancos.excluir(5);
            bancos.ler();
            VEICULO veiculo2 = new VEICULO("Honda", "Civic");
            bancos.mudar(veiculo2,2);
        }
        

    }
}

