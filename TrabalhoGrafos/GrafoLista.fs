module GrafoLista

open Grafo


type elemento = {
    Indice :int
    Peso :int
}

type GrafoLista() =
    inherit Grafo(false, true)

    let mutable listaVertice = []
    let mutable listaArestas = [|[||]|]
    let mutable quantidadeArestas = 0

    override this.inserirVertice (nomeVertice :string) =
        listaVertice <- List.append listaVertice [nomeVertice]
        listaArestas <- Array.init listaVertice.Length (fun index -> [||])
        true

    override this.imprimirGrafo() =
        listaArestas
        |> Array.mapi(fun index elem -> printf "%s -> %A\n" listaVertice.[index] elem) 
        true

    override this.labelVertice(indiceVertice :int) =
        listaVertice.[indiceVertice]


    override this.inserirAresta(origem :int, destino :int, ?peso :int) =
        let pesoRecebido = defaultArg peso 1

        listaArestas.[origem] <- Array.append listaArestas.[origem] [|(destino, pesoRecebido)|]

        if not this.isDirecionado then
            listaArestas.[destino] <- Array.append listaArestas.[destino] [|(origem, pesoRecebido)|]

        quantidadeArestas <- quantidadeArestas + 1
        true


    override this.existeAresta(origem :int, destino :int) =
        let peso = listaArestas.[origem] 
                    |> Array.filter(fun (x,_) -> x = destino) 
                    |> Array.map snd
        peso.[0]


    override this.retornarVizinhos(vertice :int) =
        listaArestas.[vertice] |> Array.map(fun (x,_) -> x) 


    override this.buscarEmLargura(indice :int) =
    let mutable listaResultado = indice

    let fila = Array.init quantidadeArestas (fun index -> this.retornarVizinhos(indice))
    fila.[0]
 
    //let filaPrincipal = fila.[0]
    
    //fila <- Array.append fila [|listaVertice.[indice]|]
    //fila <- Array.append fila <| this.retornarVizinhos(indice)

    