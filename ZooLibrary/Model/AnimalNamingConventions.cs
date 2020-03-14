using System;
using System.Collections.Generic;
using System.Text;

namespace ZooLibrary.Model
{
    public class AnimalNamingConventions
    {
        public static readonly List<string> MonkeyNames =
            new List<string>()
            {
                "Chucky","George","Bing","Charlie","Congo","Leo","Cedric","Bear","Milo","Monty","Jared","Hunky","Caesar","Max","Albert","Steve","Chester","Hector","Banana","Bubbles","Beans","Bandar","Flunkey","Mike","Pilo","Hister","Edward","Herbie","Marvin","Bertie","Arthur","Adam","Conrad","Jasper","Ned","Dave","Titano","Ape","Otis","Snoopy","Louie","Freedo","Cyril","Maurice","Byron","King","Master","Roger","Jack","Cheeks","Anie","Nica","Kiki","Liz","Tisa","Lulu","Rose","April","Nia","Kira","Lami","Wink","Sheila","Kye","Molly","Calli","Fiona","Filomena","Zuli","Lavy","Maggie","Alene","Isis","Lolly","Bibi","Zini","Merry","Kila","Suri","Liliana","Star","Mia","Ira","Anna","Oli","Koko"
            };
        public static readonly List<string> LionNames =
            new List<string>()
            {
                "Leo","Hunter","General","Leonidas","Loki","Scout","King","Fang","Rebel","Jake","Zeus","Maximilion","Apollo","Beau","Harley","Savannah","Rori","Cleopatra","Lexie","Aaliyah","Leah","Aurora","Queen","Vega","Nova","Bathsheba","Luna","Sabrina","Xena","Duchess","Paws","Skip","Bear","Cubby","Fluffy","Whiskers","Kitten","Boots","Snickers","Pumpkin","Oliver","Muffin","Romeo","Cupcake","Sprinkles","Scar","Simba","Mufasa","Nala","Surabi","Sarafina","Kiara","Kion","Kopa","Ahadi","Uru","Mohatu","Vitani","Kula","Zira","Namib","Jira","Kamili","Armani","Kodjo","Kazi","Unika"
            };
        public static readonly List<string> ElephantNames =
            new List<string>()
            {
                "Babar","Colonel Hathi","Dumbo","Elmer","Horton","Heffalumps","Mardji","Manny","Oliphaunt","Shep","Snorky","Stampy","Tantor","Abul-Abbas","Batyr","Cator","Hanno","Hansken","John L.Sullivan","Mary","Old Bet","Pollux","Ruby","Alaska","Aldrea","Alexis","Bibbles","Bubbles","Buzby","Caramel","Chesty","Cubby","Daisy","Dazzle","Dinky","Elsie","Esmerlda","Elysia","Fuffy","Flopsy","Gnash","Georgiana","Giggles","Holly","Hiccup","Helga","Isabella","Inky","Jingles","Jasmine","Koko","Kyra","Levyna","Lovey","Mia","Mocha","Nugget","Nima","Olexa","Polly","Quena","Reeny","Snerfie","Twinkles","Upir","Victoria","Whitley","Xena","Yetti","Zylonna","Axel","Alecto","Artoo","Billie Jo","Bart","Bozo","Chomper","Caiden","Cruiser","Diago","Dalores","Droopy","Ezra","Edith","Ewok","Frosty","Flappy","Gilly","Gusty","Gumby","Hendrix","Harvey","Harlo","Igus","Itzy","Jacques","Jiggy","Kermit","Klepto","Lil bear","Leroy","Mikko","Micah","Norby","Nutsy","Orion","Pesto","Quackers","Raymond","Smokey","Tiger Bob","Uzi","Victor","Wango","Xibalba","Yapper","Zinger"
            };


        public static string PickName(List<string> names)
        {
            return names[new Random().Next(0, names.Count)];
        }

    }
}
