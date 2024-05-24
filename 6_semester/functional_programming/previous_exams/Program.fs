open JParsec.TextParser

// printfn "======================================================================="
// printfn "============================== EXAM 2023 =============================="
// printfn "======================================================================="
// open exam_2023

// let p01 = TT
// let p02 = FF
// let p1 = And(TT, FF)
// let p2 = Or(TT, FF)
// let p3 = And(Or(TT, And(TT, FF)), TT)
// let p4 = And(Or(TT,And(TT,FF)), Or(FF,And(TT,FF)))

// // 1.1
// printfn "Eval p01: %A" (eval p01)
// printfn "Eval p02: %A" (eval p02)
// printfn "Eval p1: %A" (eval p1)
// printfn "Eval p2: %A" (eval p2)
// printfn "Eval p3: %A" (eval p3)
// printfn "Eval p4: %A" (eval p4)
// printfn ""

// // 1.2
// printfn "Negate p01: %A" (negate p01)
// printfn "Negate p02: %A" (negate p02)
// printfn "Negate p1: %A" (negate p1)
// printfn "Negate p2: %A" (negate p2)
// printfn "Negate p3: %A" (negate p3)
// printfn "Negate p4: %A" (negate p4)
// printfn ""

// printfn "Implies p01 p02 %A" (implies p01 p02)
// printfn "Implies p02 p01 %A" (implies p02 p01)
// printfn "Implies p3 p4 %A" (implies p3 p4)
// printfn ""

// // 1.3
// let mod2 x = if x % 2 = 0 then TT else FF
// printfn "Forall Mod2 on list 0-10: %A" ([0 .. 10] |> forall mod2 |> eval)
// printfn "Forall Mod2 on list 0-2-10: %A" ([0 .. 2 .. 10] |> forall mod2 |> eval)
// printfn ""

// // 1.4
// printfn "Exists Mod2 on list 0-10: %A" ([0 .. 10] |> exists mod2 |> eval)
// printfn "Exists Mod2 on list 0-2-10: %A" ([0 .. 2 .. 10] |> exists mod2 |> eval)
// printfn ""

// // 1.5
// printfn "Exists One Mod2 on list 0-10: %A" ([1 .. 10] |> existsOne (fun x -> if x % 2 = 0 then TT else FF) |> eval)
// printfn "Exists One Mod5 on list 0-10: %A" ([1 .. 10] |> existsOne (fun x -> if x % 5 = 0 then TT else FF) |> eval)
// printfn "Exists One Mod6 on list 0-10: %A" ([1 .. 10] |> existsOne (fun x -> if x % 6 = 0 then TT else FF) |> eval)
// printfn ""

// ///////////////////////////////////////////////////////////////////////////////
// printfn "Running baz on 'hi you' and 'hi me': %A" (baz "hi you" "hi me")
// printfn "Running baz on 'hi me' and 'hi you': %A" (baz "hi me" "hi you")
// printfn "Running baz on 'you are cute' and 'i am cute': %A" (baz "you are cute" "i am cute")
// printfn "Running baz on 'you are cute' and 'you are': %A" (baz "you are cute" "you are")
// printfn "Running baz on 'you are' and 'you are cute': %A" (baz "you are" "you are cute")
// printfn "Running baz on 'you are you are you are cute' and 'you are': %A" (baz "you are you are you are cute" "you are")
// printfn "Running baz on 'abcabcdabccabcabababaaaabcde' and 'abc': %A" (baz "abcabcdabccabcabababaaaabcde" "abc")
// printfn "Running baz on 'abcdeabc' and 'abc': %A" (baz "abcdeabc" "abc")
// printfn ""

