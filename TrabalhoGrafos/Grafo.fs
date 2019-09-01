module Grafo

[<AbstractClass>]
type Grafo(isDirecionado, isPonderado) =
    let alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

    member this.isDirecionado = isDirecionado
    member this.isPonderado = isPonderado

    abstract member inserirVertice :string -> bool

    abstract member imprimirGrafo :string -> bool

    abstract member labelVertice :int -> string

    member this.getLetraAlfabeto numeroReferencia =
        alfabeto.Chars numeroReferencia

    
    