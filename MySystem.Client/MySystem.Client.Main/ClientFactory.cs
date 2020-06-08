using MySystem.Client.Contract;

namespace MySystem.Client.Main
{
    public class ClientFactory : IClientFactory
    {
        public ClientFactory() { }

        public IMainClient CreateMainClient()
        {
            return new MainClient();
        }
    }
}
