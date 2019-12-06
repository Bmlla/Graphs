module GrafoMatriz

open System
open Grafo
open Line
open Stack

type GrafoMatriz(isDirecionado, isPonderado) =
    inherit Grafo(isDirecionado, isPonderado) //false, true

    let mutable listaVertice = [||]
    let mutable matrizArestas = array2D [[||];[||]]
    let mutable quantidadeArestas = 0
    let mutable contagemBuscaProfunda = 0
   


    override this.inserirVertice (nomeVertice :string) =
        listaVertice <- Array.append listaVertice [|nomeVertice|]
        this.refazMatriz nomeVertice
        true


    override this.imprimirGrafo() =
        printf "%s" "  "

        for posicaoLetra in 0 .. listaVertice.Length - 1 do
            printf "%c  " <| this.getLetraAlfabeto posicaoLetra

        printf "%s" "\n"

        for linha in 0 .. listaVertice.Length - 1 do
            printf "%c " <| this.getLetraAlfabeto linha
            for coluna in 0 .. listaVertice.Length - 1 do
                printf "%s  " <| matrizArestas.[linha,coluna].ToString()

            printf "%s" "\n"
        true


    override this.labelVertice (indiceVertice :int) =
        listaVertice.[indiceVertice]


    override this.inserirAresta(origem :int, destino :int, ?peso :int) =
        let peso = defaultArg peso 1

        if not this.isPonderado && peso > 1 then
            false
        else
            matrizArestas.[origem, destino] <- peso

            if not this.isDirecionado then
                matrizArestas.[destino, origem] <- peso
            true


    override this.existeAresta(origem :int, destino :int) =
        let mutable peso = 0
        if matrizArestas.[origem, destino] <> 0 then 
            peso <- matrizArestas.[origem, destino]
        peso


    override this.retornarVizinhos(vertice :int) =
        let mutable vizinhos = [||]
        let mutable resultado = [||]

        for linha in 0.. listaVertice.Length - 1 do
            if not this.isDirecionado then
                if matrizArestas.[linha, vertice] <> 0 then 
                    resultado <- Array.append vizinhos [|linha|]
            else
                if matrizArestas.[vertice, linha] <> 0 then 
                    resultado <- Array.append vizinhos [|linha|]

            vizinhos <- resultado
        vizinhos


    override this.buscarEmLargura(indice :int) =
     let mutable listaResultado = indice
     //let mutable fila = [||]
     let mutable listaExibicao = [|indice|]

     let fila = this.retornarVizinhos(indice)
     this.PercorrerGrafoEmLargura(fila, listaExibicao)


    member this.PercorrerGrafoEmLargura(listaAtual :int[], listaExibicao :int[]) =
     let mutable listaVertices = listaAtual
     let mutable listaVerificada = listaExibicao

     while listaVertices.Length > 0 do
         let vizinhosProximos = this.retornarVizinhos(listaVertices.[0])
         listaVerificada <- Line.add(listaVerificada, listaVertices.[0])
         listaVertices <- Line.remove(listaVertices)

         for posVizinho in 0 .. vizinhosProximos.Length - 1 do
             let aindaNaListaDeVertices = Array.contains vizinhosProximos.[posVizinho] listaVertices
             let jaFoiVerificado = Array.contains vizinhosProximos.[posVizinho] listaVerificada

             if not jaFoiVerificado && not aindaNaListaDeVertices then
                 listaVertices <- Line.add(listaVertices, vizinhosProximos.[posVizinho])
     listaVerificada


    override this.buscarEmProfundidade(indice :int) =
     let mutable itensJaPercorridos = [|indice|]
     this.percorreeGrafoEmProfundidade(indice, itensJaPercorridos)


    member this.percorreeGrafoEmProfundidade(indice :int, itensJaPercorridos :int[]) =
     let mutable itensJaPercorridos = itensJaPercorridos
     let vizinhos = this.retornarVizinhos(indice)   

     contagemBuscaProfunda <- (contagemBuscaProfunda + 1)
     if contagemBuscaProfunda <= listaVertice.Length then
        printf "%d" itensJaPercorridos.[itensJaPercorridos.Length - 1]

     for item in vizinhos do
         let existeNalista = Array.contains item itensJaPercorridos
         if not existeNalista then
             itensJaPercorridos <- Stack.push(itensJaPercorridos, item)
             this.percorreeGrafoEmProfundidade(item, itensJaPercorridos) 
     itensJaPercorridos <- Stack.pop(itensJaPercorridos)


    member this.refazMatriz vertice =
        matrizArestas <- Array2D.init listaVertice.Length listaVertice.Length (fun linha coluna -> 0)
        

    member this.exibeVertices =
        printf "%A" listaVertice

    

    override this.buscarDijkstra(indice :int) =
        let listaBase = Array.init listaVertice.Length (fun x -> [||])
        listaBase.[0].[0]


    override this.coloreGrafoWP() =
        let listaCores = List.init listaVertice.Length (fun index -> this.getLetraAlfabeto index)

        let mutable matrizDeControle = Array.init listaVertice.Length (fun index -> Array.init 3 (fun indiceVertice -> if index = 0 then listaVertice.[index] else ""))
        matrizArestas <- matrizArestas
        matrizDeControle


    override this.arvoreMinimaPrim(verticeInicial :int) = 
        [|""|]