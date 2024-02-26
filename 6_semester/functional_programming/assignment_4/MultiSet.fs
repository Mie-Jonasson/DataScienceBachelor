module MultiSet

    type MultiSet<'a when 'a : comparison> = R of (uint32 * Map<'a, uint32>) // I store a tuple (size, Map) to have constant time lookup for size

    let getMap (R (_, B)) = B
    let getSize (R (s, _)) = s

    let empty = R (0u, Map.empty)

    let isEmpty (A : MultiSet<'a>) = Map.isEmpty (getMap A)

    let size (A : MultiSet<'a>) = getSize A
    
    let contains (item : 'a) (A : MultiSet<'a>) = 
        match Map.tryFind item (getMap A) with
        | None -> false
        | _ -> true

    let numItems (item : 'a) (A : MultiSet<'a>) = 
        match Map.tryFind item (getMap A) with
        | None -> 0u
        | Some a -> a

    let add (item : 'a) (n : uint32) (A : MultiSet<'a>) : MultiSet<'a> = 
        let cnt = numItems item A + n // Getting current count and adding n
        let m = getMap A // Getting map object
        let s = getSize A + n // Getting size and adding n
        R (s, Map.add item cnt m) // returning a Multiset with new size and new map with item updated

    let addSingle (item : 'a) (A : MultiSet<'a>) : MultiSet<'a> = add item 1u A
    
    let remove (item : 'a) (n : uint32) (A  : MultiSet<'a>) : MultiSet<'a> =
        let cnt = numItems item A // Getting number of items
        if cnt <= n then 
            let s = getSize A - cnt // Decrease size by the number of items previously stored
            let m = Map.remove item (getMap A) // remove from map
            R (s, m)
        else
            let s = getSize A - n // Decrease the size by n
            let m = Map.add item (cnt - n) (getMap A) // update in map
            R (s, m)

    let removeSingle (item : 'a) (A : MultiSet<'a>) : MultiSet<'a>= remove item 1u A


    let fold (f : 'b -> 'a -> uint32 -> 'b) (x : 'b) (A : MultiSet<'a>) = Map.fold f x (getMap A)
    let foldBack (f : 'a -> uint32 -> 'b -> 'b) (A : MultiSet<'a>) (x : 'b) = Map.foldBack f (getMap A) x
    
    let ofList (_ : 'a list) : MultiSet<'a> = R (0u, Map.empty)
    let toList (_ : MultiSet<'a>) : 'a list = []


    let map (_ : 'a -> 'b) (_ : MultiSet<'a>) : MultiSet<'b> = R (0u, Map.empty)

    let union (_ : MultiSet<'a>) (_ : MultiSet<'a>) : MultiSet<'a> = R (0u, Map.empty)
    let sum (_ : MultiSet<'a>) (_ : MultiSet<'a>) : MultiSet<'a> = R (0u, Map.empty)
    
    let subtract (_ : MultiSet<'a>) (_ : MultiSet<'a>) : MultiSet<'a> = R (0u, Map.empty)
    
    let intersection (_ : MultiSet<'a>) (_ : MultiSet<'a>) : MultiSet<'a> = R (0u, Map.empty)