namespace WoodMasters2.Models
{
    /// <summary>
    /// Errors model
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Request Id of the error
        /// </summary>
        public string? RequestId { get; set; }
        /// <summary>
        /// Request Id to be available when not Null or Empty
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}