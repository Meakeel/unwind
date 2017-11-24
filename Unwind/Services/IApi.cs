namespace Unwind.Services
{
    using System.Threading.Tasks;
    using Refit;

    public interface IApi
    {
        [Post("/api/add")]
        Task<string> SendMessage([Body]ConversationItem body);
    }
}
