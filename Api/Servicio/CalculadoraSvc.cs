using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCalc.Servicio
{
    public class CalculadoraSvc
    {
        public ResponseBase<double> Execution { get; set; }

        public CalculadoraSvc()
        {
            Execution = new ResponseBase<double>()
            {
                Code = 200,
                Message = "Resultado"
            };
        }

        public ResponseBase<double> Addition(string numbers)
        {
            var result = new ResponseBase<double>();
            var sum = Calculate(numbers, Operations.ADD);

            result.Code = Execution.Code;
            result.Data = sum;
            result.Message = "Suma::" + Execution.Message;

            return result;
        }
        public ResponseBase<double> Substraction(string numbers)
        {
            var result = new ResponseBase<double>();
            var subs = Calculate(numbers, Operations.SUBS);

            result.Code = Execution.Code;
            result.Data = subs;
            result.Message = "Resta::" + Execution.Message;

            return result;
        }
        public ResponseBase<double> Multiplication(string numbers)
        {
            var result = new ResponseBase<double>();
            var mult = Calculate(numbers, Operations.MULT);

            result.Code = Execution.Code;
            result.Data = mult;
            result.Message = "Multiplicacion::" + Execution.Message;

            return result;
        }

        public ResponseBase<double> Division(string numbers)
        {
            var result = new ResponseBase<double>();
            var div = Calculate(numbers, Operations.DIV);

            result.Code = Execution.Code;
            result.Data = div;
            result.Message = "Division::" + Execution.Message;

            return result;
        }

        private enum Operations
        {
            ADD = 1,
            SUBS = 2,
            MULT = 3,
            DIV = 4
        }
        private double Calculate(string nums, Operations operation)
        {
            var value = 0D;
            var numbers = new List<double>();

            numbers = Transform(nums);
            if (Execution.Code == 200)
            {
                switch (operation)
                {
                    case Operations.ADD:
                        {
                            foreach (var i in numbers) value = value + i;
                            break;
                        }
                    case Operations.SUBS:
                        {
                            value = numbers[0];
                            for (var i = 1; i < numbers.Count; ++i) value = value - numbers[i];
                            break;
                        }
                    case Operations.MULT:
                        {
                            value = 1;
                            foreach (var i in numbers) value = value * i;
                            break;
                        }
                    case Operations.DIV:
                        {
                            value = ValidateDivision(numbers);
                            break;
                        }
                }
            }
            else
            {
                value = 0;
            }

            return value;
        }

        private List<double> Transform(string numbers)
        {
            var result = new List<double>();

            if (!string.IsNullOrWhiteSpace(numbers))
            {
                var splitter = numbers.Split('/');

                if (splitter.Length > 0)
                {
                    for (var i = 0; i < splitter.Length; ++i)
                    {
                        var isEmpty = string.IsNullOrWhiteSpace(splitter[i].ToString());
                        var isNumber = float.TryParse(splitter[i], out float n);

                        if (!isEmpty && isNumber)
                        {
                            result.Add(Convert.ToDouble(splitter[i]));
                        }
                        else
                        {
                            Execution.Code = 500;
                            Execution.Message = "Parametros invalidos";

                            break;
                        }
                    }
                }
                else
                {
                    Execution.Code = 500;
                    Execution.Message = "Sin parametros";
                }
            }
            else
            {
                Execution.Code = 404;
                Execution.Message = "Parametros no encontrados";
            }

            return result;
        }

        private double ValidateDivision(List<double> numbers)
        {
            var value = numbers[0];

            for (var i = 1; i < numbers.Count; ++i)
            {
                if (numbers[i] != 0)
                {
                    value = value / numbers[i];
                }
                else
                {
                    Execution.Code = 500;
                    Execution.Message = "Tipos flotantes";
                    value = 0;

                    break;
                }
            }

            return value;
        }

    }
}


  
