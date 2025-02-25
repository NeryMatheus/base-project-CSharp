namespace base_project_CSharp.Exceptions.ExceptionBase
{
    public class ErrorOnValidationException : RecipeBookException
    {
        public IList<string> ErrorsMessages { get; set; }

        public ErrorOnValidationException(IList<string> errorMessages) 
        { 
            ErrorsMessages = errorMessages;
        }
    }
}