// printfn "Running baz on 'hi you' and 'hi me': %A" (bazTail "hi you" "hi me")
// printfn "Running baz on 'hi me' and 'hi you': %A" (bazTail "hi me" "hi you")
// printfn "Running baz on 'you are cute' and 'i am cute': %A" (bazTail "you are cute" "i am cute")
// printfn "Running baz on 'you are cute' and 'you are': %A" (bazTail "you are cute" "you are")
// printfn "Running baz on 'you are' and 'you are cute': %A" (bazTail "you are" "you are cute")
// printfn "Running baz on 'you are you are you are cute' and 'you are': %A" (bazTail "you are you are you are cute" "you are")
// printfn "Running baz on 'abcabcdabccabcabababaaaabcde' and 'abc': %A" (bazTail "abcabcdabccabcabababaaaabcde" "abc")
// printfn "Running baz on 'abcdeabc' and 'abc': %A" (bazTail "abcdeabc" "abc")
// printfn ""

// ///////////////////////////////////////////////////////////////////////////////
// // 3.1
// printfn "Collatz Sequence for 1: %A" (collatz 1)
// printfn "Collatz Sequence for 2: %A" (collatz 2)
// printfn "Collatz Sequence for 3: %A" (collatz 3)
// printfn "Collatz Sequence for 42: %A" (collatz 42)
// // printfn "Collatz Sequence for 1048574: %A" (collatz 1048574) // Has the 'failwith' because it becomes 
// printfn ""

// // 3.2
// printfn "evenOddCollatz Sequence for 1: %A" (evenOddCollatz 1)
// printfn "evenOddCollatz Sequence for 2: %A" (evenOddCollatz 2)
// printfn "evenOddCollatz Sequence for 3: %A" (evenOddCollatz 3)
// printfn "evenOddCollatz Sequence for 77031: %A" (evenOddCollatz 77031)
// printfn ""

// // 3.3
// printfn "maxCollatz Sequence for 1-10: %A" (maxCollatz 1 10)
// printfn "maxCollatz Sequence for 100-1000: %A" (maxCollatz 100 1000)
// printfn "maxCollatz Sequence for 1000-1000: %A" (maxCollatz 1000 1000)
// printfn ""

// // 3.4
// printfn "Collect Collatz Sequence for 20-30: %A" (collect 20 30)
// printfn "Collect Collatz Sequence for 100-110: %A" (collect 100 110)
// printfn ""

// // 3.5
// printfn "Parallel Max Collats 1-1001 in 10 threads %A" (parallelMaxCollatz 1 1001 10)
// printfn "Parallel Max Collats 1-1001 in 100 threads %A" (parallelMaxCollatz 1 1001 100)
// printfn "Parallel Max Collats 1-1001 in 20 threads %A" (parallelMaxCollatz 1 1001 20)
// printfn "Parallel Max Collats 1-1001 in 200 threads %A" (parallelMaxCollatz 1 1001 200)
// printfn ""

// ///////////////////////////////////////////////////////////////////////////////
// // 4.1
// printfn "test Empty Memory Block: %A" (emptyMem 4)
// printfn "test Finding value at address 2: %A" (lookup (emptyMem 4) 2)
// printfn "test Assigning Value 7 to adress 2: %A" (assign (emptyMem 4) 2 7)
// printfn "test Finding value at address 2: %A" (lookup (assign (emptyMem 4) 2 7) 2)
// printfn ""

// // 4.2
// let test_empty_mem = emptyMem 4
// let test_other_mem = assign (emptyMem 5) 2 42
// printfn "Test Expression Eval Function for (Num 5): %A" (evalExpr test_other_mem (Num 5))
// printfn "Test Expression Eval Function for (Lookup (Num 2)): %A" (evalExpr test_other_mem  (Lookup (Num 2)))
// printfn "Test Expression Eval Function for (Plus (Lookup (Num 2), Num 5): %A" (evalExpr test_other_mem (Plus (Lookup (Num 2), Num 5)))
// printfn ""

