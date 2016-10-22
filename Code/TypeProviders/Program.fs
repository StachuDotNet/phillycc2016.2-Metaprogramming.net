module TypeProviders

open FSharp.Data

open System
open System.Data
open System.Data.Linq
open Microsoft.FSharp.Data.TypeProviders
open Microsoft.FSharp.Linq

// JSON Type Provider
type simpleJsonTest = 

    JsonProvider<""" { "name":"John", "age":94 } """>

type moreComplexJsonText = 
    JsonProvider<""" [{ "name":"John", "age":94 }, { "name":"Tomas" }] """>


for item in moreComplexJsonText.GetSamples() do 
    printf "%s " item.Name 
    item.Age |> Option.iter (printf "(%d)")
    printfn ""



// SQL Type Provider

type dbSchema = SqlDataConnection<"Data Source=(LocalDb)\\v11.0;Initial Catalog=FooDb;">
let db = dbSchema.GetDataContext()

db.DataContext.Log <- System.Console.Out

type OrderDetail = { OrdererName: string; ItemName: string; Count: int }

query {
    for order in db.Orders do
    join orderDetail in db.OrderDetails on (order.OrderId = orderDetail.OrderId)
    select { 
        OrdererName = order.OrdererName
        ItemName = orderDetail.ItemName
        Count = orderDetail.Count
    } 
} |> Seq.iter (fun z -> printfn "%s %s %d" z.OrdererName z.ItemName z.Count)