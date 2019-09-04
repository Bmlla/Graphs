module Interface

open System

type InterfaceUsuario() =

    let matrizIntroducao =
        ""

    let listaIntroducao =
        ""

    let opcaoSelecionada opcao :string =
        match opcao with
        | "1" -> matrizIntroducao
        | "2" -> listaIntroducao
        |   _ -> "Opção em desenvolvimento"


    static member boasVindas =
        let mutable opcao = ""
        while opcao <> "1" && opcao <> "2" do
            printf "===============================\n"
            printf "===== SIMULADOR DE GRAFOS =====\n"
            printf "===============================\n\n"

            printf "Menu: \n"
            printf "1. Representação em Matriz\n"
            printf "2. Representação em Lista\n"
            printf "Opção: "

            opcao <- Console.ReadLine()

            if opcao <> "1" && opcao <> "2" then 
                Console.Clear()
                printf "\n\nOpção inválida\n\n"


                