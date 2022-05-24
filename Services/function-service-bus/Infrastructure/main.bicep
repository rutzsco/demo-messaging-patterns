param location string = 'eastus'

param functionAppStorageAccountName string
param functionAppName string
param serviceBusName string = 'rutzscomessagingpatterns'

// Service Bus
module sb 'service-bus.bicep' = {
  name: 'sb'
  
  params: {
    location: location
    serviceBusName: serviceBusName
  }
}

// Function
module function 'function.bicep' = {
  name: 'functionDeploy'
  params: {
    location: location
    function_app_name: functionAppName
    storage_account_name: functionAppStorageAccountName
    serviceBusConnectionString: sb.outputs.connectionString
  }
}

