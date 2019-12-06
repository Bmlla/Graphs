module FileHandler

open System.IO

let alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"


let readBaseGrafico (file : string list) =
    [ file.[0] ]


let readVerticesGrafo(file : string list) =
    file |> List.filter(fun vertice -> alfabeto.Contains vertice)


let readPesosGrafos(file : string list) =
   [ 
    for index in 0 .. file.Length - 1 do 
        let vertice = file.[index] 
        if index > 0 && not(alfabeto.Contains file.[index])
            then yield(file.[index])
   ]


let readLines (filePath:string, opcaoDado:int) =
      let lines = File.ReadLines(filePath)  
      let linesList = List.ofSeq(lines)        

      let opcao =
          match opcaoDado with
          | 1 -> readBaseGrafico(linesList)
          | 2 -> readVerticesGrafo(linesList)
          | 3 -> readPesosGrafos(linesList)
          | _ -> []

      opcao

                