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

// Main form
let form = new Form(Text = "Digital Dictionary", Width = 600, Height = 600)

// Controls
let txtWord = new TextBox(Left = 20, Top = 20, Width = 200, PlaceholderText = "Enter word")
let txtDefinition = new TextBox(Left = 20, Top = 60, Width = 200, PlaceholderText = "Enter definition")
let btnAddOrUpdate = new Button(Text = "Add/Update", Left = 240, Top = 20, Width = 100)
let btnDelete = new Button(Text = "Delete", Left = 240, Top = 60, Width = 100)
let txtSearch = new TextBox(Left = 20, Top = 100, Width = 200, PlaceholderText = "Search")
let btnSearch = new Button(Text = "Search", Left = 240, Top = 100, Width = 100)
let btnShowAll = new Button(Text = "Show All", Left = 360, Top = 100, Width = 100)
let lstResults = new ListBox(Left = 20, Top = 140, Width = 550, Height = 250)
let btnSave = new Button(Text = "Save and Exit", Left = 20, Top = 400, Width = 120)


btnAddOrUpdate.Click.Add(fun _ ->
    let word = txtWord.Text
    let definition = txtDefinition.Text
    if not (String.IsNullOrWhiteSpace(word) || String.IsNullOrWhiteSpace(definition)) then
        dictionary <- addOrUpdateWord word definition dictionary
        MessageBox.Show(sprintf "Word '%s' added/updated successfully." word, "Success") |> ignore
    else
        MessageBox.Show("Please enter both a word and a definition.", "Error") |> ignore
)

btnDelete.Click.Add(fun _ ->
    let word = txtWord.Text
    if dictionary |> Map.containsKey word then
        dictionary <- deleteWord word dictionary
        MessageBox.Show(sprintf "Word '%s' deleted successfully." word, "Success") |> ignore
    else
        MessageBox.Show(sprintf "Word '%s' not found in the dictionary." word, "Error") |> ignore
)
//Add search functionality and display results
btnSearch.Click.Add(fun _ ->
    let keyword = txtSearch.Text.ToLower()
    if not (String.IsNullOrWhiteSpace(keyword)) then
        let results = 
            dictionary
            |> Map.filter (fun key _ -> key.ToLower().Contains(keyword))
            |> Map.toList
        lstResults.Items.Clear()
        if results.IsEmpty then
            lstResults.Items.Add("No matching words found.") |> ignore
        else
            results |> List.iter (fun (word, definition) -> lstResults.Items.Add(sprintf "%s: %s" word definition) |> ignore)
    else
        MessageBox.Show("Please enter a search keyword.", "Error") |> ignore
)

btnShowAll.Click.Add(fun _ ->
    lstResults.Items.Clear()
    if Map.isEmpty dictionary then
        lstResults.Items.Add("The dictionary is empty.") |> ignore
    else
        dictionary
        |> Map.iter (fun word definition -> lstResults.Items.Add(sprintf "%s: %s" word definition) |> ignore)
)