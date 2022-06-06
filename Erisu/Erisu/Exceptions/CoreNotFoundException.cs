namespace Erisu.Exceptions;

public class CoreNotFoundException : Exception
{
    public string Id { get; set; }
    public new string Message { get; set; } = "Can not find Game Core";
}