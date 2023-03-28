namespace RefactoringToPatterns.CreationMethods
{
    public class Telephone
    {
        private Telephone(string landLine, string mobileNumber)
        {
            LandLine = landLine;
            MobileNumber = mobileNumber;
        }

        public static Telephone Create(string telephoneNumber = null,
            string mobileNumber = null)
        {
            return new Telephone(telephoneNumber, mobileNumber);
        }

        public string LandLine { get; }
        public string MobileNumber { get; }
    }
}