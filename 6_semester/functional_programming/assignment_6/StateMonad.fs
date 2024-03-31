module StateMonad

    type Error = 
        | VarExists of string
        | VarNotFound of string
        | IndexOutOfBounds of int
        | DivisionByZero 
        | ReservedName of string           

    type Result<'a, 'b>  =
        | Success of 'a
        | Failure of 'b

    type State = { vars     : Map<string, int> list
                   word     : (char * int) list 
                   reserved : Set<string> }

    type SM<'a> = S of (State -> Result<'a * State, Error>)

    let mkState lst word reserved = 
           { vars = [Map.ofList lst];
             word = word;
             reserved = Set.ofList reserved }

    let evalSM (s : State) (S a : SM<'a>) : Result<'a, Error> =
        match a s with
        | Success (result, _) -> Success result
        | Failure error -> Failure error

    let bind (f : 'a -> SM<'b>) (S a : SM<'a>) : SM<'b> =
        S (fun s ->
              match a s with
              | Success (b, s') -> 
                match f b with 
                | S g -> g s'
              | Failure err     -> Failure err)


    let ret (v : 'a) : SM<'a> = S (fun s -> Success (v, s))
    let fail err     : SM<'a> = S (fun s -> Failure err)

    let (>>=)  x f = bind f x
    let (>>>=) x f = x >>= (fun () -> f)

    let push : SM<unit> = 
        S (fun s -> Success ((), {s with vars = Map.empty :: s.vars}))

    let pop : SM<unit> = S (fun s ->
        match s.vars with
        | s1::ss -> Success ((), {s with vars = ss}) 
        | _ -> Failure (IndexOutOfBounds 0)
        )

    let wordLength : SM<int> = S (fun s -> Success (s.word.Length, s))      

    let characterValue (pos : int) : SM<char> = S (fun s ->
        if s.word.Length > pos // if there are enough characters to fetch item at position
            then Success (fst s.word[pos], s) // First in tuple is char
            else Failure (IndexOutOfBounds pos)
        )      

    let pointValue (pos : int) : SM<int> = S (fun s ->
        // A peculiar note; i did not initially think of ALL negative numbers as invalid indices as they are perfectly valid in python (indexing from end of list)
        if s.word.Length > pos && pos >= 0 // if there are enough characters to fetch item at position 
            then Success (snd s.word[pos], s) // Second in tuple is pointvalue
            else Failure (IndexOutOfBounds pos)
        )          

    let lookup (x : string) : SM<int> = 
        let rec aux =
            function
            | []      -> None
            | m :: ms -> 
                match Map.tryFind x m with
                | Some v -> Some v
                | None   -> aux ms

        S (fun s -> 
              match aux (s.vars) with
              | Some v -> Success (v, s)
              | None   -> Failure (VarNotFound x))

    let declare (var : string) : SM<unit> = 
        let rec aux =
            function
            | []      -> None
            | m :: ms -> 
                match Map.tryFind var m with
                | Some v -> Some v
                | None   -> aux ms

        S (fun s -> 
              match aux (s.vars) with
              | Some v -> Failure (VarExists var) // Case when we found the variable
              | None when Set.contains var s.reserved -> Failure (ReservedName var) // Case when variable name is reserved
              | _ -> // Case when we need to add it to top map
                match s.vars with
                | x::xs -> Success ((), {s with vars = (Map.add var 0 x) :: xs}) // Adding to top map
                | _ -> Failure (IndexOutOfBounds 0) // Failure for empty stack
            )

    let update (var : string) (value : int) : SM<unit> =
        let rec aux =
            function
            | []      -> None
            | m :: ms -> 
                match Map.tryFind var m with
                | Some v -> Some v
                | None   -> aux ms

        S (fun s -> 
              match aux (s.vars) with
              | Some v -> 
                match s.vars with
                | x::xs -> Success ((), {s with vars = (Map.add var value x) :: xs}) // Adding to top map
                | _ -> Failure (IndexOutOfBounds 0) // Failure for empty stack
              | _ -> Failure (VarNotFound var) // Case when we need to add it to top map
            ) 
              

    