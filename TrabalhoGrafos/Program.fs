
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
    grafoL.inserirVertice("F")
    grafoL.inserirVertice("G")

    grafoL.inserirAresta(0,1,3)
    grafoL.inserirAresta(0,2,5)
    grafoL.inserirAresta(0,3,8)
    grafoL.inserirAresta(1,3,8)
    grafoL.inserirAresta(2,4,8)
    grafoL.inserirAresta(2,5,8)
    grafoL.inserirAresta(4,5,8)
    grafoL.inserirAresta(6,6,8)

    //printf "%A" <| grafoL.retornarVizinhos(0)
    //grafoL.imprimirGrafo()
    grafoL.buscarEmProfundidade(0)
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
