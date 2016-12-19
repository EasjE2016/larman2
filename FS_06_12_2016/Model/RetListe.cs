using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS_06_12_2016.Model
{
    class RetListe : ObservableCollection<Retter>
    {
        public RetListe()
        {
            this.Add(new Retter() { MenuNummer = 1, MenuNavn = "Jamie Oliver Gryde: Chicken curry", PrisPrKuvert = 99.50, Ingredienser = "4 spsk sorte sennepskorn\r\n2 tsk bukkehornsfrø\r\n3 udkernede chilier, både grønne og røde i fine tern\r\n1 håndfuld karryblade\r\nFrisk ingefær, stykker svarende til størrelsen af to tommelfinger\r\n3 løg\r\n3 fed hvidløg\r\n1 tsk tørret chili\r\n1 tsk gurkemeje\r\n6 hakkede tomater\r\n1 ds. kokosmælk\r\n400-500 g kyllingebryst\r\n1 hønseboullion terning\r\n2 dl vand\r\n1 spsk sukker\r\nOlie, salt og sort peber" });
            this.Add(new Retter() { MenuNummer = 2, MenuNavn = "Oksegryde med bagte kartofler", PrisPrKuvert = 40.23, Ingredienser = "500 gram hakket oksekød\r\n2 kviste frisk timian\r\n1 rødløg\r\n2 gulerødder\r\n3 forårsløg\r\n3 kviste frisk rosmarin\r\n4 fed hvidløg\r\n6 spsk worchestershiresauce\r\n1 lille bundt persille" });
            this.Add(new Retter() { MenuNummer = 3, MenuNavn = "Squash, tomat og oksekød i fad", PrisPrKuvert = 65.00, Ingredienser = "2-3 små squash – i alt ca 400 g\r\n4 fed hvidløg\r\n1 løg\r\n1 stor tomat – bøftomat eller flere små\r\n1 porre\r\n1 håndfuld persille\r\n2 spsk olivenolie\r\n1 tsk spidskommen\r\n400 g hakket oksekød\r\nSalt og peber\r\n200 g revet ost – fx mozzarella eller en anden ost du godt kan lide\r\n5 små tomater" });
            this.Add(new Retter() { MenuNummer = 4, MenuNavn = "Aubergine i fad med tomat, rosmarin og frisk Mozzarella", PrisPrKuvert = 75.50, Ingredienser = "1 stk. aubergine\r\n3 store tomater\r\n2 kugler frisk Mozzarella \r\n2-3 fed hvidløg skåret i tynde skiver\r\nEn god håndfuld friske rosmarinkviste\r\nFriskkværnet urtesalt\r\nFriskkværnet (rosen)peber\r\nOlivenolie" });
            this.Add(new Retter() { MenuNummer = 5, MenuNavn = "Andesteg med æbler og svesker", PrisPrKuvert = 85.00, Ingredienser = "1 god stor and, ca 3 kg\r\nTil at fylde i anden\r\n4 æbler, skåret i tern\r\n200 g svesker\r\n3 rødløg i både\r\nsalt og friskkværnet peber\r\nTil at komme i bradepanden\r\nindmad fra anden\r\n4 gulerødder, skrællede\r\n4-5 stængler bladselleri\r\n1 porre, renset\r\n2 rødløg\r\n4 laurbærblade\r\n4-5 kviste timian\r\nvand til at fylde bradepanden halvt op" });
        }


    }
}
