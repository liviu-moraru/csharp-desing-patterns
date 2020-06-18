#nullable enable
namespace MySingleton.v1_Naive
{
    public sealed class Singleton
    {
        private static Singleton? _instance;

        public static Singleton Instance
        {
            get
            {
                Logger.Log("Instance call");
                return _instance ??= new Singleton();    
            }
        }

        private Singleton()
        {
            Logger.Log("Constructor invoked.");
        }
    }
}