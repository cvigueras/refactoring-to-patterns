using Xunit;

namespace RefactoringToPatterns.CreationMethods.Tests
{
    public class ProductPackageShould
    {
        [Fact]
        public void CreateAProductPackageWithOnlyInternet()
        {
            var productPackage = new ProductPackage(Internet.Create("100MB"));

            Assert.True(productPackage.HasInternet());
            Assert.False(productPackage.HasVOIP());
            Assert.False(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetAndVoip()
        {
            var productPackage = new ProductPackage(Internet.Create("100MB"),
                telephone:Telephone.Create("91233788"));

            Assert.True(productPackage.HasInternet());
            Assert.True(productPackage.HasVOIP());
            Assert.False(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetAndTv()
        {
            var tvChannels = new[] { "LaLiga", "Estrenos" };
            var productPackage = new ProductPackage(Internet.Create("100MB"),
                Television.Create(tvChannels));

            Assert.True(productPackage.HasInternet());
            Assert.False(productPackage.HasVOIP());
            Assert.True(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetVoipAndTv()
        {
            var tvChannels = new[] {"LaLiga", "Estrenos"};
            var productPackage = new ProductPackage(Internet.Create("100MB"), 
                Television.Create(tvChannels), Telephone.Create("91233788"));

            Assert.True(productPackage.HasInternet());
            Assert.True(productPackage.HasVOIP());
            Assert.True(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetAndMobile()
        {
            var productPackage = new ProductPackage(Internet.Create("100MB"),
                telephone: Telephone.Create(mobileNumber: "678987654"));

            Assert.True(productPackage.HasInternet());
            Assert.True(productPackage.HasMobile());
            Assert.False(productPackage.HasVOIP());
            Assert.False(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetMobileAndTv()
        {
            var tvChannels = new[] { "LaLiga", "Estrenos" };
            var productPackage = new ProductPackage(Internet.Create("100MB"),
                Television.Create(tvChannels),
                Telephone.Create(mobileNumber: "678987654"));

            Assert.True(productPackage.HasInternet());
            Assert.True(productPackage.HasMobile());
            Assert.True(productPackage.HasTv());
            Assert.False(productPackage.HasVOIP());
        }

        [Fact]
        public void CreateWithInternetMobileLandLineAndTv()
        {
            var tvChannels = new[] { "LaLiga", "Estrenos" };
            var productPackage = new ProductPackage(Internet.Create("100MB"),
                Television.Create(tvChannels),
                Telephone.Create("968765432", "678987654"));

            Assert.True(productPackage.HasInternet());
            Assert.True(productPackage.HasMobile());
            Assert.True(productPackage.HasTv());
            Assert.True(productPackage.HasVOIP());
        }
    }
}