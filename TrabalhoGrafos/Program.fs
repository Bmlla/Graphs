
open System
open GrafoMatriz

[<EntryPoint>]
let main argv =

    let grafoM = new GrafoMatriz()
    grafoM.InserirVertice("A")
    grafoM.InserirVertice("B")
    grafoM.InserirVertice("C")
    grafoM.InserirVertice("D")
    grafoM.InserirVertice("E")

    grafoM.inserirArestas(1,1,5)
    grafoM.inserirArestas(0,1,9)
    //grafoM.exibeVertices
    grafoM.exibeMatriz
    0 // return an integer exit code
