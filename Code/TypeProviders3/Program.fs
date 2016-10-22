module TypeProviders

open FSharp.Data

open System
open System.Data
open System.Data.Linq
open Microsoft.FSharp.Data.TypeProviders
open Microsoft.FSharp.Linq


// SQL Type Provider

type dbSchema = SqlDataConnection<"Data Source=localhost;Initial Catalog=EntityFrameworkDemo;Integrated Security=true">
let db = dbSchema.GetDataContext()

db.DataContext.Log <- System.Console.Out

type OrderDetail = { OrdererName: string; ItemName: string; Count: int }

query {
    for person in db.People do
    select (person.FirstName, person.LastName, person.Age)
} |> Seq.iter (fun z -> printfn "%A" z)

Console.ReadKey() |> ignore