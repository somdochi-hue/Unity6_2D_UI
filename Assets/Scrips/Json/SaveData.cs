using JetBrains.Annotations;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using System.Linq;

public abstract class SaveData
{
    public int Version { get; protected set; }
    public abstract SaveData VersionUP();
}

public class SaveDataV4 : SaveData
{
    public string PlayerName {get; set;} = string.Empty;
    public string filstname {get; set;} = string.Empty;
    public string lastname {get; set;} = string.Empty;
    public int Gold {get; set;} = 100;

    public SaveDataV4()
    {
        Version = 3;
    }

    public void nameSplit(string playerName)
    {
        string[] splitname = PlayerName.Split(" ");
        if (splitname.Length > 0)
        {
            filstname = splitname[1];
        }
        if (splitname.Length > 1)
        {
            lastname = splitname[0];
        }
    }

    public override SaveData VersionUP()
    {
        var data = new SaveDataV4();
        data.Gold  = Gold;
        return data;
    }
}

public class SaveDataV3 : SaveData
{
    public string PlayerName {get; set;} = string.Empty;
    public int Gold {get; set;} = 100;
    public int leverUpPoint {get; set;} = 50;

    public SaveDataV3()
    {
        Version = 3;
    }

    public override SaveData VersionUP()
    {
        var data = new SaveDataV3();
        data.PlayerName = PlayerName;
        data.Gold  = Gold;
        return data;
    }
}

public class SaveDataV2 : SaveData
{
    public string PlayerName {get; set;} = string.Empty;
    public int Gold {get; set;} = 100;

    public SaveDataV2()
    {
        Version = 2;
    }

    public override SaveData VersionUP()
    {
        var data = new SaveDataV2();
        data.PlayerName = PlayerName;
        return data;
    }
}

public class SaveDataV1 : SaveData
{
    public string PlayerName { get; set; } = string.Empty;
    public SaveDataV1()
    {
        Version = 1;
    }
    public override SaveData VersionUP()
    {
        throw new System.NotImplementedException();
    }
}
