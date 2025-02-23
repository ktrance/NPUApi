# NPUApi  

NPUApi is an ASP.NET Core web API project that allows users to search and score NPU's. 

This project provides endpoints for searching NPU's based on various criteria and for submitting scores to evaluate their creativity.

## Features  

- Search NPU's: Search for NPU's based on different criteria such as name, manufacturer, and performance metrics.
- Score NPU's: Submit scores to evaluate NPU's.
- API Documentation: Automatically generated API documentation using Swagger.


## Testing Strategy  

***NOT implemented yet***

Given that the NPUApi project has minimal business logic, the primary focus of our testing strategy will be on integration testing using Testcontainers. 

The simplicity and straightforwardness of the business logic mean that unit tests may not provide substantial value or uncover significant issues. 
Instead, integration tests will ensure that all components of the system interact correctly and that the API endpoints function as expected. 
By leveraging Testcontainers, we can create isolated and reproducible test environments that include necessary services such as databases or external APIs. 
This approach allows us to verify the end-to-end functionality of the application, ensuring that data flows correctly through the system and that responses are accurate. 
The lack of complex business logic makes integration tests an efficient and effective way to validate the overall behavior of the NPUApi, giving us confidence that the application will perform reliably in a production environment.