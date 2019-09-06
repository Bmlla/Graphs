module GrafoLista

open Grafo
open Line
open Stack

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
        listaArestas.[vertice] |> 
        Array.map(fun (x,_) -> x) 


    override this.buscarEmLargura(indice :int) =
        let mutable listaResultado = indice
        let mutable fila = [||]
        let mutable listaExibicao = [|indice|]

        fila <- Array.init quantidadeArestas (fun index -> this.retornarVizinhos(indice))
        this.PercorrerGrafoEmLargura(fila.[0], listaExibicao)


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
        this.percorreeGrafoEmProfundidade(indice, itensJaPercorridos, 0)


    member this.percorreeGrafoEmProfundidade(indice :int, itensJaPercorridos :int[], contador :int) =
        let mutable itensJaPercorridos = itensJaPercorridos
        let vizinhos = this.retornarVizinhos(indice)    

        if contador < listaVertice.Length then
            printf "%d" itensJaPercorridos.[itensJaPercorridos.Length - 1]
        
        for item in vizinhos do
            let existeNalista = Array.contains item itensJaPercorridos
            if not existeNalista then
                itensJaPercorridos <- Line.add(itensJaPercorridos, item)
                contador = contador + 1
                this.percorreeGrafoEmProfundidade(item, itensJaPercorridos, contador)      
        itensJaPercorridos <- Line.remove(itensJaPercorridos)
        //itensJaPercorridos <- Line.remove(itensJaPercorridos)



    