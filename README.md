<p align="center">
  <a href="https://github.com/othneildrew/Best-README-Template">
    <img src="https://form.multinet.com.tr/sites/default/files/inline-images/trendyol-logo.png" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">Link Converter</h3>

  <p align="center">
    Within the scope of this project, web urls can transformed to the deep links. Deep links can transformed into web urls.
    <br />
    <a href="https://trendyol-linkconverter.herokuapp.com/swagger/index.html"><strong>Live Demo »</strong></a>
    <br />
    <br />
    <a href="https://github.com/ErcinDedeoglu/link-converter/blob/main/release/publish.zip">Release</a>
    ·
    <a href="https://github.com/ErcinDedeoglu/link-converter/tree/main/src">Codes</a>
    ·
    <a href="https://github.com/ErcinDedeoglu/link-converter/blob/main/Trendyol%20Link%20Converter%20Backend%20Applicant%20Case.pdf">Case Study</a>
  </p>




## Objective

Publishers with applications have to broadcast with mobile deep linking schemes in order to attract users to any category within the application. However, a link published as a mobile deeplink cannot work if the user does not have an application. In this case, the link is created in alternate form.

For example, clicking on a youtube link will take you directly to the site and the related video if you are using a desktop device. If the device you are using is a mobile device, you will be presented with several options. If there is a youtube application on your device, it can be opened directly. For this, the system asks you for permission to open this way before and after your approval, you will not be offered any additional options. If you are opening this deep link for the first time, the system asks you whether you want to use the youtube application installed, and after your approval, it will take you to the relevant channel. At this point, if you do not have the Youtube application, this link can also take you to the application market.

With this application, you can easily convert deep links to web urls.

### Built With

* [.NET Core 3.1](https://en.wikipedia.org/wiki/.NET_Core)
* [PostgreSQL](https://www.postgresql.org/)
* [Entity Framework Core](https://en.wikipedia.org/wiki/Entity_Framework)
* [Sentry IO](https://sentry.io/)
* [NUnit](https://nunit.org/)
* [Docker](https://www.docker.com/)
* [Heroku](https://www.heroku.com/)
* [Swagger](https://swagger.io/)
* [ElephantSQL](https://www.elephantsql.com/)

## Architectural Concept

Incoming requests accepting and answered via the Restful web service application. The application is designed as a 3 layer architecture. Repository Design Pattern was preferred for database communication in the project. The Unit Of Work design pattern is preferred for processing incoming web service requests and minimizing code repetition. Entity Framework Core and Code First are used on the ORM side. PostgreSQL is preferred for database. The project has been implemented as stateless in microservice architecture. In this way, it can be run on Docker. Link conversion is implemented according to the pattern recognition technique. By comparing the structure of the incoming link with the sample patterns in the data store, it is decided what the link will be converted into.

**TY.LinkConverter.WebAPI:** Main entry project. It is in a web API template implemented with .NET Core 3.1. Communicates as Restful.

**TY.LinkConverter.Context:** It is the code first project that organizes the database connection supported by the Entity Framework Core library.

**TY.LinkConverter.Data.Entity:** Holds POCOs of Database objects.

**TY.LinkConverter.Data.Interface:** The interfaces used to regulate the communication between classes. It is used for Dependency injection.

**TY.LinkConverter.Data.Migration:** The project that keeps the database structure and changes. Used for EFCore Code first. There are automatically created database changes in it.

**TY.LinkConverter.Data.Service:** The project that hosts the Unit Of Work pattern reinforced with repository design pattern. Handles requests from Dependency injection.

**TY.LinkConverter.Helper:** It is a helper library that contains codes that should be used more than once within the scope of the project and make static operations.

## Getting Started

First of all, the application is deployed using Heroku and ElephantSQL. Access to the Swagger OpenAPI is enabled at https://trendyol-linkconverter.herokuapp.com/swagger/index.html.

NET Core 3.1 SDK is required to compile the application. If you want to migrate to a different database than I use, you can get a free PostgreSQL database from ElephantSQL or use your own instance.

### Configuration

There are 3 points to touch.

1. **Database Settings:** You may need to change the value of the DefaultConnection expression under the ConnectionStrings section in appsettings.json under the TY.LinkConverter.WebAPI project.

2. **Exception Logging:** There is a SentryDSN string in UseSentry in Program.cs in the TY.LinkConverter.WebAPI project. If you want to monitor Exception logging, you need to change this as well. A free account is available at Sentry.IO. Sentry DSN has not been moved to appsettings because it is registered before the Startup class is active so that it can log information about all lifecycle.

3. ### The last and most important:

   Generic link conversion structure and settings.

   Links and patterns are stored in 2 tables in same structure. **ToDeeplinks** and **ToWebUrls**

   As the name suggests,

   **ToDeeplinks:** It is about converting Web URL to Deeplink.
   
   **ToWebUrls:** It concerns converting Deeplink to Web URL.
   
   **To Deeplink example (from DataContext):**
   
       Pattern = @"^(\w+)+?:\/\/(.*)\/(.*)\/(.*)-p-(?<content>\d+)\?boutiqueId=(?<boutique>\d+)&merchantId=(?<merchant>\d+$)",
       ParameterizedLink = "ty://?Page=Product&ContentId=[content]&CampaignId=[boutique]&MerchantId=[merchant]"
   
   **To Web URL example (from DataContext):**
   
       Pattern = @"^(\w+)+?:\/\/(.*)\?Page=Product&ContentId=(?<content>\d+)&CampaignId=(?<campaign>\d+)&MerchantId=(?<merchant>\d+$)",
       ParameterizedLink = @"https://www.trendyol.com/brand/name-p-[content]?boutiqueId=[campaign]&merchantId=[merchant]"
   
   Using the examples here, you can add new pattern definitions as Regex.
   
   **Please see:** TY.LinkConverter.Context/**DataContext.cs**
   
   When any record is changed/added or deleted, add-migration must be run so that the changes can be reflected in the TY.LinkConverter.Data.**Migration** project.
   
   `add-migration [CHANGE IT] -Context "DataContext" -StartupProject "TY.LinkConverter.WebAPI" -Project "TY.LinkConverter.Data.Migration"`



## Tests

NUnit was used to test the functionality of the project.

**Please see:** Test/**TY.LinkConverter.Test**

6 unit tests were written. Code coverage is over 90%.

* **ConfigurationTest:** Checks that the appsettings are configured properly.
* **DatabaseConnectionTest:** It tests that the connection to the database is made properly.
* **DatabaseMigrationTest:** Tests that database schemas are created properly.
* **LinkConverterTest:** Tests that link conversion works well.
* **SentryTest:** Tests that the Exception Logging engine is working properly.
* **UnitOfWorkTest:** Tests that Unit of Work and repositories are working properly with dependency injection.



## Areas To Improve

* A data caching mechanism that will work on the ORM layer can be placed between the Database and Unit Of Work.
* Link patterns can be replaced by a more manageable parser instead of Regex. In this way, people who do not know Regex can manage the pattern structure.
* Audit log of incoming and outgoing requests can be kept. A nosql database may be preferred for this.
* Load balance can be done by placing an ocelot or nginx in front of it.



## Contact

If you have any questions, do not hesitate to contact.

Erçin Dedeoğlu - [@ercindedeoglu](https://www.linkedin.com/in/ercindedeoglu/) - e.dedeoglu@gmail.com - 0 545 906 03 00

