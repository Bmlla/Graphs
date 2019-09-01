
open System
open GrafoMatriz

[<EntryPoint>]
let main argv =

    let grafoM = new GrafoMatriz()
    grafoM.inserirVertice("A")
    grafoM.inserirVertice("B")
    grafoM.inserirVertice("C")
    grafoM.inserirVertice("D")
    grafoM.inserirVertice("E")

    grafoM.inserirAresta(1,1,5)
    grafoM.inserirAresta(0,1,9)
    //grafoM.exibeVertices
    //printf "%s" <| grafoM.labelVertice(4)
    //grafoM.imprimirGrafo()
    printf "%b" <| grafoM.existeAresta(0,1)
    0 // return an integer exit code
