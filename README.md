# 🍳 CLI Recipe Finder

A simple and interactive .NET 8 console application that lets you **search**, **filter**, and **export** recipes from [TheMealDB API](https://www.themealdb.com/)

---

## Features

- 🔍 **Search Recipes** by name  
- 🧾 **Filter** search results using LINQ  
- 📄 **Export** results to `.txt` files  
- 📦 Uses [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json) for parsing API responses    

---

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)  
- Internet connection (uses TheMealDB API)  

---

## Getting Started

1. **Clone the repository:**
   ```bash
   git clone https://github.com/your-username/cli-recipe-finder.git
   cd cli-recipe-finder
   ```

2. **Ensure the `Exports` folder exists:**
   ```bash
   mkdir Exports
   ```

3. **Run the app:**
   ```bash
   dotnet run
   ```

---

## Project Structure

```
.
├── Program.cs               # Main interactive CLI loop
├── CLIrecipes/
│   ├── RecipesAPI.cs       # API fetching & parsing
│   ├── Export.cs           # File exporting logic
│   └── Menu.cs             # CLI interactive menu
├── Data_models/
│   └── Recipe.cs           # Recipe data structure
├── Exports/                # Exported recipes files
├── *.csproj                # .NET project config
```

---

## 🧾 LINQ Filtering

In this project, we use **LINQ** (Language Integrated Query) to filter the search results.
The **filtering options** allow users to refine their search results based on:

- **Category**: Filter recipes based on the recipe's category (e.g., Pasta, Soup, Dessert).
- **Origin**: Filter recipes based on the recipe's origin (e.g., Italian, American, Mexican).

---

## Usage Notes

- Results are fetched from the [public MealDB API](https://www.themealdb.com/api.php).
- You can search multiple times within the same session.
- Filtered or full results can be exported as `.txt` files.
