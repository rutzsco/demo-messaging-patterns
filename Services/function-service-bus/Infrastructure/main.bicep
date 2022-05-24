param location string = 'eastus'

@description('The function application storage account name.')
param functionAppStorageAccountName string

@description('The environment prefix to append to resource names.')
param functionAppName string


// Service Bus
module sb 'service-bus.bicep' = {
  name: 'sb'
  
  params: {
    location: location
    environmentName: functionAppName
    environmentSuffix: '-sb'
  }
}

// Function
module function 'function.bicep' = {
  name: 'functionDeploy'
  params: {
    location: location
    function_app_name: functionAppName
    storage_account_name: functionAppStorageAccountName
  }
}

