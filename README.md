# Server

## Installation and Usage

1. Clone the repository from GitHub (`git@github.com:paulhannon0/Han.Server.git`)
2. Navigate to the root directory on the command line and bring up the database and service using `docker-compose up -d`
3. Run the service from VSCode under `Run -> Start (With/Without) Debugging` (**note:** this method uses the environment variables found in .vscode/launch.json)

## Project Structure

### Han.Server.Api

This layer contains:
- Main application host
- Configuration
- Controllers
- Extensions
- Middleware
- Models

### Han.Server.Business

This layer contains:
- Commands
- Queries
- Models

### Han.Server.Common

This layer contains:
- Exceptions

### Han.Server.Data

This layer contains:
- Migrations
- Models
- Repositories

### Han.Server.Tests

This layer contains:
- Common steps
- Configuration
- Endpoint integration tests
- Helpers

