namespace RefactoringToPatterns.CreationMethods
{
    public class Television
    {
        private Television(string[] tvChannels)
        {
            TvChannels = tvChannels;
        }

        public static Television Create(string[] tvChannels)
        {
            return new Television(tvChannels);
        }

        public string[] TvChannels { get; }
    }
}