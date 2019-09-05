
open System
open GrafoMatriz
open GrafoLista
open Interface

[<EntryPoint>]
let main argv =

    //Interface.InterfaceUsuario.boasVindas



    let grafoM = new GrafoMatriz()
    let grafoL = new GrafoLista()

    grafoL.inserirVertice("A")
    grafoL.inserirVertice("B")
    grafoL.inserirVertice("C")

    grafoL.inserirAresta(0,1)
    grafoL.inserirAresta(0,2)
    //printf "%A" <| grafoL.retornarVizinhos(0)
    grafoL.imprimirGrafo()
    //grafoM.inserirVertice("A")
    //grafoM.inserirVertice("B")
    //grafoM.inserirVertice("C")
    //grafoM.inserirVertice("D")
    //grafoM.inserirVertice("E")

    //grafoM.inserirAresta(0,1,5)
    //grafoM.inserirAresta(1,2,9)
    //grafoM.inserirAresta(2,0,9)
    //grafoM.inserirAresta(0,3,9)
    //grafoM.exibeVertices
   //printf "%s" <| grafoM.labelVertice(2)
    //grafoM.imprimirGrafo()
    //printf "%d" <| grafoM.existeAresta(0,1)
    //printf "%A" <| grafoM.retornarVizinhos(0)
    0 // return an integer exit code
