using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumindoApiAluno.Entities.Services
{
    internal class AlunoServices
    {
        public async Task<Aluno> Integracao(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://localhost:7141/aluno/{id}");
            var jsonString = await response.Content.ReadAsStringAsync();

            Aluno jsonObject = JsonConvert.DeserializeObject<Aluno>(jsonString);

            if(jsonObject != null)
            {
                return jsonObject;
            }
            else
            {
                return new Aluno
                {
                    Vericacao = true
                };
            }
        }
    }
}
