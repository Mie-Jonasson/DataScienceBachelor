module ImpParser

    open Eval
    open Types

    (*

    The interfaces for JParsec and FParsecLight are identical and the implementations should always produce the same output
    for successful parses although running times and error messages will differ. Please report any inconsistencies.

    *)

    open JParsec.TextParser             // Example parser combinator library. Use for CodeJudge.
    // open FParsecLight.TextParser     // Industrial parser-combinator library. Use for Scrabble Project.
    
    let pIntToChar  = pstring "intToChar"
    let pPointValue = pstring "pointValue"

    let pCharToInt  = pstring "charToInt"
    let pToUpper    = pstring "toUpper"
    let pToLower    = pstring "toLower"
    let pCharValue  = pstring "charValue"

    let pTrue       = pstring "true"
    let pFalse      = pstring "false"
    let pIsDigit    = pstring "isDigit"
    let pIsLetter   = pstring "isLetter"
    let pIsVowel   = pstring "isVowel"

    let pif       = pstring "if"
    let pthen     = pstring "then"
    let pelse     = pstring "else"
    let pwhile    = pstring "while"
    let pdo       = pstring "do"
    let pdeclare  = pstring "declare"

    let whitespaceChar = satisfy System.Char.IsWhiteSpace <?> "whitespace"
    let pletter        = satisfy System.Char.IsLetter <?> "letter"
    let palphanumeric  = satisfy System.Char.IsLetterOrDigit <?> "alphanumeric"

    let spaces         = many whitespaceChar <?> "space"
    let spaces1        = many1 whitespaceChar <?> "space1"

    let (.>*>.) a b = (a .>> spaces) .>>. b
    let (.>*>) a b  = a .>*>. b |>> fst // Inspired by how JParsec does it
    let (>*>.) a b  = a .>*>. b |>> snd // Inspired by how JParsec does it

    let parenthesise p = pchar '(' >*>. p .>*> pchar ')'

    let pUnderScore = pchar '_'
    let charListToStr charList = // definition of helper borrowed from https://fsharpforfunandprofit.com/posts/understanding-parser-combinators-2/
        charList |> 
        List.toArray |> 
        System.String
    
    let pid = 
        (pUnderScore <|> pletter) .>>. // First a single letter / underscore
        (many (pUnderScore <|> palphanumeric)) |>> // Then 0 or more alphanumeric / underscore
        fun (start, rest) -> charListToStr (start :: rest) // Use charlist to strign to convert the entire list of chars to out string

    let unop op a = op >*>. a
    let binop op a b = (a .>*> op) .>*>. b

    let TermParse, tref = createParserForwardedToRef<aExp>()
    let ProdParse, pref = createParserForwardedToRef<aExp>()
    let AtomParse, aref = createParserForwardedToRef<aExp>()
    let CharParse, cref = createParserForwardedToRef<cExp>()

    let AddParse = binop (pchar '+') ProdParse TermParse |>> Add <?> "Addition"
    let SubParse = binop (pchar '-') ProdParse TermParse |>> Sub <?> "Subtraction"
    do tref := choice [AddParse; SubParse; ProdParse]

    let MulParse = binop (pchar '*') AtomParse ProdParse |>> Mul <?> "Multiplication"
    let DivParse = binop (pchar '/') AtomParse ProdParse |>> Div <?> "Division"
    let ModParse = binop (pchar '%') AtomParse ProdParse |>> Mod <?> "Modulo"
    do pref := choice [MulParse; DivParse; ModParse; AtomParse]

    let NParse   = pint32 |>> N <?> "Integer"
    let ParParse = parenthesise TermParse
    let PVParse = pPointValue >*>. (parenthesise TermParse) |>> PV <?> "Point Value"
    let NegParse = unop (pchar '-') TermParse |>> (fun a -> Mul (N (-1), a)) <?> "Negation"
    let VarParse = pid |>> V <?> "Variable"
    let ToIntParse = pCharToInt >*>. (parenthesise CharParse) |>> CharToInt <?> "Character to integer"
    do aref := choice [ParParse; PVParse; NegParse; NParse; ToIntParse; VarParse]

    let CParse = ((pchar '\'' >>. (satisfy (fun _ -> true))) .>> pchar '\'') |>> C <?> "Character" //a char can be a string, thus using >> instead of >*>
    let CVParse = pCharValue >*>. (parenthesise TermParse) |>> CV <?> "Character Value"
    let ToCharParse = pIntToChar >*>. (parenthesise TermParse) |>> IntToChar <?> "Integer to Character"
    let ToUpperParse = pToUpper >*>. (parenthesise CharParse) |>> ToUpper <?> "To Upper"
    let ToLowerParse = pToLower >*>. (parenthesise CharParse) |>> ToLower <?> "To Lower"
    do cref := choice [CParse; CVParse; ToCharParse; ToUpperParse; ToLowerParse]

    let AexpParse = TermParse 

    let CexpParse = CharParse

    let BexpParse = pstring "not implemented"

    let stmntParse = pstring "not implemented"


    let parseSquareProg _ = failwith "not implemented"

    let parseBoardProg _ = failwith "not implemented"

    let mkBoard (bp : boardProg) : board = failwith "not implemented"

