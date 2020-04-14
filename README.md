# Server

Source code template for an ASP.NET Core Web API project. This can be used as the base of an API, with a lot of the tedious setup tasks such as setting up data migrations, project layers etc. already done.

## Install

1. Clone the repository from GitHub (`git@github.com:paulhannon0/Han.Server.git`)
2. Navigate to the root directory on the command line and bring up the containers using `docker-compose up -d`
3. Ensure the MySQL container has started
4. Open Visual Studio Code and start the service (Menu -> Run -> Run Without Debugging)
5. The API should now be available to call, the specific port will be displayed in the 'Debug Console' (e.g. `Now listening on: http://localhost:5000`)

## Project Structure

### Han.Server.Api

This layer is the application host, as well as containing the endpoint controllers and request/response models.

### Han.Server.Business

This layer contains the commands/queries which contain the business logic for a given operation, as well as data transfer objects for these operations.

### Han.Server.Common

This layer contains any resources which could be used across projects, such as exceptions or helpers.

### Han.Server.Data

This layer contains the repositories used to interact with the database, as well as data transfer objects for these interactions.
