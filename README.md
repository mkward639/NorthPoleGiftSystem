# North Pole Gift System

The North Pole Gift System is an API MVC-based application designed to manage and organize the operations of Santa's Workshop. This system facilitates the coordination of elves, workshops, gifts, and wishlists to ensure a smooth and efficient gift production process.

## Features

- **Elf Management:** Keep track of the hardworking elves in Santa's workshop, including their roles and assigned workshops.

- **Workshop Management:** Manage the workshops located at the North Pole, overseeing their capacity, location, and the supervisor in charge.

- **Gift Management:** Track the production status, descriptions, and other details of the gifts that will be distributed during the holiday season.

- **Wishlist Management:** Keep track of the wishlists created by the elves, including the associated gifts and the last update timestamp.

## Technologies Used

- **Programming Language:** C#

- **Framework:** ASP.NET Core MVC

- **Database:** Entity Framework Core with Microsoft SQL Server

## Project Structure

The project is organized into different components:

- **Models:** Defines the data models for elves, workshops, gifts, and wishlists.

- **Data Access Layer:** Utilizes Entity Framework Core for database access. Includes the DbContext and entity classes.

- **Services:** Implements service classes to perform CRUD (Create, Read, Update, Delete) operations on elves, workshops, gifts, and wishlists.

- **Controllers:** Handles HTTP requests, interacts with services, and returns appropriate responses. Includes controllers for elves, workshops, gifts, and wishlists.

- **Views:** Represents the user interface for creating, updating, and viewing data.

## Getting Started

To run the North Pole Gift System locally, follow these steps:

1. Clone the repository:

   ```
   git clone https://github.com/your-username/north-pole-gift-system.git
   ```

2. Set up the database:
   - Ensure you have a compatible version of Microsoft SQL Server installed.
   - Update the connection string in the `appsettings.json` file with your database details.
   - Run Entity Framework migrations to create the database:

     ```
     dotnet ef database update
     ```

3. Build and run the application:

   ```
   dotnet run
   ```


## Usage

- Visit the provided endpoints for elves, workshops, gifts, and wishlists to interact with the system.
- Use the API to perform CRUD operations on the different entities.

## Contributing

Contributions to the North Pole Gift System are welcome! Whether you find a bug, have a feature request, or want to contribute code, feel free to open an issue or submit a pull request.

## License

This project is licensed under the [MIT License](LICENSE).

---

Merry Christmas! 🎅🎁
