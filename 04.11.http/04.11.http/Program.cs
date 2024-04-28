using _04._11.http;
using System.Xml.Serialization;

var client = new HttpClient();
var xmlResult = await client.GetStringAsync("http://api.napiarfolyam.hu?bank=mnb&valuta=eur&datum=20240328&datumend=20240428");

var serializer = new XmlSerializer(typeof(arfolyamok));
arfolyamok result;
using TextReader reader = new StringReader(xmlResult);
result = (arfolyamok)serializer.Deserialize(reader);
//Kiir30napraLegerosebb();
ValutaKivalasztas();
void Kiir30napraLegerosebb()
{
    var strongestKozep = new decimal();
    var strongesDate = "";
    foreach(var i in result.deviza)
    {
        if(i.kozep > strongestKozep) 
        {
            strongestKozep = i.kozep;
            strongesDate = i.datum;
        }
        Console.WriteLine($"Pénznem: {i.penznem}; Bank: {i.bank}; Közép: {i.kozep}; Dátum: {i.datum}");
    }
    Console.WriteLine($"\n{strongesDate} kor volt a legerősebb a HUF az EUR-hoz képes: {strongestKozep}");
}

async Task ValutaKivalasztas()
{
    do
    {
        Console.Write($"Adja meg hogy milyen pénznembe szeretne váltani[{(int)Menu.eur}-{Menu.eur.ToString().ToUpper()}, {(int)Menu.gbp}-{Menu.gbp.ToString().ToUpper()}, {(int)Menu.usd}-{Menu.usd.ToString().ToUpper()}, {(int)Menu.exit}-{Menu.exit.ToString().ToUpper()}]: ");
        var check = Enum.TryParse<Menu>(Console.ReadLine(), out var todo);

        if (todo != Menu.exit && check)
        {
            await Valtas(todo);
        }
        else if (!check)
        {
            Console.WriteLine("Wrong data! ");
            continue;
        }
        else if (todo == Menu.exit)
            break;
    } while (true);
}

async Task Valtas(Enum todo)
{
    var xmlResult = await client.GetStringAsync($"http://api.napiarfolyam.hu?bank=mnb&valuta={todo}");

    var serializer = new XmlSerializer(typeof(arfolyamok));
    arfolyamok result;
    using TextReader reader = new StringReader(xmlResult);
    result = (arfolyamok)serializer.Deserialize(reader);
    Szamolas(result);
}
void Szamolas(arfolyamok result)
{
    var doCheck = false;
    do
    {
        Console.Write("Mennyi forintot szeretne váltani: ");
        var check = int.TryParse(Console.ReadLine(), out var ft);
        if(check && ft > 0)
        {
            var eredmeny = ft / result.deviza[0].vetel;
            Console.WriteLine($"Árfolyam: {result.deviza[0].vetel}, {ft}Ft {eredmeny} Devizának felel meg. ");
        }
        else doCheck = true;
    } while (doCheck);

    
}