# Digital Dictionary

A digital dictionary built with F# for managing and searching word definitions. This application allows users to add, update, delete, and search for words and their definitions, with functionality to save and load the dictionary data for persistence.

# Features

1. Word Management
   Storage:
   Words and their definitions are stored in an F# Map for efficient lookup and management.
   Operations:
   Add new words with their definitions.
   Update existing word definitions.
   Delete words from the dictionary.
2. Search Functionality
   Case-Insensitive Search:
   Users can search for words or partial keywords regardless of their letter casing.
   Flexible Queries:
   Supports both full-word and partial-word searches to quickly find the desired entries.
3. Data Persistence
   Save to File:
   Save the dictionary data to a file in a chosen format (e.g., JSON or XML).
   Reload Dictionary:
   Reload the dictionary from the saved file to restore previously added entries.
   Getting Started
   Prerequisites
   F# Development Environment (e.g., Visual Studio, JetBrains Rider, or .NET CLI).
   .NET SDK installed on your system.
   Setup Instructions
   Clone the repository:

git clone https://github.com/MohammedAmr04/Dictionary.git  
cd Dictionary  
Open the project in your preferred F# IDE or editor.

Build and run the project.

# Usage

Word Management Commands
Add a Word:
Enter a word and its definition to store it in the dictionary.

Update a Word:
Search for an existing word and provide a new definition to update it.

Delete a Word:
Remove a word and its definition from the dictionary.

Search Commands
Search for a specific word or a keyword to get matching results.
All searches are case-insensitive and support partial matches.
Save & Reload Data
Save:
Save the current dictionary state to a file in JSON or XML format.

Reload:
Load the dictionary from a previously saved file to restore all data.

File Formats
The dictionary supports saving and loading in the following file formats:

JSON: Compact and readable format for structured data.

Technologies Used
Language: F#
Data Storage: F# Map, JSON/XML for persistence