// printfn "Test Statement/Program Eval Function for (Assign (Num 4, Num 5)): %A" (evalStmnt test_other_mem (Assign (Num 4, Num 5)))
// printfn "Test Statement/Program Eval Function for (fibProg 10): %A" (evalProg test_empty_mem (fibProg 10))
// printfn "Test Statement/Program Eval Function for (fibProg 10) with lookup of 2: %A" (lookup (evalProg test_empty_mem (fibProg 10)) 2)
// printfn "Test Statement/Program Eval Function for assigning i=i: %A" ([0 .. 3] |> List.map (fun x -> Assign(Num x, Num x)) |> evalProg test_empty_mem)
// printfn ""

// // 4.3 
// let empty_mem = emptyMem 5
// printfn "Test Statemonad lookup2 with 2: %A" (lookup2 2 |> evalSM empty_mem |> Option.map fst)
// printfn "Test Statemonad lookup2 with -23: %A" (lookup2 -23 |> evalSM empty_mem |> Option.map fst)
// printfn "Test Statemonad assign2 with 2-42 followed by lookup at 2: %A" ( assign2 2 42 >>>= lookup2 2 |> evalSM empty_mem |> Option.map fst)
// printfn "Test Statemonad assign2 with 2-42 followed by lookup at 4: %A" ( assign2 2 42 >>>= lookup2 4 |> evalSM empty_mem |> Option.map fst)
// printfn "Test Statemonad assign2 with 2-42: %A" ( assign2 2 42 |> evalSM empty_mem |> Option.map snd)
// printfn ""

// // 4.4
// printfn "Testing State Monad Expr. Eval of (Num 5): %A" ( (Num 5) |> evalExpr2 |> evalSM test_empty_mem |> Option.map fst)
// printfn "Testing State Monad Expr. Eval of lookup at 2: %A" ( Lookup (Num 2) |> evalExpr2 |> evalSM test_other_mem |> Option.map fst)
// printfn "Testing State Monad Expr. Eval of addition and lookup: %A" ( Plus (Lookup (Num 2), Num 5) |> evalExpr2 |> evalSM test_other_mem |> Option.map fst)
// printfn "Testing State Monad Stmnt. Eval of assign: %A" ( Assign (Num 4, Num 5) |> evalStmnt2 |> evalSM test_other_mem |> Option.map snd)
// printfn "Testing State Monad Prog. Eval of : %A" ( evalProg2 (fibProg 10) |> evalSM test_empty_mem |> Option.map snd)
// printfn "Testing State Monad Prog. Eval of : %A" (  evalProg2 (fibProg 10) >>>= lookup2 2 |> evalSM test_empty_mem |> Option.map fst)
// printfn ""

// // 4.5
// printfn "Testing parser for 5+4 \tGot result: %A" ("5+4" |> run parseExpr |> getSuccess)
// printfn "Testing parser for [4+[3]] \tGot result: %A" ("[4+[3]]" |> run parseExpr |> getSuccess)
// printfn "Testing parser for [5 + 4] \tGot result: %A" ("[5 + 4]" |> run parseExpr |> getSuccess)
// printfn ""



printfn "======================================================================="
printfn "============================= REEXAM 2023 ============================="
printfn "======================================================================="
open reexam_2023

// 1
let p1 = Num 42
let p2 = Add (Num 5, Num 3)
let p3 = Add (Add(Num 5, Num 3), Add(Num 7, Num (-9)))

// 1.1
printfn "Evaluating Arith p1: %A" (eval p1)
printfn "Evaluating Arith p2: %A" (eval p2)
printfn "Evaluating Arith p3: %A" (eval p3)
printfn ""

// 1.2
printfn "Negating p1: %A" (negate p1)
printfn "Negating p2: %A" (negate p2)
printfn "Negating p3: %A" (negate p3)
printfn "Subtracting p2 from p1: %A" (subtract p1 p2)
printfn "Subtracting p3 from p2: %A" (subtract p2 p3)
printfn "Subtracting p1 from p3: %A" (subtract p3 p1)
printfn "Evaluating subtracting p1 from p3: %A" (eval (subtract p3 p1))
printfn ""

