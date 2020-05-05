Estado del arte

Antecedentes

Pascal se caracteriza por ser un lenguaje de programación estructurado fuertemente tipificado. Esto implica que el código está dividido en porciones fácilmente legibles llamadas funciones o procedimientos. De esta forma Pascal facilita la utilización de la programación estructurada en oposición al antiguo estilo de programación monolítica. El tipo de dato de todas las variables debe ser declarado previamente para que su uso quede habilitado. Existe una gran variedad de códigos de analizadores léxicos en internet, no seremos los primeros en realizar uno, pero este no será el caso, no se copiará de ningún tutorial ni algún otro código ya existente.

Planteamiento del problema

Se plantea la creación de un analizador léxico del lenguaje Pascal en donde se leerán los caracteres de entrada y elaborar como salida una secuencia de componentes léxicos que utiliza el analizador léxico para hacer el análisis.

Justificación

Como programadores, debemos tener conocimiento de cómo funcionan los compiladores, los cuales son capaces de crear los programas que se tienen en nuestra computadora. Por esta razón es que se tiene en mente hacer este proyecto de un analizador. Pues al realizar esta aplicación por nosotros mismos sabremos la programación que conlleva para un compilador exitoso. Para la solución del problema se opto por usar un diccionario de palabras junto con una matriz de transiciones que nos dará como resultado si lo que se escribió en la sintaxis de pascal es correcta o no, es decir si el compilador de pascal puede correr dicha instrucción o nos manda a un error.

Tokens en Pascal

Los tokens son los bloques de construcción básicos del código fuente léxico: son las 'palabras' del lenguaje. Los caracteres se combinan en tokens de acuerdo con las reglas del lenguaje de programación. Hay cinco clases de tokens:

Palabras Reservadas

Estas son palabras que tienen un significado fijo en el lenguaje. No pueden ser cambiados o redefinidos.

Identificadores

Estos son nombres de símbolos que el programador define. Se pueden cambiar y reutilizar. Están sujetos a las reglas de alcance del lenguaje.

Operadores

Estos son generalmente símbolos para operaciones matemáticas u otras: +, -, * y así sucesivamente.

Separadores

Esto suele ser espacio en blanco.

Constantes

Las constantes numéricas o de caracteres se usan para denotar valores reales en el código fuente, como 1 (constante entera) o 2.3 (constante flotante) o 'Constante de cadena' (una cadena: un fragmento de texto).

Funcionamiento

Clase Program

En este archivo se hacen las llamadas correspondientes a las clases que se explicaran más adelante, en el main del programa se creó un nuevo objeto de tipo StreamReader para leer el archivo a analizar, en este objeto se manda la ruta donde está el archivo, después se utilizó el método ReadToEnd, este lee el contenido completo del archive y se guarda en una variable, después utilizamos el método Close, este cierra el archivo una vez no necesitemos leerlo más. Después de realizar la lectura del archivo se llama a la función Analizar mandando como parámetro el código leído. Todo esto dentro de un bloque Try catch para manejar posibles errores.

 
Clase Token

Esta clase guarda las palabras que fueron ingresadas desde el programa en pascal, dándole un tipo y valor a la dicha palabra lo que se conoce como token, para tener un valor único para cada palabra.









Clase Lexer

En esta clase se definen las diferentes sentencias que acepta pascal, ya sean palabras clave o números, letras del alfabeto y caracteres especiales. En esta parte del código es donde se ingresa la primera palabra y se comprueba si existe, y si existe comprueba si puede estar esa palabra después de la anterior.
Esta clase se encarga de hacer los tokens del código que se manda al constructor, por lo que se crearon atributos que nos sirvieron para poder realizar esta acción, además de que se agregaron los tipos de tokens que existen para el lenguaje Pascal. 




Clase Checker

En esta última clase es donde se programo la tabla de transiciones, comprueba que palabra puede estar después de cual, y cuando termina cada sentencia, si no se da el caso de tener esas palabras juntas nos manda a un error, pero el programa sigue analizando.
Esta clase se encarga de verificar que el código tenga la sintaxis correcta, para su funcionamiento se asignó un arreglo el cual es nuestra matriz de transiciones, en la cual se estará consultando para cada token de la lista.






Funcion Validacion

