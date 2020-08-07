using UnityEngine;

public class Boxer
{
    private Name _name;
    private int _age;
    private int _ability;
    private int _potential;

    public Boxer(Name name, int age, int ability, int potential)
    {
        this._name = name;
        this._age = age;
        this._ability = ability;
        this._potential = potential;
    }

    public string Stats { get { return $"Age: {_age} - Ability: {_ability} -  Potential: {_potential}"; } }
    public string Fullname { get { return $"{_name.Fullname}"; } }
    public string Firstname { get { return $"{_name.Firstname}"; } }
    public string Surname { get { return $"{_name.Surname}"; } }

    public override string ToString()
    {
        return $"Name: {Fullname} - {Stats}";
    }
}
