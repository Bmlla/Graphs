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

    abstract member retornarVizinhos :int -> array<int>

    //abstract member introducaoGrafo :unit -> unit

    member this.getLetraAlfabeto numeroReferencia =
        alfabeto.Chars numeroReferencia

    
    