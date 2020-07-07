# Systematics Portal Web Site
> A web site for viewing systematics data

[https://test-systematicsportal.landcareresearch.co.nz](https://test-systematicsportal.landcareresearch.co.nz)

The systematics portal web site replaces a variety of legacy websites with one modern consolidated place to access and explore systematics data.

## Useful Details

|Detail|Description|
|-|-|
|Project Lead|Aaron Wilton (wiltona@landcareresearch.co.nz)|
|Technology|ASP.NET Core MVC/API with a SQL Server database. SOLR is used for the search indexing. Identity Server is used for authentication.|
|Issue Tracker|[JIRA project](https://jira.landcareresearch.co.nz/projects/SYSPTL)|
|Documentation|[Confluence Documentation](https://confluence.landcareresearch.co.nz/display/SYSPTL)|
|Logging|The application logs to the [Systematics Data Seq log](https://logger.landcareresearch.co.nz/systematicsdata)|

### Build Status

|Build|Status|
|-|:-|
|Web Site| [![Alt text](https://build.landcareresearch.co.nz/app/rest/builds/buildType%3A%28id%3ABiota_SystematicsPortalWeb%29/statusIcon)](http://build.landcareresearch.co.nz/viewType.html?buildTypeId=Biota_SystematicsPortalWeb&guest=1)|
|Data Api| [![Alt text](https://build.landcareresearch.co.nz/app/rest/builds/buildType%3A%28id%3ABiota_SystematicsDataWebApi%29/statusIcon)](http://build.landcareresearch.co.nz/viewType.html?buildTypeId=Biota_SystematicsDataWebApi&guest=1)|

## Installing/Getting Started

The project is fairly straightforward and is ready to run after cloning from Bitbucket.

### Environments

The project uses the normal environments and is deployed via Octopus.

### Building/CI Environment

The Riparian Planner web site is in the Build Pipeline.

[https://build.landcareresearch.co.nz/project/Biota](https://build.landcareresearch.co.nz/project/Biota)

### Deploying/Publishing

The web site is deployed using Octopus Deploy.

### SOLR

The SOLR configuration is maintained in the Configuration/Solr folder.