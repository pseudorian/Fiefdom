using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace People
{
    public enum  Gender
    {
        Male, Female
    }

    public enum State
    {
        Working, Resting
    }

    public enum DeathCause
    {
        Hunger, Thirst, Age
    }

    public enum Profession
    {
        Unemployed,         //No job
        Child,              //Children can't work
        Student,            //Older children and adults can attend school
        Timberman,          //Fells trees and collects timber
        Miner,              //Mines ores
        Quarrier,           //Quarries for stone
        Architect,          //Designs buildings before they are built
        Carpenter,          //Builds wooden portions of constructions
        Mason,              //Builds stone and brick portions of constructions
        Thatcher,           //Thatches rooves
        Builder,            //Builds constructions (general)
        Brewer,				//Brews and serves ale at abbeys
        Farmer,             //Farms fields
        ClayExtractor,      //Extracts clay from clay pits
        Ceramist            //Fires clay and makes bricks, pottery, etc.
    }

    public enum WorkToughness
    {
        VeryEasy,
        Easy,
        Average,
        Hard,
        VeryHard,
        Mythical
    }

    public enum PersonalityTrait
    {
        Greedy, Envious, Gluttonous, Lazy, ShortTempered, Lustful, Proud,
        Hypocrite, Stubborn, Gossiper, Kleptomaniac
    }

    public static class Names
    {
        public static Dictionary<int, string> firstM = new Dictionary<int, string>()
        {
                {0, "Adalbert"}, {1, "Bernard"}, {2, "Bero"}, {3, "Burchard"},
                {4, "Carloman"}, {5, "Engilbert"}, {6, "Gerold"}, {7, "Grimald"},
                {8, "Hartmut"}, {9, "Hildebald"}, {10, "Tassilo"}, {11, "Otker"},
                {12, "Pepin"}, {13, "Waltgaud"}, {14, "Werinbert"}, {15, "Nathanael"},
                {16, "Glenn"}, {17, "Wilhelm"}, {18, "Ageric"}, {19, "Agiulf"},
                {20, "Alaric"}, {21, "Amalaric"}, {22, "Andica"}, {23, "Ansovald"},
                {24, "Authari"}, {25, "Athanaric"}, {26, "Arnegisel"}, {27, "Athanagild"},
                {28, "Audovald"}, {29, "Austregisel"}, {30, "Badegisel"}, {31, "Berthefried"},
                {32, "Berthar"}, {33, "Bertram"}, {34, "Bisinus"}, {35, "Chararic"},
                {36, "Charibert"}, {37, "Childebert"}, {38, "Childeric"}, {39, "Chlodomer"},
                {40, "Chramnesind"}, {41, "Clovis"}, {42, "Dagobert"}, {43, "Dagaric"},
                {44, "Eberulf"}, {45, "Ebregisel"}, {46, "Euric"}, {47, "Gararic"},
                {48, "Garivald"}, {49, "Adalwolf"}, {50, "Gunderic"}, {51, "Gundobad"},
                {52, "Gunthar"}, {53, "Guntram"}, {54, "Herminafrid"}, {55, "Hermangild"},
                {56, "Huneric"}, {57, "Imnachar"}, {58, "Ingomer"}, {59, "Leudast"},
                {60, "Leuvigild"}, {61, "Lothar"}, {62, "Magnachar"}, {63, "Magneric"},
                {64, "Merovech"}, {65, "Rathar"}, {66, "Reccared"}, {67, "Ricchar"},
                {68, "Sichar"}, {69, "Marachar"}, {70, "Munderic"}, {71, "Ragnachar"},
                {72, "Sigeric"}, {73, "Sigibert"}, {74, "Sigismund"}, {75, "Sunnegisil"},
                {76, "Willichar"}, {77, "Vulfoliac"}, {78, "Theuderic"}, {79, "Thorismund"},
                {80, "Amis"}, {81, "Aldric"}, {82, "Bruno"}, {83, "Eburwin"},
                {84, "Engel"}, {85, "Folcher"}, {86, "Fredenand"}, {87, "Fulco"},
                {88, "Geirr"}, {89, "Horsa"}, {90, "Hrodland"}, {91, "Jarl"},
                {92, "Leuthar"}, {93, "Ludolf"}, {94, "Milo"}, {95, "Rainer"},
                {96, "Reinhard"}, {97, "Ulrich"}, {98, "Wolfgang"}, {99, "Yngvildr"}
        };

        public static Dictionary<int, string> firstF = new Dictionary<int, string>()
        {
                {0, "Adaltrude"}, {1, "Adallinda"}, {2, "Bertrada"}, {3, "Fastrada"},
                {4, "Gersvinda"}, {5, "Gisela"}, {6, "Gundrada"}, {7, "Hildegarde"},
                {8, "Hiltrude"}, {9, "Liutgarde"}, {10, "Madelgarde"}, {11, "Rosamund"},
                {12, "Ruothilde"}, {13, "Rothaide"}, {14, "Theodelinda"}, {15, "Albofleda"},
                {16, "Amalasuntha"}, {17, "Adofleda"}, {18, "Arnegunde"}, {19, "Audovera"},
                {20, "Austrechild"}, {21, "Beretrude"}, {22, "Berthefled"}, {23, "Berthefried"},
                {24, "Berthegund"}, {25, "Brunhild"}, {26, "Chlodosinda"}, {27, "Clotild"},
                {28, "Faileuba"}, {29, "Fredegunde"}, {30, "Galswinth"}, {31, "Ingitrude"},
                {32, "Ingunde"}, {33, "Lanthechilde"}, {34, "Leubast"}, {35, "Leubovera"},
                {36, "Magnatrude"}, {37, "Marcatrude"}, {38, "Marcovefa"}, {39, "Radegund"},
                {40, "Rigunth"}, {41, "Signe"}, {42, "Vuldretrada"}, {43, "Elisabetha"},
                {44, "Ida"}, {45, "Hilda"}, {46, "Berta"}, {47, "Bela"},
                {48, "Grecia"}, {49, "Mathilda"}, {50, "Alia"}, {51, "Allovera"},
                {52, "Emma"}, {53, "Frida"}, {54, "Gerhild"}, {55, "Godeliva"},
                {56, "Gunda"}, {57, "Hailwic"}, {58, "Helewidis"}, {59, "Helga"},
                {60, "Herleva"}, {61, "Hrotsuitha"}, {62, "Linda"}, {63, "Linza"},
                {64, "Mahthildis"}, {65, "Odila"}, {66, "Roza"}, {67, "Rothaid"},
                {68, "Saxa"}, {69, "Sigihild"}, {70, "Unnr"}, {71, "Wigburg"},
                {72, "Waldedrudis"}, {73, "Adela"}, {74, "Adelina"}, {75, "Amalia"},
                {76, "Adalheidis"}, {77, "Alba"}, {78, "Alfhildr"}, {79, "Auda"},
                {80, "Ava"}, {81, "Bertha"}, {82, "Brunihilde"}, {83, "Chlotichilda"},
                {84, "Cunigund"}, {85, "Ermingard"}, {86, "Erminhilt"}, {87, "Erminlinda"},
                {88, "Gisila"}, {89, "Grimhilt"}, {90, "Gulla"}, {91, "Hadewig"},
                {92, "Herleva"}, {93, "Hilda"}, {94, "Ingeburg"}, {95, "Irma"},
                {96, "Luitgard"}, {97, "Oda"}, {98, "Raganhildis"}, {99, "Romilda"}
        };

        public static Dictionary<int, string> sur = new Dictionary<int, string>()
        {
                {0, "Abt"}, {1, "Adler"}, {2, "Althaus"}, {3, "Bauer"},
                {4, "Bähr"}, {5, "Becke"}, {6, "Berg"}, {7, "Buchberger"},
                {8, "Ferzan"}, {9, "Akkarman"}, {10, "Zimbarman"}, {11, "Ferlant"},
                {12, "Targan"}, {13, "Houwan"}, {14, "Fiskâri"}, {15, "Steinbôzil"},
                {16, "Truhtîn"}, {17, "Lêrâri"}, {18, "Predigôn"}, {19, "Huora"},
                {20, "Haft"}, {21, "Smid"}, {22, "Jagôn"}, {23, "Frîman"},
                {24, "Wini"}, {25, "Garto"}, {26, "Gingibero"}, {27, "Glas"},
                {28, "Enkilîn"}, {29, "Unholda"}, {30, "Luzzilhros"}, {31, "Arsbelli"},
                {32, "Stilli"}, {33, "Hrindman"}, {34, "Kol"}, {35, "Burgâri"},
                {36, "Kalt"}, {37, "Kuning"}, {38, "Nâtâri"}, {39, "Ohso"},
                {40, "Eldiron"}, {41, "Gimaht"}, {42, "Arzât"}, {43, "Kussîn"},
                {44, "Lubbi"}, {45, "Armman"}, {46, "Hafanâri "}, {47, "Swangar"},
                {48, "Bihaltan"}, {49, "Stolzman"}, {50, "Widar"}, {51, "Skarasahs"},
                {52, "Fuhs"}, {53, "Roggo"}, {54, "Brod"}, {55, "Faust"},
                {56, "Gerst"}, {57, "Gwerder"}, {58, "Haber"}, {59, "Hirsch"},
                {60, "Jung"}, {61, "Kaiser"}, {62, "Sibun"}, {63, "Biskîzan"},
                {64, "Skuohbuozo"}, {65, "Hruofan"}, {66, "Scûfla"}, {67, "Segansa"},
                {68, "Biermann"}, {69, "Willelmi"}, {70, "Jesseau"}, /*{71, ""},
				{72, ""}, {73, ""}, {74, ""}, {75, ""},
				{76, ""}, {77, ""}, {78, ""}, {79, ""},
				{80, ""}, {81, ""}, {82, ""}, {83, ""}, 
				{84, ""}, {85, ""}, {86, ""}, {87, ""}, 
				{88, ""}, {89, ""}, {90, ""}, {91, ""}, 
				{92, ""}, {93, ""}, {94, ""}, {95, ""}, 
				{96, ""}, {97, ""}, {98, ""},*/
        };
    }

    public class Task
    {
        public Structures.Project project;
        public Transform taskTarget;
        public string title;
        public string description;

        public Task()
        {
            project = null;
            taskTarget = null;
        }

        public virtual void PerformTaskAction()
        {

        }
    }

    public class BuildTask : Task
    {
        public Structures.BuildPhase phase;

        public BuildTask() : base()
        {
            phase = Structures.BuildPhase.blank;
        }

        public BuildTask(Structures.BuildPhase phase) : base()
        {
            this.phase = phase;
        }

        public override void PerformTaskAction()
        {
            
        }
    }

    public class GatherTask : Task
    {
        public Resources.Resource toGather;

        public GatherTask() : base()
        {

        }

        public GatherTask(Resources.Resource toGather) : base()
        {
            this.toGather = toGather;
        }

        public override void PerformTaskAction()
        {
            
        }
    }
}
