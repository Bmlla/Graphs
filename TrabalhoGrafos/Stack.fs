module Stack

type Stack()=
    static member pop(stack :int[]) =
        stack.[0 .. (stack.Length - 2)]

    static member push(line :array<int>, element :int) = 
        let newLine = Array.append line [|element|]
        newLine

