using Client.API.Data;

namespace Client.API.Infra
{
    public static class GeradorDeServicos
    {
        public static IServiceProvider ServiceProvider;

        public static DataContext CarregarContexto()
        {
            return ServiceProvider.GetService<DataContext>();
        }
    }
}
