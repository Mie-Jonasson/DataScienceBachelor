module Assignment3

    open Types
        
    let rec arithEvalSimple e = 
       match e with
          | N x -> x
          | Add (x, y) -> (arithEvalSimple x) + (arithEvalSimple y)
          | Sub (x, y) -> (arithEvalSimple x) - (arithEvalSimple y)
          | Mul (x, y) -> (arithEvalSimple x) * (arithEvalSimple y)
          | _ -> 0 // Return 0 for all un-handled cases
    
    let rec arithEvalState e st =
       match e with
          | N x -> x
          | Add (x, y) -> (arithEvalState x st) + (arithEvalState y st)
          | Sub (x, y) -> (arithEvalState x st) - (arithEvalState y st)
          | Mul (x, y) -> (arithEvalState x st) * (arithEvalState y st)
          | V v -> (match Map.tryFind v st with | None -> 0 | Some x -> x)
          | _ -> 0 // return 0 for all un-handled cases
              
    let hello = [('H', 4); ('E',1); ('L',1); ('L',1); ('O',1)] // Insert your version of hello here from the last assignment // Bit shitty to write this when it is a yellow exercise form last week

    let rec arithEval (e:aExp) (word:list<char*int>) (st:Map<string,int>) = 
       match e with
          | N x -> x
          | Add (x, y) -> (arithEval x word st) + (arithEval y word st)
          | Sub (x, y) -> (arithEval x word st) - (arithEval y word st)
          | Mul (x, y) -> (arithEval x word st) * (arithEval y word st)
          | V v -> (match Map.tryFind v st with | None -> 0 | Some x -> x)
          | WL -> word.Length
          | PV i -> snd (word.Item(arithEval i word st))

    type cExp =
       | C  of char      (* Character value *)
       | ToUpper of cExp (* Converts lower case to upper case character, non-characters unchanged *)
       | ToLower of cExp (* Converts upper case to lower case character, non characters unchanged *)
       | CV of aExp      (* Character lookup at word index *)

    let rec charEval (e:cExp) (word:list<char*int>) (st:Map<string,int>) = 
       match e with
          | C c -> c
          | ToUpper c -> System.Char.ToUpper (charEval c word st)
          | ToLower c -> System.Char.ToLower (charEval c word st)
          | CV cI -> fst (word.Item(arithEval cI word st))

    type bExp =             
       | TT                   (* true *)
       | FF                   (* false *)

       | AEq of aExp * aExp   (* numeric equality *)
       | ALt of aExp * aExp   (* numeric less than *)

       | Not of bExp           (* boolean not *)
       | Conj of bExp * bExp   (* boolean conjunction *)

       | IsDigit of cExp       (* check for digit *)
       | IsLetter of cExp      (* check for letter *)
       | IsVowel of cExp       (* check for vowel *)

    let (~~) b = Not b
    let (.&&.) b1 b2 = Conj (b1, b2)
    let (.||.) b1 b2 = ~~(~~b1 .&&. ~~b2)       (* boolean disjunction *)
       
    let (.=.) a b = AEq (a, b)   
    let (.<.) a b = ALt (a, b)   
    let (.<>.) a b = ~~(a .=. b)
    let (.<=.) a b = a .<. b .||. ~~(a .<>. b)
    let (.>=.) a b = ~~(a .<. b)                (* numeric greater than or equal to *)
    let (.>.) a b = ~~(a .=. b) .&&. (a .>=. b) (* numeric greater than *)

    let allVowels = ['a'; 'e'; 'i'; 'o'; 'u'; 'y']
    let rec boolEval (e:bExp) (word:list<char*int>) (st:Map<string,int>) = 
       match e with
         | TT -> true
         | FF -> false

         | AEq (x, y) -> (arithEval x word st) = (arithEval y word st)
         | ALt (x, y) -> (arithEval x word st) < (arithEval y word st)

         | Not b -> (match (boolEval b word st) with | false -> true | true -> false)
         | Conj (x, y) -> 
             let b = (boolEval x word st, boolEval y word st)
             match b with
                | (true, true) -> true
                | _ -> false

         | IsDigit c -> System.Char.IsDigit (charEval c word st)
         | IsLetter c -> System.Char.IsLetter (charEval c word st)
         | IsVowel c -> (match (charEval c word st) with | a when List.contains a allVowels -> true | _ -> false)
        
    let isConsonant _ = failwith "not implemented"

    type stmnt =
       | Skip                        (* does nothing *)
       | Ass of string * aExp        (* variable assignment *)
       | Seq of stmnt * stmnt        (* sequential composition *)
       | ITE of bExp * stmnt * stmnt (* if-then-else statement *)    
       | While of bExp * stmnt       (* while statement *)

    let evalStmnt _ = failwith "not implemented"

    let stmntToSquareFun (_: stmnt) : squareFun = fun _ _ _ -> 0
    
    let singleLetterScore : squareFun = stmntToSquareFun (Ass ("_result_", arithSingleLetterScore))
    let doubleLetterScore : squareFun = stmntToSquareFun (Ass ("_result_", arithDoubleLetterScore))
    let tripleLetterScore : squareFun = stmntToSquareFun (Ass ("_result_", arithTripleLetterScore))

    let doubleWordScore : squareFun = stmntToSquareFun (Ass ("_result_", arithDoubleWordScore))
    let tripleWordScore : squareFun = stmntToSquareFun (Ass ("_result_", arithTripleWordScore))

    
    let oddConsonants = Skip // Replace this with your version of oddConsonants

    type square2 = (int * stmnt) list
    
    let SLS = [(0, Ass ("_result_", arithSingleLetterScore))]
    let DLS = [(0, Ass ("_result_", arithDoubleLetterScore))]
    let TLS = [(0, Ass ("_result_", arithTripleLetterScore))]

    let DWS = [(1, Ass ("_result_", arithDoubleWordScore))] @ SLS
    let TWS = [(1, Ass ("_result_", arithTripleWordScore))] @ SLS

    let calculatePoints2 _ = failwith "not implemented"