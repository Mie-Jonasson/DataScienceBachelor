module exam_2023

    open JParsec.TextParser  

    type prop =
        | TT
        | FF
        | And of prop * prop
        | Or of prop * prop
    
    // 1.1 
    let rec eval p =
        match p with
        | TT            -> true
        | FF            -> false
        | And (p1, p2)  -> (eval p1) && (eval p2)
        | Or (p1, p2)   -> (eval p1) || (eval p2)
    
    // 1.2
    let rec negate p =
        match p with
        | TT            -> FF
        | FF            -> TT
        | And (p1, p2)  -> Or ((negate p1), (negate p2))
        | Or (p1, p2)   -> And ((negate p1), (negate p2))
    
    let implies p1 p2 = Or ((negate p1), p2)

    // 1.3
    let forall f l =
        let rec aux f l acc =
            match l with
            | [] -> acc
            | head :: xs -> aux f xs (And (acc, (f head)))
        aux f l TT
    
    // 1.4
    let exists f l =
        let rec aux f l acc =
            match l with
            | [] -> acc
            | head :: xs -> aux f xs (Or (acc, (f head)))
        aux f l FF
    
    // 1.5
    let existsOne f l =
        let rec aux f l acc =
            match l with
            | [] -> match acc with
                    | 1 -> TT // Only return true at the end of list if count is exactly 1
                    | _ -> FF
            | head :: xs when (eval (f head)) -> aux f xs (acc+1) // Increase count of trues accumulator if evaluate of head is true
            | head :: xs when not (eval (f head)) -> aux f xs acc
        aux f l 0
    
    ///////////////////////////////////////////////////////////////////////////
    let rec foo xs ys =
        // printfn "FOO with %A \t %A" xs ys
        match xs, ys with
        | _, []                         -> Some xs
        | x :: xs', y :: ys' when x = y -> foo xs' ys'
        | _, _                          -> None

    let rec bar xs ys =
        // printfn "BAR with %A \t %A" xs ys
        match foo xs ys with
        | Some zs -> bar zs ys
        | None -> match xs with
        | [] -> []
        | x :: xs' -> x :: (bar xs' ys)

    let baz (a : string) (b : string) =
        let tmp = bar [for c in a -> c] [for c in b -> c] 
        // printfn "Returned from BAR to BAZ: %A" tmp
        List.fold (fun acc c -> acc + string c) "" tmp
    
    // 2.1
    // types:
    //// val foo : 'a list -> 'a list -> SM<'a list>
    //// val bar : 'a list -> 'a list -> 'a list
    //// val baz : string -> string -> string list
    // What they do:
    //// foo iterates over two lists for as long as the items are equal (and there are items to iterate over). 
    ////// foo returns the remainder of xs if ys becomes empty, and otherwise returns None.
    //// bar calls foo on 2 lists, and builds a list of the items in xs with any full repetition of the chars in y removed.
    ////// bar returns xs with any full repetitions of ys removed.
    //// baz takes 2 string, calls baz on the strings made into lists of chars.
    ////// baz returns the list returned by bar as a string; i.e. the string x with any full repetitions of y removed.
    // approporiate names:
    //// foo : begins_with (i.e. because it only returns remainder of x when it begins with y)
    //// bar : remove_reps_list (i.e. because it remove any full repetitions of list y in any list)
    //// baz : remove_reps_string (i.e. because it remove any full repetitions of string y in another string)
    
    // 2.2
    // Explain Snippets:
    //// [for c in a -> c] is a list of chars (char list), as it has the char c for each position in the string a
    //// [for c in b -> c] is a list of chars (char list), as it has the char c for each position in the string b
    //// List.fold (fun acc c -> acc + string c) "" <LIST of chars> transforms a list of chars back into a string using an accumulator
    // The |> operator:
    //// This is a piping operator, which will pass the output argument of aqn expression / function to the next function. 
    //// In particular in the 'baz' function it is used to pass the output of the 'bar' function (i.e. a list of chars) 
    //// to the next function, which will transform the list of chars back into a string.
    
    // 2.3 TODO
    let foo2 xs ys =
        // Hint says to use List.splitAt which splits a list at an index... not sure hwo to work this?
        foo xs ys
    
    // 2.4
    // It becomes obvious from the definition of the function that it is not tail recursive, as it has the following recursive call:
    // | x :: xs' -> x :: (bar xs' ys)
    // I.e., here we have to remember that we need to prepend x once we get the value of the remainder of the recursive call back.
    // Let's run through a small example using the strings "abcdeabc" and "abc":
    /// (1)     bar ['a'; 'b'; 'c'; 'd'; 'e'; 'a'; 'b'; 'c'] ['a'; 'b'; 'c']
    /// (2)     bar ['d'; 'e'; 'a'; 'b'; 'c'] ['a'; 'b'; 'c']
    /// (3)     'd' :: (bar ['e'; 'a'; 'b'; 'c'] ['a'; 'b'; 'c'])               <- Here we need to remember 'd' until the end of the recursive calls
    /// (4)     'd' :: 'e' :: (bar ['a'; 'b'; 'c'] ['a'; 'b'; 'c'])             <- Here we also have to remember 'e'
    /// (5)     'd' :: 'e' :: []
    /// (6)     'd' :: ['e']                                                    <- Here the rest of the recursive call returned to 'e' and now we do teh action of prepending
    /// (7)     ['d'; 'e']                                                      <- Here the recursive call returns to where we remembered 'd' and we can perform the action we remembered

    // 2.5
    let barTail xs ys =
        let rec aux xs ys c =
            match foo xs ys with
            | Some zs -> bar zs ys
            | None -> match xs with
            | [] -> c []
            | x :: xs' -> aux xs' ys (fun r -> c (x :: r))
        
        aux xs ys (fun a -> a)
    
    let bazTail (a : string) (b : string) = // Added this for testing purposes
        let tmp = barTail [for c in a -> c] [for c in b -> c] 
        // printfn "Returned from BAR to BAZ: %A" tmp
        List.fold (fun acc c -> acc + string c) "" tmp

    ///////////////////////////////////////////////////////////////////////////
    // 3.1
    let collatz x =
        let rec f i c =
            if i <= 0 then failwith "Non positive number" // I do not know how to format with the number
            else
                match i with
                | 1             -> c [1]
                | n when n%2=0  -> f (n/2) (fun r -> c (n :: r))
                | n             -> f (3 * n + 1) (fun r -> c (n :: r))
        f x (fun a -> a)
    
    // 3.2
    let evenOddCollatz x =
        let rec f i c =
            if i <= 0 then failwith "Non positive number" // I do not know how to format with the number
            else
                match i with
                | 1             -> c (0,1)
                | n when n%2=0  -> f (n/2) (fun r -> c ((fst r) + 1, (snd r)))
                | n             -> f (3 * n + 1) (fun r -> c ((fst r), (snd r) + 1))
        f x (fun a -> a)
    
    // 3.3
    let maxCollatz (a:int) (b:int) =
        let all = [a .. b]
        let f_map x = (x,(List.length (collatz x))) // For mapping to desired output format of each item
        let all = List.map f_map all

        let f_find s x = if (snd x) > s then (snd x) else s // For folding to max length
        let max_length = List.fold f_find 0 all
        // printfn "Found max_length %A in %A" max_length all

        let f_filter x = if (snd x) = max_length then true else false // Filtering to that of max length
        let longest_options = List.filter f_filter all
        // printfn "Found longest options %A in %A" longest_options all
        
        longest_options[0]
    
    // 3.4
    let collect a b = 
        let all = [a .. b]
        let f_map x = (x,(List.length (collatz x))) // For mapping to desired output format of each item
        let all = List.map f_map all

        let f_folder s (x, l) = 
            let tmp = match Map.tryFind l s with
                      | Some se -> se
                      | None    -> Set.empty
            let tmp = Set.add x tmp
            Map.add l tmp s
        
        List.fold f_folder Map.empty all
    
    // 3.5 TODO
    let parallelMaxCollatz a b n =
        maxCollatz a b // Look into how to spawn threads :)

    ///////////////////////////////////////////////////////////////////////////
    type expr =
    | Num of int                            // Integer literal
    | Lookup of expr                        // Memory lookup
    | Plus of expr * expr                   // Addition
    | Minus of expr * expr                  // Subtraction
    type stmnt =
    | Assign of expr * expr                 // Assign value to memory location
    | While of expr * prog                  // While loop
    and prog = stmnt list                   // Programs are sequences of statements
    let (.+.) e1 e2 = Plus(e1, e2)
    let (.-.) e1 e2 = Minus(e1, e2)
    let (.<-.) e1 e2 = Assign (e1, e2)

    // 4.1
    type mem = M of Map<int,int>
    let emptyMem i = 
        let mem_data = List.map (fun x -> (x,0)) [0 .. (i-1)]
        M (Map.ofList mem_data)
    let lookup m i =
        match m with
        | M k -> Map.find i k
        | _ -> 0
    let assign m i v =
        match m with 
        | M k -> M (Map.add i v k)
        | _ -> m
    
    // 4.2
    let rec evalExpr m e =
        match e with
        | Num x             -> x
        | Lookup e1         -> lookup m (evalExpr m e1)
        | Plus (e1, e2)     -> (evalExpr m e1) + (evalExpr m e2)
        | Minus (e1, e2)    -> (evalExpr m e1) - (evalExpr m e2)

    // 4.3 
    let rec evalStmnt m s =
        match s with
        | Assign (e1, e2)                       -> assign m (evalExpr m e1) (evalExpr m e2)
        | While (e, p) when (evalExpr m e) = 0  -> m
        | While (e, p)                          -> evalProg m (p @ [While(e,p)])
    
    and evalProg m p =
        match p with
        | [] -> m
        | s1 :: ss -> evalProg (evalStmnt m s1) ss


    let fibProg x =
        [Num 0 .<-. Num x ;// {x, 0, 2, 0}
        Num 1 .<-. Num 1 ;// {x, 1, 2, 0}
        Num 2 .<-. Num 0 ;// {x, 1, 0, 0}
        While (Lookup (Num 0),
            [Num 0 .<-. Lookup (Num 0) .-. Num 1 ;
            Num 3 .<-. Lookup (Num 1) ;
            Num 1 .<-. Lookup (Num 1) .+. Lookup (Num 2) ;
            Num 2 .<-. Lookup (Num 3) ;
            ]) // after loop {0, fib (x + 1), fib x, fib x}
        ]
    
    // 4.3
    type StateMonad<'a> = SM of (mem -> ('a * mem) option)
    let ret x = SM (fun s -> Some (x, s))
    let fail = SM (fun _ -> None)
    let bind f (SM a) : StateMonad<'b> =
        SM (fun s ->
            match a s with
            | Some (x, s') -> 
                let (SM g) = f x 
                g s'
            | None -> None)
    let (>>=) x f = bind f x
    let (>>>=) x y = x >>= (fun _ -> y)
    let evalSM m (SM f) = f m

    let lookup2 i = SM (fun (M m) ->
        match Map.tryFind i m with
        | None -> None
        | Some v -> Some (v, M m)
        )

    let assign2 i v = SM (fun (M m) ->
        match Map.tryFind i m with
        | None -> None
        | Some k -> Some ((), M (Map.add i v m))
        )
    
    // 4.4
    let rec evalExpr2 e =
        match e with
        | Num x             -> ret x
        | Lookup e1         -> evalExpr2 e1 >>= lookup2
        | Plus (e1, e2)     -> (evalExpr2 e1) >>= fun x -> (evalExpr2 e2) >>= fun y -> ret (x + y)
        | Minus (e1, e2)    -> (evalExpr2 e1) >>= fun x -> (evalExpr2 e2) >>= fun y -> ret (x - y) 

    let rec evalStmnt2 s =
        match s with
        | Assign (e1, e2)                                                               -> (evalExpr2 e1) >>= fun x -> (evalExpr2 e2) >>= fun y -> assign2 x y
        // | While (e, p) when (match (evalExpr2 e) with | Some (0,_) -> true | _ -> false)-> ret () // TODO : I have no clue how to get this to work 
        | While (e, p)                                                                  -> evalProg2 (p @ [While(e,p)])
    
    and evalProg2 p =
        match p with
        | []        -> ret ()
        | s1 :: ss  -> (evalStmnt2 s1) >>>= evalProg2 ss

    // 4.5
    let whitespaceChar = satisfy System.Char.IsWhiteSpace <?> "whitespace"
    let spaces              = many whitespaceChar <?> "space"
    let (.>*>.) a b         = (a .>> spaces) .>>. b
    let (.>*>) a b          = a .>*>. b |>> fst // Inspired by how JParsec does it
    let (>*>.) a b          = a .>*>. b |>> snd // Inspired by how JParsec does it
    let unop op a           = op >*>. a
    let binop op a b        = (a .>*> op) .>*>. b
    let parenthesise p      = pchar '[' >*>. p .>*> pchar ']'

    let ParseExpr, eref = createParserForwardedToRef<expr>()
    let ParseAtom, aref = createParserForwardedToRef<expr>()

    let AddParse = binop (pchar '+') ParseAtom ParseExpr |>> Plus <?> "Addition"
    let SubParse = binop (pchar '-') ParseAtom ParseExpr |>> Minus <?> "Subtraction"

    let parseExpr = choice [AddParse; SubParse; ParseAtom]

    let NParse   = pint32 |>> Num <?> "Integer"
    let ParParse = parenthesise parseExpr |>> Lookup <?> "Lookup Integer"

    let parseAtom = choice [NParse; ParParse]
    do aref := parseAtom
    do eref := parseExpr