// 1.3
printfn "Multiplying p1 with p1: %A" (multiply p1 p1)
printfn "Multiplying p2 with p2: %A" (multiply p2 p2)
printfn "Multiplying p3 with p3: %A" (multiply p3 p3)
printfn "evaluating multiplying p3 with p3: %A" (eval (multiply p3 p3))
printfn ""

// 1.4
printfn "Finding 2 to the power of 8: %A" (pow (Num 2) (Num 8))
printfn "Finding p2 to the power of 3: %A" (pow p2 (Num 3))
printfn "Evaluating finding p2 to the power of 3: %A" (eval (pow p2 (Num 3)))
printfn ""

// 1.5
printfn "Iterating negate on p1, p2 times: %A" (iterate negate p1 p2)
printfn "Iterating negate on p1, (p2-1) times: %A" (iterate negate p1 (subtract p2 (Num 1)))
printfn "Finding 2 to the power of 8 NON-RECURSIVE: %A" (pow (Num 2) (Num 8))
printfn "Evaluating finding p2 to the power of 3 NON-RECURSIVE: %A" (eval (pow p2 (Num 3)))
printfn ""

///////////////////////////////////////////////////////////////////////////////
// 2
printfn "Testing foo with 0: %A" (foo 0)
printfn "Testing foo with 3: %A" (foo 3)
printfn "Testing foo with 6: %A" (foo 6)
printfn "Testing bar with 6: %A" (bar 0)
printfn "Testing bar with 6: %A" (bar 3)
printfn "Testing bar with 6: %A" (bar 6)
printfn "Testing baz with [0 .. 10]: %A" (baz [0 .. 10])
printfn "Testing baz with [3 .. 17]: %A" (baz [3 .. 17])
printfn ""
printfn "Testing foo2 with 0: %A" (foo2 0)
printfn "Testing foo2 with 3: %A" (foo2 3)
printfn "Testing foo2 with 6: %A" (foo2 6)
printfn "Testing bar2 with 6: %A" (bar2 0)
printfn "Testing bar2 with 6: %A" (bar2 3)
printfn "Testing bar2 with 6: %A" (bar2 6)
printfn "Testing baz2 with [0 .. 10]: %A" (baz2 [0 .. 10])
printfn "Testing baz2 with [3 .. 17]: %A" (baz2 [3 .. 17])
printfn ""
printfn "Testing bazTail with [0 .. 10]: %A" (bazTail [0 .. 10])
printfn "Testing bazTail with [3 .. 17]: %A" (bazTail [3 .. 17])
printfn ""

///////////////////////////////////////////////////////////////////////////////
// 3

let b1 = "()"
let b2 = "(){([])}"
let b3 = "(){([])}("

// 3.1
printfn "Testing Balanced on b1: %A" (balanced b1)
printfn "Testing Balanced on b2: %A" (balanced b2)
printfn "Testing Balanced on b3: %A" (balanced b3)
printfn ""

// 3.2
printfn "Testing Balanced 2 with arbitrary delimiters on abcb: %A" (balanced2 (Map.ofList [('a', 'b'); ('b', 'c')]) "abcb")
printfn "Testing Balanced 2 with arbitrary delimiters on abacb: %A" (balanced2 (Map.ofList [('a', 'b'); ('b', 'c')]) "abacb")
printfn ""

// 3.3
printfn "Testing Balanced 3 on b1: %A" (balanced3 b1)
printfn "Testing Balanced 3 on b2: %A" (balanced3 b2)
printfn "Testing Balanced 3 on b3: %A" (balanced3 b3)
printfn ""
printfn "Testing Symmetric on aabbaa: %A" (symmetric "aabbaa")
printfn "Testing Symmetric on '': %A" (symmetric "")
printfn "Testing Symmetric on Dromedaren Alpotto planerade mord!!!: %A" (symmetric "Dromedaren Alpotto planerade mord!!!")
printfn "Testing Symmetric on Dromedaren Alpotto skadar ingen: %A" (symmetric "Dromedaren Alpotto skadar ingen")
printfn ""

