namespace Erisu.Model;

    /// <summary>
    /// JavaAgent模型
    /// </summary>
    public class JavaAgentModel
    {
        public string AgentPath { get; set; }

        public string Parameter { get; set; }

        /// <summary>
        /// 转为JVM参数
        /// </summary>
        /// <returns></returns>
        public string ToArgument() => $"-javaagent:"
                + (AgentPath.Contains(" ") ? $"\"{AgentPath}\"" : AgentPath)
                + $"={Parameter}";
    }

