# Upgrade Status

Due to environment limitations (no .NET SDK available in container) and the scope of the legacy ASP.NET MVC 5 codebase, the full migration to ASP.NET Core MVC on .NET 8 could not be completed in this session.

The repository still targets the original .NET Framework projects. Before attempting the migration again, ensure the following prerequisites are met:

1. Install the latest .NET SDK (preferably .NET 8 LTS) inside the working container.
2. Replace the legacy `.csproj` files with SDK-style projects and move package references into `<ItemGroup>` sections using `PackageReference`.
3. Create a new ASP.NET Core entry point using the minimal hosting model (`Program.cs`) and move configuration to `appsettings.json`.
4. Re-implement authentication/authorization using ASP.NET Core Identity or cookie authentication.
5. Port Razor views to ASP.NET Core conventions, replacing bundling/minification with modern tooling.
6. Migrate Entity Framework 6 usage to EF Core (or enable compatibility) and register DbContexts with dependency injection.
7. Add automated tests targeting the new project layout and enable code coverage with the `coverlet.collector`.

Once these steps are achievable in the environment, re-run the migration following the original instructions.
