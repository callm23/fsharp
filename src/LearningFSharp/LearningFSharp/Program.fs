// Weitere Informationen zu F# unter "http://fsharp.org".
// Weitere Hilfe finden Sie im Projekt "F#-Tutorial".

[<EntryPoint>]
let main argv = 
  let x = 10
  // funktionen sind auch variablen
  let add a b = a + b
  let square x = x * x // int -> int (int goes to int)

  // nested
  let add' x y =
    let result =
        x + y
    result

  let add5and3 = add 5 3

  let result = add (square 12) 7

  printfn "%A" argv
  0 // Integer-Exitcode zurückgeben