
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

    grafoM.inserirAresta(0,1,5)
    grafoM.inserirAresta(1,2,9)
    grafoM.inserirAresta(2,0,1)
    grafoM.inserirAresta(0,3,9)
    //grafoM.exibeVertices
    //printf "%s" <| grafoM.labelVertice(4)
    grafoM.imprimirGrafo()
    //printf "%d" <| grafoM.existeAresta(0,1)
    //printf "%A" <| grafoM.retornarVizinhos(0)
    0 // return an integer exit code
