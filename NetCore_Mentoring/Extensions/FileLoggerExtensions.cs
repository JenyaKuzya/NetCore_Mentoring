using Microsoft.Extensions.Logging;
using NetCore_Mentoring.API.Utils;

namespace NetCore_Mentoring.API.Extensions
{
    public static class FileLoggerExtensions
    {
        public static ILoggerFactory AddFile(this ILoggerFactory factory,
                                        string filePath)
        {
            factory.AddProvider(new FileLoggerProvider(filePath));
            return factory;
        }
    }
}
