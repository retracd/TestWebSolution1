namespace SharedDependencies.Models {
    public class MessageData {
        public string? Message { get; set; } //nullable
        public int Number { get; set; }
        public DateTimeOffset Time { get; set; }
    }
}