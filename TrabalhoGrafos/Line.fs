module Line

type Line() =
    
    let mutable size = 0

    member this.lineSize with 
        get() = size and 
        private set(value) = size <- value

    member this.push(line :array<int>, element :int) = 
        let newLine = Array.append line [|element|]
        newLine

    member this.pop(line :array<int>) =
        