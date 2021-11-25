namespace tileEngine.SDK.Diagnostics
{
    /// <summary>
    /// Represents a single debug message passed between the engine and a debug hook.
    /// </summary>
    public struct DiagnosticsMessage
    {
        /// <summary>
        /// The severity of the diagnostics message.
        /// </summary>
        public DiagnosticsSeverity Severity;

        /// <summary>
        /// The title of the diagnostics message.
        /// </summary>
        public string Code;

        /// <summary>
        /// The diagnostics message itself.
        /// </summary>
        public string Message;
    }

    /// <summary>
    /// The severity of a given diagnostics message.
    /// </summary>
    public enum DiagnosticsSeverity
    {
        Notice,
        Warning,
        Error
    }
}