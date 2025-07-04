# Hotel Management System

A comprehensive Windows Forms application built with C# and .NET 6 for managing hotel operations, reservations, guests, and services.

## 🏨 Overview

This Hotel Management System provides a complete solution for hotel operations management, featuring a user-friendly Windows Forms interface with robust database integration. The system handles all aspects of hotel management from guest registration to payment processing and feedback collection.

## ✨ Features

### Core Management Modules
- **Guest Management**: Register, update, and manage guest information including contact details
- **Hotel Management**: Add and manage multiple hotels with location and room capacity
- **Room Management**: Organize rooms by categories, manage availability and pricing
- **Reservation System**: Create, update, and track reservations with multiple room support
- **Payment Processing**: Handle payments with multiple payment methods and automatic status updates
- **Service Management**: Manage additional hotel services and track service usage
- **Feedback System**: Collect and manage guest feedback for service improvement

### Advanced Features
- **Multi-Contact Support**: Store multiple phone numbers and email addresses per guest
- **Room Categories**: Organize rooms by type with different pricing structures
- **Reservation Status Tracking**: Monitor reservation states (Pending, Confirmed, etc.)
- **Bulk Price Management**: Raise all prices by percentage with a single operation
- **Data Validation**: Comprehensive input validation and error handling
- **Transaction Safety**: Database operations with transaction support for data integrity

## 🛠️ Technology Stack

- **Framework**: .NET 6.0 Windows Forms
- **Language**: C# 10
- **Database**: SQL Server with integrated security
- **Data Access**: ADO.NET with SqlClient
- **Architecture**: Layered architecture with separation of concerns

## 📋 Prerequisites

- Windows 10/11
- .NET 6.0 Runtime or SDK
- SQL Server (LocalDB, Express, or Full)
- Visual Studio 2022 (for development)

## 🚀 Installation & Setup

### 1. Clone the Repository
```bash
git clone https://github.com/anasbayoumy/db.git
cd db
```

### 2. Database Setup
1. Ensure SQL Server is running on your machine
2. Create a database named `HotelManagementSystem`
3. Set up the required tables and stored procedures for the hotel management system
4. Update the connection string in `DatabaseConnection.cs` if needed:
   ```csharp
   "Data Source=.;Initial Catalog=HotelManagementSystem;Integrated Security=True;"
   ```

### 3. Build and Run
```bash
# Using .NET CLI
dotnet run --project HotelManagement/HotelManagement.csproj

# Or using the provided run script
# See run.txt for the exact command
```

## 📁 Project Structure

```
HotelManagement/
├── Data/
│   └── DatabaseConnection.cs      # Database connection management
├── Forms/                         # Windows Forms UI
│   ├── MainForm.cs               # Main application window
│   ├── Guest Management/         # Guest-related forms
│   │   ├── AddGuestForm.cs       # Add new guests
│   │   ├── UpdateGuestForm.cs    # Update guest information
│   │   ├── GuestForm.cs          # View all guests
│   │   ├── AddEmailForm.cs       # Manage guest emails
│   │   └── AddPhoneForm.cs       # Manage guest phones
│   ├── Hotel Management/         # Hotel-related forms
│   │   ├── NewHotelForm.cs       # Add new hotels
│   │   ├── UpdateHotelForm.cs    # Update hotel information
│   │   ├── ViewHotelsForm.cs     # View all hotels
│   │   └── ViewHotelEmailsForm.cs # Manage hotel emails
│   ├── Room Management/          # Room-related forms
│   │   ├── AddRoomForm.cs        # Add new rooms
│   │   ├── UpdateRoomForm.cs     # Update room information
│   │   ├── RoomForm.cs           # View all rooms
│   │   ├── AddNewCategory.cs     # Add room categories
│   │   ├── UpdateCategoryForm.cs # Update categories
│   │   └── ViewRoomCategories.cs # View all categories
│   ├── Reservation Management/   # Reservation-related forms
│   │   ├── AddReservationForm.cs # Create new reservations
│   │   ├── UpdateReservationForm.cs # Update reservations
│   │   ├── ReservationForm.cs    # View all reservations
│   │   ├── ReservationPaymentsForm.cs # Manage payments
│   │   └── ReservationServicesForm.cs # Manage services
│   ├── Payment Management/       # Payment-related forms
│   │   ├── AddPaymentForm.cs     # Add new payments
│   │   ├── AddResPaymentForm.cs  # Add reservation payments
│   │   ├── UpdatePaymentForm.cs  # Update payment information
│   │   └── ViewAllPaymentsForm.cs # View all payments
│   ├── Service Management/       # Service-related forms
│   │   ├── AddNewService.cs      # Add new services
│   │   ├── AddServiceForm.cs     # Assign services
│   │   ├── UpdateServiceForm.cs  # Update service information
│   │   ├── UpdateServiceDataForm.cs # Update service data
│   │   └── ViewAllservicesForm.cs # View all services
│   └── Feedback Management/      # Feedback-related forms
│       ├── AddFeedback.cs        # Add customer feedback
│       ├── UpdateFeedback.cs     # Update feedback
│       └── ViewFeedbackForm.cs   # View all feedback
├── Program.cs                    # Application entry point
└── HotelManagement.csproj        # Project configuration
```

