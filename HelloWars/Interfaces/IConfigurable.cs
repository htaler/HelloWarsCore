namespace HelloWars.Common.Interfaces
{
    public interface IConfigurable
    {
        string Type { get; set; }
        int NextMoveDelay { get; set; }
    }
}
