using System;
using FS_06_12_2016.Model;
using FS_06_12_2016.ViewModel;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace UnitTestTilmeldteHuse
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAntalKuverterTest()
        {
            TilmeldteHuse hus = new TilmeldteHuse(1,1,2,4,"Test");
            //voksne fuld pris, unge ½, børn kvart pris
            // Forventet resultat er derfor 1+1+1 = 3
            Assert.AreEqual(hus.GetAntalKuverter(),3);

        }

    }
}
