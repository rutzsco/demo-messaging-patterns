// parameters
@minLength(3)
@maxLength(32)
param environmentName string = 'myprj'
param environmentSuffix string = 'ci'

@allowed([
  'Basic'  
  'Standard'
  'Premium'
])
param sku string = 'Standard'
param location string = resourceGroup().location
var serviceBusName = '${environmentName}-sb-${environmentSuffix}'

resource sb 'Microsoft.ServiceBus/namespaces@2021-01-01-preview' = {
  name: serviceBusName
  location: location
  sku: {
    name: sku
  }
  properties: {
  }
}

output name string = sb.name
output id string = sb.id
