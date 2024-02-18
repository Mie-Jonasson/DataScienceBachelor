module Assignment1

    open System
    
    let sqr x = x * x

    let pow x n = System.Math.Pow(x, n)
    
    let rec sum n = 
        match n with 
        | 0 -> 0 
        | n -> n + sum(n-1)

    let rec fib n = 
        match n with
        | 0 -> 0
        | 1 -> 1
        | n -> fib(n-1) + fib(n-2)

    let dup s : string = s + s

    let rec dupn s n = String.replicate n s

    let timediff (t1h, t1m) (t2h, t2m) = 60 * (t2h-t1h) + (t2m-t1m)

    let minutes (hh, mm) = timediff (0,0) (hh, mm)

    let rec bin (n : int, k : int) : int = 
        if k = n then 1 else
        match k with
        | 0 -> 1
        | k -> bin(n-1, k-1) + bin(n-1, k)

    let curry f a b = f (a, b)
    let uncurry f (a, b) = f a b

    let empty (letter: char, pointvalue: int) pos = (letter, pointvalue)

    let add newPos cv word pos = if pos = newPos then cv else word pos

    let singleLetterScore word pos = 
        let char, p = word pos 
        p * 1
    let doubleLetterScore word pos = 
        let char, p = word pos 
        p * 2
    let trippleLetterScore word pos = 
        let char, p = word pos 
        p * 3

    let hello = 
        empty ('H', 4)
        |> add 1 ('E', 1)
        |> add 2 ('L', 1)
        |> add 3 ('L', 1)
        |> add 4 ('O', 1)