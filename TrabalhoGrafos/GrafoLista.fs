module GrafoLista

open Grafo
open Line
open Stack

type GrafoLista(isDirecionado, isPonderado) =
    inherit Grafo(isDirecionado, isPonderado) //false, true

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
        let mutable listaBase = Array.init listaVertice.Length  (fun item -> Array.init 4 (fun itemSec -> 0))
        let mutable listaVizinhosPrimaria = this.retornarVizinhos(indice)
        let mutable posicaoListaVizinhos = 0
        let mutable proximoPeso = 0
        let mutable pesoSomado = 0
        let mutable pesoAtual = 0
        let fechado = 1
        
        for posicao in 0 .. listaBase.Length - 1 do
            listaBase.[posicao].[0] <- posicao
            listaVizinhosPrimaria <- this.retornarVizinhos(listaBase.[posicao].[0])

            for buscaSecundaria in 0 .. listaVizinhosPrimaria.Length - 1 do
                posicaoListaVizinhos <- listaVizinhosPrimaria.[buscaSecundaria]

                if listaBase.[posicaoListaVizinhos].[3] <> 1 then
                    proximoPeso <- this.existeAresta(posicao, posicaoListaVizinhos)
                    pesoAtual <- listaBase.[posicaoListaVizinhos].[1]
                    pesoSomado <- listaBase.[posicao].[1] + proximoPeso

                    if pesoAtual < proximoPeso && pesoAtual <> 0 then 
                        listaBase.[posicaoListaVizinhos].[1] <- pesoAtual 
                    else 
                        listaBase.[posicaoListaVizinhos].[1] <- pesoSomado
                        listaBase.[posicaoListaVizinhos].[2] <- posicao

                    listaBase.[posicao].[3] <- fechado                 

        listaBase


    member this.getQuantidadeDeVizinhos verticeOrigem =
        let a = this.retornarVizinhos(verticeOrigem).Length.ToString()
        a

    override this.coloreGrafoWP() =
        let listaCores = List.init listaVertice.Length (fun index -> this.getLetraAlfabeto index)

        let mutable matrizDeControle = Array.init listaVertice.Length (
                                fun index -> Array.init 3 (
                                    fun indiceVertice -> match indiceVertice with 
                                                         | 0 -> listaVertice.[index]
                                                         | 1 -> this.getQuantidadeDeVizinhos(index)
                                                         | _ -> ""
                                )
                               )
        matrizDeControle

    member this.compararListas (lista1 :int[], lista2 :int list) =
        let lista1Convertida = lista1 |> Array.toList
        let mutable listaDiferenca = []
        for posLista1 in lista2 do
            if (List.contains posLista1 lista1Convertida) then
                listaDiferenca <- List.append listaDiferenca [posLista1]
            else
                ()
        listaDiferenca

    member this.getMenorPeso(listaVertices :int[], verticeOrigem :int, verticesGrafo :int list) =
        let mutable menorPeso = 0
        let mutable verticeMenorPeso = verticeOrigem
        let mutable verticeOrigemBackup = verticeOrigem

        let mutable listaVizinhosFaltante = this.compararListas(listaVertices, verticesGrafo)

        if verticesGrafo.Length = 1 then
            listaVizinhosFaltante <- (verticesGrafo.[0] |> this.retornarVizinhos) |> Array.toList
            verticeOrigemBackup <- verticesGrafo.[0];


        for verticeDaVez in listaVizinhosFaltante do
            let pesoVertice = if verticeDaVez > verticeOrigemBackup then this.existeAresta(verticeOrigemBackup, verticeDaVez) else this.existeAresta(verticeDaVez, verticeOrigemBackup)
            if menorPeso = 0 then
                menorPeso <- pesoVertice
                verticeMenorPeso <- verticeDaVez

            if pesoVertice < menorPeso && this.vizinhoPossivel(listaVertices, verticeDaVez) then
                menorPeso <- pesoVertice
                verticeMenorPeso <- verticeDaVez
        verticeMenorPeso


    member this.vizinhoPossivel(verticesGrafo :int[], vizinhoEscolhido :int) =
        let listaVerticesGrafo = List.init verticesGrafo.Length (fun item -> verticesGrafo.[item])
        List.contains vizinhoEscolhido listaVerticesGrafo



    override this.arvoreMinimaPrim(verticeInicial :int) = 
        let mutable conjuntoSolucao = [||]
        let mutable verticesGrafo = []
        let mutable verticesGrafoEmNumeros = []
        let mutable verticeConsulta = verticeInicial
        let mutable vizinhosDoverticeEscolhido = [|0|]
        let mutable pesoAnterior = 0

        verticesGrafo <- listaVertice 
                            |> List.filter(fun item -> item <> this.getLetraAlfabeto(verticeInicial).ToString())


        verticesGrafoEmNumeros <- this.transformarListaDeLetrasEmNumero verticesGrafo

        while verticesGrafo.Length > 0 do
            vizinhosDoverticeEscolhido <- verticeConsulta |> this.retornarVizinhos
            let vizinhoEscolhido = this.getMenorPeso(vizinhosDoverticeEscolhido, verticeConsulta, verticesGrafoEmNumeros)
            pesoAnterior <- verticeConsulta
            verticeConsulta <- vizinhoEscolhido

            if verticesGrafoEmNumeros.Length = 1 then
                pesoAnterior <- verticesGrafoEmNumeros.[0]
                verticesGrafo <- []
            else
                verticesGrafo <- verticesGrafo 
                                    |> List.filter(fun item -> item <> this.getLetraAlfabeto(vizinhoEscolhido).ToString())

                verticesGrafoEmNumeros <- this.transformarListaDeLetrasEmNumero verticesGrafo



            let conjuntoItem = (this.getLetraAlfabeto(pesoAnterior).ToString() + this.getLetraAlfabeto(vizinhoEscolhido).ToString())
            conjuntoSolucao <- Array.append conjuntoSolucao [|conjuntoItem|]
        conjuntoSolucao

//if indiceVertice = 0 then listaVertice.[index] else ""