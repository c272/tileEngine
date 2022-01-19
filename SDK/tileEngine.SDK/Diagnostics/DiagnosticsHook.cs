namespace tileEngine.SDK.Diagnostics
{
    /// <summary>
    /// Diagnostics passthrough class for the engine to send messages to other assemblies indicating errors and warnings.
    /// </summary>
    public static class DiagnosticsHook
    {
        /// <summary>
        /// The current mode of the diagnostics hook.
        /// Indicates whether the engine is running in an editor, or standalone.
        /// </summary>
        public static DiagnosticsMode Mode { get; set; } = DiagnosticsMode.Standalone;

        /// <summary>
        /// Triggered when a new diagnostics message is logged in the engine.
        /// </summary>
        public static event OnDiagnosticsMessageHandler OnDiagnosticsMessage;
        public delegate void OnDiagnosticsMessageHandler(DiagnosticsMessage msg);

        /// <summary>
        /// Triggered when a new debug message is logged in the engine.
        /// </summary>
        public static event OnDebugMessageHandler OnDebugMessage;
        public delegate void OnDebugMessageHandler(string msg);

        /// <summary>
        /// Logs a diagnostics message to all diagnostics hooks.
        /// </summary>
        /// <param name="code">The title of the message.</param>
        /// <param name="msg">The body content of the message.</param>
        /// <param name="severity">The severity of the message ("Error" by default).</param>
        public static void LogMessage(int code, string msg, DiagnosticsSeverity severity = DiagnosticsSeverity.Error)
        {
            OnDiagnosticsMessage?.Invoke(new DiagnosticsMessage()
            {
                Code = "TE-" + code,
                Message = msg,
                Severity = severity
            });

            //If we're in debug mode, also output to console.
            #if DEBUG
                System.Diagnostics.Debug.WriteLine($"[TE-{code}] {severity} - {msg}");
            #endif
        }

        /// <summary>
        /// Logs a debug message to all diagnostics hooks.
        /// </summary>
        /// <param name="msg">The debug message to log.</param>
        public static void DebugMessage(string msg)
        {
            //This only ever runs in debug mode.
            #if DEBUG
                OnDebugMessage?.Invoke(msg);
            #endif
        }
    }

    /// <summary>
    /// Indicates whether the engine is currently running in editor, or standalone.
    /// </summary>
    public enum DiagnosticsMode
    {
        Standalone,
        Editor
    }
}
