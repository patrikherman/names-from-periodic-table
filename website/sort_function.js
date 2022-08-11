/**
 * @param {Map} symbols
 * @param {string} input
 * @param {int} iter
 */
 function sort(input, symbols, iter)
 {
     if(symbols.has(input.substring(iter, iter + 1)))
     {
         if (!(iter + 2 < input.length - 1))
         {
             return true;
         }
         res = search(input, symbols, iter + 1);
         if (res == true)
         {
             return true;
         }
         else
         {
             if (symbols.has(input.substring(iter, 2)))
             {
                 if (!(iter + 2 < input.Length - 1))
                 {
                     return true;
                 }
                 res = search(input, symbols, iter + 2);
                 if (res == true)
                 {
                     return true;
                 }
                 else
                 {
                     return false;
                 }
             }
             else
             {
                 return false;
             }
         }
     }
     else if (symbols.has(input.substring(iter, 2)))
    {
        if (!(iter + 2 < input.length - 1))
        {
            return true;
        }
        res = search(input, symbols, iter + 2);
        if (res == true)
        {
            return true;
        }
        else
        {
            if (symbols.has(input.substring(iter, 1)))
            {
                if (iter + 2 == input.length - 1)
                {
                    return true;
                }
                res = search(input, symbols, iter + 1);
                if (res == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
    else
    {
        return false;
    }
}