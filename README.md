# ASP.NET Core Grundkurs

Kurs Repository zum Kurs ASP.NET Core Grundkurs der ppedv AG.

## M001 | ASP.NET Überblick

-   [ ] Historie
-   [ ] Projekte und Projektmappen
-   [ ] ASP.Net Core Empty: Hello, World

## M002 | Konfiguration

-   [ ] IOC mittels Dependency Injection
-   [ ] Aufbau appsettings.json
-   [ ] Logging mit Serilog und Filesink
-   [ ] Lab: Dependency Injection OperationService

## M003 | Model View Controller (MVC)

-   [ ] Overview
-   [ ] Links setzen
-   [ ] Index und Details
-   [ ] Lab: MovieService und MVC App mit Index und Details

## M004 | Razor Pages

-   [ ] Overview
-   [ ] Links setzen
-   [ ] Details

## M005 | Forms und Validierung

-   [ ] ViewModel Mapping
-   [ ] Form Post & Validierung
-   [ ] ModelState
-   [ ] Lab: Create Page für Movies erstellt

## M006 | FileServer erstellen

-   [ ] Static Files und Directory Browser
-   [ ] File Provider und Dateizugriff
-   [ ] [Hoppscotch](https://hoppscotch.io/) (Postman Alternative)
-   [ ] API mit [httpFile testen](https://learn.microsoft.com/de-de/aspnet/core/test/http-files?view=aspnetcore-8.0)
-   [ ] Api-Key mittels Middleware abfragen
-   [ ] Lab: Request Culture Middleware

## M007 | HttpClient verwenden

-   [ ] Konfiguration auslesen
-   [ ] HttpClient verwenden
-   [ ] MultipartFormDataContent
-   [ ] HttpContext, Request, Response

## M008 | Entity Framework Code First

-   [ ] O/R Mapping Framework EFCore
-   [ ] Code First Ansatz (Entites + DbContext)
-   [ ] LocalDB verwenden (Kommandozeile: `sqllocaldb create|start|stop|info <instanceName>`)
-   [ ] [Testing Strategien gegen Datenbank](https://learn.microsoft.com/de-de/ef/core/testing/)
-   [ ] Seed erstellen und Abhängigkeiten modellieren
-   [ ] DB Migration 

```bash
// Package Manager Console aufrufen

Add-Migration InitMyModel -Context MyAppDbContext

Update-Database

```

-   [ ] Unit Tests mit EntityFramework
-   [ ] OrderService anhand von Tests entwickeln
-   [ ] Dashboard fuer aktuelle Orders anzeigen

## M009 | Entity Framework DB First

-   [ ] DB First Ansatz
-   [ ] VS Extension [EF Core Power Tools](https://marketplace.visualstudio.com/items?itemName=ErikEJ.EFCorePowerTools)
-   [ ] Controller mit Scaffolding erstellen (Microsoft.EntityFrameworkCore.Design)
-   [ ] [Northwind DB](https://github.com/microsoft/sql-server-samples/blob/master/samples/databases/northwind-pubs/instnwnd.sql)

## M010 | Benutzerverwaltung

-   [ ] AspNetCore.Identity.EFCore
-   [ ] CodeFirst & Migration
-   [ ] UserManager & SignInManager
-   [ ] Form Post & Validierung
-   [ ] MS Identity Platform gegen EntraId und GraphAPI

## M011 | Weitere Themen

-   [ ] Paging
-   [ ] Lokalisierung
-   [ ] WebAPI
-   [ ] Cookie Handling
-   [ ] Server Caching
-   [ ] Deployment 
