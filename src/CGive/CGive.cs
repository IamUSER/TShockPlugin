using TShockAPI;
using TShockAPI.DB;

namespace CGive;

public class CGive
{
    public string Executer { get; set; } = "";

    public string cmd { get; set; } = "";

    public string who { get; set; } = "";

    public int id { get; set; }

    public bool Execute()
    {
        var list = TSPlayer.FindByNameOrID(this.Executer);
        if (this.who == "-1")
        {
            this.Save();
            if (list.Count > 0 || this.Executer.ToLower() == "server")
            {
                var players = TShock.Players;
                var array = players;
                foreach (var tSPlayer in array)
                {
                    if (tSPlayer is { Active: true })
                    {
                        Commands.HandleCommand(this.Executer.Equals("server", StringComparison.CurrentCultureIgnoreCase) ? TSPlayer.Server : list[0], this.cmd.Replace("name", tSPlayer.Name));
                        var given = new Given
                        {
                            Name = tSPlayer.Name,
                            Id = this.id
                        };
                        given.Save();
                    }
                }
                return true;
            }
            return false;
        }
        var list2 = TSPlayer.FindByNameOrID(this.who);
        if (list2.Count > 0)
        {
            if (list.Count > 0 || this.Executer.Equals("server", StringComparison.CurrentCultureIgnoreCase))
            {
                Commands.HandleCommand(this.Executer.Equals("server", StringComparison.CurrentCultureIgnoreCase) ? TSPlayer.Server : list[0], this.cmd.Replace("name", this.who));
                return true;
            }
        }
        return false;
    }

    public static List<CGive> GetCGive(string who)
    {
        var list = new List<CGive>();
        using (var queryResult = TShock.DB.QueryReader("SELECT executer,cmd,who,id FROM CGive WHERE who=@0 OR who==@1", who, -1))
        {
            while (queryResult.Read())
            {
                list.Add(new CGive
                {
                    Executer = queryResult.Reader.GetString(0),
                    cmd = queryResult.Reader.GetString(1),
                    who = who,
                    id = queryResult.Reader.GetInt32(3)
                });
            }
        }
        return list;
    }

    public static IEnumerable<CGive> GetCGive()
    {
        using var re = TShock.DB.QueryReader("SELECT executer,cmd,who,id FROM CGive");
        while (re.Read())
        {
            yield return new CGive
            {
                Executer = re.Reader.GetString(0),
                cmd = re.Reader.GetString(1),
                who = re.Reader.GetString(2),
                id = re.Reader.GetInt32(3)
            };
        }
    }

    public void Save()
    {
        Data.Command($"INSERT INTO CGive(executer,cmd,who) VALUES (@0,@1,@2)", this.Executer, this.cmd, this.who);
    }

    public void Del()
    {
        Data.Command($"DELETE FROM CGive WHERE id=@0", this.id);
    }
}