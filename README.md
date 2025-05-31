# Function App on Container Apps - slow and failed executions test


[![Deploy To Azure](https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/1-CONTRIBUTION-GUIDE/images/deploytoazure.svg?sanitize=true)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fgabesmsft%2FFunctionAppSlowAndCrashTest%2Fmaster%2Fdeploy%2Fazuredeploy.json)

This sample Azure Resource Manager template deploys a Function App on Container App, using the Container App-only resource (kind=functionapp).

This application is not intended as a production application or as official instructions.

### Prerequisites
Deploy a Container App Environment.
You can use [this template](https://github.com/azureossd/Container-Apps/tree/master/ContainerAppEnvironment/deploy) to deploy a Container App Environment.

### Functions and other resources deployed

The Slow*x*minuteHttpFunctions use Thread.Sleep to sleep for x number of minutes. You will get an HTTP timeout after ~4 minutes, but the Function should continue executing for the duration of the sleep period or host timeout duration, whichever is shorter.

- Slow5minuteHttpFunction
- Slow12minuteHttpFunction
- Slow20minuteHttpFunction
- Slow25minuteHttpFunction
- CrashHttpFunction: returns an HTTP 500.
- FastHttpFunction: demonstrates a function that successfully and quickly executes.

To test a function, append /api/*FunctionName* to the end of the Function App URL. For example, to test the FastHttpFunction, make a request to https://*ReplaceWithYourFunctionAppName*.*ManagedEnvironmentClusterName*.*Region*.azurecontainerapps.io/api/FastHttpFunction

A storage account is also deployed, for Functions management operations.