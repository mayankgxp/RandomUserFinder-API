RandomUserFinder-API
Welcome to RandomUserFinder-API! This project provides a .NET Core 8 API for fetching random user data from a third-party API. It includes basic username-password authentication for secure access and offers endpoints to retrieve random user information. Additionally, it's designed to be consumed by another UI project as well as can be consumed by swagger also.

Authentication
RandomUserFinder-API implements basic username-password authentication to ensure secure access to its endpoints. Users are required to provide valid credentials to access the API.

Endpoints
1. /api/user
Method: GET
Description: Retrieves a random user from the third-party API i.e. https://randomuser.me/api/.
Parameters: None
Returns: JSON object containing random user information including name, email, phone, etc.

Consumers
RandomUserFinder-API is intended to be consumed by another UI project, enabling seamless integration of random user data into various applications.

Setup
To set up RandomUserFinder-API locally, follow these steps:

Clone the repository:
git clone https://github.com/your_username/RandomUserFinder-API.git

Navigate to the project directory:
cd RandomUserFinder-API

Restore dependencies:
dotnet restore

Run the application:
dotnet run
Access the API endpoints using the base URL http://localhost:5000.

Dependencies
RandomUserFinder-API relies on the following dependencies:

.NET Core 8
Third-party API for random user data (provide details or link to the API used)
Contributing
Contributions are welcome! If you find any issues or have suggestions for improvements, please feel free to open an issue or submit a pull request.

Note: Replace your_username in the repository URL with your actual GitHub username.
currently, is it configured in appsettings.json as username: admin and password: password
