module Exam2022
    (* If you are importing this into F# interactive then comment out
    the line above and remove the comment for the line bellow.

    Do note that the project will not compile if you do this, but 
    it does allow you to work in interactive mode and you can just remove the '=' 
    to make the project compile again.

    You will also need to load JParsec.fs. Do this by typing
    #load "JParsec.fs" 
    in the interactive environment. You may need the entire path.

    Do not remove the module declaration (even though that does work) because you may inadvertently
    introduce indentation errors in your code that may be hard to find if you want
    to switch back to project mode. 

    Alternative, keep the module declaration as is, but load ExamInteractive.fsx into the interactive environment
    *)
    (*
    module Exam2022 = 
    *)

    (* 1: Grayscale images *)

    type grayscale =
    | Square of uint8
    | Quad of grayscale * grayscale * grayscale * grayscale
    
    let img = 
      Quad (Square 255uy, 
            Square 128uy, 
            Quad(Square 255uy, 
                 Square 128uy, 
                 Square 192uy,
                 Square 64uy),
            Square 0uy)
    
(* Question 1.1 *)
    let rec countWhite (im: grayscale) : int = 
        match im with
        | Square x      -> if x=255uy then 1 else 0
        | Quad (s1, s2, s3, s4) -> (countWhite s1) + (countWhite s2) + (countWhite s3) + (countWhite s4)
    
(* Question 1.2 *)
    let rec rotateRight (im: grayscale) : grayscale = 
        match im with
        | Square x              -> Square x
        | Quad (s1, s2, s3, s4) -> Quad ((rotateRight s4), (rotateRight s1), (rotateRight s2), (rotateRight s3))

(* Question 1.3 *)
    let rec map (f: uint8 -> grayscale) (im: grayscale) : grayscale = 
        match im with
        | Square x              -> f x
        | Quad (s1, s2, s3, s4) -> Quad ((map f s1), (map f s2), (map f s3), (map f s4))
    
    let bitmap (im: grayscale) : grayscale = map (fun x -> if x > 127uy then Square 255uy else Square 0uy) im

