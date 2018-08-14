using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainApp.Entidades._Base
{
    public class Entidade
    {
        public List<string> Problemas { get; set; }
        
        public Entidade()
        {
            Init();
        }

        protected void Init()
        {
            Problemas = new List<string>();
        }

        protected void ValidarTamanhoMin(string valor, int min, string msg)
        {
            if (string.IsNullOrEmpty(valor) || valor.Length < min)
            {
                if (string.IsNullOrEmpty(msg))
                    msg = $"O valor informado '{valor}' não possui o número mínimo de caracteres esperado ({min}).";
                Problemas.Add(msg);
            }
        }

        protected void ValidarTamanhoMax(string valor, int max, string msg)
        {
            if (!string.IsNullOrEmpty(valor) && valor.Length > max)
            {
                if (string.IsNullOrEmpty(msg))
                    msg = $"O valor informado '{valor}' excede o número máximo de caracteres esperado ({max}).";
                Problemas.Add(msg);
            }
        }
    }
}
