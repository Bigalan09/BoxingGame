using UnityEngine;

public class Name
{
    public int Id { get; internal set; }
    public string Firstname { get; internal set; }
    public string Surname { get; internal set; }
    public string Fullname { get { return $"{Firstname} {Surname}";  } }

    public override string ToString()
    {
        return $"Name: {Fullname} ({Id})";
    }
}
