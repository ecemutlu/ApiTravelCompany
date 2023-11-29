# ApiTravelCompany
Swagger:
https://apitravelcompany20231129002128.azurewebsites.net/swagger/index.html
Video link:
https://ecestorageaccount.blob.core.windows.net/se4458-19070001034/ApiTravelCompany - Microsoft Visual Studio 2023-11-29 17-16-41.mp4
Er Diagram:
![image](https://github.com/ecemutlu/ApiTravelCompany/assets/109739236/d3e82449-9540-4097-92b0-a8f8dc39e774)
Design Overview:

Project Purpose:
The purpose of the project, named ApiTravel, is to provide an API for a travel-related application.

Code First Approach:
The project follows the Code First approach for database development.
Models are defined in code, and the database schema is generated based on these models.

Authentication:
JWT (JSON Web Token) is used for authentication. Users can obtain a token by providing valid credentials (username and password).

User Authentication and Token Generation:
The UserController contains a Login action that authenticates users and generates a JWT token.
The Generate method is responsible for creating the JWT token with specific claims, such as sub (subject), name, and jti (JWT ID).

Swagger Integration:
Swagger (OpenAPI) is integrated into the project for API documentation.
The Swagger UI can be accessed at /swagger/index.html.

Database Integration:
Entity Framework Core is used for database operations.
A connection string pointing to a SQL Server database is configured in the appsettings.json file.

Assumptions:

The assumption is that users need to be authenticated to access certain parts of the API.
JWT tokens are used for stateless authentication.
Swagger is assumed to be used for API documentation and testing.
The Authorize attribute is used to indicate that authentication is required for a specific endpoint.
Entity Framework Core is assumed to be the ORM (Object-Relational Mapper) for interacting with the database.

Issues Encountered:

Difficulty understanding and correctly implementing JWT token generation.
Lack of familiarity with JWT claims and their role in authentication.
Swagger UI returning a 401 (Unauthorized) error.
Needed to explicitly specify the authentication scheme for Swagger.
Use of DateOnly types required a custom JSON converter (DateOnlyJsonConverter) for proper serialization and deserialization.

Solutions and Additional Considerations:

Understanding the JWT claims and their significance in authentication.
Properly configuring and handling JWT token generation.
Explicitly specifying the authentication scheme for Swagger.
Verifying that the Swagger configuration matches the authentication setup.
Utilizing a custom JSON converter (DateOnlyJsonConverter) to handle DateOnly types during serialization and deserialization.