(* Question 1.4 *)

    let fold (f: 'a -> uint8 -> 'a) (acc: 'a) (im: grayscale) : 'a = 
        let rec aux acc im=
            match im with
            | Square x      -> f acc x
            | Quad (s1, s2, s3, s4) -> aux (aux (aux (aux acc s1) s2) s3) s4
        aux acc im
    
    let countWhite2 (im: grayscale) : int = 
        fold (fun acc x -> if x=255uy then (acc+1) else acc) 0 im

(* 2: Code Comprehension *)
    let rec foo =
        function
        | 0 -> ""
        | x when x % 2 = 0 -> foo (x / 2) + "0"
        | x when x % 2 = 1 -> foo (x / 2) + "1"

    let rec bar =
        function
        | []      -> []
        | x :: xs -> (foo x) :: (bar xs)

(* Question 2.1 *)

    (* 
    
    Q: What are the types of functions foo and bar?

    A: foo has type (int -> string), bar has type (int list -> string list)


    Q: What does the function bar do.
       Focus on what it does rather than how it does it.

    A: foo turns an integer into the corresponding bit-string representation, bar applies foo to each integer in a list.
    
    Q: What would be appropriate names for functions 
       foo and bar?

    A: foo : getBitString, bar : getBitStringList
        
    Q: The function foo does not return reasonable results for all possible inputs.
       What requirements must we have on the input to foo in order to get reasonable results?
    
    A: as foo returns the binary representation, the number should be greater than 0
    *)
        

(* Question 2.2 *)

 
    (* 
    The function foo compiles with a warning. 

    
    Q: What warning and why?

    A: Warning indicates that the value '1' might not be properly matched in the function
        This is because there exists only a match for 0 and otherwise conditional matches; 
        thus, the conditions might both be false, the compiler does not know as it is only evaluated at runtime.

    *)

    let rec foo2 =
        function
        | 0                       -> ""
        | x when x % 2 = 0  -> foo (x / 2) + "0"
        | x                 -> foo (x / 2) + "1" // This will always be "the other case" when doing %2 :)

(* Question 2.3 *) 

    let bar2 (lst: int list) = List.map foo2 lst

    
(* Question 2.4 *)

    (*

    Q: Neither foo nor bar is tail recursive. Pick one (not both) of them and explain why.
       To make a compelling argument you should evaluate a function call of the function,
       similarly to what is done in Chapter 1.4 of HR, and reason about that evaluation.
       You need to make clear what aspects of the evaluation tell you that the function is not tail recursive.
       Keep in mind that all steps in an evaluation chain must evaluate to the same value
       ((5 + 4) * 3 --> 9 * 3 --> 27, for instance).

    A: Foo is not tail recursive, as it requires us to keep memorizing an action to be applied AFTER recursive call returns,
        I.e. in the following code snippet: 'foo (x / 2) + "0"' we need to remember the '+ "0"' until we return from the recursive call.
        We do an evaluation to make this more clear for the case of running 'foo 8'
        (1)     foo 8                                       -> goes into case adding "0"
        (2)     (foo 4) + "0"                               -> goes into case adding "0"
        (3)     ((foo 2) + "0") + "0"                       -> goes into case adding "0"
        (4)     (((foo 1) + "0") + "0") + "0"               -> goes into case adding "1"
        (5)     ((((foo 0) + "1") + "0") + "0") + "0"       -> goes into base case
        (6)     ((("" + "1") + "0") + "0") + "0"            -> here we start returning from recursive calls and applying the extra transformation
        (7)     (("1" + "0") + "0") + "0"
        (8)     ("10" + "0") + "0"
        (9)     "100" + "0"
        (10)    "1000"
    
    Q: Even though neither `foo` nor `bar` is tail recursive only one of them runs the risk of overflowing the stack.
       Which one and why does  the other one not risk overflowing the stack?

    A: TODO ??????

    *)
(* Question 2.5 *)

    let fooTail (n: int) = 
        let rec aux (n: int) (acc: string) = 
            match n with
            | 0                       -> acc
            | x when x % 2 = 0  -> aux (x/2) ("0" + acc)
            | x                 -> aux (x/2) ("1" + acc)
        aux n ""

(* Question 2.6 *)
    let barTail (lst: int list) = 
        let rec aux lst c=
            match lst with
            | []        -> c []
            | x :: xs   -> aux xs (fun r -> c((fooTail x) :: r))
        aux lst (fun a -> a)

(* 3: Matrix operations *)

    type matrix = int[,]

    let init f rows cols = Array2D.init rows cols f

    let numRows (m : matrix) = Array2D.length1 m
    let numCols (m : matrix) = Array2D.length2 m

    let get (m : matrix) row col = m.[row, col]
    let set (m : matrix) row col v = m.[row, col] <- v

    let print (m : matrix) =
        for row in 0..numRows m - 1 do
            for col in 0..numCols m - 1 do
                printf "%d\t" (get m row col)
            printfn ""

(* Question 3.1 *)

    let failDimensions (m1: matrix) (m2: matrix) = 
        failwithf "Invalid matrix dimensions: m1 rows = %i, m1 columns = %i, m2 rows = %i, m2 columns = %i" (numRows m1) (numCols m1) (numRows m2) (numCols m2)

(* Question 3.2 *)

    let add (m1: matrix) (m2: matrix) : matrix = 
        if (not ((numRows m1)=(numRows m2))) || (not ((numCols m1)=(numCols m2)))
        then failDimensions m1 m2
        else 
            let getItem i j = (get m1 i j) + (get m2 i j)
            init getItem (numRows m1) (numCols m1)

(* Question 3.3 *)
    
    let m1 = (init (fun i j -> i * 3 + j + 1) 2 3) 
    let m2 = (init (fun j k -> j * 2 + k + 1) 3 2)

    let dotProduct (m1: matrix) (m2: matrix) (r1: int) (c2: int) = 
        let n = numCols m1
        let rec aux acc p =
            match p with
            | x when x=n    -> acc
            | x             -> aux (acc + ((get m1 r1 x)*(get m2 x c2))) (x+1)
        aux 0 0

    let mult (m1: matrix) (m2: matrix) : matrix = 
        if not ((numCols m1)=(numRows m2))
        then failDimensions m1 m2
        else
            init (fun i j -> dotProduct m1 m2 i j) (numRows m1) (numCols m2)

(* Question 3.4 *)
    let setSingleCell f m (i, j) : Async<unit> =
        async {
            set m i j (f i j)
            ()
        }
    
    let asyncInitCells f m: Async<unit []> =
        let each_call = 
            [for i in [0 .. ((numRows m)-1)] do 
                for j in [0 .. ((numCols m)-1)] -> (i,j)] |> List.map (setSingleCell f m)
        Async.Parallel each_call

    let parInit (f: int -> int -> int) (rows: int) (cols: int) : matrix = 
        let m = init (fun _ _ -> 0) rows cols
        let result = Async.RunSynchronously (asyncInitCells f m)
        m

(* 4: Stack machines *)

    type cmd = Push of int | Add | Mult
    type stackProgram = cmd list

(* Question 4.1 *)

    type stack = int list
    let emptyStack _ : stack= List.empty

(* Question 4.2 *)

    let runStackProgram (prog: stackProgram) : int = 
        let stck = emptyStack ()
        let rec aux stck prog =
            match prog with 
            | [] when not ((List.length stck)=0)        -> List.item 0 stck
            | []                                        -> failwith "Empty Stack"
            | x :: xs   -> match x with
                            | Push n  -> aux (n::stck) xs
                            | Add           -> match stck with
                                                | y1::y2::ys        -> aux ((y1+y2)::ys) xs
                                                | _                 -> failwith "Not Enough Items On Stack"
                            | Mult          -> match stck with
                                                | y1::y2::ys        -> aux ((y1*y2)::ys) xs
                                                | _                 -> failwith "Not Enough Items On Stack"
        aux stck prog

(* Question 4.3 *)
    
    type StateMonad<'a> = SM of (stack -> ('a * stack) option)

    let ret x = SM (fun s -> Some (x, s))
    let fail  = SM (fun _ -> None)
    let bind f (SM a) : StateMonad<'b> = 
        SM (fun s -> 
            match a s with 
            | Some (x, s') -> 
                let (SM g) = f x             
                g s'
            | None -> None)
        
    let (>>=) x f = bind f x
    let (>>>=) x y = x >>= (fun _ -> y)

    let evalSM (SM f) = f (emptyStack ())

    let push (x: int) : StateMonad<unit> = SM (fun s -> Some ((), x::s))
    let pop : StateMonad<int> = SM (fun s -> match s with
                                                    | []        -> None
                                                    | x::xs     -> Some (x, xs)
                                    )

(* Question 4.4 *)

    type StateBuilder() =

        member this.Bind(f, x)    = bind x f
        member this.Return(x)     = ret x
        member this.ReturnFrom(x) = x
        member this.Combine(a, b) = a >>= (fun _ -> b)

    let state = new StateBuilder()

    let rec runStackProg2 (prog: stackProgram) : StateMonad<int> = 
        match prog with
        | [] -> pop // Pop gives us top element :)
        | x::xs -> match x with
                    | Push n -> push n >>>= runStackProg2 xs
                    | Add -> pop >>= fun x -> pop >>= fun y -> push (x+y) >>>= runStackProg2 xs
                    | Mult -> pop >>= fun x -> pop >>= fun y -> push (x*y) >>>= runStackProg2 xs
    
(* Question 4.5 *)
    
    open JParsec.TextParser
    let whitespaceChar = satisfy System.Char.IsWhiteSpace <?> "whitespace"
    let spaces              = many whitespaceChar <?> "space"
    let (.>*>.) a b         = (a .>> spaces) .>>. b
    let (.>*>) a b          = a .>*>. b |>> fst // Inspired by how JParsec does it
    let (>*>.) a b          = a .>*>. b |>> snd // Inspired by how JParsec does it

    let parsePush = ((spaces >*>. pstring "PUSH") >*>. pint32) .>*> spaces |>> Push
    let parseAdd = (spaces >*>. pstring "ADD" .>*> spaces) |>> (fun _ -> Add)
    let parseMult = (spaces >*>. pstring "MULT" .>*> spaces) |>> (fun _ -> Mult)

    let parseCmd = parsePush <|> parseAdd <|> parseMult

    let parseStackProg : Parser<stackProgram> = many1 parseCmd