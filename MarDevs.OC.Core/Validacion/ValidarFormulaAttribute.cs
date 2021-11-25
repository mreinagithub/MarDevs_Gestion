using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Eval3;

namespace MarDevs.OC.Core
{
    public class ValidarFormulaAttribute: ValidadorBaseAttribute
    {
        public ValidarFormulaAttribute(string formula)
        {
            _formula = formula;
        }

        private string _formula;
        public string Formula
        {
            get { return _formula; }
        }


        public override bool EsValido(object valor)
        {
            //aqui, valor es la entidad que estamos validando ya que en la fórmula
            //seguramente haya referencias a las propiedades del objeto.
            Evaluator ev = new Eval3.Evaluator(ParserSyntax.cSharp, false);
            ev.AddEnvironmentFunctions(_entidad);
            ev.AddEnvironmentFunctions(this);
            OpCode opcode = ev.Parse(_formula);
            bool resultado = Convert.ToBoolean(opcode.Value);
            if (!resultado)
            {
                 _error = "Condición no satisfecha: " + _formula;
            }
            return resultado;
        }
        public bool IsNull(object valor)
        {
            return valor == null;
        }
        public bool SonIguales(object objeto1, object objeto2)
        {
            if (objeto1 == null || objeto2 == null)
            {
                return false;
            }
            else
            {
                return objeto1.Equals(objeto2);
            }
        }
    }
}
