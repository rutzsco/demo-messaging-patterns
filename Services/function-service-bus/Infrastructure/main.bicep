@description('The function application storage account name.')
param functionAppStorageAccountName string

@description('The environment prefix to append to resource names.')
param functionAppName string

// Function
module function 'function.bicep' = {
  name: 'functionDeploy'
  params: {
    function_app_name: functionAppName
    storage_account_name: functionAppStorageAccountName
  }
}
