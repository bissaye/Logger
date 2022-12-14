# Introduction 
        Ce projet a pour but de produire un de créer un 
        fournisseur de log customisé et customisable qui
        puisse repondre et s'adapter au besoin de n'importe
        quel projet

# Get started

## Installation
il y a deux façon de procéder  au téléchargement du package:
1. via nuget.org : https://www.nuget.org/packages/Logger.Logger/#readme-body-tab
2. via github : cloner le projet et l'ajouter comme reference de projet dans les projets appellant

Process installation Logger et utilisation:
1. <b><u>dans program.cs</b></u>
-  ajouter le middleware <b>LoggerMiddleware</b> avant les middlewares <b>UseAuthorization</b> et <b>MapControllers</b> avec la ligne de code: 

        app.UseALoggerMiddleware;

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();

- ajouter les configuration du niveau de log par défaut avec la ligne

        builder.Services.Configure<LoggingConfiguration>(builder.Configuration.GetSection("Logging").GetSection("LogLevel"));
2. <b><u>dans les controllers ou les endroits où logger</b></u>
- importer Logger comme suit:
        
        using LoggerService = Logger.Services.Implementations.Logger;
- initialiser votre objet logger :  

        private readonly LoggerService logger = new LoggerService(IOptions<LoggingConfiguration>);

        NB: le constructeur de l'objet prend en paramètre un objet de type IOptions<DatabasesConnectionString> , donc il faudra l'initialiser dans votre controller


## Utilisation
la classe Logger est une implementation de l'interface ILogger avec les methode suivante:
1. logInformation(string message);
2. logDebug(string message);
3. logTrace(string message);
4. logWarning(string message);
5. logError(string message);