Esta función se encarga de verificar el código, en esta se recorre la lista de tokens y recuperara la columna a la que pertenece, para así iniciar el recorrido de la tabla de transiciones para cada token, se tiene un contador de líneas el cual se le va sumando uno cuando el valor del token es ;, BEGIN o VAR. Así como una validación cada vez que se recorre la lista en la cual si el estado es igual a 404 significa que hay un error de sintaxis, y nos regresará un mensaje el cual nos dirá en que línea está el error. Al finalizar el recorrido de la lista se hace una última verificación en la que se haya llegado al estado final el cual es 41, si es diferente significa que hay un error de sintaxis, y nos regresara un mensaje el cual nos dirá en que línea está el error, en caso de que sea igual retornara un mensaje de que el análisis fue exitoso y que no hay ningún error.

Funcion Token

Esta función se encarga de retornar un valor de acuerdo con el tipo de token o valor de este, el valor que regresa el numero de la columna que corresponde a ese token en la matriz de transición.

Funcion Numeros

Esta función es llamada cuando se detecta en GenerarTokens que el carácter es igual a un número, esta se encarga de leer todos los caracteres hasta encontrar un espacio o un carácter diferente a un número y regresa el valor de la numero.

Funcion Strings

Esta función es llamada cuando se detecta en GenerarTokens que el carácter es igual a “, esta se encarga de leer todos los caracteres hasta encontrar otro “ y  regresa el valor de la cadena.

Funcion Comentarios

Esta función se encarga de leer los caracteres hasta que encuentre un carácter el cual es }, al encontrarlo este se sale del ciclo while y retorna el comentario. Es llamada cuando se detecta en GenerarTokens que el carácter es {.

Funcion Identificador

En la siguiente función es llamada cuando se detecta en GenerarTokens que la palabra es un identificador, esta se encarga de leer toda la palabra y la regresa.

Funcion Simbolos

En la siguiente función es llamada cuando se detecta en GenerarTokens que el carácter es un símbolo, esta se encarga de leer los caracteres hasta que haya un espacio y lo regresa. Si el símbolo es un paréntesis derecho se sale del ciclo while. 

Funcion Tipo

En esta función lo que se realiza es retornar el tipo de token en el cual se tiene como parámetro el valor del token, en el cual con varios if se busca el tipo utilizando una expresión regular o comparándolo con otros caracteres y así regresar el tipo de token que corresponda.
Esta función se encarga de crear una lista donde se estarán guardando los tokens, para esto se utilizó un ciclo while en el cual si detecta espacios o saltos de línea se llamará a la función Avanzar. Con distintos if anidados se verificará el tipo de token y se llamara a las funciones correspondientes, las cuales retornarán su valor o su tipo, y serán agregados a la lista de tokens, cada token agregado contiene el tipo de token y el valor del token. 

Funcion Avanzar

En esta función se realiza el proceso de cambiar los valores de las variables Posición y Carácter, donde la Posición va incrementando y el Carácter se le asigna un valor utilizando el operador ternario donde se utiliza una condición, la cual es si la Posición es menor a la longitud del código, si es verdadero asignará un nuevo carácter de lo contrario el carácter tendrá el valor de nulo.  

Funcion Analizar

En esta función se realiza el proceso de analizar el código, en esta se llaman a clases que nos ayudaran a verificar que el código este correcto, en esta función se muestra en pantalla el código a analizar y se instancia a la clase Lexer, en la cual se manda el código al constructor. Posteriormente se llama al método GenerarTokens el cual nos regresa una lista de tokens para después crear otra instancia a la clase Checker a la cual se enviará al constructor esta lista, para después realizar una llamada al método Validación el cual nos regresara un string donde nos mostrara si el código es correcto o tiene algún error y se mostrara en la consola.

Sintaxis

Palabra reservada	Función
program	

var	Marca el inicio de una sección de definición de variable

type	

begin

se usa para indicar el inicio de la sección ejecutable de una función, el método de un objeto, el procedimiento, el programa, la propiedad de un objeto o se usa para delinear el inicio de una declaración de bloque.

write

permite llevar hacia la salida estándar (la pantalla) los valores (datos) obtenidos de la evaluación de una lista de argumentos. 

writeln

Realiza lo mismo que write, pero da un salto de línea.

const

se usa para informar al compilador que ciertos identificadores que se están declarando son constantes, es decir, se inicializan con un valor específico en tiempo de compilación en lugar de una variable que se inicializa en tiempo de ejecución.

end

termina una entidad.

procedure

es una rutina que no devuelve un valor.

function

Una función es una rutina que, a diferencia de los procedimientos, devuelve un valor

readln

Realiza lo mismo que read, pero da un salto de línea.

read

permiten asignar a una o más variables, uno o más valores (datos) recibidos desde la entrada estándar (el teclado)

for

es una palabra clave utilizada junto con otras palabras clave para crear bucles.

if

La palabra clave if precede a una condición, debe ir seguida de un then y una declaración.

#, ; , =, ( , )	Indicadores

