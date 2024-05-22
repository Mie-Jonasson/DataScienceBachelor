module reexam_2023

    open JParsec.TextParser  

    // 1
    type arith =
    | Num of int
    | Add of arith * arith