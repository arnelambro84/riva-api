# riva-api
Prerequisites
Latest Net Core 5 SDK
Visual Studio 2019 Community — free code editor for C#

Project structure

Domain — for entities and the common models
Application — for Interfaces, CQRS Features, Exceptions, Behaviors
Infrastructure.Persistence — for application-specific database access
Infrastructure.Shared — for common services such as Mail Service, Date Time Service, Mock, and so on
WebApi — for controllers to expose REST API resources and endpoints
