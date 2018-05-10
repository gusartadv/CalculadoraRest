# CalculadoraRest
Calculadora .net core REST

Esta calculadora contiene cuatro operaciones basicas, su consumo se hace a traves de la URL, 
esta construida en .NET CORE con REST.

Ejemplo para consumo

Suma
http://localhost:6002/Api/values/suma/5/9

Resta
http://localhost:6002/Api/values/resta/5/9

Multiplicacion
http://localhost:6002/Api/div/suma/5/9

Division
http://localhost:6002/Api/mult/suma/5/9

Creacion del contenedor

docker run -p 6002:80 dockercal
