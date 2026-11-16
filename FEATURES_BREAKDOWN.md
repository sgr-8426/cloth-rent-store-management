# Cloth Renting Store Management System
## Granular Feature Breakdown & Development Roadmap

> **Target Platform:** Windows Native Desktop App  
> **Tech Stack:** C# / .NET 9 LTS + WPF (WPF-UI / Windows 11 Fluent Design) + SQLite (EF Core 9) + QuestPDF + ZXing.Net  
> **Architecture:** Clean MVVM (`CommunityToolkit.Mvvm`), Repository/Service Layer, Local File-based SQLite Storage  

---

## Progress Overview
- [ ] **Phase 0: Foundation & Core Infrastructure** (0/6 Complete)
- [ ] **Phase 1: Garment & Inventory Management** (0/8 Complete)
- [ ] **Phase 2: Customer & Sizing Management** (0/6 Complete)
- [ ] **Phase 3: Booking, Reservation & Availability Calendar** (0/7 Complete)
- [ ] **Phase 4: Order Dispatch & Pickup (Check-Out)** (0/6 Complete)
- [ ] **Phase 5: Return Inspection, Penalty & Deposit Settlement (Check-In)** (0/7 Complete)
- [ ] **Phase 6: Laundry & Dry Cleaning Lifecycle** (0/5 Complete)
- [ ] **Phase 7: Tailoring & Alteration Management** (0/5 Complete)
- [ ] **Phase 8: Billing, Invoices & Thermal Printing** (0/6 Complete)
- [ ] **Phase 9: Business Reports & Analytics** (0/6 Complete)
- [ ] **Phase 10: Store Settings, Access Control & Database Backup** (0/5 Complete)

---

## Phase 0: Foundation & Core Infrastructure

### 0.1 Solution & Project Scaffolding
- [ ] **Task 0.1.1:** Scaffold .NET 9 Solution with Clean Architecture:
  - `ClothRentingStore.Core` (Models, Enums, DTOs, Business Interfaces)
  - `ClothRentingStore.Data` (DbContext, Configurations, Migrations, Repositories)
  - `ClothRentingStore.Services` (Domain logic, Printing, Barcodes, PDF generation)
  - `ClothRentingStore.UI` (WPF Application with WPF-UI)
- [ ] **Task 0.1.2:** Configure Dependency Injection (`Microsoft.Extensions.DependencyInjection`) in `App.xaml.cs`.
- [ ] **Task 0.1.3:** Setup global exception handling and file logging (`Serilog`).

### 0.2 Database & Local Persistence
- [ ] **Task 0.2.1:** Setup SQLite DbContext with EF Core 9, WAL mode (Write-Ahead Logging) for fast read/write.
- [ ] **Task 0.2.2:** Configure auto-migration on application startup so database updates run smoothly without manual scripts.
- [ ] **Task 0.2.3:** Implement Seed Data for essential lookups (Default categories, sizes, garment status codes, payment methods).

---

## Phase 1: Garment & Inventory Management

### 1.1 Category & Hierarchy Management
- [ ] **Task 1.1.1:** CRUD for Master Categories (e.g., Men, Women, Kids) and Subcategories (e.g., Suits, Tuxedos, Sherwanis, Lehengas, Gowns, Sarees, Accessories).
- [ ] **Task 1.1.2:** Category-specific default pricing and deposit percentages.

### 1.2 Garment Item Master
- [ ] **Task 1.2.1:** Garment Data Model:
  - SKU / Item Code (Auto-generated or Manual)
  - Title, Description, Designer/Brand, Fabric, Color
  - Standard Size (XS, S, M, L, XL, XXL, Custom)
  - Alterable Range (Chest Min/Max, Waist Min/Max in inches)
  - Purchase Cost, Rental Fee (per day/event), Security Deposit Amount
  - Garment Condition rating (Brand New, Excellent, Good, Fair)
  - Storage Location / Rack / Bin Number
- [ ] **Task 1.2.2:** Multi-image upload with local compression and thumbnail generation stored in `AppData/Images`.
- [ ] **Task 1.2.3:** Barcode/QR Code generator using `ZXing.Net` for each SKU.
- [ ] **Task 1.2.4:** Printable Garment Hanger Tag (PDF layout with Item Name, Size, SKU, Barcode, and Rental Price).

