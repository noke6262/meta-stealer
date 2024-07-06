using Meta.MainPanel.Models.DB;
using Meta.SharedModels;
using System;

namespace Meta.MainPanel.Data.Controllers;

public class GuestLinksDb : ProtoDb<GuestLink, string>
{
    public GuestLinksDb()
        : this((GuestLink x) => x.ID, "GuestLinks")
    {
    }

    public GuestLinksDb(Func<GuestLink, string> keySelector, string Name)
        : base(keySelector, Name)
    {
    }
}
