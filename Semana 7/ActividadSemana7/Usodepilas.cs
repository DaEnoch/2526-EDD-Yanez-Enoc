using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string expresion = "{7 + (8 * 5) - [(9 - 7) + (4 + 1)]}";

        if (EstaBalanceada(expresion))
            Console.WriteLine("Fórmula balanceada.");
        else
            Console.WriteLine("Fórmula no balanceada.");
    }

    static bool EstaBalanceada(string texto)
    {
        Stack<char> pila = new Stack<char>();

        foreach (char c in texto)
        {
            // Se agregan símbolos de apertura
            if (c == '(' || c == '{' || c == '[')
                pila.Push(c);

            // Se validan símbolos de cierre
            if (c == ')' || c == '}' || c == ']')
            {
                if (pila.Count == 0)
                    return false;

                char tope = pila.Pop();

                if ((c == ')' && tope != '(') ||
                    (c == '}' && tope != '{') ||
                    (c == ']' && tope != '['))
                    return false;
            }
        }

        return pila.Count == 0;
    }
}