### 1.3 Inventory Lifecycle & Status Engine
- [ ] **Task 1.3.1:** State Machine implementation for Garment status transitions:
  - `Available` (In showroom ready to rent)
  - `Reserved` (Booked for upcoming event)
  - `OutOnRent` (With customer)
  - `Returned` (Waiting for quality check)
  - `InLaundry` (With dry cleaner)
  - `InAlteration` (With tailor)
  - `Damaged` (Under major repair)
  - `Retired` (Sold or scrapped)
- [ ] **Task 1.3.2:** Quick Barcode Scanner Reader: Global key listener or focused input for USB barcode guns to instantly open the garment's profile.
- [ ] **Task 1.3.3:** Inventory Search, Filter, and Grid view (Filter by Status, Category, Size, Color, Available Dates).

---

## Phase 2: Customer & Sizing Management

### 2.1 Customer Profile & Contact Directory
- [ ] **Task 2.1.1:** Customer Master CRUD:
  - Full Name, Primary Phone (Indexed for instant search), WhatsApp Number, Email
  - Residential Address & City
  - Customer Photo / Webcam capture (optional)
  - Trust Rating & Warning Flag (e.g., Good Payer, Habitual Late Returner, Damaged Items Previously).
- [ ] **Task 2.1.2:** Government ID Capture:
  - ID Type (Driving License, National ID, Passport)
  - ID Number & Attachment storage (PDF/Image).
- [ ] **Task 2.1.3:** Fast Lookup Dialog by phone number or name for checkout POS.

### 2.2 Customer Body Measurements (Tailoring Specs)
- [ ] **Task 2.2.1:** Men’s Measurement Fields:
  - Chest, Waist, Hips, Shoulder, Sleeve Length, Inseam, Outseam, Neck.
- [ ] **Task 2.2.2:** Women’s Measurement Fields:
  - Bust, Underbust, Waist, Hips, Blouse Length, Skirt/Lehenga Length, Armhole, Sleeve Length.
- [ ] **Task 2.2.3:** Measurement Versioning: Save measurement profiles with date stamps so seasonal customer alterations are tracked.

---

## Phase 3: Booking, Reservation & Availability Calendar

### 3.1 Availability & Double-Booking Prevention Engine
- [ ] **Task 3.1.1:** Date conflict calculation algorithm:
  - Considers: `Booking Start Date`, `Event Date`, `Return Date`, plus configurable `Laundry Buffer Days` (e.g., 2 days) and `Alteration Buffer Days`.
- [ ] **Task 3.1.2:** Garment Availability Validator: Given a Garment ID and target date range, returns `Available` or exact conflicting order details.

### 3.2 Booking Creation Workflow
- [ ] **Task 3.2.1:** Create Reservation Order:
  - Select Customer
  - Add multiple garments/accessories
  - Specify Event Date, Pickup Date/Time, Expected Return Date/Time
- [ ] **Task 3.2.2:** Advance / Token Payment:
  - Collect advance booking token amount
  - Compute remaining balance due upon pickup.
- [ ] **Task 3.2.3:** Cancellation & Advance Refund Logic (Full refund, Partial refund, or Forfeited token).

### 3.3 Visual Scheduling Calendar
- [ ] **Task 3.3.1:** Calendar View (Monthly / Weekly view) showing bookings.
- [ ] **Task 3.3.2:** Timeline / Gantt style view per garment (visual blocks of Reserved, Out, Laundry).
- [ ] **Task 3.3.3:** Today’s Action Dashboard:
  - Garments scheduled for pickup today
  - Garments due for return today
  - Overdue garments not returned.

---

## Phase 4: Order Dispatch & Pickup (Check-Out)

### 4.1 Dispatch Verification
- [ ] **Task 4.1.1:** Pickup Order Screen: Load reservation by Order Number, Customer Phone, or scanning garment barcode.
- [ ] **Task 4.1.2:** Barcode Verification: Force-scan each garment to verify the correct item and accessories (e.g., matching dupatta, bow-tie) are being handed over.
- [ ] **Task 4.1.3:** Trial Confirmation: Checkbox confirming customer tried the garment and alterations fit properly.

