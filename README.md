# 🌶️ **Flavor Fiesta — .NET MAUI Mobile App**

A personalized recipe recommendation app built with .NET MAUI.

Click below to watch the demo:
[![Watch the video](https://img.youtube.com/vi/E7nPIt362HQ/0.jpg)](https://www.youtube.com/watch?v=E7nPIt362HQ)

---

## 📌 **Overview**

**Flavor Fiesta** is a cross-platform mobile application built using **.NET MAUI** that helps users discover recipes tailored to their personal dietary preferences, cuisine choices, calorie ranges, preparation time, and more.

The app provides:
- User registration & login
- Preference selection & saving
- Recipe matching using CSV data
- Local JSON persistence for accounts & preferences
- A clean and simple MAUI UI structure

---

## 🧠 **Core Features**

### 🔐 **1. User Accounts**

* Users can register with:

  * Name
  * Email
  * Password
  * Date of Birth
* Accounts are persisted locally using **JSON serialization** via `AccountManagerDataPersistence`.

### 🍽️ **2. Custom Recipe Matching**

Users select a set of preferences, including:

| Preference Category | Example           |
| ------------------- | ----------------- |
| Diet Type           | vegetarian, keto  |
| Cuisine Type        | italian, indian   |
| Meal Type           | breakfast, dinner |
| Calorie Range       | 200–400           |
| Prep Time           | 10–20 mins        |
| Cook Time           | 20–40 mins        |
| Servings            | 1–4               |
| Total Time          | 30–60 mins        |

These map directly to the recipe CSV file, allowing your app to match the **first recipe** that exactly aligns with the user's selections.

### 📦 **3. CSV Recipe Loading**

Recipes are stored in a CSV (`recipes.txt`) with 11 columns.
`RecipeManagerDataPersistance` reads the file, trims values, constructs `Preferences` and `Recipe` objects, and loads them into the application.

### 🔄 **4. Preference Normalization**

To ensure accurate matching:

* Strings are **trimmed**
* Converted to **lowercase**
* Compared for **exact equality**

This prevents spacing or case errors from causing mismatches.

---

## 🗂️ **Project Architecture**

```
FlavorFiesta/
│
├── BusinessLogic/
│   ├── User.cs
│   ├── Preferences.cs
│   ├── Recipe.cs
│   ├── AccountsManager.cs
│   └── RecipeManager.cs
│
├── DataPersistence/
│   ├── AccountManagerDataPersistence.cs
│   ├── PrefManagerDataPersistence.cs
│   └── RecipeManagerDataPersistance.cs
│
├── App.xaml / App.xaml.cs
├── MauiProgram.cs
└── Views / Views.xaml.cs
```

---

## 🛠️ **Technologies Used**

* **.NET MAUI**
* **C# 12**
* **JSON Serialization (System.Text.Json)**
* **CSV file parsing**
* **MVVM-friendly class structure**
* **Local file-based persistence**

---

## 🚀 **Getting Started**

### **1. Clone the repository**

### **2. Open the solution**

Open in **Visual Studio 2022** with MAUI workload installed.

### **3. Set your CSV recipe file path**

In `RecipeManagerDataPersistance.cs`:

```csharp
_filePath = "C:/path/to/recipes.txt";
```

### **4. Run the app**

Choose:

* Android Emulator
* Windows App
* iOS (Mac required)

---

## 📌 Future Enhancements (Optional Section)

* Replace CSV with SQLite or EF Core
* Add advanced recipe filtering
* Add user profiles & saved recipes
* UI redesign with animations
* API integration for real recipe data

---

## 👩‍💻 Authors

* **Maryam E.**
* **Harsheta Sharma**

