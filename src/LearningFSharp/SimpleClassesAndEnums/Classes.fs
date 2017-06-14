// standard .net enum type
type CarType =
  | Tricar = 0
  | StandardFourQheeler = 1
  | HeavyLoadCarrier = 2
  | ReallyLargeTruck = 3
  | CrazyHugeMythicalMonster = 4
  | WeirdContraption = 5

// first class
//[<AbstractClass>]
type Car (color: string, wheelCount: int) =
  //do if wheelCount < 3 then failwith "We'll assume that cars must have three wheels"
  //do if wheelCount > 99 then failwith "That's ridiculous"

  // same as
  do  
    if wheelCount < 3 then 
      failwith "We'll assume that cars must have three wheels at least" //throw exception with failwith
    if wheelCount > 99 then 
      failwith "That's ridiculous"

  let carType = 
    match wheelCount with // match ~ switch/case
    | 3 -> CarType.Tricar
    | 4 -> CarType.StandardFourQheeler
    | 6 -> CarType.HeavyLoadCarrier
    | x when x % 2 = 1 -> CarType.WeirdContraption
    | _ -> CarType.CrazyHugeMythicalMonster

  // add a mutable value
  let mutable passengerCount = 0

  new() = Car("red", 4) // 2nd Constructor, default Ctor
  //x: this, self, x is a convention
  member x.Move() = printfn "The %s car (%A) is moving" color carType // method
  member x.CarType = carType // readonly property

  abstract PassengerCount : int with get, set

  default x.PassengerCount with get() = passengerCount and set v = passengerCount <- v // mutable property

type Red18Wheeler() =
  inherit Car("red", 18)

  override x.PassengerCount
    with set v =
      if v < 2 then failwith "only two passengers allowed"
        else base.PassengerCount <- v

let car = Car()

car.Move()

let greenCar = Car("green", 20)
greenCar.Move()

printfn "groon car has type %A" greenCar.CarType

printfn "Var has %d passengers on board" car.PassengerCount
car.PassengerCount <- 12
printfn "Var has now %d passengers on board" car.PassengerCount

let truck = Red18Wheeler()
truck.PassengerCount <- 1
truck.PassengerCount <- 3

// using up-casting operator
let truckObject = truck :> obj
let truckCar = truck :> Car

// down-casting operator !try to case!
let truckObjectBackToCar = truckObject :?> Car

System.Console.ReadKey()