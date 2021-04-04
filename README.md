# IReckonU Assignment

## Running the solution

Prerequistes :
* Dotnet5 runtime
* DotNet EntityFramework tool `dotnet tool install --global dotnet-ef`

Create the SQL Databse, from the IReckonUAssignment folder `dotnet ef database update`.

Then start the application with `dotnet run`.

To help with testing a Swagger endpoint has been added.

## Overview

### Projects

| Projects									| Description
| ---										| --- 
| IReckonUAssignment						| Startup Project - Aspnet MVC
| IReckonUAssignment.Logic					| Contains the business logic
| IReckonUAssignment.Models					| Contains the business Models
| IReckonUAssignment.Models					| Contains the business Models
| IReckonUAssignment.DAL					| Contains Abstractions for the Data Acces Layer
| IReckonUAssignment.DAL.JSonDAL			| JSon implementation of the Data Acces Layer
| IReckonUAssignment.DAL.EntityFrameworkDAL	| EF Core / SQL ServerJSon implementation of the Data Acces Layer
| IReckonUAssignment.CsvFileGenerator		| Tool to generate large csv files for testing

### Models

| Model									| Description
| ---									| --- 
| ApiProduct							| Represents one entry/line in the csv file
| Article and Product					| Logic models. Normalised representation of the Articles and their products
| ArticleEntity and ProductEntity		| Data Access Models. Represent Articles and Products records in the SQL Database


### Main Abstractions

| Abstraction				| Responsibility
| ---						| --- 
| IProductCSVFileParser		| Parses a csv file into a collection of ApiProduct
| IApiToLogicConverter		| Converts a collection of ApiProducts in a normalised collection of Articles and their Products
| IArticleStore				| Persists a collection Articles. Has a Json and a EF/SQL implementations

## Potential Improvements

* Abstract the business rules around conversion outside of the IArticle/IProduct Converters to improve extensibility and reusability
* To handle very large file scenarios :
	* Change the controller to queue a message to get the file processed and return a jobID to the caller. This Id can be used later to check on the import progress.
	* The message can be in-process and the file processing happens in a background service
	* Or the message can be sent out (for example with Azure Service Bus) and processed by another service
* Implement better reporting of conversion errors