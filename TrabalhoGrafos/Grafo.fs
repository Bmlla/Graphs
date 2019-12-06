module Grafo

[<AbstractClass>]
type Grafo(isDirecionado :bool, isPonderado :bool) =
    let alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

    member this.isDirecionado = isDirecionado
    member this.isPonderado = isPonderado

    abstract member inserirVertice :string -> bool

    abstract member imprimirGrafo :unit -> bool

    abstract member labelVertice :int -> string

    abstract member inserirAresta :arg:int * arg2:int * ?arg3:int -> bool

    abstract member existeAresta :int * int -> int

    abstract member retornarVizinhos :int -> int[]

    abstract member buscarEmLargura :int -> int[]

    abstract member buscarEmProfundidade :int -> unit

    abstract member buscarDijkstra :int -> int[][]

    abstract member coloreGrafoWP :unit -> string[][]

    abstract member arvoreMinimaPrim :int -> string[]

    //abstract member introducaoGrafo :unit -> unit

    member this.getLetraAlfabeto numeroReferencia =
        alfabeto.Chars numeroReferencia


    member this.getNumeroAlfabeto letraReferencia  = 
        alfabeto.IndexOf(letraReferencia :string)


    member this.transformarListaDeLetrasEmNumero listaDeLetras =
        listaDeLetras |> List.map(fun item -> this.getNumeroAlfabeto(item))



module TratamentoDadosArquivo = 

    let inline charToInt c = int c - int '0'

    
    let verificaDirecionadoTexto(textoArquivo : string list) =
        textoArquivo.[0].[2] |> charToInt > 0

    let verificaPonderadoTexto(textoArquivo : string list) =
        textoArquivo.[0].[3] |> charToInt > 0
        

    let verificaVerticeOrigem(textoArquivo : char[]) =
        textoArquivo.[0] |> charToInt

    let verificaVerticeDestino(textoArquivo : char[]) =
        textoArquivo.[1] |> charToInt

    let verificaPesoDestino(textoArquivo : char []) =
        textoArquivo.[2] |> charToInt
        