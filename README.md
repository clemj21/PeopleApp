# PeopleApp
PeopleApp application

This application will allow the user to add People as well as search for People.  Adding and Searching People 
is done through REST methods (see the Wiki).  There is also a Web UI application to allow users to Search.

- The application is designed to run inside of Visual Studio
- Seed the database using EF Migrations.  Migration files are included.  From the Package Manager console run: **update-database**
- Web server URL : http://localhost:64884/
- People Search Web UI:  http://localhost:64884/index.html
  - Bootstrap
  - AngularJS
- People Search REST API: http://localhost:64884/api/people
- Unit Tests: PeopleApp.Tests/PeopleControllerTest
