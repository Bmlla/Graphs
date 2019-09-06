module GrafoMatriz

open System
open Grafo

type GrafoMatriz() =
    inherit Grafo(false, true)

    let mutable listaVertice = [||]
    let mutable matrizArestas = array2D [[||];[||]]
   


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
        [|0|]

    override this.buscarEmProfundidade(indice :int) =
        [|0|]

    member this.refazMatriz vertice =
        matrizArestas <- Array2D.init listaVertice.Length listaVertice.Length (fun linha coluna -> 0)
        

    member this.exibeVertices =
        printf "%A" listaVertice


       

    

