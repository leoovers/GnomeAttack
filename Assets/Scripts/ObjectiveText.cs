using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectiveText : MonoBehaviour
{
    public Catapult_physics mainScript;
    private Text objectiveText;
    private Text m_Text;
    private RectTransform m_RectTransform;
    private int initFontSize;
    private int numberOfLevels = 40;

    // string instructions in English, German, Russian, Dutch, Finnish:
    private string[] eng = new string[] { "Destroy the fence!", "Destroy the beehive!", "Knock over the grill!", "Destroy the flowers!", "Bully the frogs!", "Flood the lawn!", "Break the window!", "Climb to the window!",
        "Flood the kitchen!", "Break the glass!", "Break the honey jar!", "Open the fridge!", "Destroy the cake!", "Tip over the sugar bag!", "Mess up the soup!", "Reach the door handle!", "Break the tv!",
        "Break the Flowerpot!", "Hit down the clock!", "Hit down the painting!", "Drop the curtains!", "Destroy the vitrine!", "Bounce on the sofa and hit the lamps!", "Get to the top of the stairs!", "Break the door!",
        "Clog the toilet!", "Slide the soaps to the floor!", "Turn on the washing machine!", "Soap the bath!", "Hit the ducks!", "Drop the towel!", "Fly through the door!", 
        "Destroy the door!", "Bounce on the bed and destroy the lamp!", "Turn on the radio!", "Mess up the wardrobe!", "Throw down the toys!", "Destroy the pillow!", "Hit the books!", "Fly through the window!"};

    private string[] ger = new string[] { "Zerstöre den Zaun!", "Zerstöre das Bienennest!", "Wirf den Griller um!", "Zerstöre die Blumen!", "Erwische die Frösche!", "Setz den Garten unter Wasser!", "Zerstör das Fenster!", "Kletter zum Fenster rauf!",
        "Setz die Küche unter Wasser!", "Zerbrich die Gläser!", "Zerbrich das Honigglas", "Öffne den Kühlschrank", "Zerstör den Kuchen!", "Wirf den Zucker um!", "Vermassle die Suppe!", "Erreiche die Türschnalle",
        "Zerstör den Fernseher!", "Zerbrich den Blumentopf", "Wirf die Uhr runter!", "Wirf das Gemälde runter", "Zieh die Vorhänge runter!", "Zerstör die Vitrine", "Spring auf die Couch und zerstöre die Lampen!", "Kletter die Stufen rauf!",
        "Zerstör die Tür!", "Verstopfe die Toilette", "Lass die Seifen runter schlittern!", "Schalte die Waschmaschine an!", "Mach ein Schaumbad!", "Erwische die Enten!", "Wirf das Handtuch runter!", "Flieg durch die Tür!",
        "Zerstör die Tür!", "Spring auf das Bett und zerstöre die Lampen!", "Schalt das Radio an!", "Bring die Kleidung durcheinander!", "Wirf das Spielzeug runter!", "Zerstör den Polster!", "Wirf die Bücher um!", "Flieg durchs Fenster!"};

    private string[] rus = new string[] { "Сломай забор!", "Разрушь улей!", "Опрокинь гриль!", "Сломай цветы!", "Напугай лягушек!", "Затопи лужайку!", "Разбей окно!", "Заберись в окно!", 
        "Затопи кухню!", "Разбей бутылку!", "Разбей банку с мёдом!", "Открой холодильник!", "Раздави торт!", "Рассыпь сахар!", "Испорть суп!", "Открой дверь!", 
        "Сломай телевизор!", "Разбей цветочный горшок!", "Сбей часы!", "Сбей картину!", "Сорви шторы!", "Разбей стекло!", "Прыгай на диване и бей лампы!", "Заберись по лестнице!", 
        "Сломай дверь!", "Засори туалет!", "Сдвинь мыло!", "Включи стиральную машину!", "Заполни ванну пеной!", "Бей уточек!", "Урони полотенце!", "Влети в дверь!", 
        "Сломай дверь!", "Прыгни на кровать и разбей лампу!", "Включи радио!", "Открой шкафы!", "Сбрось игрушки!", "Лопни подушку!", "Сбей книги!", "Вылети в окно!" };

    private string[] dut = new string[] {"Vernietig het hek!", "Vernietig de bijenkorf!","Duw de grill omver!","Vernietig de bloemen!", "Pest de kikkers!","Laat de gazon overstromen!", "Breek het raam!", "Klim door het raam!",
        "Laat de keuken overstromen!", "Breek het glas!", "Breek de honingpot!", "Open de koelkast!", "Maak de cake kapot!", "Duw de zak met suiker omver!", "Verpest de soep!", "Reik naar de deurklink!",
        "Breek de tv!", "Breek de bloempot!", "Laat de klok vallen!", "Laat het schilderij vallen!", "Laat de gordijnen vallen!", "Vernietig de vitrine!", "Spring in de zetel en raak de lampen!", "Klim de trap op!",
        "Breek de deur!", "Verstop de wc!", "Glij op de zeep!", "Zet de wasmachine aan!", "Zeep het bad in!", "Raak de eendjes!", "Laat de handdoeken vallen!", "Vlieg door de deur!",
        "Vernietig de deur!", "Spring op het bed en breek de lamp!", "Zet de radio aan!", "Gooi de kleren op de grond!", "Gooi het speelgoed op de grond!", "Vernietig de kussens!", "Raak de boeken!", "Vlieg door het raam!" };
    
    private string[] kaz = new string[]{"Қоршауды сындыр!", "Ара ұясын бұзып таста!", "Грильді төңкер!", "Гүлдері сындыр!", "Бақаларды қорқыт!", "Көгалдағы суды бас!", "Терезені сындыр!", "Терезеге кір!", 
        "Ас үйді суға толтыр!", "Бөтелкені сындыр!", "Бал құмыраны сындыр!", "Тоңазытқышты аш!", "Тортты жаншып таста!" , "Кантты шашып таста!", "Сорпаны бұзып таста!", "Есікті аш!", 
        "Теледидарды сындыр!", "Гүл құмырасын сындыр!", "Сағатты бұзып таста!", "Суретті бұзып таста!", "Перделерді үзіп таста!", "Шыны сындыр!", "Диванға секіріп шамдарды ұр!", "Баспалдаққа көтеріл!", 
        "Есікті сындыр!", "Дәретхананы ласта!", "Сабынды сырғыт!", "Кір жуғыш машинаны қос!", "Ваннаны көбікпен толтыр!", "Үйректерді ұр!", "Сүлгіні жерге таста!", "Есікке қарай ұш!", 
        "Есікті сындыр!", "Төсекке секіріп шамды сындыр!", "Радионы қос!", "Шкафтарды аш!", "Ойыншықтарды жерге таста!", "Жастықты жарып жібер!", "Кітаптарды қиратып таста!", "Терезеден ұш!"};

    private string[] esp = new string[] {"Rompe la valla!","Rompe el nido de las abejas!","Tira el grill!", "Rompe las flores!","Pilla las ranas!","Inunda el jardín!","Rompe la ventana!","Súbete a la ventana!",
        "Inunda la cocina!", "Rompe los vasos!", "Rompe el frasco de miel","Abre el frigorífico","Rompe el pastel!","Tira el azucar!","Fastidia la sopa!","Alcanza el tranco de la puerta",
        "Rompe el televisor!","Rompe el tiesto","Tira el reloj!","TIra el cuadro","Baja la cortina!","Rompe la vitrina","Salta al sofá y rompe las lámparas!","Sube los escalones!",
        "Rompe la puerta!","Atasca el váter","Deja que los jabones resbalen!","Enchufa la lavadora!","Haz un baño de espuma!","Pilla los patos!","Tira la toalla!","Sal volando por la puerta!",
        "Rompe la puerta!","Salta a la cama y rompe las lámparas!","Enciende la radio!","Abre el armario!","Tira el juguete!","Rompe el cojín!","Tira los libros!","Sal volando por la ventana!"};

    private string[] fra = new string[] { "Détruis la clôture!", "Détruis le nid d'abeilles!", "Renverse le barbecue!", "Détruis les fleurs!", "Attrappe les grenouilles!", "Inonde le jardin!", "Détruis la fenêtre!", "Grimpe à la fenêtre!",
        "Indonde la cuisine!", "Casse les verres!", "Casse le verre à miel", "Ouvre le frigo", "Détruis le gâteau!", "Renverse le sucre!", "Bousille la soupe!", "Atteins la poignée",
        "Détruis la télé!", "Casse le pot de fleurs", "Jette l'horologe!", "Jette le tableau", "Arrache les rideaux!", "Détruis la vitrine", "Saute sur le canapé et détruis les lampes!", "Grimpe les marches!",
        "Détruis la porte!", "Bouche les toilettes","Laisse glisser les savons!", "Allume la machine à laver!", "Fais un bain de mousse!", "Attrappe les canards!", "Jette la serviette!", "Vole à travers la porte!",
        "Détruis la porte!", " Saute sur le lit et détruis les lampes!", "Allume la radio!", "Ouvre l'armoire!", "Jette les jouets!", "Détruis l'oreiller!", "Renverse les livres!", "Vole à travers la  fenêtre!"};

    private string[] fin = new string[] { };

    // Start is called before the first frame update / default language is english
    void Start()
    {
        //Fetch the Text and RectTransform components from the GameObject
        m_Text = GetComponent<Text>();
        m_RectTransform = GetComponent<RectTransform>();
        initFontSize = m_Text.fontSize;
        StartCoroutine(objTextDisplay());

        if (LanguageManager.langIndex == 0)
        {
            callObjText(eng);
        }
        if (LanguageManager.langIndex == 1)
        {
            callObjText(ger);
        }
        if (LanguageManager.langIndex == 2)
        {
            callObjText(rus);
        }
        if (LanguageManager.langIndex == 3)
        {
            callObjText(dut);
        }
        if (LanguageManager.langIndex == 4)
        {
            callObjText(kaz);
        }
        if (LanguageManager.langIndex == 5)
        {
            callObjText(esp);
        }
        if (LanguageManager.langIndex == 6)
        {
            callObjText(fra);
        }
    }

    void setObjText(string levelName, string objText)
    {
        objectiveText = GetComponent<Text>();
        
        Scene currScene = SceneManager.GetActiveScene();
        string currSceneName = currScene.name;

        if (currSceneName == levelName)
        {
            objectiveText.text = objText;
        }
    }

    void callObjText(string[] langStrings)
    {
        for (int i = 1; i <= numberOfLevels; i++)
        {
            setObjText("Level_" + i.ToString(), langStrings[i - 1]);
        }
    }

    void changeFontSize(int size)
    {
        m_Text.fontSize = size;

        //Change the RectTransform size to allow larger fonts and sentences
        m_RectTransform.sizeDelta = new Vector2(m_Text.fontSize * 10, 100);
    }

    // Update is called once per frame
    void Update()
    {
        if (mainScript.levelWon | mainScript.levelLost)
        {
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator objTextDisplay()
    {
        changeFontSize(50);
        yield return new WaitForSeconds(2.0f);
        changeFontSize(initFontSize);
    }
}
