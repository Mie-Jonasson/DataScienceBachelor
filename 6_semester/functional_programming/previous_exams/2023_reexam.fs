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