module GrafoLista

open Grafo

type GrafoLista() =
    inherit Grafo(false, false)

    let mutable teste = [|"1"|]

    override this.InserirVertice (_) =
       false