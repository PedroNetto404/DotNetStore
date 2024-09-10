using System;
using DotNetStore.ApplicationCore.Abstractions;

namespace DotNetStore.ApplicationCore.Buyers;

public class Buyer : Entity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Document { get; private set; }
    public DateOnly BirthDateUtc { get; private set; }
    public int Age =>
        (int)Math.Floor((
            DateTime.UtcNow - BirthDateUtc.ToDateTime(TimeOnly.MinValue)).TotalDays
        / 365);

    public Buyer
    (
        string firstName,
        string lastName,
        string document,
        DateOnly birthDateUtc
    )
    {
        //TODO: validar
        FirstName = firstName;
        LastName = lastName;
        Document = document;
        BirthDateUtc = birthDateUtc;
    }
}
