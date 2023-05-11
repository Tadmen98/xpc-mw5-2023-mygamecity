namespace MyGameCity.Logging
{
    public static class MyGameCityFileLoggerExtensions
    {

        public static ILoggingBuilder AddMyGameCityFileLogger(this ILoggingBuilder builder, Action<MyGameCityFileLoggerOptions> configure)
        {
            builder.Services.AddSingleton<ILoggerProvider, MyGameCityFileLoggerProvider>();
            builder.Services.Configure(configure);

            return builder;
        }
        
    }
}
