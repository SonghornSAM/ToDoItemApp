using System.ComponentModel;

namespace ToDoItemApi.Helpers
{
    public enum ApiReturnError
    {
        [Description("Internal Error")]
        DbError = -1,

        [Description("Success")]
        Success = 0,

        [Description("No Change")]
        NoChange = 1,

        [Description("General Error")]
        GeneralError = 999,
    }
}
