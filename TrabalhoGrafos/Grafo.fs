module Grafo

[<AbstractClass>]
type Grafo(isDirecionado, isPonderado) =
    let mutable vertices = "baga"
    let alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

    member this.isDirecionado = isDirecionado
    member this.isPonderado = isPonderado

    abstract member InserirVertice :string -> bool

    member this.getLetraAlfabeto numeroReferencia =
        alfabeto.Chars numeroReferencia
    