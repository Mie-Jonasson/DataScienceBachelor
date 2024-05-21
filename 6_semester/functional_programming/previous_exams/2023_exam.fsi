module exam_2023
    type prop

    val eval : prop -> bool

    val negate : prop -> prop
    val implies : prop -> prop -> prop

    val forall : ('a -> prop) -> 'a list -> prop 

    val exists : ('a -> prop) -> 'a list -> prop

    val existsOne : ('a -> prop) -> 'a list -> prop

    ///////////////////////////////////////////////////////////////////////////
    val foo : char list -> char list -> SM<char list>
    val bar : char list -> char list -> char list
    val baz : string -> string -> string list

    val foo2 : char list -> char list -> SM<char list>
    val barTail : char list -> char list -> char list
    val bazTail : string -> string -> string list
    ///////////////////////////////////////////////////////////////////////////
    
    val collatz : int -> int list
    val evenOddCollatz : int -> int * int
    val maxCollatz : int -> int -> int * int
    val collect : int -> int -> Map<int, Set<int>>