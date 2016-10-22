module Demo

open Xunit
open Fibonacci
open Swensen.Unquote

[<Fact>]
let ``fibonacci sequence should start with 1, 1, 2, 3, 5``() = 
    test <@
            FibonacciGenerator.Get() 
            |> Seq.take 5 
            |> List.ofSeq = [1; 1; 2; 3; 5] 
         @>