using System;

namespace Unwind
{
    public class App
    {
        public static bool UseMockDataStore = false;
        //public static string BackendUrl = "http://localhost:5000";
        public static string BackendUrl = "https://unwind.azurewebsites.net/";

        public static void Initialize()
        {
            if (UseMockDataStore)
                ServiceLocator.Instance.Register<IDataStore<ConversationItem>, MockDataStore>();
            else
                ServiceLocator.Instance.Register<IDataStore<ConversationItem>, CloudDataStore>();
        }
    }
}
