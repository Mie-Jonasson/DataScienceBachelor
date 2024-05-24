open System
open Exam2022
open JParsec.TextParser
let testQ1 () =
    (* Testsfor Q1.1 *)
    printfn "Testing Question 1.1"
    printfn "Grey Square: %A" (countWhite (Square 123uy))
    printfn "White Square: %A" (countWhite (Square 255uy))
    printfn "Img: %A" (countWhite img)
    printfn ""
    
    (* Testsfor Q1.2 *)
    printfn "Testing Question 1.2"
    printfn "Grey Square: %A" (rotateRight (Square 123uy))
    printfn "White Square: %A" (rotateRight (Square 255uy))
    printfn "Quad of squares: %A" (rotateRight (Quad(Square 0uy, Square 85uy, Square 170uy, Square 255uy)))
    printfn "Img: %A" (rotateRight img)
    printfn ""

    (* Testsfor Q1.3 *)
    printfn "Testing Question 1.3"
    printfn "Increase on Black Square: %A" (map (fun x -> Square (x+10uy)) (Square 0uy))
    printfn "Increase on Quad of squares: %A" (map (fun x -> Square (x+10uy)) (Quad(Square 0uy, Square 85uy, Square 170uy, Square 255uy)))
    printfn "Quad on Grey Square: %A" (map (fun x -> Quad (Square (x+10uy), Square (x+20uy), Square (x+30uy), Square (x+40uy))) (Square 123uy))
    printfn ""
    printfn "Bitmap on dark grey: %A" (bitmap (Square 120uy))
    printfn "Bitmap on light grey: %A" (bitmap (Square 150uy))
    printfn "Bitmap on img: %A" (bitmap img)
    printfn ""

    (* Testsfor Q1.4 *)
    printfn "Testing Question 1.4"
    printfn "folding grey square: %A" (fold (fun acc x -> acc + int x) 0 (Square 123uy)) 
    printfn "folding Quad of squares: %A" (fold (fun acc x -> acc + int x) 0 (Quad(Square 0uy, Square 85uy, Square 170uy, Square 255uy))) 
    printfn "folding img: %A" (fold (fun acc x -> acc + int x) 0 img) 
    printfn "Count White Grey Square: %A" (countWhite2 (Square 123uy))
    printfn "Count White White Square: %A" (countWhite2 (Square 255uy))
    printfn "Count White Img: %A" (countWhite2 img)
    printfn ""
    ()

let testQ2 () =
    printfn "Testing Question 2"
    printfn "Foo on 1: %A" (foo 1)
    printfn "Foo on 8: %A" (foo 8)
    printfn "Foo on 200: %A" (foo 200)
    printfn "bar on [1; 8; 200]: %A" (bar [1;8;200])
    printfn ""
    printfn "Foo2 on 1: %A" (foo2 1)
    printfn "Foo2 on 8: %A" (foo2 8)
    printfn "Foo2 on 200: %A" (foo2 200)
    printfn "bar2 on [1; 8; 200]: %A" (bar2 [1;8;200])
    printfn ""
    printfn "FooTail on 1: %A" (fooTail 1)
    printfn "FooTail on 8: %A" (fooTail 8)
    printfn "FooTail on 200: %A" (fooTail 200)
    printfn "barTail on [1; 8; 200]: %A" (barTail [1;8;200])
    printfn ""
    ()

let testQ3 () =
    printfn "Testing Question 3"
    // let m1 = init (fun _ _ -> 0) 3 4
    // let m2 = init (fun _ _ -> 1) 8 9
    let m3 = init (fun x y -> x+y) 2 3
    let m4 = init (fun x y -> x*y) 2 3
    // failDimensions m1 m2 // Debug failure
    printfn "Adding m3 and m4:\n%A" (add m3 m4)
    printfn "dotProduct m1 and m2 row 0 col 1: %A" (dotProduct m1 m2 0 1)
    printfn "dotProduct m1 and m2 row 1 col 0: %A" (dotProduct m1 m2 1 0)
    printfn "multiplication of m1 and m2:\n%A" (mult m1 m2)
    printfn "multiplication of m2 and m1:\n%A" (mult m2 m1)
    printfn "Testing parallel init:\n%A" (parInit (fun i j -> i * 3 + j + 1) 2 3)
    ()

let testQ4 () =
    printfn "Testing Question 4"
    printfn "Testing runnign stack programme push: %A" (runStackProgram [Push 5])
    printfn "Testing runnign stack programme push, add, mult: %A" (runStackProgram [Push 5; Push 4; Add; Push 8; Mult])
    printfn "Testing runnign stack programme push, add, mult: %A" (runStackProgram [Push 5; Push 4; Add; Push 8; Mult; Push 42; Add])
    // printfn "Testing runnign failing stack programme push, add, mult: %A" (runStackProgram [Push 5; Push 4; Add; Push 8; Mult; Add])
    // printfn "Testing runnign failing empty stack programme: %A" (runStackProgram [])
    printfn "Testing Monadic push and pop: %A" (push 5 >>>= push 6 >>>= pop |> evalSM)
    printfn "Testing Monadic pop on empty: %A" (pop |> evalSM)
    printfn "Testing Monadic program run of push: %A" ([Push 5] |> runStackProg2 |> evalSM |> Option.map fst)
    printfn "Testing Monadic program run of push, add and mult: %A" ([Push 5; Push 4; Add; Push 8; Mult] |> runStackProg2 |> evalSM |> Option.map fst)
    printfn "Testing Monadic program run of push, add and mult: %A" ([Push 5; Push 4; Add; Push 8; Mult; Push 42; Add] |> runStackProg2 |> evalSM |> Option.map fst)
    printfn "Testing Monadic program run failing on empty stack: %A" ([Push 5; Push 4; Add; Push 8; Mult; Add] |> runStackProg2 |> evalSM |> Option.map fst)
    printfn "Testing Monadic program run failing on empty programme: %A" ([] |> runStackProg2 |> evalSM |> Option.map fst)

    printfn "Printing Program Parser: %A" ("PUSH 5\nPUSH  4     \nADD  \n    PUSH     8\nMULT     \n" |> run parseStackProg |> getSuccess |> runStackProg2 |> evalSM |> Option.map fst)
    ()

[<EntryPoint>]
let main argv =
    testQ1 ()
    testQ2 ()
    testQ3 ()
    testQ4 ()
    0 // return an integer exit code
