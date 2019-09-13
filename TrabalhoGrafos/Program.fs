
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
    grafoL.inserirVertice("D")
    grafoL.inserirVertice("E")
    //grafoL.inserirVertice("F")

    grafoL.inserirAresta(0,1,3)
    grafoL.inserirAresta(0,2,5)
    grafoL.inserirAresta(0,3,6)
    grafoL.inserirAresta(0,4,8)
    grafoL.inserirAresta(1,3,2)
    grafoL.inserirAresta(1,4,11)
    grafoL.inserirAresta(2,4,2)
    //grafoL.inserirAresta(2,5,8)
    //grafoL.inserirAresta(4,5,8)
    //grafoL.imprimirGrafo()
    //printf "%A" <| grafoL.buscarEmLargura(0)
    //printf "%A" <| grafoL.retornarVizinhos(0)
    //grafoL.imprimirGrafo()
    //printf "%A" <| grafoM.buscarEmLargura(0) 

    grafoM.inserirVertice("A")
    grafoM.inserirVertice("B")
    grafoM.inserirVertice("C")
    grafoM.inserirVertice("D")
    grafoM.inserirVertice("E")
    grafoM.inserirVertice("F")

    grafoM.inserirAresta(0,1,3)
    grafoM.inserirAresta(0,2,5)
    grafoM.inserirAresta(0,3,8)
    grafoM.inserirAresta(1,3,8)
    grafoM.inserirAresta(2,4,8)
    grafoM.inserirAresta(2,5,8)
    grafoM.inserirAresta(4,5,8)
    //grafoM.imprimirGrafo()

    printf "%A" <| grafoL.buscarDijkstra(0)
    //grafoM.buscarEmProfundidade(0)
    //printf "%A" <| grafoM.buscarEmLargura(0)
   //grafoM.exibeVertices
   //printf "%s" <| grafoM.labelVertice(2)
    //grafoM.imprimirGrafo()
    //printf "%d" <| grafoM.existeAresta(0,1)
    //printf "%A" <| grafoM.retornarVizinhos(0)
    0 // return an integer exit code
