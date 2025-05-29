# 🎨 ArtworkProjectAPI  
**Empowering creativity through seamless artwork management**

![dotnet](https://img.shields.io/badge/built%20with-C%23-512BD4?logo=csharp&logoColor=white&style=for-the-badge)  
![last-commit](https://img.shields.io/github/last-commit/MiskoValenta/ArtworkProjectApi?style=for-the-badge)  
![language](https://img.shields.io/badge/languages-1-blue?style=for-the-badge)  
![100% C#](https://img.shields.io/badge/C%23-100%25-blue?style=for-the-badge)

---

## • Table of Contents
- 🔍 [Overview](#Overview)
- 🚀 [Getting Started](#getting-started)
  - 📦 [Prerequisites](#prerequisites)
  - 🧰 [Installation](#installation)
  - ▶️ [Usage](#usage)
  - 🧪 [Testing](#testing)
- 🛠️ [Built With](#built-with)
- 🤝 [Contributing](#contributing)
- 📄 [License](#license)

---

## 🔍 Overview

**Why ArtworkProjectAPI?**  
A robust and modular web API designed to manage artwork-related content like orders, reviews, and creative submissions. Ideal for platforms looking to streamline their artistic operations.

### ✨ Key Features:
- **🔐 Secure Auth**  
  Ensures safe access using industry-standard JWT authentication.

- **📚 Comprehensive Data Management**  
  Leverages Entity Framework for powerful and efficient CRUD operations.

- **🧱 Modular Architecture**  
  Clean separation of concerns for maintainability and scalability.

- **🤝 User Interaction Enhancements**  
  Dedicated controllers for artworks, orders, and reviews to improve API clarity.

- **🔧 Development-Friendly Configuration**  
  Offers environment-based settings to support debugging and testing.

---

## 🚀 Getting Started

### 📦 Prerequisites
Before running the application, ensure you have the following installed:

| Requirement        | Version (Recommended) |
|--------------------|------------------------|
| C#                 | .NET 8                 |
| Package Manager    | NuGet                  |
| Git                | Latest                 |

---

### 🧰 Installation

Clone the repository and install the dependencies:

```bash
# Clone the repository
git clone https://github.com/MiskoValenta/ArtworkProjectApi.git

# Navigate into the project directory
cd ArtworkProjectApi

# Restore dependencies
dotnet restore
```
---

### ▶️ Usage
Run the application locally with:
```bash
dotnet run
```
The API will be accessible at: 
- **https://localhost:7131**
- **http://localhost:5263**  
  -> Use tools like Postman or Swagger (if integrated) to test the endpoints.

---

### 🧪 Testing
To run unit and integration tests:
```bash
dotnet test
```
This command executes all tests and provides output for success/failure cases.

---

### 🛠️ Built With

| **Technology**     | **Purpuse**                        |
|--------------------|------------------------------------|
| C#                 | Core programming language          |
| .NET               | Framework for building the API     |
| Entity Framework   | ORM for database interactions      |
| JWT                | Authentication and authorization   |
| NuGet              | Package management                 |
| Json               | Data format for API communication  |

---

### 🤝 Contributing
We welcome contributions that improve the project!
**Steps to Contribute:**  
  1. Fork the repository
     
  2. Create a new branch
 ```bash
     git checkout -b feature/your-feature-name
```
     
  3.  Commit your changes
```bash
    git checkout -b feature/your-feature-name
```
     
  4. Push to the branch
```bash
     git push origin feature/your-feature-name
```
     
  5. Open a pull request


- Please ensure all pull requests include appropriate tests and documentation updates.

---

"No Risk, No Story..." - Miško Valenta
