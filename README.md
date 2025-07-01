# partstracker

This repo is an implementation of a technical test.

It contains a .NET Core API,PostgreSql database , tests for the API and an Angular front end.

## Setup

### Requirements

 - Docker Desktop
 - ef core CLI tools
 - Node >= v22
 - npm
 - @angular/cli

### Steps to set up API
 - Open PartsTracker.sln
 - Ensure Docker Desktop is running
 - Run using the docker-compose launch profile
 - After the postgres docker has been started change the `Host` of `ConnectionStrings::Parts` to `localhost` in `appsettings.json`
 - Open a powershell in the root of the project and run `dotnet ef database update` to apply EF Core migrations
 - Revert the host

Congratulations the API should now be running.

### Steps to set up the front end
 - Open `PartsTacker UI/partstracker.ui` folder in VS Code or with a terminal
 - Install Angular CLI by running `npm i @angular/cli -g`
 - Run the command npm i
 - Run the command `ng serve`
 - Change the URL in `src/app/services/parts.service.ts` to the URL your API started up to and save

 Congratulations the front end should now be running and connected successfully.
