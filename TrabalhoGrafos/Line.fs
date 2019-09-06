module Line

type Line() =

    //let mutable size = 0

    //static member lineSize with 
      //  get() = this.size and 
        //private set(value) = size <- value

    static member push(line :array<int>, element :int) = 
        let newLine = Array.append line [|element|]
        newLine

    static member pop(line :int[]) =
        line.[1 .. (line.Length - 1)]
        //for pos = 1 to line.Length - 1 do
          //  arrayInicial.[pos - 1] <- line.[pos]
        //arrayInicial