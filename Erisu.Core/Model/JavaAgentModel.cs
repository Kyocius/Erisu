namespace Erisu.Model;

public record class JavaAgentModel
{
	public string Parameter { get; set; }

	public string AgentPath { get; set; }

    /// <summary>
    /// 将字符串转换成JVM参数
    /// </summary>
    /// <returns></returns>
    public string ToArgument() => $"-javaagent:"
            + (AgentPath.Contains(" ") ? $"\"{AgentPath}\"" : AgentPath)
            + $"={Parameter}";
}