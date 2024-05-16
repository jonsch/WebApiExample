### A Web API Example with database migrations, secured controllers, SOLID principals and Data Abstractions
------
### What
This project outlines using dotnet WebAPI controllers to establish a basic API that allows integrators to access customers, orders, contacts, products, etc., it also demonstrates the following:

- **SOLID Principles**
  - ```Single Responsibility```
  - ```Open/Close``` (there are no test cases, otherwise we would use test cases to ensure non-breaking funcitonality or added functionality to classes)
  - ```Liskov Subtituion``` (we did not extend any classes but there is opportunity to do that)
  - ```Interface Segregation```
  - ```Dependency Injection```

- **Repository and Service Patterns**
  - ```Controllers``` should be responsible for just handling the request
  - This codebase uses the repository pattern to add an instruction set to our ```services``` and our ```DAL``` which could incorporate business logic to be isolated from convoluted controllers

- **Authentication (API Key)**
  - There were several methods build for this and included in here though not used, and this can be extended. The key takeaways here are that the ApiKey should be in your config, it should be stored in a vault or secret manager and pulled in during deployment.  In addition this can be expanded to include Users that are assigned keys so that's not single key based.
  - The authentication happens via the x-api-key header, this is configurable in the appSettings

- **Authorization**
  - This solution uses authorization via ```Policy``` setting, again, if you extend to use a user base you can attach a ```ClaimsIdentity``` and ```Claims``` to that identity on the request ```http context```. This would allow you to verify, audit, and use additional user information within your logging

- **Logging**
  - We use the default logger which is console, ideally this would be (in a commercial product) setup to propagate logs to a service for log aggregation, alerting, monitoring, etc.

- **Database**
  - This solution uses ```SQLite``` for a small logical .db file to be used, ideally in any product you'd want an actual db service such as cosmos, sqlserver, postgres, MongoDB, FerretDB, Couch, MySQL, Maria, etc.  Because we used ```entity framework``` as an abstracted ```ORM``` and migration tool, we used a flag relational database file format
  - This solution includes database migrations, this solution has the initial db creation as well as a seed data for products.
  - ```Migrations``` currently run in startup as an example so that they dont need to be executed via the ```dotnet ef CLI```

- **Docker**
  - This includes a ```Dockerfile``` with image reference, copy and build steps and the pertinent ```docker-compose``` to get the solution up and running

- **DDD (Domain Driven Design)**
  - This solution shows how to operate core functionality and domains as well as ```isolate domain based data entities that can be separated into it's own solution and referenced within your API for cross project usage and better maintainability```, for this example they're included in the Domain folder/namespace.

- **Generics** 
  - This solution includes basic usage and demonstration of how Generics can be applied to make more robust and reusable code.

------

### Why
This example serves as a demonstration of a jump-off point for a strong API product that can be built on and added to. It's also aimed to help the tech community. Tech interview process(es) can be grueling with unnecessary homework assignments. This can serve as a baseline for future buildouts to extend what you have and expedite that process. I ```hope this helps someone``` or serves as a boilerplate in the future.

------

### How to get up and running
- Make sure that you have docker installed on your device
- From the root dir of the solution run the following ```docker-compose build``` and then ```docker-compose up``` if you want to disconnect from the terminal you can add the -d flag via the following ```docker-compose up -d```
- Exposed ports ```8080```
- Find API endpoints via ```http://localhost:8080/swagger``` once you're up and running

------

### Opportunities
There are several opporunities within this solution:
- It could include ```IAC``` via ```Terraform``` or ```Pulumi``` to help establish ```Network Gateways (Azure) and AppServices with scale-out configurations``` or ```(Security Groups) for VPC's in AWS using ECS and EKS```
- It could be built out for ```Use```r context as mentioned above to support ```multiple api keys```
- It could include a ```redis``` cache setup for key-value pairs that are heavily used for frequently queried items
- It could include unit and integration tests (I started to lack free time on this, but they are important and could be added) making use of ```XUnit``` and ```FluentAssertions``` for multiple condition assertions on ```Controllers``` and ```Services``` as well as setup an InMemoryDatabase if you continued use ```EntityFramework```
- It could include ```secret manager(s)``` and make use of ```Azure KeyVault``` or ```AWS Secrets```
- It could include log aggregation and make reflect ```Serilog``` configuratons as well as some ```Sink``` demonstrations
- It could make use of records and spans for memory and speed purposes (for this example it does not), apologies.
- It could include more ```CI/CD actions```, just a basic build one is included here that runs a CI on PR against main.
- It could include ```model validation``` on the server side using annotations and MVC helpers.
- It could include and should breakout ```DTO```'s to seperate from db entities
- It could include a ```CQRS pattern``` to ensure faster reads vs writes for better performance (which is a need for high volume transactions) and ```MediatR``` can be used for this.


### Roadmap
What I'd like to do with this from here as an example set...
- Break apart the ```microservice``` into sustainable ```azure funcctions``` or ```aws lambdas``` to build 'true' ```serverless, scalable APIs by endpoint```
- Consider implementing a ```pub/sub``` pattern using a ```bus architecture``` for high volume

------

Perhaps when I get more time, I'll add to this, but I am swamped at work as of late. In the interim, please feel free to make it your own.