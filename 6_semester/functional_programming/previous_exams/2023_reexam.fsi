module reexam_2023

    type arith

    val eval : arith -> int

    val negate : arith -> arith
    val subtract : arith -> arith -> arith
    val multiply : arith -> arith -> arith
    val pow : arith -> arith -> arith

    val iterate : ('a -> 'a) -> 'a -> arith -> 'a
    val pow2 : arith -> arith -> arith

    // ///////////////////////////////////////////////////////////////////////////
    // val foo : char list -> char list -> SM<char list>
    // val bar : char list -> char list -> char list
    // val baz : string -> string -> string list

    // val foo2 : char list -> char list -> SM<char list>
    // val barTail : char list -> char list -> char list
    // val bazTail : string -> string -> string list
    // ///////////////////////////////////////////////////////////////////////////
    
    // val collatz : int -> int list
    // val evenOddCollatz : int -> int * int
    // val maxCollatz : int -> int -> int * int
    // val collect : int -> int -> Map<int, Set<int>>