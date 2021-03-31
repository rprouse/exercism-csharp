using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/// <summary>
/// Represents a North American phone number
/// </summary>
public class PhoneNumber
{
    private const string KILLER_REGEX = @"^(?:1|[^\d]*)(?<AreaCode>\d{3})(?:[^\d]*)(?<ExchangeCode>\d{3})(?:[^\d]*)(?<SubscriberNumber>\d{4})$";
    private const string NUMBER_FORMAT  = "({0}) {1}-{2}";

    /// <summary>
    /// Constructs a phone number from a string
    /// </summary>
    /// <param name="number">A string representation of a phone number</param>
    public PhoneNumber(string number)
    {
        ParsePhoneNumber(number);
    }

    /// <summary>
    /// The sanitized version of the phone number.
    /// </summary>
    public string Number { get { return string.Concat(AreaCode, ExchangeCode, SubscriberNumber); } }

    /// <summary>
    /// Gets the area code portion of the phone number
    /// </summary>
    public string AreaCode { get; private set; }

    /// <summary>
    /// Gets the exchange code portion (second group of three digits) of the phone number.
    /// </summary>
    public string ExchangeCode { get; private set; }

    /// <summary>
    /// Gets the subscriber number portion (last four digits) of the phone number.
    /// </summary>
    public string SubscriberNumber { get; private set; }

    /// <summary>
    /// Returns a <see cref="System.String" /> that represents this Phone number.
    /// </summary>
    /// <returns>
    /// A formated phone number
    /// </returns>
    public override string ToString()
    {
        return string.Format(NUMBER_FORMAT, AreaCode, ExchangeCode, SubscriberNumber);
    }

    private void ParsePhoneNumber(string number)
    {
        Match match = Regex.Match(number, KILLER_REGEX);
        if (match.Success)
        {
            AreaCode         = match.Groups["AreaCode"].Value;
            ExchangeCode     = match.Groups["ExchangeCode"].Value;
            SubscriberNumber = match.Groups["SubscriberNumber"].Value;
        }
        else
        {
            AreaCode         = "000";
            ExchangeCode     = "000";
            SubscriberNumber = "0000";
        }
    }
}
