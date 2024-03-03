module Assignment5

    (* Exercise 5.1 *)

    let sum m n = 
        let rec _sum m n acc =
            match n with
            | 0 -> acc + m
            | k -> _sum m (n-1) (acc+n+m)
        _sum m n 0

    (* Exercise 5.2 *)

    let length lst = 
        let rec _length lst acc =
            match lst with
            | [] -> acc
            | _ :: xs -> _length xs (acc+1)
        _length lst 0

    (* Exercise 5.3 *)

    let foldBack folder lst acc = 
        let rec _foldBack folder lst c =
            match lst with
            | []      -> c acc
            | x :: xs -> _foldBack folder xs (fun r -> c (folder x r))
        _foldBack folder lst (fun a -> a)


    (* Exercise 5.4 *)

    let factA x = // Copied from description
        let rec aux acc =
            function
            | 0 -> acc
            | x -> aux (x * acc) (x - 1)

        aux 1 x

    let factC x = 
        let rec _fact x c acc=
            match x with
            | 0 -> c acc
            | x -> _fact (x-1) (fun r -> c (x * r)) acc
        _fact x (fun a -> a) 1



    (* TODO: *)
    (* Compare the running time between factA and factC. Which solution is faster and why?

    OUTPUT Interactive:
        > factA 1000000;;
        Real: 00:00:00.002, CPU: 00:00:00.000, GC gen0: 0, gen1: 0, gen2: 0
        val it: int = 0

        > factC 1000000;;
        Real: 00:00:00.023, CPU: 00:00:00.031, GC gen0: 0, gen1: 0, gen2: 0
        val it: int = 0

        > factA 10000000;;
        Real: 00:00:00.011, CPU: 00:00:00.015, GC gen0: 0, gen1: 0, gen2: 0
        val it: int = 0

        > factC 10000000;;
        Real: 00:00:00.291, CPU: 00:00:00.734, GC gen0: 1, gen1: 1, gen2: 0
        val it: int = 0

    Reasoning:
        When running for 1M, we see that factC is 10x-11x slower than factA.
        When running for 10M, this difference becomes more pronounced, a factor of 26x-27x.

        This makes sense, as factA is continuously doing the intermediate calculations, while
        factC does all of the calculations at the end. This heavy calculation in the end is slowed
        down because all multiplications we need to do are saved as functions of functions on the heap,
        thus we need to take time retrieving the function form memory and doing the calculation only at the end.
    *)

    (* Exercise 5.5 *)

    let fibW x =
        let mutable res1 = 0
        let mutable res2 = 1
        let mutable i = 1
        while (i <= x) do
            let temp = res1
            res1 <- res2
            res2 <- temp + res2
            i <- i + 1
        res1

    let fibA _ = failwith "not implemented"

    let fibC _ = failwith "not implemented"


    (* TODO: *)
    (* Compare the running time of fibW, fibA and fibC. Which solution is faster and why? 
    <Your answer goes here>

    *)

    (* Exercise 5.6 *)

    let rec bigListK c =
        function
        | 0 -> c []
        | n -> bigListK (fun res -> 1 :: c res) (n - 1)

    (* TODO *)
    (* The call bigListK id 130000 causes a stack overflow. 
    Analyse the problem and describe exactly why this happens. 
    Why is this not an iterative function?
    
    To make a compelling argument (and to prepare for the exam) you must make a step-by-step evalution of a call to
    bigListK. Test correctness of your evaluations by ensuring that they all evaluate to the same value. For example:
    
    (5 + 4) * 3 -->
    9 * 3 -->
    27
    
    If you input any of these lines into FSharp Interactive it will produce the same result. Do the same here and point
    to where you can see that this function is not tail recursive.

    <Your answer goes here>
    *)

    type aExp =
        | N of int
        | V of string
        | WL
        | PV of aExp
        | Add of aExp * aExp
        | Sub of aExp * aExp
        | Mul of aExp * aExp
        | CharToInt of cExp


    and cExp =
    | C  of char  (* Character value *)
    | CV of aExp  (* Character lookup at word index *)
    | ToUpper of cExp
    | ToLower of cExp
    | IntToChar of aExp


    let arithEvalSimple _ = failwith "not implemented"

    let charEvalSimple _ = failwith "not implemented"

    let arithEval _ = failwith "not implemented"
    let charEval _ = failwith "not implemented"