module Tuples

let t1 = 12, 5, 7
let v1, v2, v3 = t1
let v4, v5, _ = t1 // ignore 3rd value

let getTuple =
  (1,2)

let a,b = getTuple

let t2 = "hi", true
// use built-in functions to get values from tuple (fst, snd)
printfn "%A" (fst t2)
printfn "%A" (snd t2)

// or define your own function (third)
let third t =
  let _, _, r = t
  r

printfn "%A" (third t1)

let third' (_,_,r) = r

printfn "%A" (third' t1)



