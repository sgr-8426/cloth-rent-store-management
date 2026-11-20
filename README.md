# Cloth Renting Store Management System

A Windows native desktop application built with .NET 9 LTS, WPF (WPF-UI Windows 11 Fluent Design), and SQLite with Entity Framework Core 9.

## Solution Architecture

The solution follows Clean Architecture principles:

- **`ClothRentingStore.Core`**: Domain layer containing entity definitions (`BaseEntity`), enums (`GarmentStatus`), DTOs, repository interfaces (`IRepository<T>`, `IUnitOfWork`), and service contracts (`IBarcodeService`, `IPdfReportService`).
- **`ClothRentingStore.Data`**: Persistence layer containing EF Core SQLite database context (`ClothRentingDbContext`), entity type configurations, migrations, and generic repository implementations.
- **`ClothRentingStore.Services`**: Application and domain services implementing business workflows, PDF generation (QuestPDF), and barcode/QR code generation (ZXing.Net).
- **`ClothRentingStore.UI`**: Presentation layer featuring modern Windows 11 Fluent Design via WPF-UI, MVVM architecture (`CommunityToolkit.Mvvm`), Microsoft Extensions Hosting/Dependency Injection, and Serilog file logging.

## Tech Stack
- **Target Framework:** .NET 9 (`net9.0`, `net9.0-windows`)
- **UI Framework:** WPF with [WPF-UI](https://wpfui.lepo.co/)
- **MVVM:** `CommunityToolkit.Mvvm`
- **ORM / Database:** EF Core 9 SQLite
- **Barcode & QR:** ZXing.Net
- **PDF Generation:** QuestPDF
- **Logging:** Serilog
