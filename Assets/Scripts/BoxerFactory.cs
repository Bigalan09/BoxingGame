using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoxerFactory
{
    private static BoxerFactory _instance;

    private List<Name> names = new List<Name>();
    private Dictionary<int, Name> previouslySelected = new Dictionary<int, Name>();

    protected bool allowDuplicateName = false; // Change this to allow or disallow duplicate names

    private BoxerFactory()
    {
        GenerateNamedList();
    }

    public static BoxerFactory Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BoxerFactory();
            }
            return _instance;
        }
    }

    public Boxer CreateBoxer()
    {
        if (!allowDuplicateName && previouslySelected.Count == names.Count) throw new Exception("Unable to create a new player. No more names to select from.");

        Name name = GenerateName();
        int age = UnityEngine.Random.Range(15, 30);
        int ability = UnityEngine.Random.Range(0, 200);
        int potential = UnityEngine.Random.Range(ability, Math.Min(ability + 20, 200));

        Boxer boxer = new Boxer(name, age, ability, potential);

        return boxer;
    }

    private void GenerateNamedList()
    {
        TextAsset textasset = Resources.Load<TextAsset>("NameData");
        if (textasset == null)
        {
            throw new Exception("File not found!");
        }

        string[] rows = textasset.text.Split('\n');
        foreach (string row in rows.Skip(1))
        {
            string[] columns = row.Split(',');

            if (columns?.Any() == true)
            {
                Name boxerName = new Name();

                if (columns.Length >= 1)
                {
                    int.TryParse(columns[0], out int id);
                    boxerName.Id = id;
                }

                if (columns.Length >= 2)
                {
                    boxerName.Firstname = columns[1];
                }

                if (columns.Length >= 3)
                {
                    boxerName.Surname = columns[2];
                }

                names.Add(boxerName);
            }
        }
    }

    private Name GenerateName()
    {
        Name name = names[UnityEngine.Random.Range(0, names.Count)];
        
        if (!allowDuplicateName) {
            bool hasBeenSelected = false;
            do {
                name = names[UnityEngine.Random.Range(0, names.Count)];
                hasBeenSelected = previouslySelected?.Any(x => x.Key == name.Id) == true;
            } while (hasBeenSelected);

            previouslySelected.Add(name.Id, name);
        }

        return name;
    }
}
