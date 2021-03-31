using System;
using System.Linq;

/// <summary>
/// Bob is a lackadaisical teenager.
/// </summary>
public class Bob
{
    private const string QUESTION_RESPONSE = "Sure.";
    private const string YELLING_RESPONSE  = "Whoa, chill out!";
    private const string SILENCE_RESPONSE  = "Fine. Be that way!";
    private const string DEFAULT_RESPONSE  = "Whatever.";

    /// <summary>
    /// Get's Bob's response to conversation
    /// </summary>
    /// <param name="conversation">What you say to Bob</param>
    /// <returns>What Bob says back to you.</returns>
    public string Hey(string conversation)
    {
        if (IsSilence(conversation)) return SILENCE_RESPONSE;
        if (IsYelling(conversation)) return YELLING_RESPONSE;
        if (IsQuestion(conversation)) return QUESTION_RESPONSE;
        return DEFAULT_RESPONSE;
    }

    private bool IsSilence(string conversation)
    {
        return String.IsNullOrWhiteSpace(conversation);
    }

    private bool IsYelling(string conversation)
    {
        return conversation.Any(Char.IsLetter) && !conversation.Any(Char.IsLower);
    }

    private bool IsQuestion(string conversation)
    {
        return conversation.EndsWith("?");
    }
}