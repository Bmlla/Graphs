module GrafoLista

open Grafo


type elemento = {
    Indice :int
    Peso :int
}

type GrafoLista() =
    inherit Grafo(false, false)

    let mutable listaVertice = []
    let mutable listaArestas = [|[||]|]

    override this.inserirVertice (nomeVertice :string) =
        listaVertice <- List.append listaVertice [nomeVertice]
        listaArestas <- Array.init listaVertice.Length (fun index -> [||])
        true

    override this.imprimirGrafo() =
        listaArestas
        |> Array.mapi(fun index elem -> elem)
        |> Array.mapi(fun index elem -> printf "%A\n" elem.[index]) 
        true

    override this.labelVertice(indiceVertice :int) =
        listaVertice.[indiceVertice]


    override this.inserirAresta(origem :int, destino :int, ?peso :int) =
        let pesoRecebido = defaultArg peso 1

        listaArestas.[origem] <- Array.append listaArestas.[origem] [|(destino, pesoRecebido)|]

        if not this.isDirecionado then
            listaArestas.[destino] <- Array.append listaArestas.[destino] [|(origem, pesoRecebido)|]
        true


    override this.existeAresta(origem :int, destino :int) =
        let peso = listaArestas.[origem] 
                    |> Array.filter(fun (x,_) -> x = destino) 
                    |> Array.map snd
        peso.[0]


    override this.retornarVizinhos(vertice :int) =
        listaArestas.[vertice] |> Array.map(fun (x,_) -> x) 

    