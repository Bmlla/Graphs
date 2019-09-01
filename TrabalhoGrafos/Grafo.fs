module Grafo

[<AbstractClass>]
type Grafo(isDirecionado, isPonderado) =
    let alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

    member this.isDirecionado = isDirecionado
    member this.isPonderado = isPonderado

    abstract member inserirVertice :string -> bool

    abstract member imprimirGrafo :unit -> bool

    abstract member labelVertice :int -> string

    abstract member inserirAresta :arg:int * arg2:int * ?arg3:int -> bool

    member this.getLetraAlfabeto numeroReferencia =
        alfabeto.Chars numeroReferencia

    
    