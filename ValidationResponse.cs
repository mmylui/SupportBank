class ValidationResponse{
    public bool IsValid { get; }
    public string ErrorMessage { get; }

    public ValidationResponse(bool isValid, string errorMessage) {
        IsValid = isValid;
        ErrorMessage = errorMessage;
    }

}