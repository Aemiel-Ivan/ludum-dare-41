public class Door : Interactable {
    
    protected string room;

    public override void Setup(string flag)
    {
        base.Setup(flag);
        this.room = "";
    }

    public void Setup(string flag, string room)
    {
        base.Setup(flag);
        this.room = room;
    }

    public override void Interact()
    {
        base.Interact();

        if (GlobalFlags.IsSet(flag) || IsAlternate)
        {
            RoomTracker.MoveToRoom(room);
        }
    }

    public bool LeadsTo (string room)
    {
        return this.room == room;
    }
}
