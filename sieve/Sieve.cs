using System.Collections.Generic;

public class Sieve
{
    // Once processed, false is prime, true is not prime
    private readonly bool[] _numbers;

    public Sieve(int max)
    {
        if (max < 0) max = 0;
        _numbers = new bool[max+1];
        _numbers[0] = true;
        if (max == 0) return;
        _numbers[1] = true;
        CalculatePrimes(max);
    }

    private void CalculatePrimes(int max)
    {
        int lastPrime = 2;
        while (lastPrime < max)
        {
            MarkNonPrimes(lastPrime);
            lastPrime = GetNextPrime(lastPrime);
        }
    }

    private void MarkNonPrimes(int multiple)
    {
        int current = multiple*2;
        while (current < _numbers.Length)
        {
            _numbers[current] = true;
            current += multiple;
        }
    }

    private int GetNextPrime(int lastPrime)
    {
        for (int i = lastPrime + 1; i < _numbers.Length; i++)
        {
            if (!_numbers[i]) return i;
        }
        return _numbers.Length;
    }

    public IEnumerable<int> Primes
    {
        get
        {
            for (int i = 0; i < _numbers.Length; i++)
            {
                if (!_numbers[i]) yield return i;
            }
        }
    }
}