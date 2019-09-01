module GrafoMatriz

open Grafo

type GrafoMatriz() =
    inherit Grafo(false, false)

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
        matrizArestas.[origem, destino] <- peso
        true

    override this.existeAresta(origem :int, destino :int) =
        matrizArestas.[origem, destino] <> 0


    member this.refazMatriz vertice =
        matrizArestas <- Array2D.init listaVertice.Length listaVertice.Length (fun linha coluna -> 0)
        

    member this.exibeVertices =
        printf "%A" listaVertice

       

    

