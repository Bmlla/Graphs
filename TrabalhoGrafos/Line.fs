module Line

type Line() =
    static member add(line :array<int>, element :int) = 
        let newLine = Array.append line [|element|]
        newLine

    static member remove(line :int[]) =
        line.[1 .. (line.Length - 1)]