﻿using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        if(number < 1) throw new ArgumentException(nameof(number));

        var steps = 0;
        while(number != 1)
        {
            steps++;
            number = number % 2 == 0 ? number / 2 : number * 3 + 1;
        }
        return steps;
    }
}