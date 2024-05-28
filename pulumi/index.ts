import * as pulumi from "@pulumi/pulumi";
import * as azure from "@pulumi/azure-native"

// create resource group
const resourceGroup = new azure.resources.ResourceGroup("rgWebAPiDemo");

// create the app service plan
const appServicePlan = new azure.web.AppServicePlan("aspWebApiDemo", {
    resourceGroupName: resourceGroup.name,
    name: "aspWebApiDemo",
    kind: "Linux",
    reserved: true,
    sku: {
        name: "F1",
        tier: "Free",
    },
});

// create the app service
const appService = new azure.web.WebApp("waWebApiDemo", {
    resourceGroupName: resourceGroup.name,
    serverFarmId: appServicePlan.id,
    siteConfig: {
        appSettings: [
            { name: "ASPNETCORE_ENVIRONMENT", value: "Development" },
        ],
        linuxFxVersion: "DOTNETCORE|8.0",
        alwaysOn: false,
        http20Enabled: true,
        minTlsVersion: "1.2",
    },
    httpsOnly: true,
});

// output the app's endpoint
export const endpoint = pulumi.interpolate`https://${appService.defaultHostName}`;

