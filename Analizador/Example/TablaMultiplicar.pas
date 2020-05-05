program Tabla;
var
i,n:integer;
begin
 write('ingrese la tabla de multiplicar que desee ver: ');
 readln(n);
 for i:=1 to 10 do
  begin
   writeln( i, 'x',n, '=',i*n);
  end;
readln( );
end.
