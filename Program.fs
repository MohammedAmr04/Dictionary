open System
open System.IO
open System.Windows.Forms
open System.Text.Json

// Type alias for Dictionary
type Dictionary = Map<string, string>

// Load dictionary from a file
let loadDictionary (filePath: string) : Dictionary =
    if File.Exists(filePath) then
        let json = File.ReadAllText(filePath)
        JsonSerializer.Deserialize<Dictionary>(json)
    else
        Map.empty

// Save dictionary to a file
let saveDictionary (filePath: string) (dict: Dictionary) =
    let json = JsonSerializer.Serialize(dict)
    File.WriteAllText(filePath, json)

let filePath = @"C:\Users\Talaat\source\repos\Dictionary Project\dictionary.json.json"

// Check if the file exists
if not (File.Exists(filePath)) then
    // Create a new empty file if it doesn't exist
    let emptyDictionary = "{}"  // an empty dictionary in JSON format
    File.WriteAllText(filePath, emptyDictionary)
    printfn "New dictionary file created at: %s" filePath

// Load the dictionary from the file
let mutable dictionary = loadDictionary filePath
