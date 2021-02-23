using Microsoft.AspNetCore.Mvc;

namespace AFPApp.WebAPI.CustomResults {
    public class InternalServerErrorContentResult : ContentResult {
        public InternalServerErrorContentResult() {
            StatusCode = 500;
            ContentType = "application/json";
        }

        public InternalServerErrorContentResult(string message) : base() {
            Content = message;
        }
    }
}
