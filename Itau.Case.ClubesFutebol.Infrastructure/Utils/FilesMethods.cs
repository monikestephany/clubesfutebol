using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Itau.Case.ClubesFutebol.Infrastructure.Utils
{
    public static class FilesMethods
    {
        public static List<string> ReadFile(IFormFile file)
        {
            var retorno = new List<string>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    retorno.Add(reader.ReadLine());
            }
            return retorno;
        }
    }
}
