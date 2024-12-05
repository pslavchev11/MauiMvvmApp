# MAUI MVVM App for User and Log Management

The **MAUI MVVM App** is a cross-platform application built using **.NET MAUI**. It provides a structured interface for managing users and logs, demonstrating clean architectural principles like **MVVM (Model-View-ViewModel)** and using modern UI practices.

---

## Features

### **User Management**
- **Filter Users by Role**: Display users filtered by their roles using a picker.
- **Password Masking**: Protect user passwords by displaying masked characters (`******`).
- **Expiry Date Visualization**: Highlight user expiration dates with colors:
  - **Red**: Expiration in 45 days or less.
  - **Yellow**: Expiration in 46 to 90 days.
  - **Green**: Expiration in more than 90 days.

### **Log Management**
- **View Logs**: Display a list of logs with timestamps, message types, and descriptions.
- **Filter Logs by Message Type**: Show logs based on their category using a picker.
- **Sort Logs**: Sort logs by date in descending order for better accessibility.
- **Log Details**: Tap a log to display its detailed information in an alert.

### **Navigation**
- Navigate seamlessly between:
  - **Home Page**
  - **Users Page**
  - **Logs Page**

### **Modern UI Components**
- Designed with **XAML** for a clean and responsive interface.
- Built-in converters (`DateToColorConverter`, `PasswordMaskConverter`) for enhancing UI functionality.

---

## Screenshots

### **Home Page**
![Home Page](./screenshots/home_page.png)

### **User Management**
![User Management](./screenshots/user_management.png)

### **Log Management**
![Log Management](./screenshots/log_management.png)

---

## Requirements

To build and run the project, you need the following:

- **.NET 7 SDK** (or later)
- **Visual Studio 2022** with **MAUI workload** installed
- A supported platform:
  - **Windows** (WinUI)
  - **macOS** (Mac Catalyst)
  - **Android**
  - **iOS**

---

## Installation

### Clone the Repository
```bash
git clone https://github.com/your-username/maui-mvvm-app.git
cd maui-mvvm-app
