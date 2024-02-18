module Assignment2

    let rec downto1 n = 
        if n <= 0 
            then []
        else
            n::downto1 (n-1)
    
    let rec downto2 n = 
        match n with
        | n when n <= 0 -> []
        | n -> n::downto2 (n-1)

    let removeOddIdx (some_list: 'a list) : 'a list = 
        let EvenFilter (idx, item) = idx % 2 = 0
        Seq.indexed some_list |>
        Seq.filter EvenFilter |>
        List.ofSeq |>
        List.map  (fun (a, b) -> b)

    let rec combinePair (some_list: 'a list): ('a * 'a) list = 
        match some_list with
        | x::y::rest -> (x,y)::combinePair rest // two or more elements (i.e. x::y::[] minimum)
        | _ -> [] // otherwise empty (i.e. empty or one element)

    type complex = float * float
    let mkComplex a b = complex (a, b)
    let complexToPair (c:complex) = (fst c, snd c)
    let (|+|) (a:complex) (b:complex) = 
        let (a_1, a_2) = complexToPair a
        let (b_1, b_2) = complexToPair b
        mkComplex (a_1 + b_1) (a_2 + b_2)
    
    let (|*|) (a:complex) (b:complex) = 
        let (a_1, a_2) = complexToPair a
        let (b_1, b_2) = complexToPair b
        mkComplex (a_1 * b_1 - a_2 * b_2) (a_2 * b_1 + a_1 * b_2)

    let (|-|) (a:complex) (b:complex) = 
        let (b_1, b_2) = complexToPair b
        (|+|) a (mkComplex (-b_1) (-b_2))
    
    let (|/|) (a:complex) (b:complex) = 
        let (b_1, b_2) = complexToPair b
        let denom = b_1 * b_1 + b_2 * b_2
        (|*|) a (mkComplex (b_1 / denom) (-b_2 / denom))

    let explode1 (this:string) : list<char> = 
        this.ToCharArray() |>
        List.ofArray 

    let rec explode2 (this:string) = 
        match this with
        | "" -> []
        | s -> s.[0] :: explode2(s.Remove(0,1))

    let implode (cs:list<char>) : string = 
        List.fold (fun (tot:string) (s:char) -> tot + s.ToString()) ("".ToString()) cs

    let implodeRev (cs:list<char>) : string = 
        List.foldBack (fun (s:char) (tot:string) -> tot + s.ToString()) cs ("".ToString())

    let toUpper s = s |> explode1 |> List.map System.Char.ToUpper |> implode

    let rec ack ab = 
        match ab with
        | (0, n) -> n+1
        | (m, 0) when m > 0 -> ack(m-1, 1)
        | (m, n) when (m>0 && n>0) -> ack(m-1, ack(m, n-1))
        | (m, n) -> 0

    let downto3 _ = failwith "not implemented"

    let fac _ = failwith "not implemented"
    let range _ = failwith "not implemented"

    type word = (char * int) list


    let hello = [] // Fill in your answer here

    type squareFun = (char * int) list -> int -> int -> int

    let singleLetterScore _ = failwith "not implemented"
    let doubleLetterScore _ = failwith "not implemented"
    let tripleLetterScore _ = failwith "not implemented"

    let doubleWordScore _ = failwith "not implemented"
    let tripleWordScore _ = failwith "not implemented"

    type square = (int * squareFun) list


    let oddConsonants _ = failwith "not implemented"
    
    

    let SLS : square = [(0, singleLetterScore)]
    let DLS : square = [(0, doubleLetterScore)]
    let TLS : square = [(0, tripleLetterScore)]

    let DWS : square = SLS @ [(1, doubleWordScore)]
    let TWS : square = SLS @ [(1, tripleWordScore)]

    let calculatePoints _ = failwith "not implemented"


    // Testing
    // printfn "%s" (implodeRev  ['H'; 'e'; 'j'; 's'; 'a'; 'n'])
    // printfn "%s" (toUpper "hey")