namespace Erisu.Model;

public record class JavaAgentModel
{
	public string Parameter { get; set; }

	public string AgentPath { get; set; }

    /// <summary>
    /// ���ַ���ת����JVM����
    /// </summary>
    /// <returns></returns>
    public string ToArgument() => $"-javaagent:"
            + (AgentPath.Contains(" ") ? $"\"{AgentPath}\"" : AgentPath)
            + $"={Parameter}";
}