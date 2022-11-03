using RegistrationDataAccess.DataAccess;
using RegistrationDataAccess.Models;
using System.Reflection.Metadata;


namespace AA.PMTOGO.Registration.Test
{
    [TestClass]
    public class RegistrationIntegrationTest
    {
        [TestMethod]
        public void ShouldProvideUniqueUsername()
        {
            //arrange
            var user = new User()
            {
                Email = "dummy@email.com",
                UserName = "dummy@email.com",
                Password = "jade"
            };

            int expect = 1;

            //act
            int actual = 0;
            using (var context = new UserContext())
            {
                context.Users.Add(user);
                context.SaveChanges();


                if (context.Users.Find(user.UserName) is not null)
                {
                    actual++;
                }
            }
            //assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual == expect);
        }
        public void ShouldRespingWithIn5Seconds()
        {
            //arrange
            var user = new User()
            {
                Email = "dummy@email.com",
                UserName = "dummy@email.com",
                Password = "jade"
            };

            //act
            addUser(usr);

            //assert

        }
    }
}