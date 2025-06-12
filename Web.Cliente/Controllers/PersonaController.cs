using CapaEntidad;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Web.Cliente.Clases;

namespace Web.Cliente.Controllers
{
    public class PersonaController : Controller
    {

        private string urlbase;
        private string cadena;
        private readonly IHttpClientFactory _IHttpClientFactory;
        private readonly IHttpClientFactory _httpClientFactory;

        public PersonaController(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            urlbase = configuration["baseurl"];
            cadena = "Hola";
            _IHttpClientFactory = httpClientFactory;
        }



        public IActionResult Index()
        {
            return View();
        }

        //Traer los datos o la Data como string
        // Metodo para listar personas sin filtro
        public async Task<List <PersonaCLS>> listarPersonas()
        {
            //var cliente = _IHttpClientFactory.CreateClient();
            //cliente.BaseAddress = new Uri(urlbase);
            //string cadena = await cliente.GetStringAsync("api/Persona");
            //List<PersonaCLS> lista = JsonSerializer.Deserialize<List<PersonaCLS>>(cadena);
            //return lista;
            return await ClientHttp.GetAll<PersonaCLS>(_httpClientFactory, urlbase, "/api/Persona");
        }

        //Metodo para listar personas con filtro
        public async Task<List<PersonaCLS>> FiltrarPersonas(string nombrecompleto)
        {
            //var cliente = _IHttpClientFactory.CreateClient();
            //cliente.BaseAddress = new Uri(urlbase);
            //string cadena = await cliente.GetStringAsync("api/Persona/"+ nombrecompleto);
            //List<PersonaCLS> lista = JsonSerializer.Deserialize<List<PersonaCLS>>(cadena);
            //return lista;

            return await ClientHttp.GetAll<PersonaCLS>(_httpClientFactory, urlbase, "/api/Persona/"+nombrecompleto);
        }

        public async Task<PersonaCLS> RecuperarPersona(int id)
        {
            //var cliente = _IHttpClientFactory.CreateClient();
            //cliente.BaseAddress = new Uri(urlbase);
            //string cadena = await cliente.GetStringAsync("api/Persona/"+ nombrecompleto);
            //List<PersonaCLS> lista = JsonSerializer.Deserialize<List<PersonaCLS>>(cadena);
            //return lista;

            return await ClientHttp.Get<PersonaCLS>(_httpClientFactory, urlbase, "/api/Persona/recuperarPersona" + id);
        }

    }
}
