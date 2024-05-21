open exam_2023
open JParsec.TextParser

let p01 = TT
let p02 = FF
let p1 = And(TT, FF)
let p2 = Or(TT, FF)
let p3 = And(Or(TT, And(TT, FF)), TT)
let p4 = And(Or(TT,And(TT,FF)), Or(FF,And(TT,FF)))

// 1.1
printfn "Eval p01: %A" (eval p01)
printfn "Eval p02: %A" (eval p02)
printfn "Eval p1: %A" (eval p1)
printfn "Eval p2: %A" (eval p2)
printfn "Eval p3: %A" (eval p3)
printfn "Eval p4: %A" (eval p4)
printfn ""

// 1.2
printfn "Negate p01: %A" (negate p01)
printfn "Negate p02: %A" (negate p02)
printfn "Negate p1: %A" (negate p1)
printfn "Negate p2: %A" (negate p2)
printfn "Negate p3: %A" (negate p3)
printfn "Negate p4: %A" (negate p4)
printfn ""

printfn "Implies p01 p02 %A" (implies p01 p02)
printfn "Implies p02 p01 %A" (implies p02 p01)
printfn "Implies p3 p4 %A" (implies p3 p4)
printfn ""

// 1.3
let mod2 x = if x % 2 = 0 then TT else FF
printfn "Forall Mod2 on list 0-10: %A" ([0 .. 10] |> forall mod2 |> eval)
printfn "Forall Mod2 on list 0-2-10: %A" ([0 .. 2 .. 10] |> forall mod2 |> eval)
printfn ""

// 1.4
printfn "Exists Mod2 on list 0-10: %A" ([0 .. 10] |> exists mod2 |> eval)
printfn "Exists Mod2 on list 0-2-10: %A" ([0 .. 2 .. 10] |> exists mod2 |> eval)
printfn ""

// 1.5
printfn "Exists One Mod2 on list 0-10: %A" ([1 .. 10] |> existsOne (fun x -> if x % 2 = 0 then TT else FF) |> eval)
printfn "Exists One Mod5 on list 0-10: %A" ([1 .. 10] |> existsOne (fun x -> if x % 5 = 0 then TT else FF) |> eval)
printfn "Exists One Mod6 on list 0-10: %A" ([1 .. 10] |> existsOne (fun x -> if x % 6 = 0 then TT else FF) |> eval)
printfn ""

///////////////////////////////////////////////////////////////////////////////
printfn "Running baz on 'hi you' and 'hi me': %A" (baz "hi you" "hi me")
printfn "Running baz on 'hi me' and 'hi you': %A" (baz "hi me" "hi you")
printfn "Running baz on 'you are cute' and 'i am cute': %A" (baz "you are cute" "i am cute")
printfn "Running baz on 'you are cute' and 'you are': %A" (baz "you are cute" "you are")
printfn "Running baz on 'you are' and 'you are cute': %A" (baz "you are" "you are cute")
printfn "Running baz on 'you are you are you are cute' and 'you are': %A" (baz "you are you are you are cute" "you are")
printfn "Running baz on 'abcabcdabccabcabababaaaabcde' and 'abc': %A" (baz "abcabcdabccabcabababaaaabcde" "abc")
printfn "Running baz on 'abcdeabc' and 'abc': %A" (baz "abcdeabc" "abc")
printfn ""

printfn "Running baz on 'hi you' and 'hi me': %A" (bazTail "hi you" "hi me")
printfn "Running baz on 'hi me' and 'hi you': %A" (bazTail "hi me" "hi you")
printfn "Running baz on 'you are cute' and 'i am cute': %A" (bazTail "you are cute" "i am cute")
printfn "Running baz on 'you are cute' and 'you are': %A" (bazTail "you are cute" "you are")
printfn "Running baz on 'you are' and 'you are cute': %A" (bazTail "you are" "you are cute")
printfn "Running baz on 'you are you are you are cute' and 'you are': %A" (bazTail "you are you are you are cute" "you are")
printfn "Running baz on 'abcabcdabccabcabababaaaabcde' and 'abc': %A" (bazTail "abcabcdabccabcabababaaaabcde" "abc")
printfn "Running baz on 'abcdeabc' and 'abc': %A" (bazTail "abcdeabc" "abc")
printfn ""

///////////////////////////////////////////////////////////////////////////////
// 3.1
printfn "Collatz Sequence for 1: %A" (collatz 1)
printfn "Collatz Sequence for 2: %A" (collatz 2)
printfn "Collatz Sequence for 3: %A" (collatz 3)
printfn "Collatz Sequence for 42: %A" (collatz 42)
// printfn "Collatz Sequence for 1048574: %A" (collatz 1048574) // Has the 'failwith' because it becomes 
printfn ""

