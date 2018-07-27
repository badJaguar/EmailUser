using System.Threading.Tasks;

namespace EmailUser.Data
{
    public interface ISender
    {
        /// <summary>
        /// This interface provides referense to Sender method.
        ///  </summary>
        /// <param name="file"></param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> representing the result of the asynchronous operation.</returns>
        Task SendEmailAsync(string file);
    }
}
