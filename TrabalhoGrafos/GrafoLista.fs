module GrafoLista

open Grafo

type GrafoLista() =
    inherit Grafo(false, false)

    let mutable listaVertice = []
    let mutable listaArestas = [[]]

    override this.inserirVertice (nomeVertice :string) =
        listaVertice <- List.append listaVertice [nomeVertice]
        listaArestas <- List.append listaArestas [[]]
        true

    override this.imprimirGrafo() =
        printf "%A" listaArestas
        true

    override this.labelVertice(indiceVertice :int) =
        listaVertice.[indiceVertice]

    override this.inserirAresta(origem :int, destino :int, ?peso :int) =
        let arestaOrigem = [|origem|]
        listaArestas.[origem] <- List.ofArray arestaOrigem
        true

    override this.existeAresta(origem :int, destino :int) =
        0

    override this.retornarVizinhos(vertice :int) =
        [||]

  //override this.inserirVertice (_) =
       //false