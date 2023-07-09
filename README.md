# User Payments

This project was made with Vue 3 + .NET 6 with Entity Framework

In order to run this project you must:

1.- Install Node.js (LTS).

2.- On the client-app folder run `npm install` and `npm run dev`.

3.- Set the the `ASPNETCORE_ENVIRONMENT` variable to Local. Run `$env:ASPNETCORE_ENVIRONMENT="Local"` on PS or the package manager console.

4.- Create a database named  `UserPayments` and run the `update-database` command from the nuget package manager console (Startup project: UserPayments; package manager console project: Data).

5.- Run web app for the .NET solution.
