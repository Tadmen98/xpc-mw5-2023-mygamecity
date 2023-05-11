using Microsoft.Extensions.Options;

namespace MyGameCity.Logging
{
    [ProviderAlias("MyGameCityFile")]
    public class MyGameCityFileLoggerProvider : ILoggerProvider
    {   
        public readonly MyGameCityFileLoggerOptions Options;

        public MyGameCityFileLoggerProvider(IOptions<MyGameCityFileLoggerOptions> _options)
        {
            Options = _options.Value;

            if(!Directory.Exists(Options.FolderPath))
            {
                Directory.CreateDirectory(Options.FolderPath);

            }
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new MyGameCityFileLogger(this);
        }

        public void Dispose()
        {            
        }
    }
}