// 3.2
printfn "evenOddCollatz Sequence for 1: %A" (evenOddCollatz 1)
printfn "evenOddCollatz Sequence for 2: %A" (evenOddCollatz 2)
printfn "evenOddCollatz Sequence for 3: %A" (evenOddCollatz 3)
printfn "evenOddCollatz Sequence for 77031: %A" (evenOddCollatz 77031)
printfn ""

// 3.3
printfn "maxCollatz Sequence for 1-10: %A" (maxCollatz 1 10)
printfn "maxCollatz Sequence for 100-1000: %A" (maxCollatz 100 1000)
printfn "maxCollatz Sequence for 1000-1000: %A" (maxCollatz 1000 1000)
printfn ""

// 3.4
printfn "Collect Collatz Sequence for 20-30: %A" (collect 20 30)
printfn "Collect Collatz Sequence for 100-110: %A" (collect 100 110)
printfn ""

// 4.1
printfn "test Empty Memory Block: %A" (emptyMem 4)
printfn "test Finding value at address 2: %A" (lookup (emptyMem 4) 2)
printfn "test Assigning Value 7 to adress 2: %A" (assign (emptyMem 4) 2 7)
printfn "test Finding value at address 2: %A" (lookup (assign (emptyMem 4) 2 7) 2)
printfn ""

// 4.2
let test_empty_mem = emptyMem 4
let test_other_mem = assign (emptyMem 5) 2 42
printfn "Test Expression Eval Function for (Num 5): %A" (evalExpr test_other_mem (Num 5))
printfn "Test Expression Eval Function for (Lookup (Num 2)): %A" (evalExpr test_other_mem  (Lookup (Num 2)))
printfn "Test Expression Eval Function for (Plus (Lookup (Num 2), Num 5): %A" (evalExpr test_other_mem (Plus (Lookup (Num 2), Num 5)))
printfn ""

printfn "Test Statement/Program Eval Function for (Assign (Num 4, Num 5)): %A" (evalStmnt test_other_mem (Assign (Num 4, Num 5)))
printfn "Test Statement/Program Eval Function for (fibProg 10): %A" (evalProg test_empty_mem (fibProg 10))
printfn "Test Statement/Program Eval Function for (fibProg 10) with lookup of 2: %A" (lookup (evalProg test_empty_mem (fibProg 10)) 2)
printfn "Test Statement/Program Eval Function for assigning i=i: %A" ([0 .. 3] |> List.map (fun x -> Assign(Num x, Num x)) |> evalProg test_empty_mem)
printfn ""

// 4.3 
let empty_mem = emptyMem 5
printfn "Test Statemonad lookup2 with 2: %A" (lookup2 2 |> evalSM empty_mem |> Option.map fst)
printfn "Test Statemonad lookup2 with -23: %A" (lookup2 -23 |> evalSM empty_mem |> Option.map fst)
printfn "Test Statemonad assign2 with 2-42 followed by lookup at 2: %A" ( assign2 2 42 >>>= lookup2 2 |> evalSM empty_mem |> Option.map fst)
printfn "Test Statemonad assign2 with 2-42 followed by lookup at 4: %A" ( assign2 2 42 >>>= lookup2 4 |> evalSM empty_mem |> Option.map fst)
printfn "Test Statemonad assign2 with 2-42: %A" ( assign2 2 42 |> evalSM empty_mem |> Option.map snd)
printfn ""

// 4.4
printfn "Testing State Monad Expr. Eval of (Num 5): %A" ( (Num 5) |> evalExpr2 |> evalSM test_empty_mem |> Option.map fst)
printfn "Testing State Monad Expr. Eval of lookup at 2: %A" ( Lookup (Num 2) |> evalExpr2 |> evalSM test_other_mem |> Option.map fst)
printfn "Testing State Monad Expr. Eval of addition and lookup: %A" ( Plus (Lookup (Num 2), Num 5) |> evalExpr2 |> evalSM test_other_mem |> Option.map fst)
printfn "Testing State Monad Stmnt. Eval of assign: %A" ( Assign (Num 4, Num 5) |> evalStmnt2 |> evalSM test_other_mem |> Option.map snd)
// printfn "Testing State Monad Prog. Eval of : %A" ( evalProg2 (fibProg 10) |> evalSM test_empty_mem |> Option.map snd)
// printfn "Testing State Monad Prog. Eval of : %A" (  evalProg2 (fibProg 10) >>>= lookup2 2 |> evalSM test_empty_mem |> Option.map fst)
printfn ""

// 4.5
printfn "Testing parser for 5+4 \tGot result: %A" ("5+4" |> run parseExpr |> getSuccess)
printfn "Testing parser for [4+[3]] \tGot result: %A" ("[4+[3]]" |> run parseExpr |> getSuccess)
printfn "Testing parser for [5 + 4] \tGot result: %A" ("[5 + 4]" |> run parseExpr |> getSuccess)