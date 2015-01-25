using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using  Assets;

public class ProcessCoordinates : MonoBehaviour
{
    struct caracteristica
    {
        public string nume;
        public string tip;
        public Color culoare;
        public float raza;
        public int grOxidare;

    }

    string fileBuffer;
    StringReader stringToLine;
    StreamReader reader;
    string[] tipuriAtomi;
    caracteristica[] caracteristici;
    int elementeCunoscute;
    int nrDeAtomi;
    int[][] matrice;

    void initiere()
    {

        reader = new StreamReader("molecule.txt", Encoding.Default);
        tipuriAtomi = reader.ReadLine().Split(new string[] {" "}, System.StringSplitOptions.RemoveEmptyEntries);
        nrDeAtomi = tipuriAtomi.Length;
        reader.ReadLine();
        fileBuffer = reader.ReadToEnd();
        reader.Close();

        int i, j, k=0;

        matrice = new int[nrDeAtomi][];
 

        for (i=0; i<nrDeAtomi; i++)
        {
            matrice[i] = new int[nrDeAtomi];
            for (j = 0; j < nrDeAtomi; j++)
                matrice[i][j] = fileBuffer[k++]-48;
            k+=2;//omitem \r\n    
        }

        reader = new StreamReader("caracteristiciAtomi.txt", Encoding.Default);
        fileBuffer = reader.ReadToEnd();
        reader.Close();

        stringToLine = new StringReader(fileBuffer);

        elementeCunoscute = -1;//nu 0 caci ultimul rind e endOfFile

        do
        {
            elementeCunoscute++;

        } while (stringToLine.ReadLine() != null);
        elementeCunoscute /= 5;
        Debug.Log(elementeCunoscute);

        stringToLine.Close();
        stringToLine = new StringReader(fileBuffer);

        caracteristici = new caracteristica[elementeCunoscute];

        for (i = 0; i < elementeCunoscute; i++)
        {
            caracteristici[i].nume = stringToLine.ReadLine();
            caracteristici[i].tip = stringToLine.ReadLine().Substring(4);
            caracteristici[i].culoare = Assets.colorParsing.parser(stringToLine.ReadLine());
            caracteristici[i].raza = float.Parse(stringToLine.ReadLine().Substring(5));
            caracteristici[i].grOxidare = int.Parse(stringToLine.ReadLine().Substring(10));
        }

        stringToLine.Close();

/*
        for (i = 0; i < elementeCunoscute; i++)
        {
           Debug.Log(caracteristici[i].nume); 
            Debug.Log(caracteristici[i].tip); 
            Debug.Log(caracteristici[i].culoare); 
            Debug.Log(caracteristici[i].raza); 
            Debug.Log(caracteristici[i].grOxidare);
        }
        */
        //for (i=0; i<nrDeAtomi; i++) Debug.Log(tipuriAtomi[i]);

        /*for (i=0; i<nrDeAtomi; i++)
        {
            Debug.Log("\n");
            for (j = 0; j < nrDeAtomi; j++)
                Debug.Log(matrice[i][j]);
        }*/


    }

    void calculare()
    {
        
        int atomCurent = 0;
        
        atomiData.atomii = new atom[nrDeAtomi];

        do
        {
            caracteristica curenta = cautareCaracteristici(tipuriAtomi[atomCurent]);
            atomiData.atomii[atomCurent].culoare = curenta.culoare;
            atomiData.atomii[atomCurent].raza = curenta.raza;
           /* Debug.Log(atomiData.atomii[atomCurent].culoare);
            Debug.Log(atomiData.atomii[atomCurent].raza);

            for (int i = 0; i < nrDeAtomi; i++ )
*/
        } while (++atomCurent!=nrDeAtomi);

  //acum fiecarui atomidata.atomii[i] ii corespunde un rind matrice[i].

        Vector3 coordCurent = new Vector3(0.0f, 0.0f, 0.0f);
        atomiData.atomii[0].pozitia = coordCurent;


        for (atomCurent = 1; atomCurent < nrDeAtomi; atomCurent++)
        {
//            if (eAdiacent(atomCurent, atomCurent-1))  
           
        }

        
    }

    caracteristica cautareCaracteristici(string tip)
    {
        caracteristica ret = new caracteristica();
        for (int i=0; i<elementeCunoscute; i++)
        {
 
            if (caracteristici[i].tip.Contains(tip)) return caracteristici[i];
        }
        return ret;
        
    }

    bool eAdiacent(int atomA, int atomB)
    {
        if (matrice[atomA][atomB] > 0) return true; else return false;
    }

    void Start()
    {
        initiere();
        calculare();
        gameObject.AddComponent("drawSpheres");
    }

}
	// Use this for initialization

    /*

    string caracteristiciAtomi;
    StringReader stringToLine;

	void Start () 
    {
      //  Debug.Log("start!");
        string linie;
        string[] tipuriAtomi;

        int nrDeAtomi;
        string matrice;

        StreamReader reader = new StreamReader("caracteristiciAtomi.txt", Encoding.Default);

        caracteristiciAtomi = reader.ReadToEnd();
        


        reader.Close();

        reader = new StreamReader("molecule.txt", Encoding.Default);
        linie = reader.ReadLine();//fai split

        tipuriAtomi = linie.Split(' ');

        matrice = reader.ReadToEnd();

        reader.Close();

        nrDeAtomi = linie.Length / 3;

       atomiData.atomii = new atom[nrDeAtomi];


        int atomCurent = 0;
        string legaturi;
        int iterator;

        Vector3 coordCurent = new Vector3(0.0f, 0.0f, 0.0f);

        do
        {

            Debug.Log(tipuriAtomi[atomCurent]);
            atomiData.atomii[atomCurent].culoare = gasireCuloare(tipuriAtomi[atomCurent]); //ineficient, de facut
            atomiData.atomii[atomCurent].raza = gasireRaza(tipuriAtomi[atomCurent]);       //o metoda comuna
            atomiData.atomii[atomCurent].pozitia = coordCurent;



        //procesare coordCurent...
        
        }
        while (++atomCurent != nrDeAtomi);

        gameObject.AddComponent("drawSpheres");

    }

    void setareCaracteristiciFixe(atom atm)
    {

    }
 

    Color gasireCuloare(string tip)
    {
        string current;
        Color ret = new Color();
       stringToLine = new StringReader(caracteristiciAtomi);
        do
        {
            current = stringToLine.ReadLine();
            if (current == "tip=" + tip)
            {
                ret = Assets.colorParsing.parser(stringToLine.ReadLine());
                Debug.Log(ret);
                break;
            }
        } 
        while (current!="endOfFile");

        stringToLine.Close();

        return ret;

    }


    float gasireRaza(string tip)
    {
        string current;
        float ret = 0.0f;
        stringToLine = new StringReader(caracteristiciAtomi);
        do
        {
            current = stringToLine.ReadLine();
 
            if (current == "tip=" + tip)
            {

                stringToLine.ReadLine();
                ret = float.Parse(stringToLine.ReadLine().Substring(5));
                 Debug.Log(ret);
                break;
            }
        }
        while (current != "endOfFile");

        stringToLine.Close();

        return ret;


    }
	// Update is called once per frame
 
}
    */