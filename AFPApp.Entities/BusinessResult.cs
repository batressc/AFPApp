namespace AFPApp.Entities {
    public class BusinessResult<TResult> where TResult: class {
        public BusinessResult() {
            Control = BusinessControl.ServerError;
            Result = null;
            Message = "";
        }

        public BusinessControl Control { get; set; }
        public TResult Result { get; set; }
        public string Message { get; set; }
    }
}
