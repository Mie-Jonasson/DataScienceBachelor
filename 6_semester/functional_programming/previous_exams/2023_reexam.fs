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