/**
 * @param {Map} symbols
 * @param {int} cycles
 */
 function cycle_sort(input, symbols, cycles)
 {
    for (let i = 0; i < input.length; i++)
    {
        sort(input[i], symbols, 0);
    }
 }
