module GrafoLista

open Grafo
open Line
open Stack

type GrafoLista() =
    inherit Grafo(false, true)

    let mutable listaVertice = []
    let mutable listaArestas = [|[||]|]
    let mutable quantidadeArestas = 0
    let mutable contagemBuscaProfunda = 0


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


    override this.buscarDijkstra(indice :int) =
        let mutable listaBase = Array.init listaVertice.Length (fun item -> Array.init 3 (fun itemSec -> 0))
        let listaVizinhosPrimaria = this.retornarVizinhos(indice)
        let mutable posicaoListaVizinhos = 0
        let mutable proximoPeso = 0
        let mutable listaVizinhosSecundaria = [|0|]
        let mutable pesoAtual = 0
        let fechado = 1
        
        for buscaSecundaria in 0 .. listaVizinhosPrimaria.Length - 1 do
            posicaoListaVizinhos <- listaVizinhosPrimaria.[buscaSecundaria]

            proximoPeso <- this.existeAresta(indice, posicaoListaVizinhos)
            pesoAtual <- listaBase.[posicaoListaVizinhos].[0]

            if pesoAtual < proximoPeso then 
                listaBase.[posicaoListaVizinhos].[0] <- proximoPeso 
            else 
                listaBase.[posicaoListaVizinhos].[0] <- pesoAtual

            listaBase.[posicaoListaVizinhos].[1] <- indice
            //listaBase.[listaVizinhosPrimaria.[buscaSecundaria]].[2] <- fechado
        listaBase