# Introduction 
        Ce projet a pour but de produire un de créer un 
        fournisseur de log customisé et customisable qui
        puisse repondre et s'adapter au besoin de n'importe
        quel projet

# Get started

## Installation
il y a deux façon de procéder à l'installation:
1. via nuget.org : https://www.nuget.org/packages/Logger.Logger/#readme-body-tab
2. via github : cloner le projet et l'ajouter comme reference de projet dans les projets appellant

## Utilisation
la classe Logger est une implementation de l'interface ILogger avec les methode suivante:
1. logInformation(string message);
2. logDebug(string message);
3. logTrace(string message);
4. logWarning(string message);
5. logError(string message);