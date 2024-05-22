namespace SharedDependencies.Models {
    public class MessageData { // basic data class used in RequestController.cs's SendData function which uses this model to contact the MessageController
        public string? Message { get; set; } //nullable
        public int Number { get; set; }
        public DateTimeOffset Time { get; set; }
    }
}