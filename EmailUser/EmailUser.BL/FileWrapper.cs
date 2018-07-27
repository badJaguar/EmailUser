using System.IO;
using EmailUser.Data;

namespace EmailUser.BL
{
    public class FileWrapper : IFileWrapper
    {
        public void Delete(string file)
        {
            File.Delete(file);
        }
    }
}
