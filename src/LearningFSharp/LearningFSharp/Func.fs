module Func

// Functions are values
let add x y = x + y

// as lambda
let add' = fun x y -> x + y //spoken: add tick

//let checkThis item f = //without annotation
let checkThis (item: 'c) (f: 'c -> bool) : unit = //item is a generic
  if f item then
    printfn "HIT"
  else
    printfn "MISS"

checkThis 5 (fun x -> x > 3)
checkThis "str" (fun x -> x.Length > 5)

// partial application
// passing an incomplete parameter list to a function call, resulting in a new funciton
let add'' x = fun y -> x + y
// int -> (int -> int) //int "goes to" int

let add10'' = add'' 10
printfn "%d" (add10'' 32)

let add10 = add 10
printfn "%d" (add10 32)


// Composition
let mult x y = x * y
let mult5 = mult 5

let calcResult = mult5 (add10 17)
let calcResult' = 17 |> add10 |> mult5
let m = 2 |> mult

let add10mult5 = add10 >> mult5 // >> composition operator

let clacResult'' = add10mult5 17


// Precomputation
open System.Collections.Generic

let isInList (list: 'a list) v =
  let lookupTable = new HashSet<'a>(list)
  printfn "Lokup table created, looking up value"
  lookupTable.Contains v

printfn "%b" (isInList ["hi";"there";"oliver"] "there")
printfn "%b" (isInList ["hi";"there";"oliver"] "anna")
// das Array wird bei jedem Aufruf generiert --> möchte ich nicht

// deshalb probiere ich eine funktion zu erstellen, bei der ich das Array nicht immer mitgeben muss
// ist aber auch noch keine Precomputation, da ich nur die Anzahl der Parameter reduziere
// eine Funktion wird erst ausgeführt wenn alle Parameter übergeben wurden
let isInListClever = isInList ["hi";"there";"oliver"]
printfn "%b" (isInListClever "there")
printfn "%b" (isInListClever "anna")

// Precomputation kann man aber damit erreichen:
// - es wird eine Funktion zurückgegeben, wo die Umwandlung vom Array in den HashSet bereits passiert ist
// - wobei der HashSet nur 1x erzeugt werden muss, was vor allem bei aufwendigen Berechnungen wichtig ist
let constructLookup (list: 'a list) =
  let lookupTable = new HashSet<'a>(list)
  printfn "Lookup table created"
  fun v ->
    printfn "Performing lookup"
    lookupTable.Contains v

let isInListClever' = constructLookup ["hi";"there";"oliver"]
printfn "%b" (isInListClever' "there")
printfn "%b" (isInListClever' "anna")