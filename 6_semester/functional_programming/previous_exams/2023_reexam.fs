module reexam_2023

    open JParsec.TextParser  

    // 1
    type arith =
    | Num of int
    | Add of arith * arith

    // 1.1
    let rec eval a = 
        match a with
        | Num x         -> x
        | Add (a1, a2)  -> (eval a1) + (eval a2)

    // 1.2 
    let rec negate a =
        match a with
        | Num x         -> Num (-x)
        | Add (a1, a2)  -> Add((negate a1), (negate a2))
    
    let subtract a1 a2 = Add (a1, (negate a2))

    // 1.3
    let rec multiply a b =
        match a with
        | Num x1        -> match b with
                            | Num x2        -> Num (x1 * x2)
                            | Add (a1, a2)  -> Add ((multiply (Num x1) a1), (multiply (Num x1) a2))
        | Add (a1, a2)  -> Add ((multiply a1 b), (multiply a2 b))
    
    // 1.4 
    let pow a b =
        let rec aux a b acc =
            match (eval b) with
            | 1     -> multiply acc a
            | _     -> aux a (subtract b (Num 1)) (multiply acc a)
        aux a b (Num 1)
    
    // 1.5
    let rec iterate f acc n =
        match (eval n) with
        | 0 -> acc
        | _ -> iterate f (f acc) (subtract n (Num 1))
    
    let pow2 a b =
        let f = multiply a
        iterate f (Num 1) b
    
    ///////////////////////////////////////////////////////////////////////////
    // 2
    let rec foo =
        function
        | 0             -> true
        | x when x > 0  -> bar (x - 1)
        | x             -> bar (x + 1)
    
    and bar =
        function
        | 0             -> false
        | x when x > 0  -> foo (x - 1)
        | x             -> foo (x + 1)
    
    let rec baz =
        function
        | []                    -> [], []
        | x::xs when foo x      -> 
            let ys, zs = baz xs
            (x::ys, zs)
        | x::xs                 ->
            let ys, zs = baz xs
            (ys, x::zs)
    // 2.1
    // Types:
    /// val foo : int -> bool
    /// val bar : int -> bool
    /// val baz : int list -> int list * int list
    // What they do:
    /// foo     Takes an integer and returns true if it is an even number
    /// bar     Takes an integer and returns true if it is an odd number
    /// baz     Takes a single list and iteratively splits it up into a list of even and list of odd numbers: ([even number list], [odd number list])
    // Better Names:
    /// foo     isEven
    /// bar     isOdd
    /// baz     splitEvenOdd
    
    // 2.2
    // Types of Snippets:
    /// (baz xs)    int list * int list     This is a call to the baz function with xs as input
    /// (bar x)     bool                    This is a call to the bar function, which returns whether x is an odd number
    /// (ys, x::zs) int list * int list     This is a tuple with two lists, where the rightmost gets x appended as head
    
    // 2.3
    let foo2 x = x % 2 = 0
    let bar2 x = x % 2 = 1

    let rec baz2 =
        function
        | []                    -> [], []
        | x::xs when foo2 x     -> 
            let ys, zs = baz2 xs
            (x::ys, zs)
        | x::xs                 ->
            let ys, zs = baz2 xs
            (ys, x::zs)

    // 2.4 
    /// baz is not tail recursive. We see this from the structure of the recursive call,
    /// as it requires us to return from the recursive call with a set of values, and then do 
    /// some more processing. We will demonstrate with a small example of the list [0; 1; 2]:
    /// (1)     baz [0; 1; 2]                                              -> (foo 0) returns true  -> f0 l1 l2 = (0::l1, l2)
    /// (2)     f0 ( ys0, zs0 = baz [1; 2] )                               -> (foo 1) returns false -> f1 l1 l2 = (l1, 1::l2)
    /// (3)     f0 ( ys0, zs0 = f1 ( ys1, zs1 = baz [2] ) )                -> (foo 2) returns true  -> f2 l1 l2 = (2::l1, l2)
    /// (4)     f0 ( ys0, zs0 = f1 ( ys1, zs1 = f2 ( ys2, zs2 = baz []) ) )
    /// (6)     f0 ( ys0, zs0 = f1 ( ys1, zs1 = f2 ( ys2, zs2 = [], []) ) )
    /// (7)     f0 ( ys0, zs0 = f1 ( ys1, zs1 = ( 2::[], [] ) ) )
    /// (8)     f0 ( ys0, zs0 = f1 ( ys1, zs1 = ( [2], [] ) ) )
    /// (9)     f0 ( ys0, zs0 = ( [2], 1::[] ) )
    /// (10)    f0 ( ys0, zs0 = ( [2], [1] ) )
    /// (11)    ( 0::[2], [1] )
    /// (12)    ( [0; 2], [1] )
    // Here i wrote it up as functions, to ease the understanding of how 2 items are returned from
    // the baz call and then subsequently used. We see the alck of tail recursion in how we need to remember
    // that the item x we are handling shall be added as head of a certain list once we return from baz

    let bazTail x =
        let rec aux l c =
            // printfn "Intermediate AUX call with %A and %A" l c
            match l with
            | []                    -> c [] []
            | x::xs when foo2 x     -> 
                aux xs (fun l1 l2 -> c (x::l1) l2)
            | x::xs                 ->
                aux xs (fun l1 l2 -> c l1 (x::l2))
        aux x (fun a b -> (a, b))
    
    ///////////////////////////////////////////////////////////////////////////
    // 3
    let explode (str : string) = [for c in str -> c]
    let implode (lst : char list) = lst |> List.toArray |> System.String

    // 3.1
    // let openings    = ['{'; '('; '[']
    let closing     = Map.ofList [('{','}'); ('(',')'); ('[',']')]
    
    let balanced (str : string) =
        let char_list = explode str

        let rec aux lst stck =
            match lst with
            | []                                    -> match stck with
                                                        | []    -> true // If stack is empty at end of charlist -> terminate true
                                                        | _     -> false
            | x::xs when Map.containsKey x closing  -> aux xs ((Map.find x closing)::stck) // call with remainder of charlist and append corresponding closing bracket to head of stack
            | x::xs                                 -> match stck with
                                                        | []                -> false // Return false if stack is empty
                                                        | y::ys when y=x    -> aux xs ys // call with remainder of charlist and remainder of stack if item popped is equal
                                                        | _                 -> false // if items are not equal, return false
        aux char_list []

    // 3.2
    let balanced2 (m : Map<char, char>) (str : string) =
        let char_list = explode str

        let rec aux lst stck =
            match lst with
            | []                                    -> match stck with
                                                        | []    -> true // If stack is empty at end of charlist -> terminate true
                                                        | _     -> false
            | x::xs when Map.containsKey x m        -> match stck with
                                                        | y::ys when y=x    -> (aux xs ys) or (aux xs ((Map.find x m)::stck)) // we have option both to add to stack or pop from stack.... we have to try both alleys!
                                                        | _                 -> aux xs ((Map.find x m)::stck) // call with remainder of charlist and append corresponding closing bracket to head of stack
            | x::xs                                 -> match stck with
                                                        | []                -> false // Return false if stack is empty
                                                        | y::ys when y=x    -> aux xs ys // call with remainder of charlist and remainder of stack if item popped is equal
                                                        | _                 -> false // if items are not equal, return false
        aux char_list []
    
    // 3.3
    let balanced3 str =
        balanced2 closing str
    
    let symmetric str =
        let char_list = explode str |> List.map System.Char.ToLower |> List.filter System.Char.IsLetter |> implode
        let mapping = ['a' .. 'z'] |> List.map (fun x -> (x, x)) |> Map.ofList
        balanced2 mapping char_list

    // 3.4 TODO : Dont knwo how to get this to work
    // let parseBalanced, bref = createParserForwardedToRef<unit>()

    // let parseOpen = satisfy (fun x -> Map.containsKey x closing) <?> "Parse Opening"
    // // let parseClsoing n = satisfy (fun x -> x = n) <?> "Parse Closing"

    // let rec parseBalancedAux stck = 
    //     match parseOpen with
    //     | Success (o, xs)       -> parseBalancedAux ((Map.find o closing)::stck)// Parse opening bracket
    //     | Failure _             -> match stck with // If not opening, then examine stack
    //                                 | []            -> Failure (ParseError.mkParseError "balanced" "" "Input not Balanced") // If stack is empty, not balanced
    //                                 | x::stck_rest  -> match pchar x with // If stack is non-empty then attempt to parse head of stack
    //                                                     | Success (c, ys)       -> parseBalancedAux stck_rest
    //                                                     | Failure _             -> Failure (ParseError.mkParseError "balanced" "" "Input not Balanced") // If could not parse head of stack, not balanced

    // do bref := (parseBalancedAux)

    // let parseBalanced = (parseBalancedAux []) .>> pstring "**END**"

    // 3.5 
    let rec countBalancedIn lst acc =
        match lst with
        | []    -> acc
        | x::xs -> match (balanced x) with
                    | true      -> countBalancedIn xs (acc+1) // increase if x is balanced
                    | false     -> countBalancedIn xs acc

    let asynCountBalanced lst : Async<int> =
        async {return (countBalancedIn lst 0)}
    
    let asyncCountBalancedAll lst x : Async<int []> =
        let each_call = lst |> List.splitInto x |> List.map (fun l -> asynCountBalanced l)
        Async.Parallel each_call
    
    let countBalanced lst x =
        let thread_out = Async.RunSynchronously (asyncCountBalancedAll lst x)
        Array.sum thread_out

    ///////////////////////////////////////////////////////////////////////////
    // 4
    type var = string

    type expr =
    | Numx      of int
    | Lookup    of var
    | Plus      of expr * expr
    | Minus     of expr * expr

    type stmnt =
    | If        of expr * uint32    // conditional jump to line number
    | Let       of var * expr       // Variable update / declaration
    | Goto      of uint32           // Jump to line number
    | End                           // Terminate Program

    type prog = (uint32 * stmnt) list // Programs are sequences of line numbers and commands

    let (.+.) e1 e2 = Plus (e1, e2)
    let (.-.) e1 e2 = Minus (e1, e2)

    let fibProg xarg =  
        [(10u, Let("x",    Numx xarg))                         // x = xarg
         (20u, Let("acc1", Numx 1))                            // acc1 = 1
         (30u, Let("acc2", Numx 0))                            // acc2 = 0
         
         (40u, If(Lookup "x", 60u))                           // if x > 0 then goto 60 (start loop)
         
         (50u, Goto 110u)                                     // Goto 110 (x = 0, terminate program)
         
         (60u, Let ("x", Lookup "x" .-. Numx 1))               // x = x - 1
         (70u, Let ("result", Lookup "acc1"))                 // result = acc1
         (80u, Let ("acc1", Lookup "acc1" .+. Lookup "acc2")) // acc1 = acc1 + acc2
         (90u, Let ("acc2", Lookup "result"))                 // acc2 = result
         (100u, Goto 40u)                                     // Goto 40u (go to top of loop)
         
         (110u, End)                                          // Terminate program
                                                              // the variable result contains the
                                                              // fibonacci number of xarg
         ]

    // 4.1
    type basicProgram = Map<uint32, stmnt>

    let mkBasicProgram (p: prog) : basicProgram                = Map.ofList p
    let getStmnt (i: uint32) (bp: basicProgram) : stmnt        = Map.find i bp
    let nextLine (i: uint32) (bp: basicProgram) : uint32       = Map.keys bp |> Seq.filter (fun x -> x > i) |> Seq.item 0
    let firstLine (bp: basicProgram) : uint32                  = Map.minKeyValue bp |> fst

    // 4.2
    type state = (uint32 * Map<var, int>)
    let emptyState (bp: basicProgram) : state                   = ((firstLine bp), Map.empty)
    let goto (i: uint32) (st: state) : state                    = (i, (snd st))
    let getCurrentStmnt (bp: basicProgram) (st: state) : stmnt  = getStmnt (fst st) bp
    let update (v: var) (i: int) (st: state) : state            = ((fst st), (Map.add v i (snd st)))
    let lookup (v: var) (st: state) : int                       = Map.find v (snd st)

    // 4.3 
    let rec evalExpr (e: expr) (st: state) : int =
        match e with
        | Numx x            -> x
        | Lookup v          -> lookup v st
        | Plus (e1, e2)     -> (evalExpr e1 st) + (evalExpr e2 st)
        | Minus (e1, e2)    -> (evalExpr e1 st) - (evalExpr e2 st)
    
    let step (bp: basicProgram) (st: state) : state = (nextLine (fst st) bp, (snd st))

    let evalProg (bp: basicProgram) : state     =
        let rec aux (st: state) =
            match (getCurrentStmnt bp st) with
            | If (e, l) when not ((evalExpr e st) = 0)  -> aux (goto l st)
            | If (_, _)                                 -> aux (step bp st)
            | Let (v, e)                                -> 
                let tmp = evalExpr e st
                let st' = update v tmp st
                aux (step bp st')
            | Goto l                                    -> aux (goto l st)
            | End                                       -> st
        aux (emptyState bp)
        
    // 4.4
    type StateMonad<'a> = SM of (basicProgram -> state -> 'a * state)  
      
    let ret x = SM (fun _ s -> (x, s))
    
    let bind f (SM a) : StateMonad<'b> =   
        SM (fun p s ->
            let x, s' = a p s
            let (SM g) = f x
            g p s')
          
    let (>>=) x f = bind f x  
    let (>>>=) x y = x >>= (fun _ -> y)  
      
    let evalSM p (SM f) = f p (emptyState p)

    let goto2 (i: uint32) : StateMonad<unit>                    = SM (fun _ s -> goto i s               |> fun s'   -> ((), s'))
    let getCurrentStmnt2 : StateMonad<stmnt>                    = SM (fun p s -> getCurrentStmnt p s    |> fun stm  -> (stm, s))
    let update2 (v: var) (i: int) : StateMonad<unit>            = SM (fun _ s -> update v i s           |> fun s'   -> ((), s'))
    let lookup2 (v: var) : StateMonad<int>                      = SM (fun _ s -> lookup v s             |> fun i    -> (i, s))
    let step2 : StateMonad<unit>                                = SM (fun p s -> step p s               |> fun s'   -> ((), s'))

    // 4.5 TODO : evalProg2
    let rec evalExpr2 (e: expr) : StateMonad<int> =
        match e with 
        | Numx x            -> ret x
        | Lookup v          -> lookup2 v
        | Plus (e1, e2)     -> (evalExpr2 e1) >>= fun x -> (evalExpr2 e2) >>= fun y -> ret (x + y)
        | Minus (e1, e2)    -> (evalExpr2 e1) >>= fun x -> (evalExpr2 e2) >>= fun y -> ret (x - y)
    
    // let evalProg (bp: basicProgram) : state     =
    //     let rec aux (st: state) =
    //         match (getCurrentStmnt bp st) with
    //         | If (e, l) when not ((evalExpr e st) = 0)  -> aux (goto l st)
    //         | If (_, _)                                 -> aux (step bp st)
    //         | Let (v, e)                                -> 
    //             let tmp = evalExpr e st
    //             let st' = update v tmp st
    //             aux (step bp st')
    //         | Goto l                                    -> aux (goto l st)
    //         | End                                       -> st
    //     aux (emptyState bp)

    let rec evalProg2 : StateMonad<unit> = // I am not sure where i went wrong here, i tried to do it similarly to the previous but could not get it to run :-/
        getCurrentStmnt2 >>= fun x ->
            match x with
            | If (e, l)                                 -> (evalExpr2 e) >>= fun y -> 
                                                                            match y with
                                                                            | 0             -> step2 >>>= evalProg2    
                                                                            | _             -> goto2 l >>>= evalProg2
            | Let (v, e)                                -> (evalExpr2 e) >>= update2 v >>>= evalProg2
            | Goto l                                    -> goto2 l >>>= evalProg2
            | End                                       -> ret ()