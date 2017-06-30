module Options

// is a disciminated union
// some(x)
// None

let o1 = Some(5)
let o2 = None

if o1 = o2 then
  printfn "Values are equal"

o1.IsSome

let checkOption o =
  match o with
  | Some(x) -> printfn "Option contains value %A" x
  | None -> printfn "Option doesn't have a value"

checkOption o1
checkOption o2