// 3.4
// printfn "Tetsing ParseBalanced: %A" (parseBalanced "{([]())}{}**END**")

// 3.5
let lst = [for i in 1..10000 do
            yield! ["()"; "({})"; "()({[]})";
                    "(";"{{}"; "{(})"]]
printfn "Testing Async Balanced counting with 1 thread: %A" (countBalanced lst 1)
printfn "Testing Async Balanced counting with 10 threads: %A" (countBalanced lst 10)
printfn "Testing Async Balanced counting with 1000 threads: %A" (countBalanced lst 1000)
printfn "Testing Async Balanced counting with 10000 threads: %A" (countBalanced lst 10000)
printfn ""

///////////////////////////////////////////////////////////////////////////////
// 4
let fp = 10 |> fibProg |> mkBasicProgram

// 4.1
printfn "Testing mkBasicProgram: %A" (mkBasicProgram [(10u, End)])
printfn "Testing get on fibonacci Program: %A" (getStmnt 50u fp)
printfn "Testing next on fibonacci Program: %A" (nextLine 50u fp)
printfn "Testing first on fibonacci Program: %A" (firstLine fp)
printfn ""

// 4.2 
printfn "Testign empty state: %A" (emptyState fp)
printfn "Testing goto state on fibonacci: %A" (goto 50u (emptyState fp))
printfn "Testing current state on fibonacci: %A" (getCurrentStmnt fp (emptyState fp))
printfn "Testing current state on fibonacci: %A" (getCurrentStmnt fp (goto 50u (emptyState fp)))
printfn "Testing update state on fibonacci: %A" (update "x" 42 (emptyState fp))
printfn "Testing lookup state on fibonacci: %A" (lookup "x" (update "x" 42 (emptyState fp)))
printfn ""

// 4.3
let st = emptyState fp
let st' = update "x" 42 st
printfn "Testing evalExpr on Num 5: %A" (evalExpr (Numx 5) st)
printfn "Testing evalExpr on lookup x: %A" (evalExpr (Lookup "x") st')
printfn "Testing evalExpr on lookup x: %A" (evalExpr (Plus (Lookup "x", Numx 5)) st')

let smallProg = [(10u, Let ("x", Numx 42)); (20u, End)] |> mkBasicProgram
let st'' = emptyState smallProg

printfn "Testing step on smallProg: %A" (step smallProg st'')
printfn "Evaluating SmallProg: %A" (evalProg smallProg)
printfn "Evaluating Fibonacci Program: %A" (evalProg fp)
printfn "Evaluating Result of Fibonacci Program: %A" (fp |> evalProg |> lookup "result")
printfn ""

// 4.4
printfn "Testing State Monad goto: %A" (goto2 50u |> evalSM fp)
printfn "Testing State Monad goto and current stmnt: %A" (goto2 50u >>>= getCurrentStmnt2 |> evalSM fp)
printfn "Testing State Monad update: %A" (update2 "x" 42 |> evalSM fp)
printfn "Testing State Monad update and lookup: %A" (update2 "x" 42 >>>= lookup2 "x" |> evalSM fp)
printfn "Testing State Monad goto and step: %A" (goto2 50u >>>= step2 |> evalSM fp)
printfn ""

// 4.5
printfn "Testing State Monad Expression Eval on num 5: %A" (Numx 5 |> evalExpr2 |> evalSM fp)
printfn "Testing State Monad Expression Eval on update and lookup: %A" (update2 "x" 42 >>>= evalExpr2 (Lookup "x") |> evalSM fp)
printfn "Testing State Monad Expression Eval: %A" (update2 "x" 42 >>>= evalExpr2 (Plus(Lookup "x", Numx 5)) |> evalSM fp)
// printfn "Testing State Monad Program Eval: %A" (evalProg2 |> evalSM smallProg)
// printfn "Testing State Monad Program Eval: %A" (evalProg2 |> evalSM fp)
// printfn "Testing State Monad Program Eval: %A" (evalProg2 >>>= lookup2 "result" |> evalSM fp)