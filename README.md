[![.NET](https://github.com/retracd/TestWebSolution1/actions/workflows/dotnet.yml/badge.svg)](https://github.com/retracd/TestWebSolution1/actions/workflows/dotnet.yml) [![CodeQL](https://github.com/retracd/TestWebSolution1/actions/workflows/codeql.yml/badge.svg)](https://github.com/retracd/TestWebSolution1/actions/workflows/codeql.yml)

.NET mutli-webapp test environment for internal company project. This project serves as suite of several test functions which will serve as the cornerstone for the future production project.

The final project will ultimately have several services:
  1. Internet-facing webhook receiver - this service will allow incoming webhook data which alerts of changes in an SaaS employee database
  2. API-requester - this service will then contact the SaaS API, inquiring about the new data (or perhaps deletion of data); this service will then contact the...
  3. Database-interfacer - this service will receive data from the API-requester service (which was returned from the SaaS API) and then mimic (upload or delete) said data in an on-prem database
  4. Authentication service - this service will renew the bearer token hourly (or as needed, if greater than hourly) as well as annually renew the company secret

These services will work together to provide a seamless, automatic synchronization of employee data between the SaaS database and an on-prem SQL Server.
