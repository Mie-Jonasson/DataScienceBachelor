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
    
    val foo : int -> bool
    val bar : int -> bool
    val baz : int list -> int list * int list