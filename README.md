# FinalProjectWeek9 - Library Management System

A comprehensive **Library Management System** built using **ASP.NET Core MVC**. This application facilitates the management of books, authors, and library users, providing a robust platform for library administration.

## Features
- **Book Management**: Create, update, view, and delete books.
- **Author Management**: Manage author information with full CRUD operations.
- **User Management**: User registration, login, and session handling.
- **Responsive UI**: Modern and responsive design utilizing **Bootstrap**.
- **Partial Views**: Efficient code reuse with partial views for common components like the navbar and footer.

## Project Structure

### Models
- **Book**: Stores book-related details such as title, author, genre, ISBN, publication date, and availability.
- **Author**: Captures author information including name and date of birth.
- **User**: Handles user details like full name, email, password, and contact information.

### ViewModels
- **BookViewModel**: Used to display book details and manage book-related views.
- **AuthorViewModel**: Handles author details in author-related views.
- **UserViewModel**: Manages data for user authentication (sign-up and login).

### Controllers
- **BookController**: Manages book actions such as:
  - `List`: Displays a list of books.
  - `Details`: Shows details of a selected book.
  - `Create`: Adds a new book.
  - `Edit`: Updates an existing book.
  - `Delete`: Deletes a book from the system.
  
- **AuthorController**: Handles author-related actions like:
  - `List`: Shows all authors.
  - `Details`: Displays details of a selected author.
  - `Create`: Adds a new author.
  - `Edit`: Edits author information.
  - `Delete`: Deletes an author.
  
- **AuthController**: Manages user authentication with actions:
  - `SignUp`: Registers a new user.
  - `Login`: Authenticates an existing user.

### Views
- **Book Views**: 
  - `List`, `Details`, `Create`, `Edit`, and `Delete` views for managing books.
- **Author Views**: 
  - `List`, `Details`, `Create`, `Edit`, and `Delete` views for managing authors.
- **User Views**: 
  - `SignUp` and `Login` views for user authentication.

### Shared Views
- **_Layout.cshtml**: The master layout for the application.
- **_Navbar.cshtml**: The navigation bar, implemented as a partial view.
- **_Footer.cshtml**: A footer with basic information, including copyright.

## Setup Instructions

### Prerequisites
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later
- A code editor (e.g., [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/))

### Installation

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/AhmetSulu/FinalProjectWeek9.git
2.  **Navigate to the Project Directory**:
    ```bash
    cd FinalProjectWeek9
    
3.  **Restore Dependencies**:
    ```bash
    dotnet restore
    
4.  **Run the Application**:
    ```bash
    dotnet run
    
5.  **Access the Application**: Open your web browser and go to `http://localhost:5000`.
    

## Technologies Used

-   **ASP.NET Core MVC**: For building the web application and managing routes, views, and controllers.
-   **Entity Framework Core**: (if applicable) For database interactions and ORM functionality.
-   **Bootstrap**: For responsive and modern UI design.
-   **C#**: The main programming language for business logic.

## Project Design Principles

-   **OOP (Object-Oriented Programming)**: Classes and models are designed following OOP principles, ensuring modularity and reusability.
-   **MVC Architecture**: Clean separation of concerns with Models, Views, and Controllers.
-   **DRY (Don't Repeat Yourself)**: Partial views and shared components promote code reuse and maintainability.

## Future Enhancements

-   **Search Functionality**: Implementing search features to find books and authors quickly.
-   **Pagination**: Adding pagination for large lists of books and authors.
-   **User Roles**: Introducing role-based access control for admin and regular users.

## Contributing

We welcome contributions! If you'd like to improve the system or report issues:

1.  Fork the repository.
2.  Create a new branch (`git checkout -b feature/YourFeature`).
3.  Commit your changes (`git commit -m 'Add some feature'`).
4.  Push to the branch (`git push origin feature/YourFeature`).
5.  Open a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact

For any questions or support, please email ahmet.sulu1993@gmail.com
