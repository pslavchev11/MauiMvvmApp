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
[Home Page](https://scontent.xx.fbcdn.net/v/t1.15752-9/462566722_1346077263069294_6566579742989349258_n.png?stp=dst-png_s720x720&_nc_cat=108&ccb=1-7&_nc_sid=0024fc&_nc_ohc=Sb_R50FLBHoQ7kNvgEPhBIv&_nc_ad=z-m&_nc_cid=0&_nc_zt=23&_nc_ht=scontent.xx&oh=03_Q7cD1QHBDV_LQf2mimSaqGjO-DpSpoXlQ8ifpMQvhm6TJr1H5Q&oe=677A9886)

### **User Management**
[User Management](https://scontent.xx.fbcdn.net/v/t1.15752-9/462583338_900185808530989_7029370913156324664_n.png?stp=dst-png_s720x720&_nc_cat=102&ccb=1-7&_nc_sid=0024fc&_nc_ohc=fSIp8TH_V6cQ7kNvgHNbiw_&_nc_ad=z-m&_nc_cid=0&_nc_zt=23&_nc_ht=scontent.xx&oh=03_Q7cD1QG2gNPVZ7TaQUkXBd3SBdEEMBHV03VQ42qu75T5eLj1aQ&oe=677A951E)

### **Log Management**
[Log Management](https://scontent.xx.fbcdn.net/v/t1.15752-9/462583292_1641009100127260_8161928227288608666_n.png?stp=dst-png_s720x720&_nc_cat=104&ccb=1-7&_nc_sid=0024fc&_nc_ohc=xF1DQB_modoQ7kNvgGMp_xv&_nc_ad=z-m&_nc_cid=0&_nc_zt=23&_nc_ht=scontent.xx&oh=03_Q7cD1QFo_P9BqSNUiPqPjfzGiTOslsC53A7HC_-t9Flwxz_mDA&oe=677A9006)

### **Menu**
[Menu](https://scontent.xx.fbcdn.net/v/t1.15752-9/462545426_905879124609664_8857746956580358279_n.png?_nc_cat=101&ccb=1-7&_nc_sid=0024fc&_nc_ohc=avRr50JhedIQ7kNvgFgjPAA&_nc_ad=z-m&_nc_cid=0&_nc_zt=23&_nc_ht=scontent.xx&oh=03_Q7cD1QEpF4dOF_KYZTLd0m2QyhhUqNeAs23HoFNhxBRePKOmfg&oe=677A9866)

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
