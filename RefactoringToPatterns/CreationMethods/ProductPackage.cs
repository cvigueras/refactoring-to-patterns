namespace RefactoringToPatterns.CreationMethods
{
    public class ProductPackage
    {
        private readonly Internet _internet;
        private readonly Telephone _telephone;
        private readonly Television _television;

        public ProductPackage(Internet internet = null, 
            Television television = null, 
            Telephone telephone = null)
        {
            _internet = internet;
            _telephone = telephone;
            _television = television;
        }

        public bool HasInternet()
        {
            return _internet != null;
        }

        public bool HasVOIP()
        {
            return _telephone?.LandLine != null;
        }        
        
        public bool HasMobile()
        {
            return _telephone?.MobileNumber != null;
        }

        public bool HasTv()
        {
            return _television != null;
        }
    }
}