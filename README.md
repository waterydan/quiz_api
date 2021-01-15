# Star Wars Quiz - API

This project is created as part of interview process in Preezie. 
## Run the project

Make sure all NuGet packages are restored. Open Visual Studio and click Run icon.

## Design Overview

* Uses EFCore with in-memory database. Seed is generated on application run.
  
* Data annotation is used for simple validations.

* Controller is responsible for translating DTOs. It also handles translating exceptions to corresponding HTTP status code.

## Development Notes
* For simplicity, DB models are directly sent to client. This might not be ideal in real world and needs to be replaced with DTO and AutoMapper.

* Ideally all messages should be logged, as well as performance and exceptions. These are omitted for simplicity.
