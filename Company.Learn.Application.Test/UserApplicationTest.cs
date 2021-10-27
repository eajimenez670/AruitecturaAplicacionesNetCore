using Company.Learn.Application.Interface;
using Company.Learn.Service.WebApi;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.IO;

namespace Company.Learn.Application.Test
{
    [TestClass]
    public class UserApplicationTest
    {
        private static IConfiguration _configuration;
        private static IServiceScopeFactory _scopeFactory;

        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();
            _configuration = builder.Build();

            var startup = new Startup(_configuration);
            var services = new ServiceCollection();
            startup.ConfigureServices(services);
            _scopeFactory = services.AddLogging().BuildServiceProvider().GetService<IServiceScopeFactory>();
        }

        [TestMethod]
        public void Authenticate_CuandoNoSeEnvianParametros_RetornarMensajeErrorValidacion()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUserApplication>();

            // Arrange: Donde se inicializan los objetos necesarios para la ejecución del código
            var userName = string.Empty;
            var password = string.Empty;
            var expected = "Errores de validación";

            // Act: Donde se ejecuta el método que se va a probar y se obtiene el resultado
            var result = context.Authenticate(userName, password);
            var actual = result.Message;

            // Assert: Donde se comprueba que el resultado obtenido es el esperado
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Authenticate_CuandoSeEnvianParametrosCorrectos_RetornarMensajeAutenticacionExitosa()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUserApplication>();

            // Arrange: Donde se inicializan los objetos necesarios para la ejecución del código
            var userName = "eajimenez";
            var password = "123456";
            var expected = "Autenticación exitosa!!";

            // Act: Donde se ejecuta el método que se va a probar y se obtiene el resultado
            var result = context.Authenticate(userName, password);
            var actual = result.Message;

            // Assert: Donde se comprueba que el resultado obtenido es el esperado
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Authenticate_CuandoSeEnvianParametrosIncorrectos_RetornarMensajeUsuarioOContrasenaInvalidos()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUserApplication>();

            // Arrange: Donde se inicializan los objetos necesarios para la ejecución del código
            var userName = "eajimenez";
            var password = "6666";
            var expected = "Usuario o contraseña inválidos.";

            // Act: Donde se ejecuta el método que se va a probar y se obtiene el resultado
            var result = context.Authenticate(userName, password);
            var actual = result.Message;

            // Assert: Donde se comprueba que el resultado obtenido es el esperado
            Assert.AreEqual(expected, actual);
        }
    }
}
