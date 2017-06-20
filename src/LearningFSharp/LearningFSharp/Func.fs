module Func

// Functions are values
let add x y = x + y

// as lambda
let add' = fun x y -> x + y

//let checkThis item f = //without annotation
let checkThis (item: 'c) (f: 'c -> bool) : unit = //item is a generic
  if f item then
    printfn "HIT"
  else
    printfn "MISS"

checkThis 5 (fun x -> x > 3)
checkThis "str" (fun x -> x.Length > 5)