### 4.2 Security Deposit Collection
- [ ] **Task 4.2.1:** Deposit Calculation: Calculate total required refundable security deposit.
- [ ] **Task 4.2.2:** Payment Mode selection for deposit: Cash, UPI, Card, or Physical ID held as deposit.
- [ ] **Task 4.2.3:** Collect remaining rental fee balance.

### 4.3 Rental Contract & Agreement Generation
- [ ] **Task 4.3.1:** Auto-generate printable Rental Agreement (PDF via QuestPDF) containing:
  - List of items & accessories
  - Deposit amount collected
  - Strict return due date & time
  - Late fee rate per day
  - Customer signature line and Terms & Conditions.
- [ ] **Task 4.3.2:** Status Transition: Move Garment to `OutOnRent`, Order to `Dispatched`.

---

## Phase 5: Return Inspection, Penalty & Deposit Settlement (Check-In)

### 5.1 Garment Return & Quality Inspection
- [ ] **Task 5.1.1:** Return Intake: Scan returned garment barcode to instantly open active rental order.
- [ ] **Task 5.1.2:** Quality Inspection Checklist:
  - Condition status: Normal Wear (OK), Minor Stain, Major Stain, Torn/Damaged, Missing Accessories, Lost.
  - Photo attachment for damages recorded.

### 5.2 Late Fee & Penalty Assessment
- [ ] **Task 5.2.1:** Late Fee Calculator: Auto-compute overdue days based on expected return timestamp vs current timestamp multiplied by daily late fee rate.
- [ ] **Task 5.2.2:** Damage Deduction input: Charge repair/cleaning fee against the deposit.
- [ ] **Task 5.2.3:** Missing Item Deduction: Forfeit replacement cost if an accessory or dress is lost.

### 5.3 Security Deposit Settlement
- [ ] **Task 5.3.1:** Financial Settlement Summary:
  - `Deposit Held` - `Late Fees` - `Damage Charges` = `Net Refund to Customer` (or `Balance Due from Customer` if damages exceed deposit).
- [ ] **Task 5.3.2:** Record Deposit Refund payout method (Cash returned, UPI refund).
- [ ] **Task 5.3.3:** Print Deposit Settlement Receipt / Voucher.
- [ ] **Task 5.3.4:** Routing action after return:
  - Route directly to `Laundry` batch
  - Route to `Alteration` for repair
  - Route back to `Available` if no cleaning is needed.

---

## Phase 6: Laundry & Dry Cleaning Lifecycle

### 6.1 Laundry Batch Dispatch
- [ ] **Task 6.1.1:** Laundry Vendor Master CRUD (Vendor name, contact, cost per garment type).
- [ ] **Task 6.1.2:** Create Laundry Outward Challan: Select multiple returned garments, assign to vendor, set expected return date.
- [ ] **Task 6.1.3:** Print Laundry Outward Challan (list of clothes, fabric instructions, stain notes).
- [ ] **Task 6.1.4:** Update Garment status to `InLaundry`.

### 6.2 Laundry Return & Quality Check
- [ ] **Task 6.2.1:** Inward Challan Intake: Scan or check off garments returning from dry cleaner.
- [ ] **Task 6.2.2:** Inspection & Expense recording: Record cleaning cost per item, verify stains are removed.
- [ ] **Task 6.2.3:** Transition clean garments back to `Available`.

---

## Phase 7: Tailoring & Alteration Management

### 7.1 Alteration Job Orders
- [ ] **Task 7.1.1:** Create Alteration Ticket linked to an upcoming Rental Order and Customer measurements.
- [ ] **Task 7.1.2:** Tailor Master CRUD (In-house tailors or external alteration partners).
- [ ] **Task 7.1.3:** Specific Instructions input (e.g., "Shorten length by 1.5 inches, loosen chest by 1 inch").
- [ ] **Task 7.1.4:** Printable Alteration Job Slip for tailor to pin onto garment hanger.

### 7.2 Trial & Approval Workflow
- [ ] **Task 7.2.1:** Status updates: `Pending Alteration` -> `Ready for Trial` -> `Trial Approved` / `Re-alteration Needed`.
- [ ] **Task 7.2.2:** Transition garment to `Ready for Pickup`.

