using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Analizador
{
    public class Lexer
    {
        String letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        String digitos = "0123456789";
        String simbolos = "+-*/=><:.,;(){}";
        String[] keywords = {
            "PROGRAM", "VAR", "BEGIN", "WRITE", "WRITELN", "READLN", "FOR", "TO",
            "DO", "IF","THEN", "ELSE", "END"
        };

        String[] tipoVar = {
            "INTEGER", "REAL"
        };

        // Tokens
        String UNKNOWN = "UNKNOWN";
        String KEYWORD = "KEYWORD";
        String VARTYPE = "VARTYPE";
        String COMMENT = "COMMENT";
        String NUMBER = "NUMBER";
        String IDENTIFIER = "IDENTIFIER";
        String STRING = "STRING";
        String SEMMICOLON = "SEMMICOLON";
        String PLUS = "PLUS";
        String LE = "LESS EQUAL";
        String GE = "GREATER EQUAL";
        String MINUS = "MINUS";
        String TIMES = "TIMES";
        String DIVIDE = "DIVIDE";
        String EQUALS = "EQUALS";
        String CE = "COLON/EQUAL";
        String COMMA = "COMMA";
        String COLON = "COLON";
        String PERIOD = "PERIOD";
        String LP = "LEFT PARENTHESIS";
        String RP = "RIGHT PARENTHESIS";
        String LB = "LEFT BRACE";
        String RB = "RIGHT BRACE";
        String PROGRAMNAME = "PROGRAM NAME";

        string Codigo;
        int Posicion;
        char Caracter;

        public Lexer(string Codigo)
        {
            this.Codigo = Codigo;
            this.Posicion = 0;
            this.Caracter = this.Codigo[this.Posicion];
        }

        public void Avanzar(){
            this.Posicion++;
            this.Caracter = (this.Posicion < this.Codigo.Length) ? this.Codigo[this.Posicion] : '\0';
        }

        public List<Tokens> GenerarTokens(){
            String Valor;
            String TipoVar;
            bool Programname = false;
            bool Comments = false;

            List<Tokens> tokens = new List<Tokens>();

            while (this.Caracter != '\0'){
                
                if (this.Caracter == '\n'){
                    Avanzar();
                    continue;

                }else if (this.Caracter == ' '){
                    Avanzar();
                    continue;
                }

                if (digitos.Contains(this.Caracter.ToString())){  // Detecta digitos
                    Valor = Numeros();
                    tokens.Add(new Tokens(NUMBER, Valor));

                }else if (Programname == true && letras.Contains(this.Caracter.ToString().ToUpper())){ // Detecta nombre de programa
                    Valor = Identificador();
                    tokens.Add(new Tokens(PROGRAMNAME, Valor));
                    Programname = false;

                }else if (Comments == true && letras.Contains(this.Caracter.ToString().ToUpper())){  // Detecta comentarios
                    Valor = Comentarios();
                    tokens.Add(new Tokens(COMMENT, Valor));

                }else if (letras.Contains(this.Caracter.ToString().ToUpper())){ // Detecta letras
                    Valor = Identificador();
                    TipoVar = Tipo(Valor);
                    tokens.Add(new Tokens(TipoVar, Valor));

                    if(Valor.ToUpper() == "PROGRAM"){
                        Programname = true;
                    }

                }else if(simbolos.Contains(this.Caracter.ToString())){  // Detecta simbolos
                    Valor = Simbolos();
                    TipoVar = Tipo(Valor);
                    tokens.Add(new Tokens(TipoVar, Valor));

                    if (Valor == "{"){
                        Comments = true;
                    }

                    if (Valor == "}")
                    {
                        Comments = false;
                    }


                }else if(this.Caracter.ToString() == "'"){  // Detecta strings
                    Valor = Strings();
                    tokens.Add(new Tokens(STRING, Valor));

                }
            }

            return tokens;
        }

        public String Tipo(String cadena){
            String tipo = UNKNOWN;
            Regex VarName = new Regex("[A-Z]([A-Z]|[0-9])*");

            if(keywords.Contains(cadena.ToUpper())){
                tipo = KEYWORD;
            }else if(tipoVar.Contains(cadena.ToUpper())){
                tipo = VARTYPE;
            }else if(VarName.IsMatch(cadena.ToUpper())){
                tipo = IDENTIFIER;
            }else if(cadena == ";"){
                tipo = SEMMICOLON;
            }else if(cadena == "<="){
                tipo = LE;
            }else if (cadena == ">="){
                tipo = GE;
            }else if (cadena == "+"){
                tipo = PLUS;
            }else if (cadena == "-"){
                tipo = MINUS;
            }else if (cadena == "*"){
                tipo = TIMES;
            }else if (cadena == "/"){
                tipo = DIVIDE;
            }else if (cadena == "="){
                tipo = EQUALS;
            }else if (cadena == ":="){
                tipo = CE;
            }else if (cadena == ","){
                tipo = COMMA;
            }else if (cadena == ":"){
                tipo = COLON;
            }else if (cadena == "."){
                tipo = PERIOD;
            }else if (cadena == "("){
                tipo = LP;
            }else if (cadena == ")"){
                tipo = RP;
            }else if (cadena == "{"){
                tipo = LB;
            }else if (cadena == "}"){
                tipo = RB;
            }

            return tipo;
        }

        public String Identificador(){
            String result = "";

            while (letras.Contains(this.Caracter.ToString().ToUpper()) || digitos.Contains(this.Caracter.ToString())){
                result += this.Caracter;
                Avanzar();
            }

            return result;
        }

        public String Simbolos(){
            String simbolo = "";

            while (simbolos.Contains(this.Caracter.ToString()))
            {
                if(simbolo == ")"){
                    break;
                }
                simbolo += this.Caracter;
                Avanzar();
            }

            return simbolo;
        }

        public String Strings(){
            String cadena = "";

            Avanzar();

            while (this.Caracter.ToString() != "'")
            {
                cadena += this.Caracter;
                Avanzar();
            }

            Avanzar();

            return cadena;
        }

        public String Comentarios(){
            String comentario = "";


            while (this.Caracter.ToString() != "}")
            {
                comentario += this.Caracter;
                Avanzar();
            }

            return comentario;
        }

        public String Numeros(){
            String numero = "";

            while (digitos.Contains(this.Caracter.ToString()))
            {
                numero += this.Caracter;
                Avanzar();
            }

            return numero;
        }
    }
}