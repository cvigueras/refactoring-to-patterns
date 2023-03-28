namespace RefactoringToPatterns.CreationMethods
{
    public class Internet
    {
        private Internet(string internetLabel)
        {
            InternetLabel = internetLabel;
        }

        public static Internet Create(string internetLabel)
        {
            return new Internet(internetLabel);
        }

        public string InternetLabel { get; }
    }
}