## 🎯 Usage

### Main Dashboard
The application starts with a main dashboard providing access to all management modules:
- View and manage guests
- View and manage rooms
- Handle reservations
- Manage room categories
- Oversee hotel operations
- Track services and payments
- Review customer feedback
- Bulk price adjustments

### Guest Management
- Add new guests with personal information (name, nationality, gender, DOB, passport)
- Store multiple contact methods (phones, emails)
- Update guest details
- View guest history and reservations

### Hotel & Room Management
- Add and manage multiple hotels with location and capacity information
- Create and categorize rooms by type
- Set room pricing and availability
- Update hotel and room information

### Reservation Workflow
1. Select guest from existing records or add new guest
2. Choose hotel and available rooms
3. Set check-in and check-out dates
4. Confirm reservation (status: Pending)
5. Process payment to confirm reservation
6. Track reservation status throughout stay

### Payment Processing
- Multiple payment methods supported
- Automatic reservation status updates upon payment
- Payment history tracking
- Update and modify payment records

### Service Management
- Add additional hotel services
- Assign services to reservations
- Track service usage and billing
- Update service information and pricing

### Feedback System
- Collect customer feedback and ratings
- Update and manage feedback records
- View feedback analytics for service improvement

## 🗄️ Database Schema

The system uses a relational database with the following key entities:
- **Guest**: Guest information and demographics
- **Guest_Phone_nums**: Multiple phone numbers per guest
- **Guest_Emails**: Multiple email addresses per guest (with cascade delete)
- **Hotel**: Hotel information and capacity
- **Room**: Room details and categories
- **Reservation**: Booking information and status
- **Reservation_Rooms**: Many-to-many relationship for multi-room bookings
- **Payment**: Payment records and methods
- **Service**: Additional hotel services
- **Feedback**: Guest feedback and ratings

### Key Database Features
- **Stored Procedures**: `Raise_All_Prices_By_10_Percent`, `DeleteGuestAndPhones`, `GetAllReservationDetails()`
- **Foreign Key Constraints**: Maintain data integrity across related tables
- **Cascade Deletes**: Automatic cleanup of related records (e.g., guest emails and phones)
- **Transaction Support**: Ensure data consistency during complex operations

## 🔧 Configuration

### Database Connection
Update the connection string in `HotelManagement/Data/DatabaseConnection.cs`:
```csharp
private static string connectionString = "Data Source=YOUR_SERVER;Initial Catalog=HotelManagementSystem;Integrated Security=True;";
```

### Application Settings
- The application uses Windows Forms with .NET 6
- Nullable reference types are enabled
- Implicit usings are enabled for cleaner code
- Supports both SQL Server and MySQL (packages included)

## 🎮 Key Features in Detail

### Multi-Entity Management
- **Hotels**: Multiple hotels with location and room capacity tracking
- **Rooms**: Categorized rooms with pricing and availability management
- **Guests**: Comprehensive guest profiles with multiple contact methods
- **Reservations**: Complex reservation system supporting multiple rooms per booking

### Advanced Functionality
- **Bulk Operations**: Raise all prices by 10% with a single click
- **Data Relationships**: Proper foreign key relationships with cascade operations
- **Status Tracking**: Reservation status management (Pending → Confirmed)
- **Contact Management**: Multiple emails and phone numbers per guest
- **Service Integration**: Additional services can be added to reservations

- Database connection requires SQL Server with integrated security
- Application is Windows-specific due to Windows Forms dependency
- Some forms may require additional validation enhancements

---

**Note**: This application is designed for educational and demonstration purposes. For production use, additional security measures, input validation, and testing should be implemented.
