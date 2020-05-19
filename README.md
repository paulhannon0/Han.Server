# Server

## Installation and Usage

1. Clone the repository from GitHub (`git@github.com:paulhannon0/Han.Server.git`)
2. Navigate to the root directory on the command line and bring up the database and service itself using `docker-compose up -d`
3. The service is now ready and exposed at the port specified in the docker-compose.yml (default: 8080)

## Project Structure

### Han.Server.Api

This layer is the application host, as well as containing the endpoint controllers and request/response models.

### Han.Server.Business

This layer contains the commands/queries which contain the business logic for a given operation, as well as data transfer objects for these operations.

### Han.Server.Common

This layer contains components which can be used in any layer, such as custom exceptions.

### Han.Server.Data

This layer contains the repositories used to interact with the database, as well as migration scripts and data transfer objects for these interactions.

### Han.Server.Tests

This layer contains all tests for the API.
