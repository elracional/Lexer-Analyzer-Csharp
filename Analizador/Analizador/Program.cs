using System;
using System.IO;
using System.Collections.Generic;

namespace Analizador
{
    class Analizador
    {
        public static void Main(string[] args)
        {
            TextReader LeerCodigo;
            String Codigo = "";


            try{
                LeerCodigo = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Analizador/Example/TablaMultiplicar.pas");
                Codigo = LeerCodigo.ReadToEnd();
                LeerCodigo.Close();
                Analizar(Codigo);
            }
            catch(Exception e){
                Console.WriteLine("Mensaje de excepcion:"+ e.Message);
            }
        }

        public static void Analizar(string Codigo)
        {
            List<Tokens> tokens;
            String Mensaje;

            Console.WriteLine("Analizador lexico para PASCAL\n");
            Console.WriteLine("<--- Codigo para analizar --->");
            Console.WriteLine(Codigo);

            Lexer lexer = new Lexer(Codigo);
            tokens = lexer.GenerarTokens();

            Checker analizador = new Checker(tokens);
            Mensaje = analizador.Validacion();

            Console.WriteLine(Mensaje);
        } 
    }
}
