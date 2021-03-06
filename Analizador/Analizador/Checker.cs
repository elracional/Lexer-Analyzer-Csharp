﻿using System;
using System.Collections.Generic;

namespace Analizador
{
    public class Checker
    {
        int[][] TablaTransiciones = {
            new int[]{1,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404},   // 0
            new int[]{404,2,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404},   // 1
            new int[]{404,404,3,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404},   // 2
            new int[]{404,404,404,4,404,404,7,404,404,404,404,14,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404},      // 3
            new int[]{404,404,404,404,5,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404},   // 4
            new int[]{404,404,404,404,404,6,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404},   // 5
            new int[]{404,404,404,404,404,404,7,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404},   // 6
            new int[]{404,404,404,12,404,404,404,8,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404},    // 7
            new int[]{404,404,404,404,404,404,404,404,7,9,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404},     // 8
            new int[]{404,404,404,404,404,404,404,404,404,404,10,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404},  // 9
            new int[]{404,404,11,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404},  // 10
            new int[]{404,404,404,12,404,404,404,8,404,404,404,14,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404},     // 11
            new int[]{404,404,404,404,13,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404},  // 12
            new int[]{404,404,404,404,404,11,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404},  // 13
            new int[]{404,404,404,38,404,404,404,25,404,404,404,14,15,15,404,404,404,404,404,21,404,28,404,404,34,404,14,40,404,404},          // 14
            new int[]{404,404,404,404,404,404,404,404,404,404,404,404,404,404,16,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404},  // 15
            new int[]{404,404,404,404,404,404,404,17,404,404,404,404,404,404,404,17,404,404,404,404,404,404,404,404,404,404,404,404,404,404},   // 16
            new int[]{404,404,404,404,404,404,404,404,16,404,404,404,404,404,404,404,18,19,404,404,404,404,404,404,404,404,404,404,404,404},    // 17
            new int[]{404,404,14,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404},  // 18
            new int[]{404,404,404,404,404,404,404,20,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404},      // 19
            new int[]{404,404,404,404,404,404,404,404,16,404,404,404,404,404,404,404,18,404,404,404,404,404,404,404,404,404,404,404,404,404},   // 20
            new int[]{404,404,404,404,404,404,404,404,404,404,404,404,404,404,22,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404},  // 21
            new int[]{404,404,404,404,404,404,404,23,404,404,404,404,404,404,404,404,24,404,404,404,404,404,404,404,404,404,404,404,404,404},  // 22
            new int[]{404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,24,404,404,404,404,404,404,404,404,404,404,404,404,404},  // 23
            new int[]{404,404,14,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404},  // 24
            new int[]{404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,26,404,404,404,404,404,404,404,404,404},  // 25
            new int[]{404,404,404,404,404,404,404,27,404,404,404,404,404,404,404,404,404,404,27,404,404,404,404,404,404,404,404,404,404,404},   // 26
            new int[]{404,404,14,404,404,404,404,404,404,404,404,404,404,404,404,404,404,26,404,404,404,404,404,404,404,404,404,404,404,404},   // 27
            new int[]{404,404,404,404,404,404,404,29,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404},  // 28
            new int[]{404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,30,404,404,404,404,404,404,404,404,404},  // 29
            new int[]{404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,31,404,404,404,404,404,404,404,404,404,404,404},  // 30
            new int[]{404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,32,404,404,404,404,404,404,404},  // 31
            new int[]{404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,33,404,404,404,404,404,404,404,404,404,404,404},  // 32
            new int[]{404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,14,404,404,404,404,404,404},  // 33
            new int[]{404,404,404,404,404,404,404,35,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404},  // 34
            new int[]{404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,36,404,404,404,404,404,404,404,404,404,404,404,404},  // 35
            new int[]{404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,37,404,404,404,404,404,404,404,404,404,404,404},  // 36
            new int[]{404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,14,404,404,404,404},  // 37
            new int[]{404,404,404,404,39,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404},  // 38
            new int[]{404,404,404,404,404,14,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404},  // 39
            new int[]{404,404,14,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,41,404},   // 40
            //new int[]{404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404,404}  // 41
        };

        public List<Tokens> tokens;
        public int line;
        public int state;

        public Checker(List<Tokens> tokensArray)
        {
            this.tokens = tokensArray;
            this.line = 1;
            this.state = 0;
        }

        public int Token(Tokens token){
            int rtn = 29;

            if (token.type == "KEYWORD"){
                if(token.value.ToUpper() == "PROGRAM"){
                    rtn = 0;
                }else if(token.value.ToUpper() == "VAR"){
                    rtn = 6;
                }else if (token.value.ToUpper() == "BEGIN"){
                    rtn = 11;
                }else if (token.value.ToUpper() == "WRITE"){
                    rtn = 12;
                }else if (token.value.ToUpper() == "WRITELN"){
                    rtn = 13;
                }else if (token.value.ToUpper() == "READLN"){
                    rtn = 19;
                }else if (token.value.ToUpper() == "FOR"){
                    rtn = 21;
                }else if (token.value.ToUpper() == "TO"){
                    rtn = 22;
                }else if (token.value.ToUpper() == "DO"){
                    rtn = 23;
                }else if (token.value.ToUpper() == "IF"){
                    rtn = 24;
                }else if (token.value.ToUpper() == "THEN"){
                    rtn = 25;
                }else if (token.value.ToUpper() == "ELSE"){
                    rtn = 26;
                }else if (token.value.ToUpper() == "END"){
                    rtn = 27;
                }
            }else if(token.type == "PROGRAM NAME"){
                rtn = 1;
            }else if (token.type == "SEMMICOLON"){
                rtn = 2;
            }else if (token.type == "LEFT BRACE"){
                rtn = 3;
            }else if (token.type == "COMMENT"){
                rtn = 4;
            }else if (token.type == "RIGHT BRACE"){
                rtn = 5;
            }else if (token.type == "IDENTIFIER"){
                rtn = 7;
            }else if (token.type == "COMMA"){
                rtn = 8;
            }else if (token.type == "COLON"){
                rtn = 9;
            }else if (token.type == "VARTYPE"){
                rtn = 10;
            }else if (token.type == "LEFT PARENTHESIS"){
                rtn = 14;
            }else if (token.type == "STRING"){
                rtn = 15;
            }else if (token.type == "RIGHT PARENTHESIS"){
                rtn = 16;
            }else if (token.type == "PLUS" || token.type == "LESS EQUAL" || token.type == "GREATER EQUAL" || token.type == "MINUS" || token.type == "TIMES" || token.type == "DIVIDE"){
                rtn = 17;
            }else if (token.type == "NUMBER"){
                rtn = 18;
            }else if (token.type == "COLON/EQUAL"){
                rtn = 20;
            }else if (token.type == "PERIOD"){
                rtn = 28;
            }else if (token.type == "UNKNOWN"){
                rtn = 29;
            }


            return rtn;
        }

        public String Validacion(){
            String valido = "No se encontraron errores. Analisis exitoso";
            String cadena;
            int coord = 0;
            int Col = 0;

            foreach (var item in tokens)
            {
                Col = Token(item);
                coord = this.state;
                this.state = TablaTransiciones[this.state][Col];

                if(item.value == ";" || item.value.ToUpper() == "BEGIN" || item.value.ToUpper() == "VAR"){
                    this.line += 1;
                }

                if(this.state == 404){
                    cadena = "Syntax error in line: " + this.line.ToString();
                    return cadena;
                }
                if (this.state != 41){
                    cadena = "Syntax error in line: " + this.line.ToString();
                    return cadena;
                }
            }

            return valido;
        }
    }
}
