
open System
open GrafoMatriz
open GrafoLista
open Interface
open FileHandler
open Grafo.TratamentoDadosArquivo

[<EntryPoint>]
let main argv =

    //Interface.InterfaceUsuario.boasVindas


    let grafoL = new GrafoLista(false, true)


    grafoL.inserirVertice("A")
    grafoL.inserirVertice("B")
    grafoL.inserirVertice("C")
    grafoL.inserirVertice("D")
    grafoL.inserirVertice("E")
    grafoL.inserirVertice("F")

    grafoL.inserirAresta(0,2,7)
    grafoL.inserirAresta(0,4,10)
    grafoL.inserirAresta(0,3,2)
    grafoL.inserirAresta(1,2,3)
    grafoL.inserirAresta(1,5,2)
    grafoL.inserirAresta(2,4,9)
    grafoL.inserirAresta(2,5,3)
    grafoL.inserirAresta(3,5,4)
    grafoL.inserirAresta(3,4,7)
    grafoL.inserirAresta(4,5,8)
    //grafoL.imprimirGrafo(

    printf "%A" <| grafoL.arvoreMinimaPrim(2)
    //printf "%A" <| grafoL.buscarEmLargura(0)
    //printf "%A" <| grafoL.retornarVizinhos(0)
    //grafoL.imprimirGrafo()
    //printf "%A" <| grafoM.buscarEmLargura(0) 

    //grafoM.inserirVertice("A")
    //grafoM.inserirVertice("B")
    //grafoM.inserirVertice("C")
    //grafoM.inserirVertice("D")
    //grafoM.inserirVertice("E")
    //grafoM.inserirVertice("F")

    //grafoM.inserirAresta(0,1,3)
    //grafoM.inserirAresta(0,2,5)
    //grafoM.inserirAresta(0,3,8)
    //grafoM.inserirAresta(1,3,8)
    //grafoM.inserirAresta(2,4,8)
    //grafoM.inserirAresta(2,5,8)
    //grafoM.inserirAresta(4,5,8)
    //grafoM.imprimirGrafo()

    //printf "%A" <| grafoL.buscarDijkstra(0)
    //grafoM.buscarEmProfundidade(0)
    //printf "%A" <| grafoM.buscarEmLargura(0)
   //grafoM.exibeVertices
   //printf "%s" <| grafoM.labelVertice(2)
    //grafoM.imprimirGrafo()
    //printf "%d" <| grafoM.existeAresta(0,1)
    //printf "%A" <| grafoM.retornarVizinhos(0)

    //let textoArquivo = "/Users/brunomuller/Projects/TrabalhoGrafos/layoutImportacao/grafo.txt"

    //let dadosBaseGrafo = readLines(textoArquivo, 1)
    //let isPonderado = verificaPonderadoTexto(dadosBaseGrafo)
    //let isDirecionado = verificaDirecionadoTexto(dadosBaseGrafo)

    //let verticesGrafo = readLines(textoArquivo, 2)
    //let pesosGrafo = readLines(textoArquivo, 3)

    //let grafoL = new GrafoLista(isDirecionado, isPonderado)


    //let grafoM = new GrafoMatriz(isDirecionado, isPonderado)

    //printf "%A" verticesGrafo
    //verticesGrafo |> List.map(fun verticeNome -> grafoL.inserirVertice(verticeNome))

    //pesosGrafo 
   //    |> List.map(fun grupoPesoVertice -> 
    ///                   let charArrayPesoVertice = grupoPesoVertice.ToCharArray()
   //                     let verticeOrigem = verificaVerticeOrigem(charArrayPesoVertice)
   //                     let verticeDestino = verificaVerticeDestino(charArrayPesoVertice)
   //                     let pesoAresta = if isPonderado then verificaPesoDestino(charArrayPesoVertice) else 1
    //                    grafoL.inserirAresta(verticeOrigem, verticeDestino, pesoAresta)
   //                )

    //grafoL.imprimirGrafo(
    //printf "%A" <| grafoL.coloreGrafoWP()
    0 // return an integer exit code