---

## Phase 8: Billing, Invoices & Thermal Printing

### 8.1 POS Billing Engine
- [ ] **Task 8.1.1:** Itemized line items: Rental fee, Alteration fee, Delivery charges, Late fees, Damage recovery.
- [ ] **Task 8.1.2:** Discounts & Coupons: Flat discount or percentage discount with authorized override.
- [ ] **Task 8.1.3:** Tax / GST calculation (Configurable percentage, inclusive or exclusive).
- [ ] **Task 8.1.4:** Multi-mode Payment Tender: Split payments (e.g., $50 Cash + $100 Card/UPI).

### 8.2 Printing Subsystem
- [ ] **Task 8.2.1:** Standard A4/A5 Full Tax Invoice & Rental Contract (QuestPDF).
- [ ] **Task 8.2.2:** 80mm / 58mm ESC/POS Thermal Receipt for POS counters (Fast print, cuts paper).

---

## Phase 9: Business Reports & Analytics

### 9.1 Financial Reports
- [ ] **Task 9.1.1:** Daily Cash Book & POS Close-out (Total cash in drawer, UPI collections, card settlements, deposits refunded).
- [ ] **Task 9.1.2:** Revenue Summary (Rental revenue vs late fee/damage penalties by date range).

### 9.2 Inventory & Utilization Analytics
- [ ] **Task 9.2.1:** Top Performing Garments (Most rented, highest revenue generators).
- [ ] **Task 9.2.2:** Idle Stock / Dead Inventory (Items not rented for > 60/90 days).
- [ ] **Task 9.2.3:** ROI Tracker: Total rental earnings vs original garment purchase cost.

### 9.3 Operational Overdue & Risk Reports
- [ ] **Task 9.3.1:** Overdue Returns Alert List (Customers with unreturned items past due date).
- [ ] **Task 9.3.2:** Export any report to Excel (CSV) or PDF.

---

## Phase 10: Store Settings, Security & Database Backups

### 10.1 Store Profile & Business Rules Configuration
- [ ] **Task 10.1.1:** Store Details: Business Name, Address, Phone, Email, Tax/GSTIN number, Store Logo upload.
- [ ] **Task 10.1.2:** Rental Policy Defaults:
  - Standard rental period (e.g., 3 days / 72 hours)
  - Default laundry buffer days (e.g., 2 days)
  - Default security deposit percentage or fixed amount
  - Per-day late fee calculation rules.
  - Terms & Conditions text for rental contracts.

### 10.2 User Roles & Access Control
- [ ] **Task 10.2.1:** User accounts: Admin (Full access) vs Staff/Cashier (POS & Returns only, no financial report editing).
- [ ] **Task 10.2.2:** PIN / Password login screen.

### 10.3 1-Click SQLite Database Backup & Restore
- [ ] **Task 10.3.1:** 1-Click Manual Backup: Copies active SQLite `.db` file to a selected external folder/USB with timestamp.
- [ ] **Task 10.3.2:** Auto-backup on application shutdown to local backup directory.
- [ ] **Task 10.3.3:** Database Restore utility from backup file with integrity verification.
- [ ] **Task 10.3.4:** Theme Toggle: Fluent Light Mode / Dark Mode (Mica backdrop).

---

## Implementation Strategy: How We Will Develop (1 by 1)
1. **Sprint 1:** Phase 0 (Solution, Database setup, EF Core, Dependency Injection)
2. **Sprint 2:** Phase 1 (Garment Catalog, Categories, Barcode generation & tag printing)
3. **Sprint 3:** Phase 2 (Customer profile, ID storage, Body measurement charts)
4. **Sprint 4:** Phase 3 (Booking engine, double-booking prevention, availability calendar)
5. **Sprint 5:** Phase 4 (Order dispatch, security deposit collection, rental contract)
6. **Sprint 6:** Phase 5 (Return quality check, late fee & damage calculations, deposit refund)
7. **Sprint 7:** Phase 6 & 7 (Laundry & Alteration tracking workflows)
8. **Sprint 8:** Phase 8 & 9 (Thermal POS billing, QuestPDF receipts, business reports)
9. **Sprint 9:** Phase 10 (Settings, user roles, 1-click DB backup, final UI polish)
