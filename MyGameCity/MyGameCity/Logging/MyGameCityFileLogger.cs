namespace MyGameCity.Logging
{
    public class MyGameCityFileLogger : ILogger
    {
        protected readonly MyGameCityFileLoggerProvider _myGameCityFileLoggerProvider;
        public MyGameCityFileLogger(MyGameCityFileLoggerProvider myGameCityFileLoggerProvider)
        {
            _myGameCityFileLoggerProvider = myGameCityFileLoggerProvider;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.None;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if(!IsEnabled(logLevel))
            {
                return;
            }
            var fullFilePath = string.Format("{0}/{1}", _myGameCityFileLoggerProvider.Options.FolderPath, _myGameCityFileLoggerProvider.Options.FilePath.Replace("{date}",DateTime.UtcNow.ToString("yyyyMMdd")));
        
            var logRecord = string.Format("{0} [{1}] {2} {3}", DateTime.UtcNow.ToString("yyy-MM-dd HH:mm:ss"), logLevel.ToString(), formatter(state, exception), (exception != null ? exception.StackTrace : ""));
            
            using (var streamWriter = new StreamWriter(fullFilePath,true))
            {
                streamWriter.WriteLine(logRecord);
            }
        }

    }
}
