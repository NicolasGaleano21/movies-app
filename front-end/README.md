# Movie Search Web Application

## Description

This project is a web application that allows users to search for movies using different filters. The interface is designed to be intuitive, ensuring that users can perform searches by simply pressing the `Enter` key or clicking the search icon.

### Key Features:
- **Search Functionality:** Users can search for movies based on three filters: Title, Actors, and Genre.
- **Reset Mechanism:** The search filter resets only when the clear icon is pressed and the input field is completely emptied, ensuring a clear understanding of filter behavior.
- **Filter Options:** A button next to the search field opens a menu with available filtering options.
- **Movie Cards:** Display key details such as title, genres, and actors.
  - If actor names exceed the space available, a tooltip appears when hovering over the text to display full information.
  - The cards are responsive, adjusting to screen size with layouts supporting 3, 2, or 1 column(s) depending on the device width.
- **Pagination System:**
  - Users can choose to display 5, 10, or 15 rows per page.
  - Pagination controls trigger new API requests to fetch only the required number of records, optimizing performance and reducing unnecessary data load.

---

## Implementation Details

### Frontend:
The frontend is developed using **TypeScript** and **React** as the primary library. The key technologies used include:

- **Material UI:** Used for UI components to ensure a modern and standardized design.
- **Redux:** Manages global state effectively.
- **Axios:** Handles HTTP requests within a separate class to standardize API calls across services.
- **React Router:** Implements simple routing within the application.

### Backend:
The backend is built with **.NET Core**, following the **Clean Architecture** principles. It employs:

- **Entity Framework:** ORM for database interaction.
- **LINQ:** Querying the database in an efficient manner.
- **MediatR:** Implements the **CQRS (Command Query Responsibility Segregation) pattern** for handling application logic.
- **Dependency Injection:** Enhances modularity and testability.
- **Unit of Work & Repository Pattern:** Centralizes repository management. In the future, SQL transaction  handling can be added.
- **Middleware for Exception Handling:** Standardizes error responses for the frontend in case of failures.
- **AutoMapper:** Maps database entities to DTOs for data transformation.
- **Database Context & Migrations:** Used to define and manage database schema and seed initial data.

---

## Installation & Setup

### Prerequisites:
- **Node.js v18 or higher** (for frontend)
- **.NET 8** (for backend)
- **SQL Server** (for database management)

### Steps to Run the Application

#### Backend Setup:
1. Install dependencies:
   ```sh
   dotnet restore
   ```
2. Configure the database connection:
   - Add an `appsettings.json` file in the backend directory.
   - Ensure it includes a connection string under `DefaultConnection`.
   Example:
     ```json
     {
       "ConnectionStrings": {
         "DefaultConnection": "Server=YOUR_SERVER;Database=MovieDB;User Id=YOUR_USER;Password=YOUR_PASSWORD;"
       }
     }
     ```
3. Apply database migrations:
   ```sh
   dotnet ef database update --project Infrastructure --startup-project ClearMechanicMovies.Api
   ```
4. Run the backend server:
   ```sh
   dotnet run
   ```

#### Frontend Setup:
1. Install dependencies:
   ```sh
   npm install
   ```
2. Configure API URL:
- Create or update the `.env.development` file in the frontend directory.
- Set VITE_API_URL to match the backend API URL, ensuring it ends with /api/.
Example:
  ```sh
  VITE_API_URL=https://localhost:44361/api/
  ```
1. Start the frontend application:
   ```sh
   npm run dev
   ```

The application should now be running and accessible. It is important that the frontend is accessible at http://localhost:5173/ to avoid conflicts with the CORS policy.



