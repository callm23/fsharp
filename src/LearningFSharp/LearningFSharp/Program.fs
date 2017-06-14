// Weitere Informationen zu F# unter "http://fsharp.org".
// Weitere Hilfe finden Sie im Projekt "F#-Tutorial".

open Call.Demo.Calculator // open a namespae
open Call.Demo.Calculator.Adder // open a module (also possible)
open Call.Demo.Calculator.Multiplier // open a module (also possible)

[<EntryPoint>]
let main argv = 
  let x = 10
  // funktionen sind auch variablen

  // nested
  let add' x y =
    let result =
        x + y
    result

  let add5and3 = add 5 3

  let result = add (square 12) 7

  printfn "%A" argv
  0 // Integer-Exitcode zurückgeben