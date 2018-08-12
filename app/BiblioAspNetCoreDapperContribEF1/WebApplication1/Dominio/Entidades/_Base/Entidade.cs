using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Dominio.Entidades._Base
{
    public interface IEntidade
    {
        IReadOnlyList<string> Problemas();
    }

    public class Entidade : IEntidade
    {
        private List<string> _problemas { get; set; }
        public IReadOnlyList<string> Problemas() => _problemas.ToList();

        public Entidade()
        {
            Init();
        }

        protected void Init()
        {
            _problemas = new List<string>();
        }

        protected void ValidarTamanhoMin(string valor, int min, string msg)
        {
            if (string.IsNullOrEmpty(valor) || valor.Length < min)
            {
                if (string.IsNullOrEmpty(msg))
                    msg = $"O valor informado '{valor}' não possui o número mínimo de caracteres esperado ({min}).";
                _problemas.Add(msg);
            }
        }

        protected void ValidarTamanhoMax(string valor, int max, string msg)
        {
            if (!string.IsNullOrEmpty(valor) && valor.Length > max)
            {
                if (string.IsNullOrEmpty(msg))
                    msg = $"O valor informado '{valor}' excede o número máximo de caracteres esperado ({max}).";
                _problemas.Add(msg);
            }
        }
    }
}
