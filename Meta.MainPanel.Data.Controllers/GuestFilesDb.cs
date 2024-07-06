using Meta.MainPanel.Models.DB;
using Meta.SharedModels;
using System;

namespace Meta.MainPanel.Data.Controllers;

public class GuestFilesDb : ProtoDb<GuestFile, int>
{
    public GuestFilesDb()
        : this((GuestFile x) => x.ID, "GuestFiles")
    {
    }

    public GuestFilesDb(Func<GuestFile, int> keySelector, string Name)
        : base(keySelector, Name)
    {
    }
}
