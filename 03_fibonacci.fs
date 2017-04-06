module Fibonacci
open System

let rec fibonacci x = 
    match x with
        | 0 -> 1 
        | 1 -> 1
        | _ -> fibonacci (x - 1) + fibonacci (x - 2)

[<EntryPoint>]

printfn "fibonacci 5: %A" (fibonacci 5)
