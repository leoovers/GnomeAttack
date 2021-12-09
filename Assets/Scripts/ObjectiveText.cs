using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectiveText : MonoBehaviour
{
    public Catapult_physics mainScript;
    private Text objectiveText;
    private int numberOfLevels = 40;
    private Text m_Text;
    private RectTransform m_RectTransform;
    private int initFontSize;

    // string instructions in English, German, Russian, Dutch, Finnish:
    private string[] eng = new string[] { "Destroy the fence!", "Destroy the flowers!", "Knock over the grill!", "Destroy the beehive!", "Bully the frogs!", "Flood the lawn!", "Break the window!", "Climb to the window!",
        "Flood the kitchen!", "Break the glass!", "Break the honey jar!", "Open the fridge!", "Destroy the cake!", "Tip over the sugar bag!", "Mess up the soup!", "Reach the door handle!", "Break the tv!",
        "Break the Flowerpot!", "Hit down the clock!", "Hit down the painting!", "Drop the curtains!", "Destroy the vitrine!", "Bounce on the sofa and hit the lamps!", "Get to the top of the stairs!", "Break the door!",
        "Clog the toilet!", "Slide the soaps!", "Turn on the washing machine!", "Soap the bath!", "Hit the ducks!", "Drop the towel!", "Fly through the door!", "Destroy the door!", "Bounce on the bed and destroy the lamp!",
        "Turn on the radio!", "Open the cupboards!", "Throw down the toys!", "Destroy the pillow!", "Hit the books!", "Fly through the window!"};

    private string[] ger = new string[] { "Zerstöre den Zaun!", "Zerstöre die Blumen!", "Wirf den Griller um!", "Zerstöre das Bienennest!", "Erwische die Frösche!", "Setz den Garten unter Wasser!", "Zerstör das Fenster!", "Kletter zum Fenster rauf!",
        "Setz die Küche unter Wasser!", "Zerbrich die Gläser!", "Zerbrich das Honigglas", "Öffne den Kühlschrank", "Zerstör den Kuchen!", "Wirf den Zucker um!", "Vermassle die Suppe!", "Erreiche die Türschnalle",
        "Zerstör den Fernseher!", "Zebrich den Blumentopf", "Wirf die Uhr runter!", "Wirf das Gemälde runter", "Zieh die Vorhänge runter!", "Zerstör die Vitrine", "Spring auf die Couch und zerstöre die Lampen!", "Kletter die Stufen rauf!",
        "Zerstör die Tür!", "Verstopfe die Toilette", "Lass die Seifen runter schlittern!", "Schalte die Waschmaschine an!", "Mach ein Schaumbad!", "Erwische die Enten!", "Wirf das Handtuch runter!", "Flieg durch die Tür!",
        "Zerstör die Tür!", "Spring auf das Bett und zerstöre die Lampen!", "Schlat das Radio an!", "Öffne den Kasten!", "Wirf das Spielzeug runter!", "Zerstör den Polster!", "Wirf die Bücher um!", "Flieg durchs Fenster!"};

    private string[] rus = new string[] { "Сломай забор!", "Сломай цветы!", "Опрокинь гриль!", "Разрушь улей!", "Напугай лягушек!", "Затопи лужайку!", "Разбей окно!", "Заберись в окно!", 
        "Затопи кухню!", "Разбей бутылку!", "Разбей банку с мёдом!", "Открой холодильник!", "Раздави торт!", "Рассыпь сахар!", "Испорть суп!", "Открой дверь!", 
        "Сломай телевизор!", "Разбей цветочный горшок!", "Сбей часы!", "Сбей картину!", "Сорви шторы!", "Разбей стекло!", "Прыгай на диване и бей лампы!", "Заберись по лестнице!", 
        "Сломай дверь!", "Засори туалет!", "Сдвинь мыло!", "Включи стиральную машину!", "Заполни ванну пеной!", "Бей уточек!", "Урони полотенце!", "Влети в дверь!", 
        "Сломай дверь!", "Прыгни на кровать и разбей лампу!", "Включи радио!", "Открой шкафы!", "Сбрось игрушки!", "Лопни подушку!", "Сбей книги!", "Вылети в окно!" };

    private string[] dut = new string[] {"Vernietig het hek!", "Vernietig de bloemen!","Duw de grill omver!","Vernietig de bijenkorf!", "Pest de kikkers!","Laat de gazon overstromen!", "Breek het raam!", "Klim door het raam!",
        "Laat de keuken overstromen!", "Breek het glas!", "Breek de honingpot!", "Open de koelkast!", "Maak de cake kapot!", "Duw de zak met suiker omver!", "Verpest de soep!", "Reik naar de deurklink!",
        "Breek de tv!", "Breek de bloempot!", "Laat de klok vallen!", "Laat het schilderij vallen!", "Laat de gordijnen vallen!", "Vernietig de vitrine!", "Spring in de zetel en raak de lampen!", "Klim de trap op!",
        "Breek de deur!", "Verstop de wc!", "Glij op de zeep!", "Zet de wasmachine aan!", "Zeep het bad in!", "Raak de eendjes!", "Laat de handdoeken vallen!", "Vlieg door de deur!",
        "Vernietig de deur!", "Spring op het bed en breek de lamp!", "Zet de radio aan!", "Open de kasten!", "Gooi het speelgoed op de grond!", "Vernietig de kussens!", "Raak de boeken!", "Vlieg door het raam!" };
    
    private string[] kaz = new string[]{"Қоршауды сындыр!", "Гүлдері сындыр!", "Грильді төңкер!", "Ара ұясын бұзып таста!", "Бақаларды қорқыт!", "Көгалдағы суды бас!", "Терезені сындыр!", "Терезеге кір!", 
        "Ас үйді суға толтыр!", "Бөтелкені сындыр!", "Бал құмыраны сындыр!", "Тоңазытқышты аш!", "Тортты жаншып таста!" , "Кантты шашып таста!", "Сорпаны бұзып таста!", "Есікті аш!", 
        "Теледидарды сындыр!", "Гүл құмырасын сындыр!", "Сағатты бұзып таста!", "Суретті бұзып таста!", "Перделерді үзіп таста!", "Шыны сындыр!", "Диванға секіріп шамдарды ұр!", "Баспалдаққа көтеріл!", 
        "Есікті сындыр!", "Дәретхананы ласта!", "Сабынды сырғыт!", "Кір жуғыш машинаны қос!", "Ваннаны көбікпен толтыр!", "Үйректерді ұр!", "Сүлгіні жерге таста!", "Есікке қарай ұш!", 
        "Есікті сындыр!", "Төсекке секіріп шамды сындыр!", "Радионы қос!", "Шкафтарды аш!", "Ойыншықтарды жерге таста!", "Жастықты жарып жібер!", "Кітаптарды қиратып таста!", "Терезеден ұш!"};
    
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
