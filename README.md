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
[Home Page](https://github.com/user-attachments/assets/68d8b571-3a8e-4a5e-893a-4586479541eb)


### **User Management**
[User Page](https://github.com/user-attachments/assets/53b237cf-7d34-4d6f-bac8-9a5b62e1bffd)


### **Log Management**
[Log Page](https://github.com/user-attachments/assets/ca8b6dcf-730e-40c0-8659-b7b8d2eebeef)


### **Menu**
[Menu](https://github.com/user-attachments/assets/3e1115a5-315c-4672-b017-bebccc037289)


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
git clone https://github.com/pslavchev11/MauiMvvmApp.git
cd MauiMvvmApp
