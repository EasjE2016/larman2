using System;
using FS_06_12_2016.Model;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;


namespace UnitTestTilmeldteHuse
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TilmeldteHuse Tilmeldtehuse = new TilmeldteHuse();
            try
            {
                Tilmeldtehuse.HusNr = -2;
                Assert.Fail();
            }
            catch (Exception ex)
            {
                //ok
                Assert.AreEqual("Husnummer skal være større end 0", ex.Message);
               
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            TilmeldteHuse Tilmeldtehuse = new TilmeldteHuse();
            try
            {
                Tilmeldtehuse.HusNr = 1;
                
            }
            catch (Exception)
            {
                Assert.Fail();

            }
        }

        //[TestMethod]
        //public void TestMethod3()
        //{
        //    TilmeldteHuse Tilmeldtehuse = new TilmeldteHuse();
        //    try
        //    {
        //        Tilmeldtehuse.HusNr = 1;

        //    }
        //    catch (Exception)
        //    {
        //        Assert.Fail();

        //    }
        //}



    }
}
